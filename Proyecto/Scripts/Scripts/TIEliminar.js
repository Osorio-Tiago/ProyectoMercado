//Objeto para leer posibles respuestas del servidor
var url = "/TI/"

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};

//funcion principal
function eliminarProducto() {
       
    //validacion producto no fresco
    if (document.getElementById("tipoProducto").value == "noFresco") {
        fetch(url + "TI_EliminarProductoNoFresco", {
            method: "POST",
            body: JSON.stringify({
                Ean: document.getElementById("idProducto").value,
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
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Producto eliminado correctamente</div>`
                $('#eliminarProducto').modal('show');
            }
            else {
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Error al eliminar el producto</div>`

                $('#eliminarProducto').modal('show');
            }

        })
    
    }
    
     //validacion producto  fresco
    if (document.getElementById("tipoProducto").value == "fresco") {
        fetch(url + "TI_EliminarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                Plu: document.getElementById("idProducto").value
                
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
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Producto eliminado correctamente</div>`
                $('#eliminarProducto').modal('show');
            }
            else {
                document.getElementById("eliminarProductoRespuesta").innerHTML = `<div>Error al eliminar el producto</div>`

                $('#eliminarProducto').modal('show');
            }

        })
    }
    
}