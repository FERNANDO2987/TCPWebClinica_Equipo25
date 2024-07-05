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
    public partial class NuevoAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            IAccesoDatos accesoDatos = new AccesoDatos();
            AdministradorModule moduleAdmin = new AdministradorModule(accesoDatos);

            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"].ToString());
                Administrador admin = moduleAdmin.listarAdministrador().Find(x => x.Id == id);

                txtLegajo.Text = admin.Id.ToString();
                txtNombre.Text = admin.Nombre;
                txtApellido.Text = admin.Apellido;
                txtEmail.Text = admin.Email;

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
                AdministradorModule moduleAdmin = new AdministradorModule(accesoDatos);

                Administrador admin = new Administrador();
                admin.Id = int.Parse(txtLegajo.Text);
                admin.Nombre = txtNombre.Text;
                admin.Apellido = txtApellido.Text;
                admin.Email = txtEmail.Text;


                moduleAdmin.agregaAdministrador(admin);
                Response.Redirect("Administradores.aspx");

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
                AdministradorModule moduleAdmin = new AdministradorModule(accesoDatos);
                int id = int.Parse(Request.QueryString["id"].ToString());
                moduleAdmin.eliminarAdministrador(id);
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
                AdministradorModule moduleAdmin = new AdministradorModule(accesoDatos);

                Administrador admin = new Administrador();
                admin.Nombre = txtNombre.Text;
                admin.Apellido = txtApellido.Text;
                admin.Id = int.Parse(txtLegajo.Text);
                admin.Email = txtEmail.Text;

                moduleAdmin.modificarAdministrador(admin);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}