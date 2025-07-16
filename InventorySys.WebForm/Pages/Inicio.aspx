﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="InventorySys.WebForm.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <div class="app-content-header">
            <!--begin::Container-->
            <div class="container-fluid">
                <!--begin::Row-->
                <div class="row">
                    <div class="col-sm-6">
                        <h3 class="mb-0"></h3>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-end">
                            <li class="breadcrumb-item"><a href="/Pages/Inicio">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Inicio</li>
                        </ol>
                    </div>
                    <!-- /.Start col -->
                </div>
                <!-- /.row (main row) -->
            </div>
            <!--end::Container-->
        </div>
        <!--end::App Content-->

        <!-- Contenedor principal -->
        <div class="container mt-5">
            <!-- Sección de bienvenida -->
            <div class="jumbotron bg-light p-5 rounded">
                <h1 class="display-4">¡Bienvenido a Nuestro Sistema de Inventario!</h1>
                <p class="lead">Estamos encantados de tenerte con nosotros. Aquí podrás gestionar de manera eficiente el inventario de porcelanato.</p>
                <hr class="my-4">
                <p>Utiliza las herramientas a continuación para explorar y administrar las distintas funciones del sistema.</p>
            </div>

            <!-- Tarjetas de funciones -->
            <div class="row">
                <!-- Tarjeta de Gestión de Productos -->
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Gestión de Inventario</h5>
                            <br />
                            <br />
                            <p class="card-text">Añade, edita y elimina productos en el inventario. Mantén un registro actualizado de todos los artículos disponibles.</p>
                        </div>
                    </div>
                </div>
                <!-- Tarjeta de Reportes -->
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Generar Reportes</h5>
                            <br />
                            <br />
                            <p class="card-text">Genera reportes detallados sobre las transacciones y el estado del inventario. Puedes personalizar los reportes según tus necesidades.</p>
                        </div>
                    </div>
                </div>
                <!-- Tarjeta de Configuración -->
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Soporte y Ayuda</h5>
                            <br />
                            <br />
                            <p class="card-text">Encuentra respuestas a tus preguntas frecuentes y contacta al soporte si necesitas ayuda adicional. No dudes en contactarnos.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </main>
</asp:Content>
