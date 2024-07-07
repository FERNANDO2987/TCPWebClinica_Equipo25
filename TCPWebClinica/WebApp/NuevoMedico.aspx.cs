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
    public partial class NuevoMedico : System.Web.UI.Page
    {
        EspecialidadModule especialidadModule = new EspecialidadModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    SetupModificar();
                    
                }
                CargarHorarioEntrada(ddlHorarioEntrada);
                CargarHorarioSalida(ddlHorarioSalida);
                CargarEspecialidades(ddlEspecialidad);
            }
        }
        private void SetupModificar()
        {
            MedicoModule module = new MedicoModule(new AccesoDatos());
            int idUrl = int.Parse(Request.QueryString["id"]);
            Medico medico = new Medico();
            medico = module.listarMedicos().Find(x => x.Id == idUrl);

            lblTitulo.Text = "Modificar medico";
            txtContraseña.Visible = false;
            lblContraseña.Visible = false;
            txtNombreUsuario.Visible = false;
            lblNombreUsuario.Visible = false;
            ddlHorarioEntrada.Visible = false;
            lblHorarioEntrada.Visible = false;
            ddlHorarioSalida.Visible = false;
            lblHorarioSalida.Visible = false;
            ddlEspecialidad.Visible = false;
            Agregar.Visible = false;
            btnEspecialidades.Visible = true;
            btnHorarios.Visible = true;
            btnEliminar.Visible = true;
            btnModificar.Visible = true;
            txtEmail.ReadOnly = true;

            txtId.Text = idUrl.ToString();
            txtNombre.Text = medico.Nombre;
            txtApellido.Text = medico.Apellido;
            txtEmail.Text = medico.Email;
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
                UsuariosModule usuariosModule = new UsuariosModule(new AccesoDatos());
                int horarioEntrada = int.Parse(ddlHorarioEntrada.SelectedValue.Replace(":00hs", ""));
                int horarioSalida = int.Parse(ddlHorarioSalida.SelectedValue.Replace(":00hs", ""));

                Usuario usuario = new Usuario()
                {
                    Nombre = txtNombreUsuario.Text,
                    Contraseña = txtContraseña.Text,
                    Email = txtEmail.Text,
                    Rol = new Rol() { Id = 3, Descripcion = "Medico" }
                };
                //usuariosModule.agregarUsuario(usuario);

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
                    //Id = 4,
                    Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? string.Empty : txtApellido.Text,
                    Nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? string.Empty : txtNombre.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? string.Empty : txtEmail.Text,
                    Especialidades = new List<Especialidad>() { especialidad },
                    HorarioDeTrabajo = new List<HorarioDeTrabajo>() { horarioDeTrabajo },
                };

                //module.agregarMedico(medico);
                module.agregarUsuarioyMedico(usuario, medico);

                Response.Redirect("Medicos.aspx");
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