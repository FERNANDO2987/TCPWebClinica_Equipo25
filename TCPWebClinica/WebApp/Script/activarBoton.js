var initialSearchText = '';

function activarBotonBuscar() {
    var btnBuscar = document.getElementById('<%= btnBuscarPaciente.ClientID %>');
    btnBuscar.disabled = false;
}

function handleKeyPress(event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);

    // Si se presiona Enter (código 13) y el texto no ha cambiado desde el inicio, evitamos la acción por defecto (submit)
    if (keycode == 13 && this.value.trim() === initialSearchText) {
        event.preventDefault();
        return false;
    }
}

// Llamada inicial para deshabilitar el botón si hay un paciente seleccionado
window.onload = function () {
    var selectedPatientName = document.getElementById('<%= txtNombreApellidoPaciente.ClientID %>').value.trim();
    var btnBuscar = document.getElementById('<%= btnBuscarPaciente.ClientID %>');

    if (selectedPatientName !== '') {
        btnBuscar.disabled = true;
    }

    // Guardar el texto inicial del cuadro de texto de búsqueda
    initialSearchText = document.getElementById('<%= txtBuscarPaciente.ClientID %>').value.trim();

    // Agregar el listener para el evento keypress en el cuadro de texto de búsqueda
    var txtBuscarPaciente = document.getElementById('<%= txtBuscarPaciente.ClientID %>');
    txtBuscarPaciente.addEventListener('keypress', handleKeyPress);
};