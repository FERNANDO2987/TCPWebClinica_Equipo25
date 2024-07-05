using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Modules;

namespace WebApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SeguridadModule.sesionActiva(Session["Usuario"]))
            {
                btnCerrarSesion.Visible = false;
            }
            if (!(Page is Login))
            {
                if (!SeguridadModule.sesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("Login.aspx", false);
        }
    }
}