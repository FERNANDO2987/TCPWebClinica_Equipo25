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
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            PacienteModule module = new PacienteModule(accesoDatos);
            dgvPacientes.DataSource = module.listarPacientes();
            dgvPacientes.DataBind();
        }

        protected void dgvPcaientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dgvPacientes.SelectedDataKey.Value.ToString());
            Response.Redirect("NuevoPaciente.aspx?id=" + id);
        }
    }
}