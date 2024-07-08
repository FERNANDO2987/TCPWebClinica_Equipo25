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
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }
            if(!(IsPostBack))
            {
                if (Request.QueryString["id"] != null)
                {
                    cargarModificar();
                }
            }
        }

        protected void cargarModificar()
        {
            Especialidad especialidad = new Especialidad();
            int idurl = int.Parse(Request.QueryString["id"]);
            especialidad = especialidadModule.listarEspecialidad().Find(x => x.Id == idurl);
            txtId.Text = especialidad.Id.ToString();
            txtNombre.Text = especialidad.Nombre;

            btnAgregar.Visible=false;
            btnEliminar.Visible=true;
            btnModificar.Visible=true;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad();
            especialidad.Nombre = txtNombre.Text;
            especialidadModule.agregarEspecialidad(especialidad);
            Response.Redirect("Especialidades.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad()
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
            };
            especialidadModule.agregarEspecialidad(especialidad);
            Response.Redirect("Especialidades.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idurl = int.Parse(Request.QueryString["id"]);
            especialidadModule.eliminarEspecilidad(idurl);
            Response.Redirect("Especialidades.aspx", false);

        }
    }
}
