<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Administradores.aspx.cs" Inherits="WebApp.Administradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Administradores</h3>
            <asp:GridView ID="dgvAdmin" OnSelectedIndexChanged="dgvAdmin_SelectedIndexChanged" DataKeyNames="Id" cssclass="table" autogeneratecolumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id"/>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <a href='mailto:<%# Eval("Email") %>' class="mailto"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-Alert btn-sm"/>
                </Columns>
            </asp:GridView>
            <a class="btn btn-primary" href="NuevoAdministrador.aspx">Agregar</a>

        </div>
        <div class="col"></div>
    </div>
</asp:Content>
