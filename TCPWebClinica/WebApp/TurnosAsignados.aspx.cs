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
    public partial class TurnosAsignados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            TurnoModule turnoModule = new TurnoModule(accesoDatos);
            Usuario usu = (Usuario)Session["Usuario"];
            //List<TurnoConPaciente> turnos = turnoModule.listarTurnosConPacientes().FindAll(x => x.IdMedico == usu.Id);

            dgvTurnosAsignados.DataSource = turnoModule.listarTurnosConPacientes().FindAll(x => x.IdMedico == usu.Id); 
            dgvTurnosAsignados.DataBind();
        }

        protected void dgvTurnosAsignados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvTurnosAsignados.SelectedDataKey.Value.ToString());
            Response.Redirect("AgregarObservacion.aspx?id=" + id, false);
        }
    }
}