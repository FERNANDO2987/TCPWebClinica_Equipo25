using Business;
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
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(SeguridadModule.esAdmin(Session["Usuario"])))
            {
                Response.Redirect("Turno.aspx", false);
                //Session.Add("error", "Solo los usuarios de tipo administrador pueden acceder al panel");
                //Response.Redirect("Error.aspx", false);
            }

        }



    }
}