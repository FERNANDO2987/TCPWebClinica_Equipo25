<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaEspecialidadXM.aspx.cs" Inherits="WebApp.NuevaEspecialidadXM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">+
    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em; margin-left: 2em;">
        <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em;">
            <asp:Label ID="Titulo" cssclass="h3" runat="server" Text="Agregar Especialidad"></asp:Label>
        </div>
        <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left:2em; ">
            <div class="col-1" id="columna1" style="width: 45%;">
                <p style="color:red;">(*) Campos obligatorios</p>
            <div class="form-floating mb-3">
                <asp:TextBox type="text" CssClass="form-control" ID="txtId" placeholder="Id" ReadOnly="true"  runat="server" />
                <label for="Id">ID del medico </label>
            </div>
            <div id="especialidad-ls" style="padding-top: 20px;">
                <asp:DropDownList ID="ddlEspecialidad" runat="server" class="form-select" aria-label="Default select example" required="true">
                    <asp:ListItem Text="Especialidad *" />
                </asp:DropDownList>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox type="text" CssClass="form-control" ID="txtNombre" placeholder="Nombre" ReadOnly="true" required="true" runat="server" />
                <label for="nombre">Nombre *</label>
            </div>
                <div class="ps-2" margin-top: 2em;">
                    <asp:Button Text="Agregar" CssClass="btn btn-outline-primary m-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
                    <asp:Button Visible="false" Text="Eliminar" CssClass="btn btn-outline-danger m-1" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
