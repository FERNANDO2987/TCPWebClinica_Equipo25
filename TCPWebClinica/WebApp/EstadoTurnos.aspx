<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EstadoTurnos.aspx.cs" Inherits="WebApp.EstadoTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Estado Turno</h3>
            <asp:GridView ID="dgvEstadoTurno" OnSelectedIndexChanged="dgvEstadoTurno_SelectedIndexChanged" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" />
                </Columns>
            </asp:GridView>
            <a class="btn btn-primary" href="NuevoEstadoTurno.aspx">Agregar</a>

        </div>
        <div class="col"></div>
    </div>
</asp:Content>
