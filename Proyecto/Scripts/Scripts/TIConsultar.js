//Declaracion de variables 
var idProducto = document.getElementById("idProducto");
var tipoProducto = document.getElementById("tipoProducto");
var modalHead = document.getElementById("consultarInformacion");
var modalBody = document.getElementById("mostrarInformacion") 

//Objeto para leer posibles respuestas del servidor
var url = "/TI/"

//funcion principal
function consultarProducto() {
    $('#consultarInformacion').modal('show');
     
    fetch(url + "TI_ConsultarProductoFresco") //Nombre pendiente a ver cual le pone Santiago
         .then((respuesta) => {
             return respuesta.json();
         }).then((datos) => {
             var producto = datos;
             //En la variable producto se pone la información en lenguaje html que se mostrará en el modal de Bootstrap
            // document.getElementById("listaMarcas").innerHTML = producto
         });
}