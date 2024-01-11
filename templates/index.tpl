<!DOCTYPE html>
<html lang="hu">

<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta name="google-signin-client_id"
    content="760772940560-kb6mq2eheo9lhltg5urbomendq589iod.apps.googleusercontent.com">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css"
    integrity="sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA=="
    crossorigin="anonymous">
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;700&display=swap" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="css/index.css">
  <link rel="stylesheet"
    href="https://cdn.jsdelivr.net/gh/creativetimofficial/tailwind-starter-kit/compiled-tailwind.min.css">
  <title>Index</title>
</head>

<body>
  <img src="img/Logo1.gif" alt="logo" class="logo">
  <div class="container bejelentkezes">
    <h2 id="siker">##SIKER##</h2><br>
    <h4 id="warning">##ERROR##</h4><br>
    <h1>Jelentkezz be!</h1>
    <form action="login.php" method="POST">
      <div class="form-control">
        <input type="text" name="nev" required>
        <label>Felhasználónév</label>
      </div>
      <div class="form-control">
        <input type="password" name="jelszo" required>
        <label>Jelszó</label>
      </div>
      <input type="hidden" name="mode" value="login">
      <button class="btn">Bejelentkezés</button>
      <p class="text">Nincs még fiókja? <a href="registration.php">Regisztráljon!</a></p>
  </div>
  </form>
  </div>
  <footer>
    <p>Készítette: Bráz Bálint, Trischler Gergő, Horváth Mátyás</p>
  </footer>
  <script src="js/index.js"></script>
</body>

</html>