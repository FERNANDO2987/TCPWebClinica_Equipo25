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
    public partial class GestionHorariosMedicos : System.Web.UI.Page
    {
        IAccesoDatos accesoDatos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
        }

        /*  protected void btnBuscar_Click(object sender, EventArgs e)
          {
              // Obtener el texto ingresado para buscar por apellido
              string apellidoBusqueda = txtBusqueda.Text.Trim();

              // Instanciar el módulo de médicos utilizando el acceso a datos
              MedicoModule medicoModule = new MedicoModule(accesoDatos);

              // Obtener la lista de médicos filtrada por apellido
              List<Medico> medicosEncontrados = medicoModule.listarMedicos().Where(m => m.Apellido.ToLower().Contains(apellidoBusqueda.ToLower())).ToList();

              // Asignar los resultados al GridView para mostrarlos en la interfaz
              gvMedicos.DataSource = medicosEncontrados;
              gvMedicos.DataBind();
          }*/

        protected void txtBuscarMedico_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarMedico_Click(object sender, EventArgs e)
        {

        }
    }
}