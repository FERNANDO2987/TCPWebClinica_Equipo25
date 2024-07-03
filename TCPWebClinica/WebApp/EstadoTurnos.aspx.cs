using Business.AccesoSQL;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class EstadoTurnos : System.Web.UI.Page
    {
        EstadoTurnoModule estadoTurnoModule = new EstadoTurnoModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvEstadoTurno.DataSource = estadoTurnoModule.listarEstadosTurno();
            dgvEstadoTurno.DataBind();
        }

        protected void dgvEstadoTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvEstadoTurno.SelectedDataKey.Value.ToString());
            estadoTurnoModule.eliminarEstadoTurno(id);
            Response.Redirect("EstadoTurnos.aspx", false);
        }
    }
}