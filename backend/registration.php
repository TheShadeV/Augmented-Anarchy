<?php
$html = file_get_contents('../frontend/login/registration.html');
if (!isset($_POST['mode']) || $_POST['mode'] != 'reg') {
    $html = str_replace("##ERROR##", '', $html);
} else {
    include('inc/db.inc');
    $kapcsolat = csatlakozas();

    $leker = lekerdezes($kapcsolat);
    $error = '';
    while ($sor = mysqli_fetch_array($leker)) {
        if ($_POST['fnev'] == $sor['nev']) {
            $error .= 'Már létezik ilyen nevű felhasználó!<br>';
        }
        if ($_POST['email'] == $sor['email']) {
            $error .= 'Már létezik felhasználó ilyen e-mail címmel!<br>';
        }
    }
    if ($_POST['jelszo'] !== $_POST['jelszo_2']) {
        $error .= 'Nem ugyanaz a két jelszó!<br>';
    }
    if ($error != '') {
        $html = str_replace("##ERROR##", $error, $html);
    } else {
        $update = feltolt($kapcsolat, $_POST);
        if ($update) {
            $html = file_get_contents("../frontend/templates/index.html");
            $html = str_replace("##SIKER##", "Sikeres regisztráció!", $html);
            $html = str_replace("##ERROR##", "", $html);
        }
    }
}
echo $html;
?>