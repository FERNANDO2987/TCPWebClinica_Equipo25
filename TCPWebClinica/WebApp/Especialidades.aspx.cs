using Business.AccesoSQL;
using Business.Interfaces;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Especialidades : System.Web.UI.Page
    {
        EspecialidadModule especialidadModule= new EspecialidadModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            if (!IsPostBack)
            {
                dgvEspecialidades.DataSource = especialidadModule.listarEspecialidad();
                dgvEspecialidades.DataBind();
            }
        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvEspecialidades.SelectedDataKey.Value.ToString());
            especialidadModule.eliminarEspecilidad(id);
            Response.Redirect("Especialidades.aspx", false);
        }
    }
}