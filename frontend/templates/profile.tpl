<!DOCTYPE html>
<html lang="hu">

<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;700&display=swap" rel="stylesheet">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
    crossorigin="anonymous"></script>
  <link rel="stylesheet" type="text/css" href="../frontend/css/profile.css">
  <title>Profil szerkesztése</title>
</head>

<body>
  <nav class="navbar navbar-expand-sm navbar-light bg-info">
    <img src="../frontend/img/logo1.gif" alt="logo" class="logo img-fluid">
    <div class="container-fluid">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse justify-content-end" id="navbarSupportedContent">
        <div class="row">
          <div class="col-sm-auto">
            <button class="btn btn-light btn-block" aria-current="page"
              onclick="window.location.href='login.php'">Eredmények</button>
          </div>
          <div class="col-sm-auto">
            <button class="btn btn-danger btn-block" onclick="window.location.href='logout.php'"
              id="remainingTime">Kijelentkezés</button>
          </div>
        </div>
      </div>
    </div>
  </nav>

  <div class="container d-flex align-items-center justify-content-center flex-column">
    <h1 class="mt-5">Profil adatok</h1>
    <form action="profile.php" method="POST" class="w-50 mb-3">
      <div class="mb-3">
        <label for="nev" class="form-label">Felhasználónév:</label>
        <input type="text" name="nev" id="nev" class="form-control" maxlength="20" value="##FNEV##">
      </div>
      <div class="mb-3">
        <label for="email" class="form-label">E-mail cím:</label>
        <input type="email" name="email" id="email" class="form-control" required maxlength="50" value="##EMAIL##">
      </div>
      <div class="text-center">
        <input type="submit" class="btn btn-primary w-75" value="Profil frissítése">
      </div>
    </form>

    <h2 class="mt-5">Jelszó módosítása</h2>
    <form action="profile.php" method="POST" class="w-50">
      <div class="mb-3">
        <label for="oldPass" class="form-label">Régi jelszó:</label>
        <input type="password" name="oldPass" id="oldPass" class="form-control">
      </div>
      <div class="mb-3">
        <label for="newPass" class="form-label">Új jelszó:</label>
        <input type="password" name="newPass" id="newPass" class="form-control">
      </div>
      <div class="mb-3">
        <label for="rePass" class="form-label">Új jelszó mégegyszer:</label>
        <input type="password" name="rePass" id="rePass" class="form-control">
      </div>
      <div class="text-center">
        <input type="submit" class="btn btn-primary w-75" value="Jelszó frissítése">
      </div>
    </form>
  </div>
  <script src="../frontend/js/inactivityCounter.js"></script>
</body>

</html>