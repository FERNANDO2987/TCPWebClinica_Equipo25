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
                DateTime fecha = turno.FechaHora;
                ddlMedicos.SelectedIndex = turno.Id;
                //Falta paciente
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

     /*   protected void ddlMedicosXEspecilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int medicoId = int.Parse(ddlMedicos.SelectedValue);
            CargarEspecilidadXMedico(medicoId);
        }*/

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



     /*   private void CargarHorarioTrabajo()
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            HorarioTrabajoModule horarioTrabajoModule  = new HorarioTrabajoModule(accesoDatos);

            //Cargar ObraSociales en un DropDownList
            ddlHorarioTrabajo.DataSource = horarioTrabajoModule.listarHorarioTrabajo();
            ddlHorarioTrabajo.DataValueField = "Id";
            ddlHorarioTrabajo.DataTextField = "FechaYHora";
            ddlHorarioTrabajo.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlHorarioTrabajo.Items.Insert(0, new ListItem("-- Seleccionar Hora --", "0"));



        }*/
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            /*    EnviarEmailModule enviarEmailModule = new EnviarEmailModule();
                enviarEmailModule.ArmarCorreo("fernandopalacios51@gmail.com","Esto es una prueba piloto","Hola que tal...");

                try
                {
                    enviarEmailModule.EnviarEmail();

                }
                catch (Exception ex)
                {

                    Session.Add("Error al Enviar E-mail",ex);
                }*/

            try
            {


                IAccesoDatos accesoDatos = new AccesoDatos();
                TurnoModule turnoModule = new TurnoModule(accesoDatos);

                Business.Models.Turno turno = new Business.Models.Turno();
                turno.FechaHora = DateTime.Parse(fechaTurno.Text);
                turno.Medico = new Medico();
                turno.Medico.Id = int.Parse(ddlMedicos.SelectedValue);
                turno.Paciente = new Paciente();
                turno.Paciente.Id = int.Parse("");
                turno.Especialidad = new Especialidad();
                turno.Especialidad.Id = int.Parse(dllEspecialidad.SelectedValue);
                turno.Observaciones = txtObservaciones.Text;
                turno.Estado = new EstadoTurno();
                turno.Estado.Id = int.Parse(ddlEstadoTurno.SelectedValue);
                turno.ObraSocial = new ObraSocial();
                turno.ObraSocial.Id = int.Parse(ddlObraSocial.SelectedValue);

                turnoModule.agregarTurno(turno);

                Response.Redirect("Turnos.aspx");
            }
            catch (Exception ex)
            {

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
                // Manejar la excepción adecuadamente
                throw new Exception("Error al buscar pacientes: " + ex.Message);
            }
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvPacientes.Rows[index];
                int pacienteId = Convert.ToInt32(selectedRow.Cells[0].Text);
                // Aquí puedes guardar el ID del paciente en una variable de sesión o en un control oculto para usarlo más adelante
            }
        }
    }
}