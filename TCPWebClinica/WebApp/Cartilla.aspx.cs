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
    public partial class Cartilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            MedicoModule module = new MedicoModule(accesoDatos);
            dgvMedicos.DataSource = module.listarMedicos();
            dgvMedicos.DataBind();
        }
        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvMedicos.SelectedDataKey.Value.ToString());
            Response.Redirect("CargarMedicos.aspx?id=" + id);
        }
    }
}