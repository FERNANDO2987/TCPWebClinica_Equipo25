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
    public partial class ObrasSociales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }


            IAccesoDatos accesoDatos = new AccesoDatos();
            ObraSocialModule moduleObraSocial = new ObraSocialModule(accesoDatos);
            dgvObraSocial.DataSource = moduleObraSocial.listarObraSociales();
            dgvObraSocial.DataBind();
        }
        protected void dgvObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvObraSocial.SelectedDataKey.Value.ToString());
            Response.Redirect("NuevaObraSocial.aspx?id=" + id);
        }
    }
}