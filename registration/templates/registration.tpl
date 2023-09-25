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
        <h1>Regisztrálás</h1>
        <div class="regist">
            <p id="warning">##ERROR##</p>
            <form action="registration.php" method="POST">
                <label for="fnev">Felhasználónév: </label><br>
                <input type="text" name="fnev" id="fnev" required autofocus maxlength="20"><br>
                <label for="email">E-mail cím: </label><br>
                <input type="email" name="email" id="email" required maxlength="50"><br>
                <label for="jelszo">Jelszó: </label><br>
                <input type="password" name="jelszo" id="jelszo" required maxlength="15"><br>
                <input type="hidden" name="mode" value="reg">
                <input type="submit" value="Regisztrálás">
            </form>
        </div>
    </div>
</body>
</html>