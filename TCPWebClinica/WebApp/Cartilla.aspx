<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="WebApp.Cartilla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--      <div id="tableContenedor" style="margin-top:1em; box-shadow : 0 0 10px black; padding:2em;" >

     <div style="display:flex; justify-content:space-between; align-items:center; margin-bottom:1em;" title="Nuevo Registro" >
        <h3>Cartilla de Profesionales</h3>
         <a href="CargarMedicos.aspx" class="btn btn-primary">Nuevo medico</a>
        
      </div>
   
  </div>--%>
            <div class="row mt-5">
        <div class="col"></div>
        <div class="col-6">

            <h3>Lista de Profecionales</h3>
            <asp:GridView ID="dgvMedicos" DataKeyNames="Id" cssclass="table" autogeneratecolumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <a href='mailto:<%# Eval("Email") %>' class="mailto"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-Alert btn-sm"/>
                </Columns>
            </asp:GridView>
         <a href="CargarMedicos.aspx" class="btn btn-primary">+</a>
        </div>
        <div class="col"></div>
    </div
</asp:Content>
