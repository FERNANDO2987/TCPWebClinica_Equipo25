<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionHorariosMedicos.aspx.cs" Inherits="WebApp.GestionHorariosMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="form3" style="display: flex; flex-direction: column; align-items: center; width: 100%; margin: 2em 0;">
     <div class="col-12 col-md-8" id="columna3">
         <div class="form-floating mb-3 search-container">
             <div class="input-group input-group-custom">
                 <asp:TextBox type="search" ID="txtBuscarMedico" role="combobox" spellcheck="false" runat="server" CssClass="form-control" placeholder="Buscar" required="true" AutoPostBack="true" OnTextChanged="txtBuscarMedico_TextChanged" />
                 <div class="input-group-append">
                     <asp:Button ID="btnBuscarMedico" runat="server" Text="Buscar" OnClick="btnBuscarMedico_Click" CssClass="btn btn-primary" />
                    
                 </div>
             </div>
         </div>
</asp:Content>
