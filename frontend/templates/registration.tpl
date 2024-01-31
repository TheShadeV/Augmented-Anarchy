<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css"
        integrity="sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA=="
        crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../frontend/css/index.css">
    <title>Regisztráció</title>
</head>

<body>
    <div class="container">
        <h1>Regisztrálás</h1>
        <p id="warning">##ERROR##</p>
        <form action="registration.php" method="POST">
            <div class="form-control">
                <input type="text" name="fnev" id="fnev" required maxlength="20" autofocus>
                <label>Felhasználónév</label>
            </div>
            <div class="form-control">
                <input type="email" name="email" id="email" required maxlength="50">
                <label>E-mail cím</label>
            </div>
            <div class="form-control">
                <input type="password" name="jelszo" id="jelszo" required maxlength="15">
                <label>Jelszó</label>
            </div>
            <div class="form-control">
                <input type="password" name="jelszo_2" id="jelszo_2" required maxlength="15">
                <label>Jelszó újra</label><br>
                <input type="hidden" name="mode" value="reg">
            </div>
            <div class="checkbox">
                <input type="checkbox" required>
                <label>Elfogadom a <a href="acceptTerms.php" target="_blank">felhasználói feltételeket</a>!</label>
            </div>
            <button class="btn">Regisztrálás</button>
            <br>
            <p class="text"><a href="index.php">Vissza a belépéshez</a></p>
        </form>
    </div>
    <script src="../frontend/js/registration.js"></script>
</body>

</html>



<!-- Fejlesztés alatt -->
<!-- <div class="tartalom">
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
</div> -->