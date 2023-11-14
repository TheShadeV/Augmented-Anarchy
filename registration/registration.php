<?php
    $html = file_get_contents('templates/registration.tpl');
    if (!isset($_POST['mode']) || $_POST['mode'] != 'reg') {
        $html = str_replace("##ERROR##",'',$html);
    }
    else {
        include('inc/db.inc');
        $kapcsolat = csatlakozas();

        $leker = lekerdezes($kapcsolat);
        $error = '';
        while ($sor = mysqli_fetch_array($leker)) {
            if ($_POST['fnev'] == $sor['nev']){
                $error .= 'Már létezik ilyen nevű felhasználó!';
            }
            if ($_POST['email'] == $sor['email']){
                $error .= 'Már létezik felhasználó ilyen e-mail címmel!';
            }
        }
        if ($_POST['jelszo'] !== $_POST['jelszo_2']){
            $error .= 'Nem ugyanaz a két jelszó!';
        }
        if ($error != ''){
            $html = str_replace("##ERROR##",$error,$html);
        }
        else {
            $update = feltolt($kapcsolat, $_POST);
            if ($update){
                //header("Location: index.php");
                $html = file_get_contents("templates/index.tpl");
                $html = str_replace("##SIKER##", "Sikeres regisztráció!", $html);
            }
        }
    }
    echo $html;
?>