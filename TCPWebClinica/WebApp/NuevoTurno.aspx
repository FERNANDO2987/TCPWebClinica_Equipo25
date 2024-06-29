<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoTurno.aspx.cs" Inherits="WebApp.NuevoTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin: 2em 0 0 2em;">
        <div id="titulo" style="width: 100%; margin-bottom: 2em;">
            <h3>Agregar Turno</h3>
        </div>

        <div id="buscarPaciente" style="padding-top: 20px;">
            <label for="txtBuscarPaciente">Buscar Paciente</label>
            <asp:TextBox ID="txtBuscarPaciente" runat="server" CssClass="form-control" />
            <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar" OnClick="btnBuscarPaciente_Click" CssClass="btn btn-primary" />
        </div>



        <div id="resultadosBusqueda" style="width: 100%; margin-top: 20px;">
            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvPacientes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Documento" HeaderText="DNI" />
                    <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </div>


        <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left: 2em;">
            <div class="col-1" id="columna1" style="width: 45%;">
                <p style="color: red;">(*) Campos obligatorios</p>

                <div id="fechaTurno-ls" style="padding-top: 20px;">
                    <label for="fechaTurno">Fecha *</label>
                    <asp:TextBox type="date" ID="fechaTurno" class="form-select" AutoPostBack="true" onkeydown="return false;" runat="server" OnTextChanged="fechaTurno_TextChanged"></asp:TextBox>
                </div>

                <div id="medicos" style="padding-top: 20px;">
                    <label for="ddlMedicos">Medicos *</label>
                    <asp:DropDownList ID="ddlMedicos" runat="server" class="form-select" aria-label="Default select example" required="true" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                        <asp:ListItem Text="Medicos *" Enabled="false" />
                    </asp:DropDownList>
                </div>

                <div id="especialidades" style="padding-top: 20px;">
                    <label for="dllEspecialidad">Especialidades *</label>
                    <asp:DropDownList ID="dllEspecialidad" runat="server" class="form-select" aria-label="Default select example" required="true">
                        <asp:ListItem Text="Especialidades *" Enabled="false" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-2" id="columna2" style="width: 45%;">
                <p style="color: red;">(*) Campos obligatorios</p>



                <div id="estadoTurno" style="padding-top: 20px;">
                    <label for="ddlEstadoTurno">Estado Turno *</label>
                    <asp:DropDownList ID="ddlEstadoTurno" runat="server" class="form-select" aria-label="Default select example" required="true">
                        <asp:ListItem Text="Estado Turno *" Enabled="false" />
                    </asp:DropDownList>
                </div>

                <div id="hora" style="padding-top: 20px;">
                    <label for="ddlHorarioTrabajo">Hora *</label>
                    <asp:DropDownList ID="ddlHorarioTrabajo" runat="server" class="form-select" aria-label="Default select example" required="true">
                        <asp:ListItem Text="Hora *" Enabled="false" />
                    </asp:DropDownList>
                </div>

                <div id="obra_social" style="padding-top: 20px;">
                    <label for="ddlObraSocial">Obra Social *</label>
                    <asp:DropDownList ID="ddlObraSocial" runat="server" class="form-select" aria-label="Default select example" required="true">
                        <asp:ListItem Text="Obra Social *" Enabled="false" />
                    </asp:DropDownList>
                </div>
                <br />
                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtObservaciones" placeholder="Observaciones" runat="server" />
                    <label for="observaciones">Observaciones</label>
                </div>
            </div>
        </div>

        <div id="agregar" class="col-3" style="display: flex; justify-content: end; width: 100%; margin: 2em 15em 0 0;">
            <asp:Button Text="Agregar" CssClass="btn btn-outline-success" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
            <asp:Button Text="Modificar" CssClass="btn btn-outline-success m-1" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
            <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger m-1" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
        </div>
    </div>
</asp:Content>
