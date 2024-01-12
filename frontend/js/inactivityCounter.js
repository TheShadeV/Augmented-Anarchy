var remainingTimeElement = document.getElementById('remainingTime');
var seconds = 300;
var timer;

function updateRemainingTime() {
  if (remainingTimeElement) {
    document.getElementById("remainingTime").innerHTML =
      "Kijelentkezés (" + Math.floor(seconds / 60) + ":" +
      (seconds % 60 < 10 ? '0' : '') + seconds % 60 + ")";

    if (seconds > 0) {
      seconds--;
      timer = setTimeout(updateRemainingTime, 1000);
    } else {
      window.location.href = 'logout.php';
    }
  }
}

function startTimer() {
  updateRemainingTime();

  document.addEventListener('click', function () {
    seconds = 300;
    clearTimeout(timer);
    updateRemainingTime();
  });
}

document.addEventListener('DOMContentLoaded', startTimer);