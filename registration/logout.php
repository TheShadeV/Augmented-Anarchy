<?php
session_start();

if (isset($_SESSION['nev']) && isset($_SESSION['jelszo'])) {
    unset($_SESSION['nev']);
    unset($_SESSION['jelszo']);
    session_regenerate_id(true);
    session_destroy();
    echo "<h1>Sikeres kijelentkezés</h1>";
    echo "<p>Visszatérés a főoldalra <span id='countdown' style=\"color: red;\">3</span> másodpercen belül...</p>";
} else {
    echo "<h1>Nincs aktív bejelentkezés</h1>";
}
?>
<script src="js/logout.js"></script>