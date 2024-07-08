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
    public partial class Horarios : System.Web.UI.Page
    {
        HorarioTrabajoModule module = new HorarioTrabajoModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int idUrl = int.Parse(Request.QueryString["id"]);
                    dgvHorarios.DataSource = module.listarHorarioTrabajoPorMedico(idUrl);
                    dgvHorarios.DataBind();
                
                }
            }
        }



        protected void dgvHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorarioTrabajoModule module = new HorarioTrabajoModule(new AccesoDatos());
            var id = int.Parse(dgvHorarios.SelectedDataKey.Value.ToString());
            module.eliminarHorarioTrabajo(id);
            Response.Redirect("Horarios.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idUrl = int.Parse(Request.QueryString["id"]);
            Response.Redirect("NuevoHorario.aspx?id=" + idUrl, false);
        }
    }
}