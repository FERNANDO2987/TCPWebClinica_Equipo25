<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar> 

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaObraSocial.aspx.cs" Inherits="WebApp.NuevaObraSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em; margin-left:2em;">

        <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em;">
            <h3>Alta Obra Social</h3>
        </div>

        <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left:2em; ">

            <div class="col-1" id="columna1" style="width: 45%;">
            <p class="color:red;">(*) Campos obligatorios</p>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtId" placeholder="Id" ReadOnly="true"  runat="server" />
                    <label for="Id">ID </label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtNombre" placeholder="Nombre" required="true" runat="server" />
                    <label for="nombre">Nombre *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtDescripcion" placeholder="Descripcion" required="true" runat="server" />
                    <label for="Descripcion">Descripcion *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" class="form-control" ID="txtDireccion" placeholder="Direccion" required="true" runat="server" />
                    <label for="Direccion">Direccion *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="tel" CssClass="form-control" ID="txtTelefono" placeholder="Telefono" runat="server" />
                    <label for="telefono">Telefono *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" ID="txtEmail" placeholder="name@example.com" CssClass="form-control" runat="server" />
                    <label for="email">Email *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtWebsite" placeholder="NameExample.com" runat="server" />
                    <label for="direccion">Sitio Web *</label>
                </div>
            </div>
           
        </div>


    </div>
        <div class="ps-5" margin-top: 2em;">
            <asp:Button Text="Agregar" CssClass="btn btn-outline-primary m-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
            <asp:Button Text="Modificar" CssClass="btn btn-outline-success m-1" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
            <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger m-1" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
        </div>
</asp:Content>
