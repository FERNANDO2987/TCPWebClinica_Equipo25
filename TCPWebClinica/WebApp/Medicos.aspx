﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebApp.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Lista de Médicos</h3>
            <asp:GridView ID="dgvMedicos" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged1" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <a href='mailto:<%# Eval("Email") %>' class="mailto"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-Alert btn-sm" />
                </Columns>
            </asp:GridView>
            <a href="NuevoMedico.aspx" class="btn btn-primary">+</a>
        </div>
        <div class="col"></div>
    </div>

</asp:Content>
