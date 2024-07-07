<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Horarios.aspx.cs" Inherits="WebApp.Horarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
    <div class="col"></div>
    <div class="col-6">
        <asp:Label ID="lblTitulo" cssclass="h3" runat="server" Text="Horarios"></asp:Label>
        <asp:GridView ID="dgvHorarios" OnSelectedIndexChanged="dgvHorarios_SelectedIndexChanged" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Horario de entrada" DataField="HoraEntrada" />
                <asp:BoundField HeaderText="Horario de salida" DataField="HoraSalida" />
                <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" />
            </Columns>
        </asp:GridView>
        <a class="btn btn-primary" href="NuevaEspecialidad.aspx">Agregar</a>

    </div>
    <div class="col"></div>
</div>
</asp:Content>
