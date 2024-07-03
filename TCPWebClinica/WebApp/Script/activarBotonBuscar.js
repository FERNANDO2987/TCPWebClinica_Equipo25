function activarBotonBuscar() {
    var btnBuscar = document.getElementById('<%= btnBuscarPaciente.ClientID %>');
    btnBuscar.disabled = false;
}

// Llamada inicial para deshabilitar el botón si hay un paciente seleccionado
window.onload = function () {
    var selectedPatientName = document.getElementById('<%= txtNombreApellidoPaciente.ClientID %>').value.trim();
    var btnBuscar = document.getElementById('<%= btnBuscarPaciente.ClientID %>');

    if (selectedPatientName !== '') {
        btnBuscar.disabled = true;
    }
};