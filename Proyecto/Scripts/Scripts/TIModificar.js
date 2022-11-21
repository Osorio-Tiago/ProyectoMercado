//Declaracion de variables 
var idProducto = document.getElementById("idProducto");
var tipoProducto = document.getElementById("tipoProducto");
var descripcion = document.getElementById("descripcion");
var peso = document.getElementById("peso");
var precio = document.getElementById("precio");
var cantidad = document.getElementById("cantidad");

var modificarProducto = document.getElementById("modificarProducto");
var modificarProductoRespuesta = document.getElementById("modificarProductoRespuesta");

//Objeto para leer posibles respuestas del servidor
var url = "/TI/"

//funcion principal
function modificarProducto() {
    if (document.getElementById("tipoProducto").value == "noFresco") {
        fetch(url + "TI_ModificarProductoNoFresco", {
            method: "POST",
            body: JSON.stringify({
                ean: document.getElementById("idProducto").value,  //pendiente al nombre que le de Santiago
                descripcion: document.getElementById("descripcion").value,
                peso: document.getElementById("peso").value,
                precio: document.getElementById("precio").value,
                cantidad: document.getElementById("cantidad").value
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
                document.getElementById("modificarProductoRespuesta").innerHTML = `<div>Producto modificado correctamente/div>`
                $('#modificarProducto').modal('show');
            }
            else {
                document.getElementById("modificarProductoRespuesta").innerHTML = `<div>Error al modificar el producto</div>`

                $('#modificarProducto').modal('show');
            }
        })
        $('#respuesta').modal('show');
    }


    if (document.getElementById("tipoProducto").value == "fresco") {
        fetch(url + "GerenteArea_ModificarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                plu: document.getElementById("idProducto").value,                   //pendiente al nombre que le de Santiago
                descripcion: document.getElementById("descripcion").value,
                peso: document.getElementById("peso").value,
                precio: document.getElementById("precio").value,
                cantidad: document.getElementById("cantidad").value,
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
                document.getElementById("modificarProductoRespuesta").innerHTML = `<div>Producto modificado correctamente</div>`
                $('#modificarProducto').modal('show');
            }
            else {
                document.getElementById("modificarProductoRespuesta").innerHTML = `<div>Error al modificar el producto</div>`

                $('#modificarProducto').modal('show');
            }
        })
    }
}