
var idProducto = document.getElementById("idProducto");
var tipoProducto = document.getElementById("tipoProducto");
var modalHead = document.getElementById("consultarInformacion");
var modalBody = document.getElementById("mostrarInformacion"); 

//Objeto para leer posibles respuestas del servidor
var url = "/Cajero/"

//funcion principal
function consultarProducto() {
    fetch(url + "Cajero_Consultar") //Nombre pendiente a ver cual le pone Santiago
    .then((respuesta) => {
        return respuesta.json();
    }).then((datos) => {
        var producto = '';
        //En la variable producto se pone la información en lenguaje html que se mostrará en el modal de Bootstrap
        document.getElementById("listaMarcas").innerHTML = producto
    });
}