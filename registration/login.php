<?php
if (isset($_POST["mode"]) && $_POST["mode"] == "login") {
    $usernev = trim(strip_tags($_POST['nev']));
    $jelszo = md5($_POST['jelszo']);

    include("inc/db.inc");
    $kapcsolat = csatlakozas();
    $user = egy_leker($kapcsolat, $usernev, $jelszo);

    if ($user) {
        $html = file_get_contents('templates/login.tpl');
        session_start();
        $_SESSION['nev'] = $usernev;
        $_SESSION['jelszo'] = $jelszo;
        echo $html;
    } else {
        //echo "<h1 class=\"hiba\">Hibás felhasználónév vagy jelszó!</h1>";
        //echo "<p>Visszatérés a főoldalra <span id='countdown' style=\"color: red;\">3</span> másodpercen belül...</p>";
        $html = file_get_contents('templates/index.tpl');
        $html = str_replace("##SIKER##", '', $html);
        $html = str_replace("##ERROR##", 'Hibás felhasználónév vagy jelszó!', $html);
        echo $html;
    }
}
?>
<!-- <script src="js/login.js"></script> -->