<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Profil szerkesztése</title>
</head>
<body>
    <h1>Profil adatok</h1>
    <form action="profile.php" method="POST">
        <input type="hidden" name="mode" value="profileUpdate">
        <input type="hidden" name="id" value="##ID##">
        <label for="unev">Teljes név: </label><br>
        <input type="text" name="unev" id="unev" maxlength="50" value="##UNEV##" autofocus><br>
        <label for="nev">Felhasználónév: </label><br>
        <input type="text" name="nev" id="nev" maxlength="20" value="##FNEV##"><br>
        <label for="email">E-mail cím: </label><br>
        <input type="email" name="email" id="email" required maxlength="50" value="##EMAIL##"><br>
        <label for="szuldatum">Születési dátum</label><br>
        <input type="date" name="szuldatum" id="szuldatum" value="##DATUM##"><br>
        <label for="telefon">Telefonszám: </label><br>
        <input type="tel" name="telefon" id="telefon" value="##TEL##"><br>
        <input type="submit" value="Profil frissítése">
    </form>
    <h2>Jelszó módosítása</h2>
    <form action="profile.php" method="POST">
        <label for="oldPass">Régi jelszó: </label><br>
        <input type="password" name="oldPass" id="oldPass"><br>
        <label for="newPass">Új jelszó: </label><br>
        <input type="password" name="newPass" id="newPass"><br>
        <label for="rePass">Új jelszó mégegyszer: </label><br>
        <input type="password" name="rePass" id="rePass"><br>
        <input type="submit" value="Jelszó frissítése">
    </form>
</body>
</html>