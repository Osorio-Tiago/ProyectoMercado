var url = "/GerenteGeneral/"//Objeto para leer posibles respuestas del servidor.

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};


function consultarProducto() {
    idProducto = document.getElementById("idproducto").value
    if (document.getElementById("tipoProducto").value == "noFresco") {
        /* fetch(url + "GerenteGeneral_ConsultarProductoNoFresco"+idProducto) //Nombre pendiente a ver cual le pone Santiago       
             .then((respuesta) => {
                 return respuesta.json();
                 
             }).then((datos) => {
                 var producto += ``
                 //En la variable producto se pone la información en lenguaje html que se mostrará en el modal de Bootstrap
                 document.getElementById("infoProducto").innerHTML = producto
             });*/
        $('#detalleProducto').modal('show');
    }
    if (document.getElementById("tipoProducto").value == "fresco") {
        /* fetch(url + "GerenteGeneral_ConsultarProductoFresco") //Nombre pendiente a ver cual le pone Santiago
             method: "GET",
                body: JSON.stringify({
                    plu: document.getElementById("idProducto").value  //pendiente al nombre que le de Santiago
                
                }),
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
             .then((respuesta) => {
                 return respuesta.json();
                
             }).then((datos) => {
                 var producto += ``
                 //En la variable producto se pone la información en lenguaje html que se mostrará en el modal de Bootstrap
                 document.getElementById("infoProducto").innerHTML = producto
             });*/
    }
}


