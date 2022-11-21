
var usuario = document.getElementById("username");
var contra = document.getElementById("password");

//Objeto para leer posibles respuestas del servidor
var url = "/Cajero/"

//funcion principal
function iniciarSesion() {
   
    fetch(url + "IniciarSesion", {
        method: "POST",
        body: JSON.stringify({
            UsuarioLogin: document.getElementById("username").value , 
            ContraLogin: document.getElementById("password").value  
          
        }),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        if (response.ok)
            return response.text()
        else
            document.location.href = "/Error.cshtml"
    }).then(function (Data) {
        EstadosDeRespuesta = JSON.parse(Data);
        if (EstadosDeRespuesta.StatusDescription == "OK") {
            
        }
        else {
            document.getElementById("usuarioIncorrecto").innerHTML = `<div>Error al iniciar sesion</div>`

        }

    })

}
