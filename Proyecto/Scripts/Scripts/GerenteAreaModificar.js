var url = "/GerenteArea/"//Objeto para leer posibles respuestas del servidor.

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};


function modificarProducto() {

    if (document.getElementById("areaProducto").value == "Fresco") {
        fetch(url + "GerenteArea_ModificarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                plu: document.getElementById("idProducto").value,
                descripcion: document.getElementById("descripcion").value,

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
    }


    else {
        fetch(url + "GerenteArea_ModificarProductoNoFresco", {
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
                document.getElementById("modificarProductoRespuesta").innerHTML = `<div>Producto modificado correctamente</div>`
                $('#modificarProducto').modal('show');
            }
            else {
                document.getElementById("modificarProductoRespuesta").innerHTML = `<div>Error al modificar el producto</div>`

                $('#modificarProducto').modal('show');
            }
        })
        $('#respuesta').modal('show');
    }


}




