var url = "/GerenteGeneral/"//Objeto para leer posibles respuestas del servidor.

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};


function eliminarProducto() {
  
    if (document.getElementById("tipoProducto").value == "noFresco") {
        fetch(url + "GerenteGeneral_EliminarProductoNoFresco", {
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
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Producto eliminado correctamente/div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Error al eliminar el producto</div>`

                $('#respuesta').modal('show');
            }

        })
    
    }
    if ((document.getElementById("tipoProducto").value == "fresco") {
        fetch(url + "GerenteGeneral_EliminarProductoFresco", {
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
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Producto eliminado correctamente/div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Error al eliminar el producto</div>`

                $('#respuesta').modal('show');
            }

        })
    }
}
                       


