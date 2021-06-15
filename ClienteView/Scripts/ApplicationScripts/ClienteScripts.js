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