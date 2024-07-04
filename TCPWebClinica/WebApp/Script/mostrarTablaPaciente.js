// JavaScript para controlar la visibilidad de la tabla y detalles del paciente seleccionado
function mostrarTablaPacientes() {
    var divTablaPacientes = document.getElementById('<%= gvPacientes.ClientID %>').parentNode;
    var selectedPatientName = document.getElementById('<%= txtNombreApellidoPaciente.ClientID %>').value.trim();

    if (selectedPatientName !== '') {
        divTablaPacientes.style.display = 'none'; // Oculta la tabla
    } else {
        divTablaPacientes.style.display = 'block'; // Muestra la tabla
    }
}

// Llamar a la función inicialmente para establecer la visibilidad
mostrarTablaPacientes();