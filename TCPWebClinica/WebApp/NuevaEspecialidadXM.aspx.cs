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
    public partial class NuevaEspecialidadXM : System.Web.UI.Page
    {
        EspecialidadModule especialidadModule = new EspecialidadModule(new AccesoDatos());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
            }
            if (!(IsPostBack))
            {
                if (Request.QueryString["idmed"] != null)
                {
                    cargarModificar();
                }
            }
        }

        protected void cargarModificar()
        {
            Especialidad especialidad = new Especialidad();
            int idMed = int.Parse(Request.QueryString["idmed"]);
            int idEsp = int.Parse(Request.QueryString["idesp"]);
            especialidad = especialidadModule.listarEspecilidadPorMedico(idMed).Find(x => x.Id == idEsp);
            txtId.Text = especialidad.Id.ToString();
            txtNombre.Text = especialidad.Nombre;

            btnAgregar.Visible = false;
            btnEliminar.Visible = true;

        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMed = int.Parse(Request.QueryString["idmed"]);
            int idEsp = int.Parse(Request.QueryString["idesp"]);
            especialidadModule.eliminarEspecialidadXM(idMed, idEsp);
            Response.Redirect("Medicos.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}