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
using System.Globalization;

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


                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    CargarPaciente(id);
                }


                IAccesoDatos accesoDatos = new AccesoDatos();
                PacienteModule pacienteModule = new PacienteModule(accesoDatos);

                if (Request.QueryString["id"] != null)
                {
                    btnAgregar.Visible = false;

                    int id = int.Parse(Request.QueryString["id"].ToString());
                    Paciente paciente = pacienteModule.listarPacientes().Find(x => x.Id == id);

                    //txtId.Text = paciente.Id.ToString();
                    DateTime fechan = paciente.FechaNacimiento;
                    txtApellido.Text = paciente.Apellido;
                    txtNombre.Text = paciente.Nombre;
                    txtDni.Text = paciente.Documento.ToString();
                    txtCelular.Text = paciente.Celular;
                    txtEmail.Text = paciente.Email;
                    //ddlObraSocial.SelectedValue = paciente.Id.ToString();
                    // Asigna el valor correcto a ddlObraSocial
                    if (ddlObraSocial.Items.FindByValue(paciente.ObraSocial.Id.ToString()) != null)
                    {
                        ddlObraSocial.SelectedValue = paciente.ObraSocial.Id.ToString();
                    }
                    else
                    {
                        // Maneja el caso en el que el valor no existe en la lista
                        ddlObraSocial.SelectedIndex = 0; // O selecciona un valor predeterminado
                    }


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
                IAccesoDatos accesoDatos = new AccesoDatos();
                PacienteModule module = new PacienteModule(accesoDatos);

                Paciente paciente = new Paciente();
                paciente.HistoriaClinica = int.Parse(txtDni.Text); ;
                paciente.Nombre = txtNombre.Text;
                paciente.Apellido = txtApellido.Text;
                paciente.Documento = int.Parse(txtDni.Text);
                paciente.FechaNacimiento = DateTime.Parse(fecha.Text);
                paciente.Celular = txtCelular.Text;
                paciente.Email = txtEmail.Text;
                paciente.Sexo = ObtenerSexo();

                paciente.ObraSocial = new ObraSocial();
                paciente.ObraSocial.Id = int.Parse(ddlObraSocial.SelectedValue);

                module.agregarPaciente(paciente);

            

                Response.Redirect("Pacientes.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
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
                Response.Redirect("Pacientes.aspx", false);
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
                IAccesoDatos accesoDatos = new AccesoDatos();
                PacienteModule pacienteModule = new PacienteModule(accesoDatos);

                Paciente p = new Paciente();
                p.Apellido = txtApellido.Text;
                p.Nombre = txtNombre.Text;
                p.FechaNacimiento = DateTime.Parse(fecha.Text);
                p.Documento = int.Parse(txtDni.Text);
                p.Email = txtEmail.Text;
                p.Celular = txtCelular.Text;
                p.Sexo = ObtenerSexo();
                p.ObraSocial = new ObraSocial { Id = int.Parse(ddlObraSocial.SelectedValue) };
                pacienteModule.agregarPaciente(p);

                Response.Redirect("Pacientes.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void CargarPaciente(int id)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            PacienteModule pacienteModule = new PacienteModule(accesoDatos);
            Paciente paciente = pacienteModule.listarPacientes().Find(x => x.Id == id);

            if (paciente != null)
            {
                txtApellido.Text = paciente.Apellido;
                txtNombre.Text = paciente.Nombre;
                txtDni.Text = paciente.Documento.ToString();
                txtCelular.Text = paciente.Celular;
                txtEmail.Text = paciente.Email;
                fecha.Text = paciente.FechaNacimiento.ToString("yyyy-MM-dd");
                ddlObraSocial.SelectedValue = paciente.ObraSocial.Id.ToString();

                if (paciente.Sexo == "f" || paciente.Sexo == "F")
                {
                    rbtnF.Selected = true;
                }
                else if (paciente.Sexo == "m" || paciente.Sexo == "M")
                {
                    rbtnM.Selected = true;
                }
                else if (paciente.Sexo == "x" || paciente.Sexo == "X")
                {
                    rbtnX.Selected = true;
                }

                btnAgregar.Visible = false;
            }
            else
            {
                throw new Exception("No se encontró el paciente especificado.");
            }
        }
    }
}