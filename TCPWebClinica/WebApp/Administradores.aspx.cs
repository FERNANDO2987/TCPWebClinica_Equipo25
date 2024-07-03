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
    public partial class Administradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            AdministradorModule moduleAdmin = new AdministradorModule(accesoDatos);
            dgvAdmin.DataSource = moduleAdmin.listarAdministrador();
            dgvAdmin.DataBind();
        }

        protected void dgvAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvAdmin.SelectedDataKey.Value.ToString());
            Response.Redirect("NuevoAdministrador.aspx?" + id);
        }
    }
}