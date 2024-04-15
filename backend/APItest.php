<?php
$apiUrl = 'http://localhost/Augmented-Anarchy/backend/ApiRequest.php';

// Bemeneti adatok
$user_id = 1;
$map_id = 1;
$health = 100;
$maptime = 100;
$score = 100;

// Bemeneti adatok összeállítása
$data = array('mode' => 'uploadMapScore', 'user_id' => $user_id, 'map_id' => $map_id, 'health' => $health, 'maptime' => $maptime, 'score' => $score);

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
    // Sikeres válasz esetén dolgozd fel 'password' => hash('sha512',$password), 'newusername' => $email
    $response = mb_convert_encoding($response, 'UTF-8', 'auto');
    echo 'API válasz: ' . $response;
}

?>


 