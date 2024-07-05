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
    public partial class NuevoRecepcionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            IAccesoDatos accesoDatos = new AccesoDatos();
            RecepcionistaModule moduleRecepcionista = new RecepcionistaModule(accesoDatos);

            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"].ToString());
                Recepcionista recepcionista = moduleRecepcionista.listarRecepcionistas().Find(x => x.Id == id);

                txtLegajo.Text = recepcionista.Id.ToString();
                txtNombre.Text = recepcionista.Nombre;
                txtApellido.Text = recepcionista.Apellido;
                txtEmail.Text = recepcionista.Email;

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
                RecepcionistaModule moduleRecepcionista = new RecepcionistaModule(accesoDatos);

                Recepcionista recepcionista = new Recepcionista();
                recepcionista.Id = int.Parse(txtLegajo.Text);
                recepcionista.Nombre = txtNombre.Text;
                recepcionista.Apellido = txtApellido.Text;
                recepcionista.Email = txtEmail.Text;


                moduleRecepcionista.agregaRecepcionista(recepcionista);
                Response.Redirect("Recepcionistas.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IAccesoDatos accesoDatos = new AccesoDatos();
                RecepcionistaModule moduleRecepcionista = new RecepcionistaModule(accesoDatos);
                int id = int.Parse(Request.QueryString["id"].ToString());
                moduleRecepcionista.eliminarRecepcionista(id);
                Response.Redirect("Recepcionistas.aspx");

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
                RecepcionistaModule moduleRecepcionista = new RecepcionistaModule(accesoDatos);

                Recepcionista recepcionista = new Recepcionista();
                recepcionista.Nombre = txtNombre.Text;
                recepcionista.Apellido = txtApellido.Text;
                recepcionista.Id = int.Parse(txtLegajo.Text);
                recepcionista.Email = txtEmail.Text;
                
                moduleRecepcionista.modificarRecepcionista(recepcionista);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}