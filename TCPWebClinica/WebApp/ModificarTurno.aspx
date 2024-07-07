<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="WebApp.ModificarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

             
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


     <div class="ps-5" margin-top: 2em;">
        
         <asp:Button Text="Modificar" CssClass="btn btn-outline-success m-1" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
         <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger m-1" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
     </div>
</asp:Content>
