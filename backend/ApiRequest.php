<?php

if ($_SERVER['REQUEST_METHOD'] === 'POST') {


    if(isset($_POST['mode']) && $_POST['mode'] == 'login') {
        if(isset($_POST['username']) && isset($_POST['password'])) {
            $username = $_POST['username'];
            $password = $_POST['password'];
            $response = array("success" => true, "message" => "Sikeres API kérés!", "data" => Login($username, $password));

        } else {
            $response = array("success" => false, "message" => "Hiányzó paraméter!");
        }
    } 
    
    else if(isset($_POST['mode']) && $_POST['mode'] == 'register') {
        if(isset($_POST['email']) && isset($_POST['username']) && isset($_POST['password'])){
            $email = $_POST['email'];
            $username = $_POST['username'];
            $password = $_POST['password'];
            $response = array("success" => true, "message" => "Sikeres API kérés!", "data" => Register($email, $username, $password));
        } else {
            $response = array("success" => false, "message" => "Hiányzó paraméter!");
        }
    } 
    
    else {
        $response = array("success" => false, "message" => "Nem létezik ilyen tipúsú kérés!");
    }
} else {
    $response = array("success" => false, "message" => "Nem megfelelő kérési metódus!");
}
    header('Content-Type: application/json');
    echo json_encode($response);

function Login($username, $jelszo) {
    include 'inc/db.inc';
    $result = validateLogin(csatlakozas(), $username, $jelszo);
    return $result;
}

function Register($email, $username, $password) {
    include 'inc/db.inc';
    $result = registerUser(csatlakozas(), $email, $username, $password);
    return $result;
}

?>
