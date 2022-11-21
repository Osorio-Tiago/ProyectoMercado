var url = "/GerenteGeneral/"//Objeto para leer posibles respuestas del servidor.

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};


function modificarProducto() {
    if (document.getElementById("areaProducto").value == "Fresco") {
        fetch(url + "GerenteGeneral_ModificarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                plu: document.getElementById("idProducto").value,
                descripcion: document.getElementById("descripcion").value,
                peso: document.getElementById("peso").value,
                precio: document.getElementById("precio").value

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
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Producto modificado correctamente</div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Error al modificar el producto</div>`

                $('#respuesta').modal('show');
            }
        })
    }
    else {
        fetch(url + "GerenteGeneral_ModificarProductoNoFresco", {
            method: "POST",
            body: JSON.stringify({
                ean: document.getElementById("idProducto").value,  //pendiente al nombre que le de Santiago
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
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Producto modificado correctamente</div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Error al modificar el producto</div>`

                $('#respuesta').modal('show');
            }
        })
        $('#respuesta').modal('show');
    }


    

}




