<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="WebApp.Cartilla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="tableContenedor" style="margin-top:1em; box-shadow : 0 0 10px black; padding:2em;" >

     <div style="display:flex; justify-content:space-between; align-items:center; margin-bottom:1em;" title="Nuevo Registro" >
        <h3>Cartilla de Profesionales</h3>
         <a href="CargarMedicos.aspx" class="btn btn-primary">Nuevo medico</a>
        
      </div>
   
  </div>
</asp:Content>
