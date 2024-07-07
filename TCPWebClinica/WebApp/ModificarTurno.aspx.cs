using Business.AccesoSQL;
using Business.Interfaces;
using Business.Models;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ModificarTurno : System.Web.UI.Page
    {
        private IAccesoDatos accesoDatos;
        protected void Page_Load(object sender, EventArgs e)
        {

            accesoDatos = new AccesoDatos();
            DateTime hoy = DateTime.Today;

            if (!IsPostBack)
            {
                // Cargar datos iniciales
                CargarEspecialidades();
                CargarMedicos(ddlMedicos);
                CargarEstadoTurno();
                CargarObraSocial(ddlObraSocial);
                CargarHorarioTrabajo();

                if (fechaTurno.Text == hoy.ToString("yyyy-MM-dd"))
                {
                    fechaTurno.BorderColor = System.Drawing.Color.Red;
                }

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    CargarTurno(id);
                }
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IAccesoDatos accesoDatos = new AccesoDatos();
                TurnoModule moduleObraSocial = new TurnoModule(accesoDatos);
                int id = int.Parse(Request.QueryString["id"].ToString());
                moduleObraSocial.eliminarTurno(id);
                Response.Redirect("Turno.aspx",false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear instancia de acceso a datos y módulo de turno
                IAccesoDatos accesoDatos = new AccesoDatos();
                TurnoModule turnoModule = new TurnoModule(accesoDatos);

                // Obtener el ID del turno a modificar desde la consulta de la URL
                int idTurno = int.Parse(Request.QueryString["id"].ToString());

                // Obtener el turno existente que se desea modificar
           
            Business.Models.Turno turnoExistente = turnoModule.listarTurnos().FirstOrDefault(t => t.Id == idTurno);
                if (turnoExistente == null)
                {
                    throw new Exception("No se encontró el turno especificado para modificar.");
                }

                // Actualizar los datos del turno con los valores de los controles de la página
                turnoExistente.Medico = new Medico { Id = int.Parse(ddlMedicos.SelectedValue) };
                turnoExistente.Especialidad = new Especialidad { Id = int.Parse(dllEspecialidad.SelectedValue) };
                turnoExistente.Observaciones = txtObservaciones.Text;
                turnoExistente.Estado = new EstadoTurno { Id = int.Parse(ddlEstadoTurno.SelectedValue) };
                turnoExistente.ObraSocial = new ObraSocial { Id = int.Parse(ddlObraSocial.SelectedValue) };
                turnoExistente.FechaHora = DateTime.ParseExact(fechaTurno.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                // Guardar los cambios en el módulo de turno
                turnoModule.agregarTurno(turnoExistente);

                // Redireccionar a la página de visualización de turnos después de la modificación
                Response.Redirect("Turno.aspx");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el turno: " + ex.Message);
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

        private void CargarHorarioTrabajo()
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            HorarioTrabajoModule horarioTrabajoModule = new HorarioTrabajoModule(accesoDatos);

            // Obtener el ID del turno seleccionado
            int idTurnoSeleccionado = int.Parse(Request.QueryString["id"].ToString());
            TurnoModule turnoModule = new TurnoModule(accesoDatos);
            Business.Models.Turno turno = turnoModule.listarTurnos().Find(x => x.Id == idTurnoSeleccionado);

            // Cargar los horarios de trabajo en el DropDownList
            ddlHorarioTrabajo.DataSource = horarioTrabajoModule.listarHorarioTrabajo();
            ddlHorarioTrabajo.DataValueField = "Id";
            ddlHorarioTrabajo.DataTextField = "FechaYHora";
            ddlHorarioTrabajo.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlHorarioTrabajo.Items.Insert(0, new ListItem("-- Seleccionar Hora --", "0"));

            // Seleccionar el horario del turno seleccionado si existe
            if (turno != null)
            {
                // Formatear la hora del turno para comparación con los horarios disponibles
                string horaTurno = turno.FechaHora.ToString(@"hh\:mm");

                // Buscar el ListItem que coincide con la hora del turno y seleccionarlo
                ListItem item = ddlHorarioTrabajo.Items.FindByText(horaTurno);
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }





        private void CargarTurno(int id)
        {
            TurnoModule turnoModule = new TurnoModule(accesoDatos);
            Business.Models.Turno turno = turnoModule.listarTurnos().Find(x => x.Id == id);

            if (turno != null)
            {
                ddlMedicos.SelectedValue = turno.Medico.Id.ToString();
                dllEspecialidad.SelectedValue = turno.Especialidad.Id.ToString();
                txtObservaciones.Text = turno.Observaciones;
                ddlEstadoTurno.SelectedValue = turno.Estado.Id.ToString();
                ddlObraSocial.SelectedValue = turno.ObraSocial.Id.ToString();
                fechaTurno.Text = turno.FechaHora.ToString("yyyy-MM-dd");
            }
            else
            {
                // Manejar el caso cuando no se encuentra el turno
                
            }
        }

    }
}