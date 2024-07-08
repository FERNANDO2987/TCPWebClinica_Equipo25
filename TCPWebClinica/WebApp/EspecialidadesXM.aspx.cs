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
    public partial class EspecialidadesXM : System.Web.UI.Page
    {
        EspecialidadModule module = new EspecialidadModule(new AccesoDatos());
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
                    dgvEspecialidades.DataSource = module.listarEspecilidadPorMedico(idUrl);
                    dgvEspecialidades.DataBind();
                }
            }
        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(Request.QueryString["id"]);
            int id2 = int.Parse(dgvEspecialidades.SelectedDataKey.Value.ToString());
            
            Response.Redirect("NuevaEspecialidadXM.aspx?idmed=" + id + "&idesp=" + id2);

        }
    }
}