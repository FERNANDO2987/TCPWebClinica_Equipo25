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
    public partial class Turno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            TurnoModule turnoModule = new TurnoModule(accesoDatos);
            dgvTurnos.DataSource = turnoModule.listarTurnos();
            dgvTurnos.DataBind();
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvTurnos.SelectedDataKey.Value.ToString());
            Response.Redirect("NuevoTurno.aspx?id=" + id);
        }
    }
}