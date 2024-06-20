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
            DateTime hoy = DateTime.Today;

            if (!Page.IsPostBack)
            {
                CargarObrasSociales(ddlObraSocial);
               
                if (fecha.Text == hoy.ToString("yyyy-MM-dd"))
                {
                    fecha.BorderColor = System.Drawing.Color.Red;
                    //Response.Redirect("/Solicitar_Turno.aspx?ex=1");
                }

                if (Request.QueryString["ex"] != null)
                {
                    var ex = int.Parse(Request.QueryString["ex"]);
                    if (ex == 1)
                    {
                        fecha.BorderColor = System.Drawing.Color.Red;
                    }
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

            //foreach (var obrasocial in obrassociales)
            //{
            //    ddlObraSocial.Items.Add(new ListItem(obrasocial.Nombre, obrasocial.Nombre));
            //}
        }

        protected void fecha_TextChanged(object sender, EventArgs e)
        {
    

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteModule module = new PacienteModule(new AccesoDatos());

                //ObraSocial obraSocial = new ObraSocial()
                //{
                //    Nombre = ddlObraSocial.SelectedValue,
                //};

                Paciente paciente = new Paciente();
                paciente.Id = int.Parse(txtId.Text);
                paciente.Apellido = txtApellido.Text;
                paciente.Nombre = txtNombre.Text;
                paciente.FechaNacimeinto = DateTime.Parse(fecha.Text);
                paciente.Documento = txtDni.Text;
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
    }   
}