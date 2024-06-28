<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoTurno.aspx.cs" Inherits="WebApp.NuevoTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">




</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em; margin-left: 2em;">

        <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em;">
            <h3>Agregar Turno</h3>
        </div>

        <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left: 2em;">

            <div class="col-1" id="columna1" style="width: 45%;">
                <p class="color:red;">(*) Campos obligatorios</p>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtObservaciones" placeholder="Observaciones" runat="server" />
                    <label for="observaciones">Observaciones</label>
                </div>

                <div id="fecha-ls" style="padding-top: 20px;">
                    <label for="fecha">Fecha *</label>
                    <asp:TextBox type="date" ID="fecha" class="form-select" AutoPostBack="true" onkeydown="return false;" runat="server" OnTextChanged="fecha_TextChanged"></asp:TextBox>
                </div>
                <div class="form-floating mb-3">
                    <asp:DropDownList ID="ddlHorarioTrabajo" CssClass="form-select" runat="server"></asp:DropDownList>
                    <label for="horarioTrabajo">Hora</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:DropDownList ID="dllEspecialidad" CssClass="form-select" runat="server"></asp:DropDownList>
                    <label for="especialidad">Especialidad</label>
                </div>


            </div>

            <div class="col-2" id="columna2" style="width: 45%;">
                <p class="color:red;">(*) Campos obligatorios</p>


                <div class="form-floating mb-3">
                    <asp:DropDownList ID="ddlMedicos" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged"></asp:DropDownList>
                    <label for="medicos">Medicos</label>
                </div>



                <div class="form-floating mb-3">
                    <asp:DropDownList ID="ddlEstadoTurno" CssClass="form-select" runat="server"></asp:DropDownList>
                    <label for="estadoTurno">EstadoTurno</label>
                </div>


                <div class="form-floating mb-3">
                    <asp:DropDownList ID="ddlObraSocial" CssClass="form-select" runat="server"></asp:DropDownList>
                    <label for="obraSocial">ObraSocial</label>
                </div>


            </div>

        </div>

        <div style="margin-top: 2em;">
            <asp:Button Text="Agregar" CssClass="btn btn-outline-primary m-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
            <asp:Button Text="Modificar" CssClass="btn btn-outline-success m-1" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
            <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger m-1" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
        </div>


    </div>

</asp:Content>
