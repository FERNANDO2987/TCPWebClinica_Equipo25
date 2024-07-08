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
    public partial class NuevoHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarHorarioEntrada(ddlHorarioEntrada);
            CargarHorarioSalida(ddlHorarioSalida);
        }

        private void CargarHorarioEntrada(DropDownList horario)
        {
            for (int i = 7; i <= 22; i++)
            {
                var descripcion = $"{i.ToString()} :00";
                ListItem horariosParaCargar = new ListItem(descripcion, descripcion);
                horario.Items.Add(horariosParaCargar);
            }
        }

        private void CargarHorarioSalida(DropDownList horario)
        {
            for (int i = 7; i <= 22; i++)
            {
                var descripcion = $"{i.ToString()}:00";
                ListItem horariosParaCargar = new ListItem(descripcion, descripcion);
                horario.Items.Add(horariosParaCargar);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HorarioTrabajoModule module = new HorarioTrabajoModule(new AccesoDatos());
            HorarioDeTrabajo horarioDeTrabajo = new HorarioDeTrabajo()
            {
                IdMedico = int.Parse(Request.QueryString["id"]),
                HoraEntrada = DateTime.Parse(ddlHorarioEntrada.SelectedValue),
                HoraSalida = DateTime.Parse(ddlHorarioSalida.SelectedValue),
            };
            module.agregarHorarioTrabajo(horarioDeTrabajo);
        }
    }
}