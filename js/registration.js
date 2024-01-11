const labels = document.querySelectorAll('.form-control label');

labels.forEach(label => {
    label.innerHTML = label.innerText
    .split("")
    .map((letter, idx) => `<span style="transition-delay: ${idx * 50}ms">${letter}</span>`)
    .join("")
});

function checkPasswordMatch() {
    var jelszo = document.getElementById("jelszo").value;
    var jelszo_2 = document.getElementById("jelszo_2").value;

    if (jelszo !== jelszo_2) {
        alert("A jelszavak nem egyeznek meg!");
        return false;
    }
}