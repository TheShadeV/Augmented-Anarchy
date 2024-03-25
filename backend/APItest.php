<?php
$apiUrl = 'http://localhost/reg4/backend/ApiRequest.php';

// Bemeneti adatok
$username = 'asd';
$password = '12345';

// Bemeneti adatok összeállítása
$data = array('mode' => 'login', 'username' => $username, 'password' => hash('sha512',$password));

// HTTP kérés összeállítása
$options = array(
    'http' => array(
        'header'  => 'Content-type: application/x-www-form-urlencoded',
        'method'  => 'POST',
        'content' => http_build_query($data),
    ),
);

// Kérés végrehajtása és válasz tárolása
$response = file_get_contents($apiUrl, false, stream_context_create($options));

// Hibakezelés
if ($response === false) {
    echo 'Hiba az API kérés során.';
} else {
    // Sikeres válasz esetén dolgozd fel
    $response = mb_convert_encoding($response, 'UTF-8', 'auto');
    echo 'API válasz: ' . $response;
}
?>
