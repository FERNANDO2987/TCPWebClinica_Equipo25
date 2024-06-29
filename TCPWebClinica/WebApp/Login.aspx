<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">
        <div class="card col-md-6 offset-md-3 mt-5">
            <div class="card-header">Login</div>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email address</label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <asp:TextBox TextMode="Password" ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" cssclass="btn btn-primary" runat="server" Text="Submit" />
        </div>
    </div>



<%--    <div class="container h-100">
        <div class="row justify-content-sm-center h-100">
            <div class="col-xxl-4 col-xl-5 col-lg-5 col-md-7 col-sm-9">
                <div class="card shadow-lg">
                    <h1 class="fs-4 card-title fw-bold mb-4">Login</h1>
                    
                    <div class="mb-3">
                        <label class="mb-2 text-muted" for="email">Nombre de usuario</label>
                        <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="invalid-feedback">
                            Email invalido
                        </div>
                    </div>
                   
                    <div class="mb-3">

                        <div class="mb-2 w-100">
                            <label class="text-muted" for="contraseña">Contraseña</label>
                            <a href="forgot.html" class="float-end">Olvidaste tu contraseña?
                            </a>
                        </div>
                        <asp:TextBox TextMode="Password" ID="txtContraseña" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="invalid-feedback">
                            Password is required
                        </div>
                    </div>
                   
                    <div class="d-flex align-items-center">
                        <asp:Button ID="Button1" CssClass="btn btn-primary w-100" runat="server" Text="Aceptar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    
 
    --%>


</asp:Content>
