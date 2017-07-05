function sair() {
    document.getElementById('DivLogOut').style.display = "block";
}

function sair_cancel() {
    document.getElementById('DivLogOut').style.display = 'none';
}

function sair_exit() {
    window.open('LogOut.aspx', '_parent');
}

function myFunction(id) {
    var x = document.getElementById(id);
    if (x.className.indexOf("w3-show") == -1) {
        x.className += " w3-show";
    } else {
        x.className = x.className.replace(" w3-show", "");
    }
}