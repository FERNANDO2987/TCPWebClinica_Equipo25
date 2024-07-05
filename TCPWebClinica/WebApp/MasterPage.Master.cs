using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!(Page is Login))
            {
                if (!SeguridadModule.sesionActiva(Session["Usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

        }
    }
}