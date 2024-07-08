<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarObservacion.aspx.cs" Inherits="WebApp.AgregarObservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em; margin-left: 2em;">
        <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em;">
            <asp:Label ID="Titulo" cssclass="h3" runat="server" Text="Modificar Turno"></asp:Label>
        </div>
        <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left:2em; ">
            <div class="col-1" id="columna1" style="width: 45%;">
                <p style="color:red;">(*) Campos obligatorios</p>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtId" placeholder="IdTurno" ReadOnly="true"  runat="server" />
                    <label for="Id">ID Turno </label>
                </div>
                <div class="mb-3">
                    <asp:DropDownList ID="ddlEstadoTurno" runat="server" class="form-select" aria-label="Default select example" required="true">
                        <asp:ListItem Text="Estado *" />
                    </asp:DropDownList>
                </div>
                
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtObservaciones" TextMode="MultiLine" placeholder="Observaciones" required="true" runat="server" />
                    <label for="nombre">Observaciones *</label>
                </div>
                <div class="ps-2" margin-top: 2em;">
                    <asp:Button Text="Agregar" CssClass="btn btn-outline-primary m-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
