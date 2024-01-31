<?php
session_start();

if (isset($_SESSION['nev']) && isset($_SESSION['jelszo'])) {
    unset($_SESSION['nev']);
    unset($_SESSION['jelszo']);
    session_regenerate_id();
    session_destroy();
    $html = file_get_contents('../frontend/templates/logout.tpl');
    echo $html;
} else {
    $html = file_get_contents('../frontend/templates/nologin.tpl');
    echo $html;
}
?>