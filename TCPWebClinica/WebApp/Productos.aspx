<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApp.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
             
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">
    <div class="row mb-3">
        <div class="col-md-8">
            <input type="text" id="searchInput" class="form-control" placeholder="Buscar productos...">
        </div>
        <div class="col-md-2">
            <select id="priceFilter" class="form-control">
                <option value="">Filtrar por precio</option>
                <option value="low">Menor a Mayor</option>
                <option value="high">Mayor a Menor</option>
            </select>
        </div>
        <div class="col-md-2">
            <button id="searchButton"  class="btn btn-primary" >Buscar</button>
        </div>
    </div>

</div>



    <script src="Script/Filtro.js"></script>

    <script src="Script/AgregarCarrito.js"></script>

  
</asp:Content>



