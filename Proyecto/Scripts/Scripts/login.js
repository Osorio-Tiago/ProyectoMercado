
var usuario = document.getElementById("username");
var contra = document.getElementById("password");

//Objeto para leer posibles respuestas del servidor
var url = "/Login/"

//funcion principal
function iniciarSesion() {
    fetch(url + "Index", {
        method: "POST",
        body: JSON.stringify({
            Username: document.getElementById("username").value , 
            Password: document.getElementById("password").value  
          
        }),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        if (response.ok)
            return document.location.href = response.url
        else
            document.getElementById("usuarioIncorrecto").innerHTML = `<div>Error al iniciar sesion</div>`
           // document.location.href = "/Error.cshtml"
    })
}
