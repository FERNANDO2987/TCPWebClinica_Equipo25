<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="WebApp.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
    <div class="col"></div>
    <div class="col-6">

        <h3>Especialidades</h3>
        <asp:GridView ID="dgvEspecialidades" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged" DataKeyNames="Id" cssclass="table" autogeneratecolumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id"/>
                <asp:BoundField HeaderText="Especialidad" DataField="Nombre"/>
                <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm"/>
            </Columns>
        </asp:GridView>
        <a class="btn btn-primary" href="NuevaEspecialidad.aspx">Agregar</a>

    </div>
    <div class="col"></div>
</div>
</asp:Content>
