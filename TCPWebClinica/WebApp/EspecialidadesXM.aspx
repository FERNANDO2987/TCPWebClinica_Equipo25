<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EspecialidadesXM.aspx.cs" Inherits="WebApp.EspecialidadesXM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
    <div class="col"></div>
    <div class="col-6">

        <h3>Especialidades</h3>
        <asp:GridView ID="dgvEspecialidades" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Especialidad" DataField="Nombre" />
                <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAgregar" cssclass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>

    </div>
    <div class="col"></div>
</div>
</asp:Content>
