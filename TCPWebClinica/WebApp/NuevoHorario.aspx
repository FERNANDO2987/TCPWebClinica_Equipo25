<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoHorario.aspx.cs" Inherits="WebApp.NuevoHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-3 ms-5 " >
        <h3>Agregar horario</h3>
        <hr />
        <div id="hora-he" style="padding-top: 20px;">
            <asp:Label ID="lblHorarioEntrada" for="ddlHorarioEntrada" runat="server" Text="Horario Entrada *"></asp:Label>
            <asp:DropDownList ID="ddlHorarioEntrada" runat="server" class="form-select" aria-label="Default select example" required="true">
                <asp:ListItem Text="Horario de entrada*" Enabled="false" />
            </asp:DropDownList>
        </div>
        <div id="hora-hs" style="padding-top: 20px;">
            <asp:Label ID="lblHorarioSalida" for="ddlHorarioSalida" runat="server" Text="Horario Salida *"></asp:Label>

            <asp:DropDownList ID="ddlHorarioSalida" runat="server" class="form-select" aria-label="Default select example" required="true">
                <asp:ListItem Text="Horario de salida *" Enabled="false" />
            </asp:DropDownList>
        </div>
        <br />
        <asp:Button ID="btnAgregar" cssclass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" Text="Agregar"/>
    </div>

    
</asp:Content>
