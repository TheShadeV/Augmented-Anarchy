<?php
session_start();
if (isset($_POST["action"]) && $_POST["action"] == "login") {
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

        if ($eredmenyek) {
            $eredmeny_sor = mysqli_fetch_assoc($eredmenyek);

            if ($eredmeny_sor !== null) {
                $html = str_replace("##CLASS##", $eredmeny_sor['class'], $html);
                $html = str_replace("##HEALTH##", $eredmeny_sor['health'], $html);
                $equipped = json_decode($eredmeny_sor['equipped'], true);
                $html = str_replace("##EQUIPPED##", $equipped['MB1'], $html);

                mysqli_free_result($eredmenyek);
            } else {
                $html = str_replace("##KILLS##", "Még nincs eredménye", $html);
                $html = str_replace("##ELAPSEDTIME##", "Még nincs eredménye", $html);
                $html = str_replace("##BESTTIME##", "Még nincs eredménye", $html);
            }

            echo $html;

            echo "<table class='container table table-striped table-dark table-responsive' border='1'>";
            echo "<tr><th>Rang</th><th>Felhasználó neve</th><th>Legmagasabb pontszám</th></tr>";
            $score = score_lekerdezese($kapcsolat);
            $rank = 1;
            while ($sor = mysqli_fetch_assoc($score)) {
                echo "<tr class='rank-row'>";
                echo "<td>" . $rank . "</td>";
                echo "<td";
                if ($sor["felhasznalo_nev"] == $usernev) {
                    echo " style='font-weight: bold; background-color: #cd7f32;'";
                }
                echo ">" . $sor["felhasznalo_nev"] . "</td>";
                echo "<td>" . $sor["legmagasabb_pontszam"] . "</td>";
                echo "</tr>";
                $rank++;
            }
            echo "</table>";

            mysqli_close($kapcsolat);
        }
    } else {
        $html = file_get_contents('../frontend/templates/index.tpl');
        $html = str_replace("##SIKER##", '', $html);
        $html = str_replace("##ERROR##", 'Hibás felhasználónév vagy jelszó!', $html);
        echo $html;
    }
}
?>