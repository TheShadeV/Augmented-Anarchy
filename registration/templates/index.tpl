<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <div class="felso">
        <form action="login.php" method="POST" id="login_form">
            <label for="fnev">Felhasználónév: </label>
            <input type="text" name="nev" id="nev">
            <label for="jelszo">Jelszó: </label>
            <input type="password" name="jelszo" id="jelszo">
            <input type="hidden" name="mode" value="login">
            <input type="submit" value="Belépés"><br>
            <small><a href="registration.php">Nincs még fiókja?</a></small>
        </form>
    </div>
    <div class="tartalom">
        <h1>Főoldal</h1>
        <h2 id="siker">##SIKER##</h2>
    </div>
</body>
</html>