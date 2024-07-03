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
    public partial class NuevaEspecialidad : System.Web.UI.Page
    {
        EspecialidadModule especialidadModule = new EspecialidadModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad();
            especialidad.Nombre = txtNombre.Text;
            especialidadModule.agregarEspecialidad(especialidad);
        }
    }
}