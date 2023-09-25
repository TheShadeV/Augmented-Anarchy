<?php
    session_start();
    //ar_dump($_SESSION); // csak azért van, lássuk átviszi-e az adatokat


    
    include("inc/db.inc");
    $kapcsolat = csatlakozas();

    if (isset($_POST['mode']) && $_POST['mode'] == 'profileUpdate'){
        $create_update = createUpdate($kapcsolat, $_POST);
        $upd = "A profil sikeresen frissítve";
    }
    else {
        $upd = "";
    }

    $user = egy_leker($kapcsolat, $_SESSION['nev'],
    $_SESSION['jelszo']);

    if ($user) {
    $html = file_get_contents('templates/profile.tpl');
    $html = str_replace('##UPD##', $upd, $html);
    $html = str_replace("##FNEV##", $_SESSION['nev'],$html);
    $user = user_leker($kapcsolat, $_SESSION['nev']);
    $userid = $sor['id'];
    
    $sor = mysqli_fetch_array($user);
    $html = str_replace("##EMAIL##", $sor['email'], $html);
    $html = str_replace('##ID##', $sor['id'], $html);
    }

    $profil = profil_leker($kapcsolat, $userid);
    //var_dump($profil);

    if (mysqli_num_rows($profil) == 0){
        $html = str_replace('##UNEV##', '', $html);
        $html = str_replace('##DATUM##', '', $html);
        $html = str_replace('##TEL##', '', $html);
        $html = str_replace('##ID##', 'na', $html);
    }
    else {
        while ($sor = mysqli_fetch_array($profil)) {
        $html = str_replace('##UNEV##', $sor['unev'], $html);
        $html = str_replace('##DATUM##', $sor['szuldatum'], $html);
        $html = str_replace('##TEL##', $sor['telefon'], $html);
        $html = str_replace('##ID##', $sor['id'], $html);
        }
    }
    echo $html;




?>