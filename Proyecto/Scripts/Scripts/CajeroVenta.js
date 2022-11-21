
var idProducto = document.getElementById("idProducto");
var tipoProducto = document.getElementById("tipoProducto");
var cantidad=  document.getElementById("cantidad");
//modal 1 
var agregarProductoModal = document.getElementById("agregarProducto");
var agregarProductoModalInfo = document.getElementById("agregarProductoRespuesta");

//Objeto para leer posibles respuestas del servidor
var url = "/Cajero/"

//funcion principal
function agregarProducto() {

    fetch(url + "AgregarVenta", {
        method: "POST",
        body: JSON.stringify({
            idProducto: document.getElementById("idProducto").value,
            tipoProducto: document.getElementById("tipoProducto").value, 
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
            document.getElementById("agregarProductoRespuesta").innerHTML = `<div>Producto agregado correctamente/div>`
            $('#agregarProducto').modal('show');
        }
        else {
            document.getElementById("agregarProductoRespuesta").innerHTML = `<div>No se pudo ingresar el producto. /div>`
            $('#agregarProducto').modal('show');

        }

    })
}

