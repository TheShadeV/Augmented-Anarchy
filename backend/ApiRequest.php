<?php

if ($_SERVER['REQUEST_METHOD'] === 'POST') {


    if(isset($_POST['mode']) && $_POST['mode'] == 'login') {
        if(isset($_POST['username']) && isset($_POST['password'])) {
            $username = $_POST['username'];
            $password = $_POST['password'];

            $result = Login($username, $password);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem létezik ilyen felhasználónév és jelszó párosítás!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    } 
    
    else if(isset($_POST['mode']) && $_POST['mode'] == 'register') {
        if(isset($_POST['email']) && isset($_POST['username']) && isset($_POST['password'])){
            $email = $_POST['email'];
            $username = $_POST['username'];
            $password = $_POST['password'];

            $result = Register($email, $username, $password);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Már létezik ilyen felhasználó névvel vagy email címmel profil!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    } 
    



    
    else {
        $response = "Nem létezik ilyen tipúsú kérés!";
    }
} else {
    $response = "Nem megfelelő kérési metódus!";
}
    header('Content-Type: application/json; charset=utf-8');
    echo json_encode($response, JSON_UNESCAPED_UNICODE);

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