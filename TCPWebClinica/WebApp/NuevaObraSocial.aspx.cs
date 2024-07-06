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
    public partial class NuevaObraSocial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            IAccesoDatos accesoDatos = new AccesoDatos();
            ObraSocialModule moduleObraSocial = new ObraSocialModule(accesoDatos);
            
            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"].ToString());
                ObraSocial os = moduleObraSocial.listarObraSociales().Find(x => x.Id == id);

                txtId.Text = os.Id.ToString();
                txtNombre.Text = os.Nombre;
                txtDescripcion.Text = os.Descripcion;
                txtDireccion.Text = os.Direccion;  
                txtEmail.Text = os.Email;
                txtTelefono.Text = os.Telefono;
                txtWebsite.Text = os.Website;

            }
            else
            {
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                IAccesoDatos accesoDatos = new AccesoDatos();   
                ObraSocialModule moduleObraSocial = new ObraSocialModule(accesoDatos);

                ObraSocial os = new ObraSocial();
                os.Nombre = txtNombre.Text;
                os.Descripcion = txtDescripcion.Text;
                os.Direccion = txtDireccion.Text;
                os.Email = txtEmail.Text;
                os.Telefono = txtTelefono.Text;
                os.Website = txtWebsite.Text;

                moduleObraSocial.agregarObraSocial(os);
                Response.Redirect("ObrasSociales.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      
    }
}