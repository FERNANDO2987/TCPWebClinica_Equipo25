﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/Style/StyleMiApp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="d-flex p-2">
        <h1 class="m-auto">Panel Administrador</h1>
    </div>
    <hr />
    <div class="container" style="width: 800px">

        <%--<div class="row row-cols-1 row-cols-md-2 g-4">
            <div class="col">
                <a class="btn btn-outline-success fs-2" style="width: 100%; height: 200px; line-height: 200px;" href="Medicos.aspx">Medicos</a>
            </div>
            <div class="col">
                <a class="btn btn-outline-success fs-2" style="width: 100%; height: 200px; line-height: 200px;" href="Administradores.aspx">Administradores</a>
            </div>
        </div>--%>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="Medicos.aspx">Medicos</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="GestionHorariosMedicos.aspx">Gestion Horarios de Medicos</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="Pacientes.aspx">Pacientes</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="ObrasSociales.aspx">Obras Sociales</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="Turno.aspx">Turnos</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="Usuarios.aspx">Usuarios</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="Especialidades.aspx">Especialidades</a>
        </div>
        <div class="col">
            <a class="btn btn-outline-success fs-2" style="width: 100%; height: 115px; line-height: 100px;" href="EstadoTurnos.aspx">Estado Turno</a>
        </div>
    </div>
</asp:Content>
