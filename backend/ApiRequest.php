<?php

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    include 'inc/db.inc';

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
    
    else if(isset($_POST['mode']) && $_POST['mode'] == 'changeEmail') {
        if(isset($_POST['email']) && isset($_POST['username']) && isset($_POST['password'])){
            $email = $_POST['email'];
            $username = $_POST['username'];
            $password = $_POST['password'];

            $result = changeEmails($email, $username, $password);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem sikerült az email cím módosítása!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'changePassword') {
        if(isset($_POST['username']) && isset($_POST['password']) && isset($_POST['newpassword'])){
            $username = $_POST['username'];
            $password = $_POST['password'];
            $newpassword = $_POST['newpassword'];

            $result = changePass($username, $password, $newpassword);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a jelszó módosítása!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'changeUsername') {
        if(isset($_POST['username']) && isset($_POST['newusername']) && isset($_POST['password'])){
            $username = $_POST['username'];
            $newusername = $_POST['newusername'];
            $password = $_POST['password'];

            $result = changeUsernm($username, $newusername, $password);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a felhasználónév módosítása!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'createCharacter') {
        if(isset($_POST['user_id'])){
            $user_id = $_POST['user_id'];

            $result = createCharacters($user_id);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a karakter létrehozása!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'getAllMapScores') {
        $result = getAllMapScore();
        if($result){
            $response = $result;
        }
        else{
            $response = "Nem sikerült a karakter létrehozása!";
        }
    }
    
    elseif(isset($_POST['mode']) && $_POST['mode'] == 'getCharacterData') {
        if(isset($_POST['token'])){
            $token = $_POST['token'];

            $result = getCharacterDatas($token);
            if($result){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a karakter adatainak lekérdezése!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'getMapScores') {
        if(isset($_POST['map_id'])){
            $map_id = $_POST['map_id'];

            $result = getMapScore($map_id);
            if($result){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a pálya pontszámának lekérdezése!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'getPlayerAllMapScores') {
        if(isset($_POST['user_id'])){
            $user_id = $_POST['user_id'];

            $result = getPlayerAllMapScore($user_id);
            if($result){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a játékos összes pálya pontszámának lekérdezése!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    elseif(isset($_POST['mode']) && $_POST['mode'] == 'getPlayerMapScores') {
        if(isset($_POST['user_id']) && isset($_POST['map_id'])){
            $user_id = $_POST['user_id'];
            $map_id = $_POST['map_id'];

            $result = getPlayerMapScore($user_id, $map_id);
            if($result){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a játékos pálya pontszámának lekérdezése!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }
    
    elseif(isset($_POST['mode']) && $_POST['mode'] == 'updateCharacterData') {
        if(isset($_POST['token']) && isset($_POST['health'])){
            $token = $_POST['token'];
            $health = $_POST['health'];

            $result = updateCharacterDatas($token, $health);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a karakter adatainak frissítése!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }
    
    elseif(isset($_POST['mode']) && $_POST['mode'] == 'uploadMapScore') {
        if(isset($_POST['user_id']) && isset($_POST['map_id']) && isset($_POST['score'])){
            $user_id = $_POST['user_id'];
            $map_id = $_POST['map_id'];
            $health = $_POST['health'];
            $maptime = $_POST['maptime'];
            $score = $_POST['score'];

            $result = uploadMapScores($user_id, $map_id, $health, $maptime, $score);
            if($result == "TRUE"){
                $response = $result;
            }
            else{
                $response = "Nem sikerült a pálya pontszám feltöltése!";
            }
        } else {
            $response = "Hiányzó paraméter!";
        }
    }

    else {
        $response = "Nem létezik ilyen típusú kérés!";
    }
} else {
    $response = "Nem megfelelő kérési metódus!";
}

header('Content-Type: application/json; charset=utf-8');
echo json_encode($response, JSON_UNESCAPED_UNICODE);

function Login($username, $password) {
    $result = validateLogin(csatlakozas(), $username, $password);
    return $result;
}

function Register($email, $username, $password) {
    $result = registrateUser(csatlakozas(), $email, $username, $password);
    return $result;
}


function changeEmails($email, $username, $password) {
    $result = changeEmail(csatlakozas(), $username, $email, $password);
    return $result;
}

function changePass($username, $password, $newpassword) {
    $result = changePassword(csatlakozas(), $password, $newpassword, $username);
    return $result;
}

function changeUsernm($username, $newusername, $password) {
    $result = changeUsername(csatlakozas(), $username, $password, $newusername);
    return $result;
}

function createCharacters($user_id) {
    $result = createCharacter(csatlakozas(), $user_id);
    return $result;
}

function getAllMapScore() {
    $result = getAllMapScores(csatlakozas());
    return $result;
}

function getCharacterDatas($token) {
    $result = getCharacterData(csatlakozas(), $token);
    return $result;
}

function getMapScore($map_id) {
    $result = getMapScores(csatlakozas(), $map_id);
    return $result;
}

function getPlayerAllMapScore($user_id) {
    $result = getPlayerAllMapScores(csatlakozas(), $user_id);
    return $result;
}

function getPlayerMapScore($user_id, $map_id) {
    $result = getPlayerMapScores(csatlakozas(), $map_id, $user_id);
    return $result;
}

function updateCharacterDatas($token, $health) {
    $result = updateCharacterData(csatlakozas(), $token, $health);
    return $result;
}

function uploadMapScores($user_id, $map_id, $health, $maptime, $score) {
    $result = uploadMapScore(csatlakozas(), $user_id, $map_id, $health, $maptime, $score);
    return $result;
}
?>