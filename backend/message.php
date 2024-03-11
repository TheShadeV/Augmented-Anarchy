<?php
// Adatbázis kapcsolódás
$servername = "localhost";
$username = "root"; // A felhasználóneved
$password = ""; // A jelszavad
$dbname = "augmentedanarchy"; // Az adatbázis neve

$conn = new mysqli($servername, $username, $password, $dbname);

// Ellenőrizd a kapcsolódást
if ($conn->connect_error) {
    die("Sikertelen kapcsolódás: " . $conn->connect_error);
}

// Űrlap adatainak fogadása és az adatbázisba való beszúrása
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $name = $_POST["name"];
    $email = $_POST["email"];
    $subject = $_POST["subject"];
    $message = $_POST["message"];

    $sql = "INSERT INTO messages (name, email, subject, message) VALUES ('$name', '$email', '$subject', '$message')";

    if ($conn->query($sql) === TRUE) {
        echo "Az üzenet sikeresen elküldve!";
    } else {
        echo "Hiba: " . $sql . "<br>" . $conn->error;
    }
}

$conn->close();
?>
