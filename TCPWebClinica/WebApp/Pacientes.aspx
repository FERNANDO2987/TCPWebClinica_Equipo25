<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="WebApp.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row mt-1">
        <div class="col"></div>
        <div class="col-10">

            <h3>Pacientes</h3>
            <asp:GridView ID="dgvPacientes" OnSelectedIndexChanged="dgvPcaientes_SelectedIndexChanged" DataKeyNames="Id" cssclass="table" autogeneratecolumns="false" runat="server">
                <Columns>
                     <asp:BoundField HeaderText="ID" DataField="Id"/>
                     <asp:BoundField HeaderText="HC" DataField="HistoriaClinica"/>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:BoundField HeaderText="DNI" DataField="Documento"/>
                    <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento"/>
                    <asp:BoundField HeaderText="Telefono" DataField="Celular"/>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <a href='mailto:<%# Eval("Email") %>' class="mailto"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-Alert btn-sm"/>
                </Columns>
            </asp:GridView>
         <a href="NuevoPaciente.aspx" class="btn btn-primary">Nuevo Paciente</a>
        </div>
        <div class="col"></div>
    </div>
</asp:Content>
