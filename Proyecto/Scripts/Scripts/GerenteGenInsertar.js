var url = "/GerenteGeneral/"//Objeto para leer posibles respuestas del servidor.

var EstadosDeRespuesta = {
    StatusCode: 0,
    StatusDescription: ''
};


function insertarProducto() {

    if (document.getElementById("areaProducto").value == "Fresco") {
        fetch(url + "GerenteGeneral_InsertarProductoFresco", {
            method: "POST",
            body: JSON.stringify({
                PLU: document.getElementById("idProducto").value,
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

                document.getElementById("mensajeRespuesta").innerHTML = `<div>Producto insertado correctamente</div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Error al insertar el producto</div>`

                $('#respuesta').modal('show');
            }
        })
    }
    else {
        fetch(url + "GerenteGeneral_InsertarProductoNoFresco", {
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

                document.getElementById("mensajeRespuesta").innerHTML = `<div>Producto insertado correctamente</div>`
                $('#respuesta').modal('show');
            }
            else {
                document.getElementById("mensajeRespuesta").innerHTML = `<div>Error al insertar el producto</div>`

                $('#respuesta').modal('show');
            }
        })
    }

}





