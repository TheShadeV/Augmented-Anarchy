var seconds = 3;

function countdown() {
    document.getElementById("countdown").innerHTML = seconds;
    seconds--;

    if (seconds < 0) {
        window.location.href = "index.php";
    } else {
        setTimeout(countdown, 1000);
    }
}

window.onload = function() {
    countdown();
};