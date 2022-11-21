//Declaracion de variables 
var idProducto = document.getElementById("idProducto");
var tipoProducto = document.getElementById("tipoProducto");
var modalHead = document.getElementById("eliminarProducto");
var modalBody = document.getElementById("eliminarProductoRespuesta") 

//Objeto para leer posibles respuestas del servidor
var url = "/TI/"

//funcion principal
function eliminarProducto() {
       
    //validacion producto no fresco
    if (document.getElementById("tipoProducto").value == "noFresco") {
        fetch(url + "TI_EliminarProductoNoFresco", {
            method: "POST",
            body: JSON.stringify({
                IdProducto: document.getElementById("idproducto").value  
              
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
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Producto eliminado correctamente/div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Error al eliminar el producto</div>`

                $('#respuesta').modal('show');
            }

        })
    
    }

     //validacion producto  fresco
    if ((document.getElementById("tipoProducto").value == "fresco") {
        fetch(url + "TI_EliminarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                IdProducto: document.getElementById("idproducto").value
                
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
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Producto eliminado correctamente/div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Error al eliminar el producto</div>`

                $('#respuesta').modal('show');
            }

        })
    }
    
}