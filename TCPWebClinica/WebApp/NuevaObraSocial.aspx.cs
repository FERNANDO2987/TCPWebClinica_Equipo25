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
            
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                IAccesoDatos accesoDatos = new AccesoDatos();
                ObraSocialModule moduleObraSocial = new ObraSocialModule(accesoDatos);
                ObraSocial os = moduleObraSocial.listarObraSociales().Find(x => x.Id == id);

                txtId.Text = os.Id.ToString();
                txtNombre.Text = os.Nombre;
                txtDescripcion.Text = os.Descripcion;
                txtDireccion.Text = os.Direccion;  
                txtEmail.Text = os.Email;
                txtTelefono.Text = os.Telefono;
                txtWebsite.Text = os.Website; 

            }
        }
    }
}