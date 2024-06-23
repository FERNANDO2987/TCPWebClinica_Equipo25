<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Turno.aspx.cs" Inherits="WebApp.Turno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Turnos</h3>
            <asp:GridView ID="dgvTurnos" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" runat="server">
                <Columns>

                    <asp:BoundField HeaderText="Nombre" DataField="Paciente.Nombre" />
                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                    <asp:BoundField HeaderText="Hora" DataField="Hora" />
                    <asp:BoundField HeaderText="Medico" DataField="Medico.Nombre" />
                    <asp:BoundField HeaderText="Especialidad" DataField="Especialidad.Nombre" />
                    <asp:BoundField HeaderText="Obra Social" DataField="ObraSocial.Nombre" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado.Nombre" />
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-Alert btn-sm" />
                </Columns>
            </asp:GridView>
            <a class="btn btn-primary" href="NuevoTurno.aspx">Agregar</a>

        </div>
        <div class="col"></div>
    </div>
</asp:Content>
