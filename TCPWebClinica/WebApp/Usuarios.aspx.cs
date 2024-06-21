﻿using Business.AccesoSQL;
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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccesoDatos accesoDatos = new AccesoDatos();
            UsuariosModule moduloUsuarios = new UsuariosModule(accesoDatos);
            if (!IsPostBack)
            {
                dgvUsuarios.DataSource = moduloUsuarios.listarUsuarios(); 
                dgvUsuarios.DataBind();

            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}