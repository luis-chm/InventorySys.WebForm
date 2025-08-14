<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="InventorySys.WebForm.Pages.Dashboard.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<main>
        <div class="app-content-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-6">
                        <h3 class="mb-0">Dashboard</h3>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-end">
                            <li class="breadcrumb-item"><a href="/Pages/Inicio">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid mt-4">
            <!-- Sección de bienvenida -->
            <div class="row mb-4">
                <div class="col-12">
                    <div class="alert alert-info border-0 shadow-sm">
                        <div class="row align-items-center">
                            <div class="col-md-8">
                                <h4 class="alert-heading mb-2">
                                    <i class="fas fa-tachometer-alt me-2"></i>
                                    ¡Bienvenido al Sistema de Inventario!
                                </h4>
                                <p class="mb-1">
                                    <i class="fas fa-calendar-alt me-2"></i>
                                    <asp:Label ID="lblFechaActual" runat="server" Text=""></asp:Label>
                                </p>
                                <p class="mb-0">Gestiona eficientemente tu inventario de porcelanato desde este panel de control.</p>
                            </div>
                            <div class="col-md-4 text-center">
                                <i class="fas fa-warehouse fa-4x text-primary"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Tarjetas de métricas principales -->
            <div class="row mb-4">
                <!-- Total de Materiales -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-primary text-white">
                            <i class="fas fa-boxes fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblTotalMateriales" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Total Materiales</p>
                        </div>
                    </div>
                </div>

                <!-- Stock Total -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-success text-white">
                            <i class="fas fa-warehouse fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblStockTotal" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Stock Total</p>
                        </div>
                    </div>
                </div>

                <!-- Transacciones -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-info text-white">
                            <i class="fas fa-exchange-alt fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblTotalTransacciones" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Total Transacciones</p>
                        </div>
                    </div>
                </div>

                <!-- Colecciones Activas -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-warning text-white">
                            <i class="fas fa-layer-group fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblColeccionesActivas" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Colecciones Activas</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Segunda fila de métricas -->
            <div class="row mb-4">
                <!-- Sitios Activos -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-danger text-white">
                            <i class="fas fa-map-marker-alt fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblSitiosActivos" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Sitios Activos</p>
                        </div>
                    </div>
                </div>

                <!-- Formatos Activos -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-secondary text-white">
                            <i class="fas fa-ruler-combined fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblFormatosActivos" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Formatos Activos</p>
                        </div>
                    </div>
                </div>

                <!-- Acabados Activos -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center bg-dark text-white">
                            <i class="fas fa-palette fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblAcabadosActivos" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Acabados Activos</p>
                        </div>
                    </div>
                </div>

                <!-- Usuarios Registrados -->
                <div class="col-xl-3 col-md-6 mb-3">
                    <div class="card border-0 shadow-sm h-100">
                        <div class="card-body text-center" style="background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white;">
                            <i class="fas fa-users fa-3x mb-3"></i>
                            <h2 class="mb-2">
                                <asp:Label ID="lblUsuariosRegistrados" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p class="mb-0">Usuarios Registrados</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Accesos rápidos -->
            <div class="row">
                <div class="col-12">
                    <div class="card border-0 shadow-sm">
                        <div class="card-header bg-white border-bottom">
                            <h5 class="mb-0">
                                <i class="fas fa-rocket me-2 text-primary"></i>
                                Accesos Rápidos
                            </h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-3 mb-3">
                                    <div class="d-grid">
                                        <a href="../Materials/Create.aspx" class="btn btn-outline-primary btn-lg">
                                            <i class="fas fa-plus-circle fa-2x mb-2 d-block"></i>
                                            Agregar Material
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <div class="d-grid">
                                        <a href="../MaterialTransactions/Create.aspx" class="btn btn-outline-success btn-lg">
                                            <i class="fas fa-exchange-alt fa-2x mb-2 d-block"></i>
                                            Nueva Transacción
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <div class="d-grid">
                                        <a href="../Reportes/ReporteMaterials.aspx" class="btn btn-outline-info btn-lg">
                                            <i class="fas fa-chart-line fa-2x mb-2 d-block"></i>
                                            Ver Reportes
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <div class="d-grid">
                                        <a href="../Materials/Materials.aspx" class="btn btn-outline-warning btn-lg">
                                            <i class="fas fa-search fa-2x mb-2 d-block"></i>
                                            Consultar Inventario
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
