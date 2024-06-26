﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ObrasSociales.aspx.cs" Inherits="WebApp.ObrasSociales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Obras Sociales</h3>
            <asp:GridView ID="dgvObraSocial" OnSelectedIndexChanged="dgvObraSocial_SelectedIndexChanged" DataKeyNames="Id" cssclass="table" autogeneratecolumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id"/>
                    <asp:BoundField HeaderText="Obra Social" DataField="Nombre"/>
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
            <a class="btn btn-primary" href="NuevaObraSocial.aspx">Agregar</a>

        </div>
        <div class="col"></div>
    </div>
</asp:Content>
