<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Usuarios</h3>
    <a class="btn btn-primary" href="NuevoUsuario.aspx">Agregar</a>

    <asp:GridView ID="dgvUsuarios" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" CssClass="table" DataKeyNames="Id" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id"/>
            <asp:BoundField HeaderText="Nombre Usuario" DataField="Nombre"/>
            <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
