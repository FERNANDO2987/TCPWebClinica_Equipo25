using Business.AccesoSQL;
using Business.Interfaces;

using Business.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Models;

namespace WebApp
{
    public partial class NuevoTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;

            if (!IsPostBack)
            {
                // Cargar datos iniciales
                //CargarEspecialidades();

                //Cargar datos de Medicos
                CargarMedicos(ddlMedicos);

                //Cargar Estado de Turno
                CargarEstadoTurno();

                //Cargar Obras Sociales
                CargarObraSocial(ddlObraSocial);

                if (fechaTurno.Text == hoy.ToString("yyyy-MM-dd"))
                {
                    fechaTurno.BorderColor = System.Drawing.Color.Red;
                }


            }

            IAccesoDatos accesoDatos = new AccesoDatos();
            TurnoModule turnoModule = new TurnoModule(accesoDatos);

            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"].ToString());
                Business.Models.Turno turno = turnoModule.listarTurnos().Find(x => x.Id == id);

                // Recuperar y asignar paciente si existe
                if (turno.Paciente != null)
                {
                    hfPacienteId.Value = turno.Paciente.Id.ToString();
                    // Aquí deberías mostrar el nombre del paciente en algún control, por ejemplo:
                    // lblPacienteSeleccionado.Text = turno.Paciente.NombreCompleto; // Ajusta según tu interfaz
                }
                DateTime fecha = turno.FechaHora;
                ddlMedicos.SelectedIndex = turno.Id;





                dllEspecialidad.SelectedIndex = turno.Id;
                txtObservaciones.Text = turno.Observaciones;
                ddlEstadoTurno.SelectedIndex = turno.Id;
                ddlObraSocial.SelectedIndex = turno.Id;
                fechaTurno.Text = fecha.ToString("yyyy-MM-dd");

            }
            else
            {
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
            }

        }

        protected void fechaTurno_TextChanged(object sender, EventArgs e)
        {
            // Tu lógica aquí
        }
        private void CargarEspecialidades()
        {

            IAccesoDatos accesoDatos = new AccesoDatos();
            EspecialidadModule especialidadModule = new EspecialidadModule(accesoDatos);

            // Cargar las especialidades en un DropDownList
            dllEspecialidad.DataSource = especialidadModule.listarEspecialidad();
            dllEspecialidad.DataTextField = "Nombre"; // Nombre de la propiedad en Especialidad
            dllEspecialidad.DataValueField = "Id";    // ID de la propiedad en Especialidad
            dllEspecialidad.DataBind();

            // Agregar un elemento vacío para selección inicial
            dllEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));

        }

        private void CargarMedicos(DropDownList ddlMedicos)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            MedicoModule medicoModule = new MedicoModule(accesoDatos);

            // Cargar los Médicos en un DropDownList
            ddlMedicos.DataSource = medicoModule.listarMedicos();
            ddlMedicos.DataValueField = "Id";
            ddlMedicos.DataTextField = "NombreCompleto";
            ddlMedicos.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlMedicos.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

            // Agregar evento para cargar horarios al seleccionar un médico
            ddlMedicos.SelectedIndexChanged += new EventHandler(ddlMedicos_SelectedIndexChanged);


        }

        private void CargarEstadoTurno()
        {

            IAccesoDatos accesoDatos = new AccesoDatos();
            EstadoTurnoModule estadoTurnoModule = new EstadoTurnoModule(accesoDatos);

            //Cargar los Medicos en un DropDownList
            ddlEstadoTurno.DataSource = estadoTurnoModule.listarEstadosTurno();
            ddlEstadoTurno.DataValueField = "Id";
            ddlEstadoTurno.DataTextField = "Descripcion";
            ddlEstadoTurno.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlEstadoTurno.Items.Insert(0, new ListItem("-- Seleccione un Medico --", "0"));

            // Establecer el valor por defecto a "Confirmado"
            ListItem item = ddlEstadoTurno.Items.FindByText("Confirmado");
            if (item != null)
            {
                ddlEstadoTurno.ClearSelection();
                item.Selected = true;
            }


        }

        private void CargarObraSocial(DropDownList ddlObraSocial)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            ObraSocialModule obraSocialModule = new ObraSocialModule(accesoDatos);

            //Cargar ObraSociales en un DropDownList
            ddlObraSocial.DataSource = obraSocialModule.listarObraSociales();
            ddlObraSocial.DataValueField = "Id";
            ddlObraSocial.DataTextField = "Nombre";
            ddlObraSocial.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlObraSocial.Items.Insert(0, new ListItem("-- Seleccionar ObraSocial --", "0"));



        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int medicoId = int.Parse(ddlMedicos.SelectedValue);
            CargarHorariosDeMedico(medicoId);
            CargarEspecilidadXMedico(medicoId);
        }

        private void CargarHorariosDeMedico(int medicoId)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            HorarioTrabajoModule horarioTrabajoModule = new HorarioTrabajoModule(accesoDatos);
            try
            {

                List<HorarioDeTrabajo> horarios = horarioTrabajoModule.listarHorarioTrabajoPorMedico(medicoId);

                // Lógica para cargar los horarios en el dropdown ddlHorarioTrabajo
                ddlHorarioTrabajo.DataSource = horarios;
                ddlHorarioTrabajo.DataValueField = "Id";
                ddlHorarioTrabajo.DataTextField = "FechaYHora";
                ddlHorarioTrabajo.DataBind();

                // Agregar un elemento vacío para selección inicial
                ddlHorarioTrabajo.Items.Insert(0, new ListItem("-- Seleccionar Horario --", "0"));
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                throw new Exception("Error al cargar los horarios de trabajo por médico: " + ex.Message);
            }
        }


        private void CargarEspecilidadXMedico(int medicoId)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            EspecialidadModule especialidadModule = new EspecialidadModule(accesoDatos);


            try
            {
                List<Especialidad> especialidad = especialidadModule.listarEspecilidadPorMedico(medicoId);

                // Lógica para cargar las Especialidades
                dllEspecialidad.DataSource = especialidad;
                dllEspecialidad.DataValueField = "Id";
                dllEspecialidad.DataTextField = "Nombre";
                dllEspecialidad.DataBind();

                // Agregar un elemento vacío para selección inicial
                dllEspecialidad.Items.Insert(0, new ListItem("-- Seleccionar Especilidad--", "0"));
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                throw new Exception("Error al cargar los horarios de trabajo por médico: " + ex.Message);
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
              EnviarEmailModule enviarEmailModule = new EnviarEmailModule();
           


            try
            {
                // Retrieve the patient ID from the hidden field
                if (int.TryParse(hfPacienteId.Value, out int pacienteId) && pacienteId > 0)
                {
                    // Crear una instancia de los módulos y acceso a datos necesarios
                    IAccesoDatos accesoDatos = new AccesoDatos();
                    TurnoModule turnoModule = new TurnoModule(accesoDatos);
                    PacienteModule pacienteModule = new PacienteModule(accesoDatos);
                    // Crear un nuevo objeto de Turno y asignar valores
                    Business.Models.Turno turno = new Business.Models.Turno
                    {
                        FechaHora = DateTime.Parse(fechaTurno.Text),
                        Medico = new Medico { Id = int.Parse(ddlMedicos.SelectedValue) },
                        Paciente = new Paciente { Id = pacienteId },
                        Especialidad = new Especialidad { Id = int.Parse(dllEspecialidad.SelectedValue) },
                        Observaciones = txtObservaciones.Text,
                        Estado = new EstadoTurno { Id = int.Parse(ddlEstadoTurno.SelectedValue) },
                        ObraSocial = new ObraSocial { Id = int.Parse(ddlObraSocial.SelectedValue) }
                    };

                    // Agregar el turno

                    turnoModule.agregarTurno(turno);

                  var  result =  pacienteModule.ObtenerPacientePorId(turno.Id);

                    try
                    {
                        
                        enviarEmailModule.ArmarCorreo(result.Email, "Esto es una prueba piloto", "Hola que tal...");

                        enviarEmailModule.EnviarEmail();

                    }
                    catch (Exception ex)
                    {

                        Session.Add("Error al Enviar E-mail", ex);
                    }

                    // Redireccionar a la página de turnos después de agregar
                    Response.Redirect("Turno.aspx");

                   
                }
                else
                {
                    throw new Exception("Debe seleccionar un paciente antes de agregar el turno.");
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                throw ex;
            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {


            IAccesoDatos accesoDatos = new AccesoDatos();

        }

        protected void txtBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            string criterio = txtBuscarPaciente.Text.Trim();
            BuscarYMostrarPacientes(criterio);
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarPaciente.Text;
            BuscarYMostrarPacientes(criterio);
        }

        private void BuscarYMostrarPacientes(string criterio)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            PacienteModule pacienteModule = new PacienteModule(accesoDatos);

            try
            {
                List<Paciente> pacientes = pacienteModule.BuscarPacientePorCriterio(criterio);
                gvPacientes.DataSource = pacientes;
                gvPacientes.DataBind();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar pacientes: " + ex.Message);
            }
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            PacienteModule pacienteModule = new PacienteModule(accesoDatos);

            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                // Obtener el ID del paciente desde los DataKeys de la GridView
                int pacienteId = Convert.ToInt32(gvPacientes.DataKeys[index].Value);

                // Guardar el ID del paciente en el campo oculto
                hfPacienteId.Value = pacienteId.ToString();

                // Opcional: Mostrar el nombre y apellido del paciente seleccionado en un TextBox (o cualquier otro control)
                string nombre = gvPacientes.Rows[index].Cells[1].Text; // Ajusta el índice según la posición del campo en la GridView
                string apellido = gvPacientes.Rows[index].Cells[2].Text; // Ajusta el índice según la posición del campo en la GridView
                txtNombreApellidoPaciente.Text = $"{nombre} {apellido}";

                // Resaltar visualmente la fila seleccionada
                gvPacientes.SelectedIndex = index;
            }
        }












    }
}