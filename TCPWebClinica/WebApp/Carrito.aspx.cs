using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApp
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (!IsPostBack)
            {
                // Verifica si hay parámetros en la URL
                if (Request.QueryString["id"] != null && Request.QueryString["nombre"] != null &&
                    Request.QueryString["precio"] != null && Request.QueryString["imagenURL"] != null)
                {
                    // Obtiene los parámetros de la URL
                    string id = Request.QueryString["id"];
                    string nombre = Request.QueryString["nombre"];
                    string precio = Request.QueryString["precio"];
                    string imagenURL = Request.QueryString["imagenURL"];

                    // Crea un nuevo artículo
                    Articulo nuevoArticulo = new Articulo
                    {
                        Id = id,
                        Nombre = nombre,
                        Precio = decimal.Parse(precio),
                        ImagenURL = imagenURL,
                        Cantidad = 1,
                        Subtotal = decimal.Parse(precio)
                    };

                    // Obtiene la lista del carrito de la sesión
                    List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

                    // Si la lista del carrito es nula, inicialízala
                    if (carrito == null)
                    {
                        carrito = new List<Articulo>();
                    }

                    // Agrega el nuevo artículo al carrito
                    carrito.Add(nuevoArticulo);

                    // Guarda la lista actualizada en la sesión
                    Session["Carrito"] = carrito;
                }

                // Carga los artículos del carrito en el Repeater
                CargarCarrito();
                ActualizarTotal();
            }*/
        }

 /*       private void CargarCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            if (carrito != null && carrito.Count > 0)
            {
                CarritoRepeater.DataSource = carrito;
                CarritoRepeater.DataBind();
            }
            else
            {
                CarritoRepeater.DataSource = null;
                CarritoRepeater.DataBind();
            }
        }

        private void ActualizarTotal()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            if (carrito != null && carrito.Count > 0)
            {
                decimal total = carrito.Sum(a => a.Subtotal);
                lblTotal.Text = total.ToString("0.00");
            }
            else
            {
                lblTotal.Text = "0";
            }
        }

        protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)ddl.NamingContainer;
            string id = (item.FindControl("btnEliminar") as Button).CommandArgument;
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito != null)
            {
                Articulo articulo = carrito.FirstOrDefault(a => a.Id == id);
                if (articulo != null)
                {
                    articulo.Cantidad = int.Parse(ddl.SelectedValue);
                    articulo.Subtotal = articulo.Cantidad * articulo.Precio;
                    Session["Carrito"] = carrito;
                    CargarCarrito();
                    ActualizarTotal();
                }
            }
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            if (carrito != null)
            {
                var articuloAEliminar = carrito.FirstOrDefault(a => a.Id == id);
                if (articuloAEliminar != null)
                {
                    carrito.Remove(articuloAEliminar);
                    Session["Carrito"] = carrito;
                    CargarCarrito();
                    ActualizarTotal();
                }
            }
        }

        protected void CarritoRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Articulo articulo = (Articulo)e.Item.DataItem;
                DropDownList ddlCantidad = (DropDownList)e.Item.FindControl("ddlCantidad");

                // Rellenar DropDownList con cantidades
                for (int i = 1; i <= 10; i++)
                {
                    ddlCantidad.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                // Establecer la cantidad seleccionada
                ddlCantidad.SelectedValue = articulo.Cantidad.ToString();
            }
        }*/
    }




}

