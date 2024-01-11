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
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
    crossorigin="anonymous"></script>
  <link rel="stylesheet" type="text/css" href="css/login.css">
  <title>Bejelentkezve</title>
</head>

<body>
  <nav class="navbar navbar-expand-sm navbar-light bg-info">
    <div class="container-fluid">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse justify-content-end" id="navbarSupportedContent">
        <div class="row">
          <div class="col-sm-auto">
            <button class="btn btn-light btn-block" aria-current="page"
              onclick="window.location.href='profile.php'">Profil beállítások</button>
          </div>
          <div class="col-sm-auto">
            <button class="btn btn-danger btn-block" onclick="window.location.href='logout.php'"
              id="remainingTime">Kijelentkezés</button>
          </div>
        </div>
      </div>
    </div>
  </nav>

  <div class="container mt-5">
    <h1 class="text-center mt-3">Üdvözöljük ##FNEV##!</h1>
  </div>
  <div class="container mt-5">
    <div class="table-responsive">
      <table class="table table-hover table-bordered table-secondary">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col" class="table-danger">Ölések</th>
            <th scope="col" class="table-warning">Eltelt idő</th>
            <th scope="col" class="table-primary">Legjobb idő</th>
          </tr>
        </thead>
        <tbody class="table-group-divider">
          <tr>
            <th scope="row">1</th>
            <td class="table-danger">##KILLS##</td>
            <td class="table-warning">##ELAPSEDTIME##</td>
            <td class="table-primary">##BESTTIME##</td>
          </tr>
          <tr>
            <th scope="row">2</th>
            <td class="table-danger">XYZ</td>
            <td class="table-warning">XYZ</td>
            <td class="table-primary">XYZ</td>
          </tr>
          <tr>
            <th scope="row">3</th>
            <td class="table-danger">XYZ</td>
            <td class="table-warning">XYZ</td>
            <td class="table-primary">XYZ</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <script src="js/inactivityCounter.js"></script>
</body>

</html>