<?php
// prettier-ignore
define('DB_USER', 'root');
define('DB_PASS', '');
define('DB_DBASE', 'augmentedanarchy');

/**
 * Connect to the database
 * @return mysqli|false    The MySQL connection resource or false if there was an error (A MySQL kapcsolat erőforrása vagy hamis, ha hiba történt)
 */
function csatlakozas()
{
    $kapcsolat = mysqli_connect('localhost', DB_USER, DB_PASS, DB_DBASE);
    if (!$kapcsolat) {
        die('Nem sikerült csatlakozni az adatbázishoz!');
    }
    return $kapcsolat;
}


/**
 * Change email of a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param string $usernameIN      The username of the user (A felhasználó felhasználóneve)
 * @param string $emailIN         The new email address (Az új e-mail cím)
 * @param string $pwIN            The password of the user (A felhasználó jelszava)
 * @return string                 The result of the operation (A művelet eredménye)
 */
function changeEmail($kapcsolat, $usernameIN, $emailIN, $pwIN)
{
    $sql = "CALL changeEmail('$usernameIN','$emailIN','$pwIN')";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['result'];
}

/**
 * Change password of a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param string $oldPW           The old password of the user (A felhasználó régi jelszava)
 * @param string $newPW           The new password to be set (Az új jelszó, amely beállításra kerül)
 * @param string $usernameIN      The username of the user (A felhasználó felhasználóneve)
 * @return string                 The result of the operation (A művelet eredménye)
 */
function changePassword($kapcsolat, $oldPW, $newPW, $usernameIN)
{
    $sql = "CALL changePassword('$oldPW','$newPW','$usernameIN')";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['result'];
}

/**
 * Change username of a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param string $oldUsername     The old username of the user (A felhasználó régi felhasználóneve)
 * @param string $pwIN            The password of the user (A felhasználó jelszava)
 * @param string $newUsername     The new username to be set (Az új felhasználónév, amely beállításra kerül)
 * @return string                 The result of the operation (A művelet eredménye)
 */
function changeUsername($kapcsolat, $oldUsername, $pwIN, $newUsername)
{
    $sql = "CALL changeUsername('$oldUsername','$pwIN','$newUsername')";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['result'];
}

/**
 * Create a new character for a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $id_user            The user ID (A felhasználó azonosítója)
 * @return bool                   True if successful, false otherwise (Igaz, ha sikeres, különben hamis)
 */
function createCharacter($kapcsolat, $id_user)
{
    $sql = "CALL createCharacter($id_user)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['result'];
}

/**
 * Get all map scores
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @return mysqli_result|false    The result of the query or false if there was an error (A lekérdezés eredménye vagy hamis, ha hiba történt)
 */
function getAllMapScores($kapcsolat)
{
    $sql = "CALL getAllMapScores()";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result;
}
/**
 * Get character data for a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $tokenInput         The token input (A token bemenet)
 * @return mysqli_result|false    The result of the query or false if there was an error (A lekérdezés eredménye vagy hamis, ha hiba történt)
 */
function getCharacterData($kapcsolat, $tokenInput)
{
    $sql = "CALL getCharacterData($tokenInput)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result;
}

/**
 * Get map scores for a specific map
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $mapID              The map ID (A térkép azonosítója)
 * @return mysqli_result|false    The result of the query or false if there was an error (A lekérdezés eredménye vagy hamis, ha hiba történt)
 */
function getMapScores($kapcsolat, $mapID)
{
    $sql = "CALL getMapScores($mapID)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result;
}

/**
 * Get all map scores for a specific player
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $userID             The user ID (A felhasználó azonosítója)
 * @return mysqli_result|false    The result of the query or false if there was an error (A lekérdezés eredménye vagy hamis, ha hiba történt)
 */
function getPlayerAllMapScores($kapcsolat, $userID)
{
    $sql = "CALL getPlayerAllMapScores($userID)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = array(); 
    while ($row = $query->fetch_assoc()) {
        $result[] = $row; 
    }
    return $result;
}
/**
 * Get map scores for a specific player and map
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $mapID              The map ID (A térkép azonosítója)
 * @param int $userID             The user ID (A felhasználó azonosítója)
 * @return mysqli_result|false    The result of the query or false if there was an error (A lekérdezés eredménye vagy hamis, ha hiba történt)
 */
function getPlayerMapScores($kapcsolat, $mapID, $userID)
{
    $sql = "CALL getPlayerMapScores($mapID, $userID)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = array(); 
    while ($row = $query->fetch_assoc()) {
        $result[] = $row; 
    }
    return $result;
}

/**
 * Register a new user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param string $emailIN         The email address of the user (A felhasználó e-mail címe)
 * @param string $usernameIN      The username of the user (A felhasználó felhasználóneve)
 * @param string $passwordIN      The password of the user (A felhasználó jelszava)
 * @return string                 The result of the operation (A művelet eredménye)
 */
function registrateUser($kapcsolat, $emailIN, $usernameIN, $passwordIN)
{
    $sql = "CALL registrateUser('$emailIN','$usernameIN','$passwordIN')";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['isDone'];
}

/**
 * Update character data for a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $tokenInput         The token input (A token bemenet)
 * @param int $healthInput        The health input (Az egészség bemenet)
 * @return bool                   True if successful, false otherwise (Igaz, ha sikeres, különben hamis)
 */
function updateCharacterData($kapcsolat, $tokenInput, $healthInput)
{
    $sql = "CALL updateCharacterData($tokenInput, $healthInput)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['result'];
}

/**
 * Upload map score for a user
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param int $userID             The user ID (A felhasználó azonosítója)
 * @param int $mapID              The map ID (A térkép azonosítója)
 * @param int $healthIN           The health input (Az egészség bemenet)
 * @param string $maptimeIN       The map time input (A térkép idő bemenet)
 * @param int $scoresIN           The scores input (A pontszámok bemenet)
 * @return bool                   True if successful, false otherwise (Igaz, ha sikeres, különben hamis)
 */
function uploadMapScore($kapcsolat, $userID, $mapID, $healthIN, $maptimeIN, $scoresIN)
{
    $sql = "CALL uploadMapScore($userID, $mapID, $healthIN, '$maptimeIN', $scoresIN)";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['result'];
}

/**
 * Validate user login
 * @param mysqli $kapcsolat       The MySQL connection resource (A MySQL kapcsolat erőforrása)
 * @param string $usernameIN      The username of the user (A felhasználó felhasználóneve)
 * @param string $passwordIN      The password of the user (A felhasználó jelszava)
 * @return bool                   True if login is valid, false otherwise (Igaz, ha a bejelentkezés érvényes, különben hamis)
 */
function validateLogin($kapcsolat, $usernameIN, $passwordIN)
{
    $sql = "CALL validateLogin('$usernameIN','$passwordIN')";
    $query = mysqli_query($kapcsolat, $sql);
    $result = mysqli_fetch_assoc($query);
    return $result['isValid'] === 'TRUE';
}