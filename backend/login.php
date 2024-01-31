<?php
session_start();
if (isset($_POST["mode"]) && $_POST["mode"] == "login") {
    $usernev = trim(strip_tags($_POST['nev']));
    $jelszo = hash('sha512', $_POST['jelszo']);

    include("inc/db.inc");
    $kapcsolat = csatlakozas();
    $user = egy_leker($kapcsolat, $usernev, $jelszo);

    if ($user) {
        $html = file_get_contents('../frontend/templates/login.tpl');
        $_SESSION['nev'] = $usernev;
        $_SESSION['jelszo'] = $jelszo;

        $html = str_replace("##FNEV##", $usernev, $html);

        $eredmenyek = eredmenyek_lekerdezese($kapcsolat, $usernev);
        mysqli_close($kapcsolat);

        if ($eredmenyek) {
            $eredmeny_sor = mysqli_fetch_assoc($eredmenyek);

            if ($eredmeny_sor !== null) {
                $html = str_replace("##KILLS##", $eredmeny_sor['kills'], $html);
                $html = str_replace("##ELAPSEDTIME##", $eredmeny_sor['elapsedTime'], $html);
                $html = str_replace("##BESTTIME##", $eredmeny_sor['bestTime'], $html);

                mysqli_free_result($eredmenyek);
            } else {
                $html = str_replace("##KILLS##", "Még nincs eredménye", $html);
                $html = str_replace("##ELAPSEDTIME##", "Még nincs eredménye", $html);
                $html = str_replace("##BESTTIME##", "Még nincs eredménye", $html);
            }

            echo $html;
        }
    } else {
        $html = file_get_contents('../frontend/templates/index.tpl');
        $html = str_replace("##SIKER##", '', $html);
        $html = str_replace("##ERROR##", 'Hibás felhasználónév vagy jelszó!', $html);
        echo $html;
    }
} else {
    header("location: index.php");
}
?>