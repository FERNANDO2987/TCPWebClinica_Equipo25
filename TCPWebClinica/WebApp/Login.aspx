<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="d-flex justify-content-center align-items-center">
        <div class="card p-3 mt-5" style="width: 400px;padding: 2rem;">
            <div class="card-header">Login</div>
            <div class="mb-3">
                <label for="txtNombreUsuario" class="form-label">Nombre de usuario</label>
                <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtContraseña" class="form-label">Contraseña</label>
                <asp:TextBox TextMode="Password" ID="txtContraseña" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary w-100" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
        </div>
    </div>

</asp:Content>
