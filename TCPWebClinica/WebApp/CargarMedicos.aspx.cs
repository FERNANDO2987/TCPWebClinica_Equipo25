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
    public partial class CargarMedicos : System.Web.UI.Page
    {
        EspecialidadModule especialidadModule = new EspecialidadModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarHorarioEntrada(ddlHorarioEntrada);
                CargarHorarioSalida(ddlHorarioSalida);
                CargarEspecialidades(ddlEspecialidad);
            }
        }

        private void CargarEspecialidades(DropDownList ddlEspecialidad)
        {
            List<Especialidad> especialidades = especialidadModule.listarEspecialidad();

            foreach (var especialidad in especialidades)
            {
                ddlEspecialidad.Items.Add(new ListItem(especialidad.Nombre, especialidad.Nombre));
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoModule module = new MedicoModule(new AccesoDatos());
                int horarioEntrada = int.Parse(ddlHorarioEntrada.SelectedValue.Replace(":00hs", ""));
                int horarioSalida = int.Parse(ddlHorarioSalida.SelectedValue.Replace(":00hs", ""));

                Especialidad especialidad = new Especialidad()
                {
                    Nombre = ddlEspecialidad.SelectedValue,
                };

                HorarioDeTrabajo horarioDeTrabajo = new HorarioDeTrabajo()
                {
                    HoraEntrada = new DateTime(2024,1,1, horarioEntrada,0,0),
                    HoraSalida = new DateTime(2024, 1, 1, horarioSalida, 0, 0),
                };

                Medico medico = new Medico()
                {
                    Id = 4,
                    Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? string.Empty : txtApellido.Text,
                    Nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? string.Empty : txtNombre.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? string.Empty : txtEmail.Text,
                    Especialidades = new List<Especialidad>() { especialidad },
                    HorarioDeTrabajo = new List<HorarioDeTrabajo>() { horarioDeTrabajo },
                };

                module.agregarMedico(medico);

                Response.Redirect("Cartilla.aspx");
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void CargarHorarioEntrada(DropDownList horario)
        {
            for (int i = 7; i <= 22; i++)
            {
                var descripcion = $"{i.ToString()} :00hs";
                ListItem horariosParaCargar = new ListItem(descripcion, descripcion);
                horario.Items.Add(horariosParaCargar);
            }
        }

        private void CargarHorarioSalida(DropDownList horario)
        {
            for (int i = 7; i <= 22; i++)
            {
                var descripcion = $"{i.ToString()}:00hs";
                ListItem horariosParaCargar = new ListItem(descripcion, descripcion);
                horario.Items.Add(horariosParaCargar);
            }
        }
    }
}