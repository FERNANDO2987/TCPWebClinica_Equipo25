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

            if(!IsPostBack)
            {
                
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
            usuario.Rol.Id = int.Parse(txtRolId.Text);

            usuario.Rol = new Rol();
            Rol rol = (Rol) rolModule.listarRoles().Where(x => x.Id == usuario.Rol.Id);
            usuario.Rol.Descripcion = rol.Descripcion;

            usuariosModule.agregarUsuario(usuario);
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}