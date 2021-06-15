const baseUrl = 'https://localhost:44377/'
const cliente = {
    id: 0,
    nombre: '',
    apellidos: '',
    cedula: '',
    telefono: '',
    correo: '',
    direccion: '',
    balance: 0.0,
    fechaNacimiento: new Date(),
    tipoClienteId: 0,
    estatusId: 0
};


$(document).ready(function () {
    $.get(`${baseUrl}/Cliente/ListarClientes`, function (data, status) {
        const $listarCliente = document.getElementById('listarClientes');
        if ($listarCliente) {
            data.forEach(cliente => {
                $listarCliente.innerHTML += `
              <tr>
                  <td class="text-center">${cliente.Nombre} ${cliente.Apellidos}</td>
                  <td class="text-center">${cliente.Cedula}</td>
                  <td class="text-center">${cliente.Telefono}</td>
                  <td class="text-center">${cliente.Balance}</td>
                  <td class="text-center">
                     <a class="btn btn-primary" href="/Cliente/DetalleCliente/${cliente.Id}">Ver</a>
                     <a class="btn btn-warning" href="/Cliente/ModificarCliente/${cliente.Id}">Modificar</a>
                     <button class="delete btn btn-danger" onclick="eliminarCliente(${cliente.Id.toString()})" value="${cliente.Id.toString()}">Eliminar</button>
                 </td>
              </tr>
            `
            });
        }
    });
})

function ObtenerCliente() {
    if ($('#cliente_Id').val()) {
        cliente.id = $('#cliente_Id').val()
    }
    cliente.nombre = $('#cliente_Nombre').val();
    cliente.apellidos = $('#cliente_Apellidos').val();
    cliente.cedula = $('#cliente_Cedula').val();
    cliente.correo = $('#cliente_Correo').val();
    cliente.telefono = $('#cliente_Telefono').val();
    cliente.direccion = $('#cliente_Direccion').val();
    cliente.balance = $('#cliente_Balance').val();
    cliente.fechaNacimiento = $('#cliente_FechaNacimiento').val();
    cliente.tipoClienteId = $('#tipoCliente').val();
    cliente.estatusId = $('#estatus').val();
    
}

$('#crearCliente').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(cliente),
        dataType: 'json',
        url: `${baseUrl}/cliente/crearcliente`
    })
})

$('#modificarCliente').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(cliente),
        dataType: 'json',
        url: `${baseUrl}/cliente/modificarcliente`
    })
})

function eliminarCliente(Id) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({Id}),
        dataType: 'json',
        url: `${baseUrl}/cliente/eliminarcliente`
    })
}