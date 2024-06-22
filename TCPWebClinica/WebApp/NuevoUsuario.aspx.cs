using System;
using Business.AccesoSQL;
using Business.Interfaces;
using Business.Models;
using Business.Modules;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);
            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Usuario usuario = new Usuario();
                    int idUrl = int.Parse(Request.QueryString["id"]);
                    usuario =(Usuario) usuariosModule.listarUsuarios().FirstOrDefault(x => x.Id == idUrl); 
                    txtId.Text = Request.QueryString["id"];
                    txtNombre.Text = usuario.Nombre;
                    txtContraseña.Text = usuario.Contraseña;
                    txtEmail.Text = usuario.Email;
                    txtRolId.Text = usuario.Rol.Id.ToString();
                }


            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            RolModule rolModule = new RolModule(accesoDatos);
            UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);

            Usuario usuario = new Usuario();
            usuario.Nombre = txtNombre.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.Email = txtEmail.Text;

            usuario.Rol = new Rol();
            usuario.Rol.Id = int.Parse(txtRolId.Text);
            //Rol rol = (Rol) rolModule.listarRoles().Where(x => x.Id == usuario.Rol.Id);
            //usuario.Rol.Descripcion = rol.Descripcion;

            usuariosModule.agregarUsuario(usuario);
            Response.Redirect("Usuarios.aspx");


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);
                int idUrl = int.Parse(Request.QueryString["id"]);

                usuariosModule.eliminarUsuario(idUrl);
                Response.Redirect("Usuario.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}