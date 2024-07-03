function mostrarPacienteSeleccionado() {
    document.getElementById('<%= gvPacientes.ClientID %>').style.display = 'none';
    document.getElementById('selectedPatientDetails').style.display = 'block';
}