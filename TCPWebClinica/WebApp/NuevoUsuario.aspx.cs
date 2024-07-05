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
using System.Security.Policy;

namespace WebApp
{
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        RolModule rolModule = new RolModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }


            AccesoDatos accesoDatos = new AccesoDatos();
            UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);
            if(!IsPostBack)
            {
                CargarRoles(ddlRol);
                if (Request.QueryString["id"] != null)
                {
                    btnAgregar.Visible = false;
                    int idUrl = int.Parse(Request.QueryString["id"]);
                    Usuario usuario = new Usuario();

                    usuario =(Usuario) usuariosModule.listarUsuarios().FirstOrDefault(x => x.Id == idUrl); 
                    Rol rol = (Rol)rolModule.listarRoles().Find(x => x.Id == usuario.Rol.Id);

                    txtId.Text = Request.QueryString["id"];
                    txtNombre.Text = usuario.Nombre;
                    txtContraseña.Text = usuario.Contraseña;
                    txtEmail.Text = usuario.Email;
                    //txtRolId.Text = usuario.Rol.Id.ToString();
                    ddlRol.SelectedValue = rol.Id.ToString();
                }


            }

            if(!IsPostBack)
            {
                
            }

        }

        private void CargarRoles(DropDownList ddlRol)
        {
            List<Rol> roles = rolModule.listarRoles();

            ddlRol.DataSource = roles;
            ddlRol.DataValueField = "Id";
            ddlRol.DataTextField = "Descripcion";
            ddlRol.DataBind();

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
            usuario.Rol.Id = int.Parse(ddlRol.SelectedValue);
            //usuario.Rol.Id = int.Parse(txtRolId.Text);
            //Rol rol = (Rol) rolModule.listarRoles().Where(x => x.Id == usuario.Rol.Id);
            //usuario.Rol.Descripcion = rol.Descripcion;

            usuariosModule.agregarUsuario(usuario);
            Response.Redirect("Usuarios.aspx");


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);
                Usuario aux = new Usuario();     
                
                aux.Id = int.Parse(txtId.Text);
                aux.Nombre = txtNombre.Text;
                aux.Email = txtEmail.Text;
                aux.Contraseña = txtContraseña.Text;
                aux.Rol = new Rol();
                aux.Rol.Id = int.Parse(ddlRol.SelectedValue);
                //aux.Rol.Id = int.Parse(txtRolId.Text);

                usuariosModule.agregarUsuario(aux);
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