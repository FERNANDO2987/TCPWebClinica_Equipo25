using Business.AccesoSQL;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            Usuario usuario;
            UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);

            try
            {
                usuario = new Usuario();
                usuario.Nombre = txtNombreUsuario.Text;
                usuario.Contraseña = txtContraseña.Text;

                if (usuariosModule.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "nombre de usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}