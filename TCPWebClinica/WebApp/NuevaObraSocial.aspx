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
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="Id" placeholder="Id" ReadOnly="true"  runat="server" />
                    <label for="Id">ID </label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="nombre" placeholder="Nombre" required="true" runat="server" />
                    <label for="nombre">Nombre *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="Descripcion" placeholder="Descripcion" required="true" runat="server" />
                    <label for="Descripcion">Descripcion *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" class="form-control" ID="Direccion" placeholder="Direccion" required="true" runat="server" />
                    <label for="Direccion">Direccion *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="tel" CssClass="form-control" ID="telefono" placeholder="Telefono" runat="server" />
                    <label for="telefono">Telefono *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" ID="email" placeholder="name@example.com" CssClass="form-control" runat="server" />
                    <label for="email">Email *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="Website" placeholder="NameExample.com" runat="server" />
                    <label for="direccion">Sitio Web *</label>
                </div>
            </div>
           
        </div>
        <div id="agregar" class="col-3" style="display: flex; justify-content: space-between; width: 100%; margin-top: 2em;">
            <p>(*) Campos obligatorios</p>
            <%--<asp:Button Text="Agregar" CssClass="btn btn-outline-success" ID="Agregar" OnClick="btnAgregar_Click" runat="server" />--%>
        </div>


    </div>
</asp:Content>
