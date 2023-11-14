<?php
    session_start();
    //var_dump($_SESSION); // csak azért van, lássuk átviszi-e az adatokat

    include("inc/db.inc");
    $kapcsolat = csatlakozas();
    $user = egy_leker($kapcsolat, $_SESSION['nev'],
    $_SESSION['jelszo']);

    if ($user) {
    $html = file_get_contents('templates/profile.tpl');
    $html = str_replace("##FNEV##",$_SESSION['nev'],$html);
    $user = user_leker($kapcsolat, $_SESSION['nev']);
    $sor = mysqli_fetch_array($user);
    $html = str_replace("##EMAIL##", $sor['email'], $html);
    $html = str_replace('##ID##', $sor['id'], $html);
    }

    $profil = profil_leker($kapcsolat, $sor['id']);

    if (mysqli_num_rows($profil) == 0){
        $html = str_replace('##UNEV##', '', $html);
        $html = str_replace('##DATUM##', '', $html);
        $html = str_replace('##TEL##', '', $html);
    }
    else {
        while ($sor = mysqli_fetch_array($profil)) {
        $html = str_replace('##UNEV##', $sor['unev'], $html);
        $html = str_replace('##DATUM##', $sor['szuldatum'], $html);
        $html = str_replace('##TEL##', $sor['telefon'], $html);
        }
    }
    echo $html;




?>