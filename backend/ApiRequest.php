<?php
// Bemeneti adatok ellenőrzése
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Bemeneti paraméterek lekérése
    if(isset($_POST['mode']) && $_POST['mode'] == 'login') {
        if(isset($_POST['username']) && isset($_POST['password'])) {
            $username = $_POST['username'];
            $password = $_POST['password'];
            $response = array("success" => true, "message" => "Sikeres API kérés!", "data" => Login($username, $password));

        } else {
            $response = array("success" => false, "message" => "Hiányzó paraméter!");
        }
    } else {
        $response = array("success" => false, "message" => "Nem létezik ilyen tipúsú kérés!");
    }
    header('Content-Type: application/json');
    echo json_encode($response);
    /*$password = isset($_POST['password']) ? $_POST['password'] : null;

    // Ellenőrzés, hogy mindkét paraméter át lett-e adva
    if ($username !== null && $password !== null) {
        // Itt további feldolgozást végezhet a kapott adatokkal
        // Példa: Adatbázis ellenőrzés, felhasználói jogosultságok ellenőrzése stb.

        // Válasz összeállítása
        $response = array("success" => true, "message" => "Sikeres API kérés!", "data" => array("username" => $username, "password" => $password));

        // JSON válasz küldése
        header('Content-Type: application/json');
        echo json_encode($response);
    } else {
        // Hiányzó paraméter esetén hibaüzenet küldése
        $response = array("success" => false, "message" => "Hiányzó vagy érvénytelen paraméterek.");

        // JSON válasz küldése
        header('Content-Type: application/json');
        echo json_encode($response);
    }
*/
} else {
    // Nem POST kérés esetén hibaüzenet küldése
    $response = array("success" => false, "message" => "Csak POST kérést fogadunk el.");

    // JSON válasz küldése
    header('Content-Type: application/json');
    echo json_encode($response);
}

function Login($username, $jelszo) {
    include 'inc/db.inc';
    $result = validateLogin(csatlakozas(), $username, $jelszo);
    return $result;
}

?>
