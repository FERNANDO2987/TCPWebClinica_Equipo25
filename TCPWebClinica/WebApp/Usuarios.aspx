<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Usuarios</h3>
            <hr />

            <asp:GridView ID="dgvUsuarios" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" CssClass="table" DataKeyNames="Id" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre Usuario" DataField="Nombre" />
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <a href='mailto:<%# Eval("Email") %>' class="mailto"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success btn-sm" SelectText="Seleccionar" />
                </Columns>
            </asp:GridView>
            <a class="btn btn-primary" href="NuevoUsuario.aspx">Agregar</a>

        </div>
        <div class="col"></div>
    </div>
</asp:Content>
