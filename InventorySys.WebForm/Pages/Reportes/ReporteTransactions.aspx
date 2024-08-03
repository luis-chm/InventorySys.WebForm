<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="ReporteTransactions.aspx.cs" Inherits="InventorySys.WebForm.Pages.Reportes.ReporteTransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Reporte de Transacciones</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Inicio">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Reportes</li>
                    </ol>
                </div>
                <!-- /.Start col -->
            </div>
            <!-- /.row (main row) -->
        </div>
        <!--end::Container-->
    </div>

        <div class="container mt-5">
            <!-- Contenedor para tarjetas con clase personalizada -->
            <div class="row justify-content-center">
                <div class="col-md-8"> <!-- Ajusta el tamaño de la columna según tus necesidades -->
                    <!-- Tarjeta para Reporte General -->
                    <div class="card">
                        <div class="card-header">
                            Reporte General
                        </div>
                        <div class="card-body">
                            <div class="row justify-content-center">
                                <div class="col-md-6 text-center"> <!-- Centra el botón en la columna -->
                                    <asp:Button ID="btnReporteGeneral" class="btn btn-success" runat="server" Text="Descargar Reporte General" Width="370px" OnClick="btnReporteGeneral_Click" />
                                </div>
                            </div>
                            <hr />
                        </div>
                    </div>

                    <!-- Tarjeta para Reporte por Fechas -->
                    <div class="card mt-4">
                        <div class="card-header">
                            Reporte por Fechas
                        </div>
                        <div class="card-body">
                            <div class="row align-items-end">
                                <div class="col-sm-4">
                                    <label class="form-label">Fecha Inicio</label>
                                    <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="form-control" type="date" />
                                </div>
                                <div class="col-sm-4">
                                    <label class="form-label">Fecha Fin</label>
                                    <asp:TextBox runat="server" ID="txtFechaFin" CssClass="form-control" type="date" />
                                </div>
                                <div class="col-sm-4">
                                    <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Exportar Excel" OnClick="btnReporteByDate_Click"/>
                                </div>
                            </div>
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
