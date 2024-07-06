﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TurnosAsignados.aspx.cs" Inherits="WebApp.TurnosAsignados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
        <div class="col-2"></div>
        <div class="col-8">
            <h3>Turnos</h3>
            <asp:GridView ID="dgvTurnosAsignados" OnSelectedIndexChanged="dgvTurnosAsignados_SelectedIndexChanged" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="NombrePaciente" DataField="NombrePaciente" />
                    <asp:BoundField HeaderText="ApellidoPaciente" DataField="ApellidoPaciente" />
                    <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" />
                    <asp:BoundField HeaderText="FechaTurno" DataField="FechaTurno" />
                    <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                    <asp:BoundField HeaderText="Medico" DataField="Medico" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="ObraSocial" DataField="ObraSocial" />
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-Alert btn-sm" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>