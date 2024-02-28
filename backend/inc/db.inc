<?php
define('DB_USER', 'root');
define('DB_PASS', '');
define('DB_DBASE', 'augmentedanarchy');

/**
 * Függvény a MySQL-kapcsolat kialakításához
 * @param mysqli $kapcsolat   A MySQL-kapcsolat erőforrása
 * @return $kapcsolat
 */
function csatlakozas()
{
    $kapcsolat = mysqli_connect('localhost', DB_USER, DB_PASS, DB_DBASE);
    if (!$kapcsolat)
        die("Adatbázis hiba: " . mysqli_connect_error());
    return $kapcsolat;
}

/**
 * Összes adat lekérdezése az adatbázisból
 * @param mysqli $kapcsolat         A MySQL-kapcsolat erőforrása
 * @param string $sql               A lekérdezés parancsa
 * @return mysqli_result $query     A kérdések listája tömbként
 */
function lekerdezes($kapcsolat)
{
    $sql = 'SELECT * FROM users';
    $query = mysqli_query($kapcsolat, $sql);
    if (!$query)
        die("Adatbázis-hiba: " . mysqli_error($kapcsolat));
    return $query;
}

/**
 * Új felhasználó rögzítése az adatbázisban
 * @param mysqli kapcsolat  A MySQL-kapcsolat erőforrása
 * @param array $user       A felhasználói adatokat tartalmazó tömb
 * @param string $sql       A lekérdezés parancsa
 * @return boolean          Sikeres volt-e a rögzítés
 */
function feltolt($kapcsolat, $user)
{
    $sql = 'INSERT INTO users(nev, email, jelszo) VALUES (
            "' . $user["fnev"] .
        '", "' . $user["email"] .
        '", "' . hash('sha512', $user["jelszo"]) . '")';
    $query = mysqli_query($kapcsolat, $sql);
    if (!$query)
        die("Adatbázis-hiba: " . mysqli_error($kapcsolat));
    return true;
}

/**
 * A felhasználó nevének és jelszavának lekérése
 * @param mysqli $kapcsolat     A MySQL-kapcsolat erőforrása
 * @param string $usernev       A felhasználónév
 * @param string $jelszo        A SHA256-al kódolt jelszó
 * @param string $sql           A lekérdezés parancsa
 * @return boolean              Sikeres volt-e a lekérdezés
 */
function egy_leker($kapcsolat, $usernev, $jelszo)
{
    $sql = "SELECT nev, jelszo FROM users WHERE nev = '{$usernev}' AND jelszo = '{$jelszo}'";
    // "{$usernev}" === "'.$usernev.'"
    $query = mysqli_query($kapcsolat, $sql);
    if (!$query)
        die("Adatbázis-hiba: " . mysqli_error($kapcsolat));
    if (mysqli_num_rows($query) > 0) {
        return true;
    } else {
        return false;
    }
}

/**
 * A felhasználó adatait kéri le
 * @param mysqli $kapcsolat         A MySQL-kapcsolat erőforrása
 * @param string $usernev           A felhasználó felhasználóneve
 * @return mysqli_result $query     A felhasználó adatait tartalmazo MySQL-erőforrás
 */
function user_leker($kapcsolat, $usernev)
{
    $sql = 'SELECT * FROM users WHERE nev = "' . $usernev . '"';
    // "{$usernev}" === "'.$usernev.'"
    $query = mysqli_query($kapcsolat, $sql);
    if (!$query)
        die("Adatbázis-hiba: " . mysqli_error($kapcsolat));
    return $query;
}

/**
 * A felhasználó profiljának lekérése
 * @param mysqli $kapcsolat       A MySQL-kapcsolat erőforrása
 * @param number $id              A felhasználó azonosítója
 * @return mysqli_result $query   A felhasználó MySQLI-erőforrása
 * @return number                 0, ha a felhasználó nem létezik
 */
function profil_leker($kapcsolat, $id)
{
    $sql = 'SELECT * FROM users WHERE id = "' . $id . '"';
    // "{$usernev}" === "'.$usernev.'"
    $query = mysqli_query($kapcsolat, $sql);
    if (!$query) {
        die("Adatbázis-hiba: " . mysqli_error($kapcsolat));
    }
    return $query;
}

/**
 * A felhasználó jelszavának módosítása az adatbázisban
 * @param mysqli $kapcsolat       A MySQL-kapcsolat erőforrása
 * @param string $usernev         A felhasználó felhasználóneve
 * @param string $uj_jelszo       Az új jelszó, amelyet beállítunk a felhasználónak
 * @param string $regi_jelszo     A régi jelszó, amelyet ellenőrzünk
 * @return bool                   Sikeres módosítás esetén true, egyébként false
 */
function jelszo_modosit($kapcsolat, $usernev, $uj_jelszo, $regi_jelszo)
{
    $regi_jelszo_hash = hash('sha512', $regi_jelszo);
    if (!jelszo_ellenorzes($kapcsolat, $usernev, $regi_jelszo_hash)) {
        return false;
    }

    $uj_jelszo_hash = hash('sha512', $uj_jelszo);

    $query = "UPDATE users SET jelszo = ? WHERE nev = ?";
    $stmt = mysqli_prepare($kapcsolat, $query);
    mysqli_stmt_bind_param($stmt, "ss", $uj_jelszo_hash, $usernev);
    $success = mysqli_stmt_execute($stmt);

    if ($success) {
        mysqli_stmt_close($stmt);
        return true;
    } else {
        mysqli_stmt_close($stmt);
        return false;
    }
}

/**
 * A felhasználó jelszavának ellenőrzése az adatbázisban
 * @param mysqli $kapcsolat       A MySQL-kapcsolat erőforrása
 * @param string $usernev         A felhasználó felhasználóneve
 * @param string $jelszo_hash     A hashelt jelszó, amelyet ellenőrzünk
 * @return bool                   Az ellenőrzés eredménye (true, ha a jelszó helyes, egyébként false)
 */
function jelszo_ellenorzes($kapcsolat, $usernev, $jelszo_hash)
{
    $sql = "SELECT jelszo FROM users WHERE nev = ?";
    $stmt = mysqli_prepare($kapcsolat, $sql);
    mysqli_stmt_bind_param($stmt, "s", $usernev);
    mysqli_stmt_execute($stmt);
    mysqli_stmt_bind_result($stmt, $tavoli_jelszo);
    mysqli_stmt_fetch($stmt);
    mysqli_stmt_close($stmt);

    return $tavoli_jelszo && hash_equals($tavoli_jelszo, $jelszo_hash);
}

/**
 * Felhasználó játékbéli eredményeinek lekérdezése
 * @param mysqli $kapcsolat   A MySQL-kapcsolat erőforrása
 * @param string $usernev A lekérdezett felhasználó neve
 * @return mysqli_result|false A lekérdezés eredménye vagy false, ha hiba történt
 */
function eredmenyek_lekerdezese($kapcsolat, $usernev)
{
    $sql = "SELECT kills, elapsedTime, bestTime FROM achievements
            WHERE user_id = (SELECT id FROM users WHERE nev = ?)";

    $stmt = mysqli_prepare($kapcsolat, $sql);
    mysqli_stmt_bind_param($stmt, "s", $usernev);
    mysqli_stmt_execute($stmt);
    $eredmenyek = mysqli_stmt_get_result($stmt);
    mysqli_stmt_close($stmt);

    return $eredmenyek;
}

function validateLogin($kapcsolat,$username,$password){
    $sql = "CALL validateLogin('$username','$password')";
    $query = mysqli_query($kapcsolat, $sql);
    return mysqli_fetch_assoc($query);
}

function registerUser($kapcsolat,$email,$username,$password){
    $sql = "CALL registrateUser('$email','$username','$password')";
    $query = mysqli_query($kapcsolat,$sql);
    return mysqli_fetch_assoc($query);
}