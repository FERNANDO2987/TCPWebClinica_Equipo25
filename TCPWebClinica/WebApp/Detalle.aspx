<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Content/Style/StyleDetalle.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="ProductDetailsPanel" runat="server" Visible="false">
        <div class="container">
            <h1>Detalle del Articulo</h1>

        </div>
        <div class="container3">
            <h1>
                <asp:Label ID="lblNombre" runat="server" /></h1>
        </div>

        <div class="container2">



            <div id="imageContainer">
                <asp:Repeater ID="rptImages" runat="server">
                    <ItemTemplate>
                        <img src='<%# Container.DataItem %>' alt="Product Image" class="product-image" />
                    </ItemTemplate>


                </asp:Repeater>
                <p>
                    <span class="bold-text">Codigo:</span>
                    <asp:Label ID="lblCodigo" runat="server" />
                </p>
                <p>
                    <span class="bold-text">Precio:</span>
                    <asp:Label ID="lblPrecio" runat="server" />
                </p>
                <p>
                    <span class="bold-text">Descripción:</span>
                    <asp:Label ID="lblDescripcion" runat="server" />
                </p>
                <p>
                    <span class="bold-text">Marca:</span>
                    <asp:Label ID="lblMarca" runat="server" />
                </p>
                <p>
                    <span class="bold-text">Categoria:</span>
                    <asp:Label ID="lblCategoria" runat="server" />
                </p>


                <!-- Cambiamos el tipo de botones de "submit" a "button" -->
                <button type="button" id="btnPrev" onclick="showPrevImage()" class="btn btn-primary">Previous</button>
                <button type="button" id="btnNext" onclick="showNextImage()" class="btn btn-primary">Next</button>
            </div>
        </div>
    </asp:Panel>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" />

    <script src="Script/JavaScriptNavegacion.js"></script>
</asp:Content>
