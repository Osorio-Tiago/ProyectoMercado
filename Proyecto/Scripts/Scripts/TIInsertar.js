//Declaracion de variables 
var idProducto = document.getElementById("idProducto");
var tipoProducto = document.getElementById("tipoProducto");
var modalHead = document.getElementById("agregarProducto");
var modalBody = document.getElementById("agregarProductoRespuesta");

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};

//Objeto para leer posibles respuestas del servidor
var url = "/TI/"

//funcion principal
function agregarProducto() {
    if (document.getElementById("areaProducto").value == "Fresco") {
        fetch(url + "TI_InsertarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                PLU: document.getElementById("idProducto").value,                   //pendiente al nombre que le de Santiago        
                descripcion: document.getElementById("descripcion").value,
                peso: document.getElementById("peso").value,
                precio: document.getElementById("precio").value,

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

                document.getElementById("agregarProductoRespuesta").innerHTML = `<div>Producto insertado correctamente</div>`
                $('#agregarProducto').modal('show');
            }
            else {
                document.getElementById("agregarProductoRespuesta").innerHTML = `<div>Error al insertar el producto</div>`

                $('#agregarProducto').modal('show');
            }
        })
    }
   else{
        fetch(url + "TI_InsertarProductoNoFresco", {
            method: "POST",
            body: JSON.stringify({
                EAN: document.getElementById("idProducto").value,                         
                descripcion: document.getElementById("descripcion").value,
                area: document.getElementById("areaProducto").value,
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

                document.getElementById("agregarProductoRespuesta").innerHTML = `<div>Producto insertado correctamente</div>`
                $('#agregarProducto').modal('show');
            }
            else {
                document.getElementById("agregarProductoRespuesta").innerHTML = `<div>Error al insertar el producto</div>`

                $('#agregarProducto').modal('show');
            }
        })
    }

    
}