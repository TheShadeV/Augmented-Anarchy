<?php
define('DB_USER', 'root');
define('DB_PASS', '');
define('DB_DBASE', 'augmentedanarchy');

/**
 * Függvény a MySQL-kapcsolat kialakításához
 * 
 * @param Mysqli $kapcsolat   A MySQL-kapcsolat erőforrása
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
 * @param Mysqli $kapcsolat         A MySQL-kapcsolat erőforrása
 * @param string $sql               A lekérdezés parancsa
 * @return Mysqli_result $query     A kérdések listája tömbként
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
 * @param Mysqli kapcsolat  A MySQL-kapcsolat erőforrása
 * @param array $user       A felhasználói adatokat tartalmazó tömb
 * @param string $sql       A lekérdezés parancsa
 * @return boolean          Sikeres volt-e a rögzítés
 */
function feltolt($kapcsolat, $user)
{
    $sql = 'INSERT INTO users(nev, email, jelszo) VALUES (
            "' . $user["fnev"] .
        '", "' . $user["email"] .
        '", "' . md5($user["jelszo"]) . '")';
    $query = mysqli_query($kapcsolat, $sql);
    if (!$query)
        die("Adatbázis-hiba: " . mysqli_error($kapcsolat));
    return true;
}

/**
 * A felhasználó nevének és jelszavának lekérése
 * @param Mysqli $kapcsolat     A MySQL-kapcsolat erőforrása
 * @param string $usernev       A felhasználónév
 * @param string $jelszo        Az MD5-el kódolt jelszó
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
 * @param Mysqli $kapcsolat    A MySQL-kapcsolat erőforrása
 * @param string $usernev      A felhasználó felhasználóneve
 * @return mysqli_result $query       A felhasználó adatait tartalmazo MySQL-erőforrás
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
 * @param Mysqli $kapcsolat       A MySQL-kapcsolat erőforrása
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
?>