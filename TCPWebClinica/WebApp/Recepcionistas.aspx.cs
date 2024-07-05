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
    public partial class Recepcionistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }

            IAccesoDatos accesoDatos = new AccesoDatos();
            RecepcionistaModule moduleRecepcionista = new RecepcionistaModule(accesoDatos);
            dgvRecepcionista.DataSource = moduleRecepcionista.listarRecepcionistas();
            dgvRecepcionista.DataBind();
        }

        protected void dgvRecepcionista_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvRecepcionista.SelectedDataKey.Value.ToString());
            Response.Redirect("NuevoRecepcionista.aspx?" + id);
        }
    }
}