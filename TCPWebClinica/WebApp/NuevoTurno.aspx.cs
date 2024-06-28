using Business.AccesoSQL;
using Business.Interfaces;
using Business.Models;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class NuevoTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar datos iniciales
               // CargarEspecialidades();

                //Cargar datos de Medicos
                CargarMedicos();

                //Cargar Estado de Turno
                CargarEstadoTurno();

                //Cargar Obras Sociales
                CargarObraSocial();

              
            }

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

        private void CargarMedicos()
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

        private void CargarObraSocial()
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
            try
            {
                HorarioTrabajoModule horarioTrabajoModule = new HorarioTrabajoModule(new AccesoDatos());
                List<HorarioDeTrabajo> horarios = horarioTrabajoModule.listarHorarioTrabajoPorMedico(medicoId);

                // Lógica para cargar los horarios en el dropdown ddlHorarioTrabajo
                ddlHorarioTrabajo.DataSource = horarios;
                ddlHorarioTrabajo.DataValueField = "Id";
                ddlHorarioTrabajo.DataTextField = "FechaYHora";
                ddlHorarioTrabajo.DataBind();

                // Agregar un elemento vacío para selección inicial
                ddlHorarioTrabajo.Items.Insert(0, new ListItem("-- Seleccionar Hora --", "0"));
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
            try
            {
                EspecialidadModule especialidadModule = new EspecialidadModule(new AccesoDatos());
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
            EnviarEmailModule enviarEmailModule = new EnviarEmailModule();
            enviarEmailModule.ArmarCorreo("fernandopalacios51@gmail.com","Esto es una prueba piloto","Hola que tal...");

            try
            {
                enviarEmailModule.EnviarEmail();

            }
            catch (Exception ex)
            {

                Session.Add("Error al Enviar E-mail",ex);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
           
                IAccesoDatos accesoDatos = new AccesoDatos();
            
        }
    }
}