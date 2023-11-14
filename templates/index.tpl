<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css"
    integrity="sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA=="
    crossorigin="anonymous">
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;700&display=swap" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="css/index.css">
  <title>Index</title>
</head>

<body>
  <div class="container">
    <h2 id="siker">##SIKER##</h2><br>
    <h4 id="warning">##ERROR##</h4><br>
    <h1>Jelentkezz be!</h1>
    <form action="login.php" method="POST">
      <div class="form-control">
        <input type="text" name="nev" required />
        <label>Felhasználónév</label>
      </div>
      <div class="form-control">
        <input type="password" name="jelszo" required />
        <label>Jelszó</label>
      </div>
      <input type="hidden" name="mode" value="login">
      <button class="btn">Bejelentkezés</button>
      <p class="text">Nincs még fiókja? <a href="registration.php">Regisztráljon!</a></p>
    </form>
  </div>
  <footer>
    <p>Készítette: Bráz Bálint, Trischler Gergő, Horváth Mátyás</p>
  </footer>
  <script src="js/index.js"></script>
</body>

</html>