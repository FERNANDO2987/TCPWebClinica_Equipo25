using Business;
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
    public partial class Productos : System.Web.UI.Page
    {
        /*  protected List<ListarArticulosEimagen> Imagenes { get; set; }*/

        // Crear una instancia de AccesoDatos 
        IAccesoDatos accesoDatos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {


            EspecialidadModule especialidadModule = new EspecialidadModule(accesoDatos);
            especialidadModule.listarEspecialidad();

            var especialidad = new Especialidad()
            {
           
                Nombre = "UCO 2"

            };

            var result = especialidadModule.agregarEspecialidad(especialidad);

            UsuariosModule usuariosModule = new UsuariosModule(accesoDatos);



            /*
                        var usuario = new Usuario
                        {
                            Id = 0, 
                            Nombre = "TestUser", 
                            Contraseña = "Test",
                            Email = "a",
                            Rol = new Rol
                           {
                               Id = 3
                           }
                        };
                        var resultUsuario = usuariosModule.agregarUsuario(usuario);*/
            /*
                        var listar = usuariosModule.listarUsuarios();

                        var r = listar;*/


/*
            var result2 = usuariosModule.eliminarUsuario(1);

            var r = result2;*/

              RolModule rolModule = new RolModule(accesoDatos);

            var r = rolModule.ObtenerRolPorId(3);

            var m = r;

        }





    }
}