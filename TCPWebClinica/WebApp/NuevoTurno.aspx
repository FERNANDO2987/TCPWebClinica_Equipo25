<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoTurno.aspx.cs" Inherits="WebApp.NuevoTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .input-group-custom .form-control {
            width: 100%; /* Ocupa todo el ancho disponible */
        }

        .input-group-custom .input-group-append .btn {
            margin-left: 10px; /* Separar un poco el botón del textbox */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin: 2em 0 0 2em;">
        <div id="titulo" style="width: 30%; margin-bottom: 2em;">
            <h3>Agregar Turno</h3>
        </div>

        <div id="form3" style="display: flex; flex-direction: column; align-items: center; width: 100%; margin: 2em 0;">
            <div class="col-12 col-md-8" id="columna3">
                <div class="form-floating mb-3 search-container">
                    <div class="input-group input-group-custom">
                        <asp:TextBox type="search" ID="txtBuscarPaciente" role="combobox" spellcheck="false" runat="server" CssClass="form-control" placeholder="Buscar" required="true" AutoPostBack="true" OnTextChanged="txtBuscarPaciente_TextChanged" />
                        <div class="input-group-append">
                            <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar" OnClick="btnBuscarPaciente_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mt-4">
                            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="gvPacientes_RowCommand" DataKeyNames="Id">
                                <Columns>
                                    <asp:BoundField DataField="HistoriaClinica" HeaderText="HC" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                    <asp:BoundField DataField="Documento" HeaderText="DNI" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:TextBox ID="txtNombreApellidoPaciente" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="hfPacienteId" runat="server" />

                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtBuscarPaciente" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <!-- Campo oculto para almacenar el ID del paciente seleccionado -->
     


        <div id="form" style="display: flex; flex-direction: row; justify-content: start; width: 100%; margin-left: 2em;">
            <div class="col-1" id="columna1" style="width: 45%;">


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
                    <asp:DropDownList ID="dllEspecialidad" runat="server" class="form-select" aria-label="Default select example" required="true" >
                        <asp:ListItem Text="Especialidades *" Enabled="false" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-2" id="columna2" style="width: 45%;">




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
