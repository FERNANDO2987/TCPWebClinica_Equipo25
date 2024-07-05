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
    public partial class NuevoEstadoTurno : System.Web.UI.Page
    {
        EstadoTurnoModule module = new EstadoTurnoModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            EstadoTurno estadoTurno = new EstadoTurno();
            estadoTurno.Codigo = txtCodigo.Text;
            estadoTurno.Descripcion = txtDescripcion.Text;
            module.agregarEstadoTurno(estadoTurno);
            Response.Redirect("EstadoTurno.aspx", false);
        }
    }
}