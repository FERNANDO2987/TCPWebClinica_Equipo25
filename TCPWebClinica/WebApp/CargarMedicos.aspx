<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CargarMedicos.aspx.cs" Inherits="WebApp.CargarMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em;">

        <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em; margin-left: 5em";>
            <h3>Agregar nuevo Profesional</h3>
        </div>

        <div id="form" style="display: flex; flex-direction: row; justify-content: space-around; width: 100%;">

            <div class="col-1" id="columna1" style="width: 45%;">
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtNombre" placeholder="Nombre" required="true" runat="server" />
                    <label for="nombre">Nombre *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtApellido" placeholder="Apellido" required="true" runat="server" />
                    <label for="Apellido">Apellido *</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" ID="txtEmail" placeholder="name@example.com" CssClass="form-control" required="true" runat="server" />
                    <label for="email">Email *</label>
                </div>

            </div>
            <di v class="col-2" id="columna2" style="display: flex; flex-direction: column; justify-content: space-around; width: 45%;">

                <div id="horarios">

                    <div id="hora-he" style="padding-top: 20px;">
                        <label for="ddlHorarioEntrada">Horario Entrada *</label>
                        <asp:DropDownList ID="ddlHorarioEntrada" runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Horario de entrada*" Enabled="false" />
                        </asp:DropDownList>
                    </div>
                    <div id="hora-hs" style="padding-top: 20px;">
                        <label for="ddlHorarioSalida">Horario Salida *</label>
                        <asp:DropDownList ID="ddlHorarioSalida" runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Horario de salida *" Enabled="false" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="especialidad-ls" style="padding-top: 20px;">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" class="form-select" aria-label="Default select example" required="true">
                        <asp:ListItem Text="Especialidad *" />
                    </asp:DropDownList>
                </div>
            </div>

        <div id="agregar" class="col-3" style="display: flex; justify-content:end; width: 100%; margin-top: 2em;margin-right: 15em">
            <asp:Button Text="Agregar" cssClass="btn btn-outline-success" ID="Agregar" OnClick="btnAgregar_Click" runat="server" />
        </div>
        <br />
        <div>
            <p>(*) Campos obligatorios</p>
        </div>
</div>
</asp:Content>
