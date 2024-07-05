using Business.AccesoSQL;
using Business.Interfaces;
using Business.Models;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class NuevoPaciente : System.Web.UI.Page
    {
        ObraSocialModule obrasocialmodule = new ObraSocialModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            DateTime hoy = DateTime.Today;

            if (!Page.IsPostBack)
            {
                CargarObrasSociales(ddlObraSocial);

                if (fecha.Text == hoy.ToString("yyyy-MM-dd"))
                {
                    fecha.BorderColor = System.Drawing.Color.Red;
                }

            }
            IAccesoDatos accesoDatos = new AccesoDatos();
            PacienteModule pacienteModule = new PacienteModule(accesoDatos);

            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"].ToString());
                Paciente paciente = pacienteModule.listarPacientes().Find(x => x.Id == id);
                DateTime fechan = paciente.FechaNacimiento;
                txtApellido.Text = paciente.Apellido;
                txtNombre.Text = paciente.Nombre;
                txtDni.Text = paciente.Documento.ToString();
                txtTelefono.Text = paciente.Celular;
                txtEmail.Text = paciente.Email;
                ddlObraSocial.SelectedValue = paciente.Id.ToString();
                fecha.Text = fechan.ToString("yyyy-MM-dd");
                if (paciente.Sexo == "f" || paciente.Sexo == "F")
                {
                    rbtnF.Selected = true;
                }
                if (paciente.Sexo == "m" || paciente.Sexo == "M")
                {
                    rbtnM.Selected = true;
                }
                if (paciente.Sexo == "x" || paciente.Sexo == "X")
                {
                    rbtnX.Selected = true;
                }
            }
            else
            {
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
            }
        }
        private void CargarObrasSociales(DropDownList ddlObraSocial)
        {
            List<ObraSocial> obrassociales = obrasocialmodule.listarObraSociales();

            ddlObraSocial.DataSource = obrassociales;
            ddlObraSocial.DataValueField = "Id";
            ddlObraSocial.DataTextField = "Nombre";
            ddlObraSocial.DataBind();

        }

        protected void fecha_TextChanged(object sender, EventArgs e)
        {


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteModule module = new PacienteModule(new AccesoDatos());

                Paciente paciente = new Paciente();

                paciente.Apellido = txtApellido.Text;
                paciente.Nombre = txtNombre.Text;
                paciente.FechaNacimiento = DateTime.Parse(fecha.Text);
                paciente.Documento = int.Parse(txtDni.Text);
                paciente.Email = txtEmail.Text;
                paciente.Celular = txtTelefono.Text;
                paciente.Sexo = ObtenerSexo();
                paciente.ObraSocial = new ObraSocial();
                paciente.ObraSocial.Id = int.Parse(ddlObraSocial.SelectedValue);

                module.agregarPaciente(paciente);

                Response.Redirect("Pacientes.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string ObtenerSexo()
        {
            if (rbtnM.Selected)
            {
                return rbtnM.Value;

            }
            if (rbtnF.Selected)
            {
                return rbtnF.Value;

            }
            if (rbtnX.Selected)
            {
                return rbtnX.Value;
            }

            return string.Empty;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IAccesoDatos accesoDatos = new AccesoDatos();
                PacienteModule pacienteModule = new PacienteModule(accesoDatos);
                int id = int.Parse(Request.QueryString["id"].ToString());
                pacienteModule.eliminarPaciente(id);
                Response.Redirect("Pacientes.aspx");

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
                IAccesoDatos accesoDatos = new AccesoDatos();
                PacienteModule pacienteModule = new PacienteModule(accesoDatos);

                Paciente paciente = new Paciente();
                paciente.Apellido = txtApellido.Text;
                paciente.Nombre = txtNombre.Text;
                paciente.FechaNacimiento = DateTime.Parse(fecha.Text);
                paciente.Documento = int.Parse(txtDni.Text);
                paciente.Email = txtEmail.Text;
                paciente.Celular = txtTelefono.Text;
                paciente.Sexo = ObtenerSexo();
                paciente.ObraSocial = new ObraSocial();
                paciente.ObraSocial.Id = int.Parse(ddlObraSocial.SelectedValue);

                pacienteModule.modificarPaciente(paciente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}