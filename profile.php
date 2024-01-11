<?php
session_start();
if (!isset($_SESSION['nev']) || !isset($_SESSION['jelszo'])) {
    header("Location: index.php");
    exit();
}

include("inc/db.inc");
$kapcsolat = csatlakozas();
$user = egy_leker(
    $kapcsolat,
    $_SESSION['nev'],
    $_SESSION['jelszo']
);

if ($user) {
    $html = file_get_contents('templates/profile.tpl');
    $html = str_replace("##FNEV##", $_SESSION['nev'], $html);
    $user = user_leker($kapcsolat, $_SESSION['nev']);
    $sor = mysqli_fetch_array($user);
    $html = str_replace("##EMAIL##", $sor['email'], $html);
    $html = str_replace('##ID##', $sor['id'], $html);
}

// Jelszó módosítása
if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $oldPass = $_POST['oldPass'];
    $newPass = $_POST['newPass'];
    $rePass = $_POST['rePass'];

    if ($newPass == $rePass) {

        $updateSuccess = jelszo_modosit($kapcsolat, $_SESSION['nev'], $newPass, $oldPass);

        if ($updateSuccess) {
            echo "<script>alert('Sikeres jelszómódosítás!');</script>";
        } else {
            echo "<script>alert('Hiba történt a jelszó módosítása közben!');</script>";
        }
    } else {
        echo "<script>alert('Az új jelszó és az ismételt jelszó nem egyezik!');</script>";
    }
}

// Fejlesztés alatt
// $profil = profil_leker($kapcsolat, $sor['id']);

// if (mysqli_num_rows($profil) == 0){
//     $html = str_replace('##UNEV##', '', $html);
//     $html = str_replace('##DATUM##', '', $html);
//     $html = str_replace('##TEL##', '', $html);
// }
// else {
//     while ($sor = mysqli_fetch_array($profil)) {
//     $html = str_replace('##UNEV##', $sor['unev'], $html);
//     $html = str_replace('##DATUM##', $sor['szuldatum'], $html);
//     $html = str_replace('##TEL##', $sor['telefon'], $html);
//     }
// }

echo $html;
?>