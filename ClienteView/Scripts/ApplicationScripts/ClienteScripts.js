const baseUrl = 'https://localhost:44377/'
const cliente = {
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
        console.log(data)
        const $listarCliente = document.getElementById('listarClientes');
        data?.forEach(cliente => {
            $listarCliente.innerHTML += `
              <tr>
                  <td class="text-center">${cliente.Nombre} ${cliente.Apellidos}</td>
                  <td class="text-center">${cliente.Cedula}</td>
                  <td class="text-center">${cliente.Telefono}</td>
                  <td class="text-center">${cliente.Balance}</td>
                  <td class="text-center">
                     <a class="btn btn-primary" href="/Cliente/DetalleCliente/${cliente.Id}">Ver</a>
                     <a class="btn btn-warning">Modificar</a>
                     <a class="btn btn-danger">Eliminar</a>
                 </td>
              </tr>
            `
        });
    });
})

function ObtenerCliente() {
    cliente.nombre = $('#Nombre').val();
    cliente.apellidos = $('#Apellidos').val();
    cliente.cedula = $('#Cedula').val();
    cliente.correo = $('#Correo').val();
    cliente.telefono = $('#Telefono').val();
    cliente.direccion = $('#Direccion').val();
    cliente.balance = $('#Balance').val();
    cliente.fechaNacimiento = $('#FechaNacimiento').val();
    cliente.tipoClienteId = $('#tipoCliente').val();
    cliente.estatusId = $('#estatus').val();
}
$('#crearCliente').on('click', function (e) {
    e.preventDefault();
    ObtenerCliente();
    console.log(cliente);
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(cliente),
        dataType: 'json',
        url: `${baseUrl}/cliente/crearcliente`,
        success: () => {
            console.log('success')
        },
        complete: () => {
            location.href = `${baseUrl}/cliente/listadoclientes`
        }
    })
})