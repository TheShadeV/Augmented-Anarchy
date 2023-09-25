<?php
    if (isset($_POST["mode"]) && $_POST["mode"] == "login"){
        $usernev = $_POST['nev'];
        $jelszo = md5($_POST['jelszo']);

        include("inc/db.inc");
        $kapcsolat = csatlakozas();
        $user = egy_leker($kapcsolat, $usernev, $jelszo);

        if ($user)
            $html = file_get_contents('templates/login.tpl');
            session_start();
            $_SESSION['nev'] = $usernev;
            $_SESSION['jelszo'] = $jelszo;
    }
    echo $html;
?>