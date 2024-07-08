using Business.AccesoSQL;
using Business.Interfaces;
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
    public partial class AgregarObservacion : System.Web.UI.Page
    {
        TurnoModule module = new TurnoModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEstado(ddlEstadoTurno);
                if (Request.QueryString["id"] != null)
                {
                    txtId.Text = Request.QueryString["id"];

                }
            }
        }

        private void CargarEstado(DropDownList ddlEstadoTurno)
        {
            EstadoTurnoModule estadoTurnoModule = new EstadoTurnoModule(new AccesoDatos());
            List<EstadoTurno> estadoTurnos = estadoTurnoModule.listarEstadosTurno();

            ddlEstadoTurno.DataSource = estadoTurnos;
            ddlEstadoTurno.DataValueField = "Id";
            ddlEstadoTurno.DataTextField = "Descripcion";
            ddlEstadoTurno.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idurl = int.Parse(Request.QueryString["id"]);
            Business.Models.Turno turno = new Business.Models.Turno();
            turno = (Business.Models.Turno) module.listarTurnos().FirstOrDefault(x => x.Id == idurl);

            turno.Observaciones = txtObservaciones.Text;
            EstadoTurno estado = new EstadoTurno() { Id = int.Parse(ddlEstadoTurno.SelectedValue) };
            turno.Estado = estado;

            module.agregarTurno(turno);
            Response.Redirect("TurnosAsignados.aspx", false);
        }
    }
}