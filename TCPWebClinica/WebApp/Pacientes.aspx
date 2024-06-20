<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="WebApp.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Pacientes</h3>
            <asp:GridView ID="dgvPacientes" DataKeyNames="Id" cssclass="table" autogeneratecolumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:BoundField HeaderText="Nro Documento" DataField="Dni"/>
                    <asp:BoundField HeaderText="Direccion" DataField="Direccion"/>
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <a href='mailto:<%# Eval("Email") %>' class="mailto"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sitio Web">
                        <ItemTemplate>
                            <a href='<%# Eval("Website", "http://{0}") %>' target="_blank"><%# Eval("Website") %></a>
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
