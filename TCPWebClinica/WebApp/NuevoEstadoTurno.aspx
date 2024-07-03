<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoEstadoTurno.aspx.cs" Inherits="WebApp.NuevoEstadoTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em; margin-left: 2em;">
     <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em;">
         <asp:Label ID="Titulo" cssclass="h3" runat="server" Text="Agregar Estado Turno"></asp:Label>
     </div>
     <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left:2em; ">
         <div class="col-1" id="columna1" style="width: 45%;">
             <p style="color:red;">(*) Campos obligatorios</p>
             <div class="form-floating mb-3">
                 <asp:TextBox type="text" CssClass="form-control" ID="txtId" placeholder="Id" ReadOnly="true"  runat="server" />
                 <label for="txtId">ID </label>
             </div>
             <div class="form-floating mb-3">
                 <asp:TextBox type="text" CssClass="form-control" ID="txtCodigo" placeholder="Nombre" required="true" runat="server" />
                 <label for="txtCodigo">Codigo *</label>
             </div>
             <div class="form-floating mb-3">
                 <asp:TextBox type="text" CssClass="form-control" ID="txtDescripcion" placeholder="Descripcion" required="true" runat="server" />
                 <label for="txtDescripcion">Descripcion *</label>
             </div>
             <div class="ps-5" margin-top: 2em;">
                 <asp:Button Text="Agregar" CssClass="btn btn-outline-primary m-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
             </div>
         </div>
     </div>
 </div>
</asp:Content>
