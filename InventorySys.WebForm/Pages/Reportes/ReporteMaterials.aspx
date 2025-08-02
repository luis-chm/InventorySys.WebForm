<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="ReporteMaterials.aspx.cs" Inherits="InventorySys.WebForm.Pages.Reportes.ReporteMaterials1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Encabezado de la Página -->
<div class="app-content-header">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <h3 class="mb-0">Reportes de Materiales</h3>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-end">
                    <li class="breadcrumb-item"><a href="/Pages/Inicio">Inicio</a></li>
                    <li class="breadcrumb-item active">Reportes</li>
                </ol>
            </div>
        </div>
    </div>
</div>

<!-- Contenido Principal -->
<div class="container-fluid mt-4">
    <!-- Reportes Principales -->
    <div class="row">
        <!-- Reporte General -->
        <div class="col-lg-6 mb-4">
            <div class="card report-card shadow-sm h-100">
                <div class="card-header bg-light border-bottom">
                    <h5 class="mb-0 text-dark">
                        <i class="fas fa-chart-bar me-2 text-success"></i>General
                    </h5>
                </div>
                <div class="card-body text-center p-4">
                    <p class="text-muted mb-4">Descarga el reporte completo con todos los materiales registrados en el sistema</p>
                    <div class="d-grid gap-2">
                        <asp:LinkButton ID="btnReporteGeneral1" runat="server" 
                            CssClass="btn btn-success btn-rounded btn-lg text-white text-decoration-none" 
                            OnClick="btnReporteGeneral_Click">
                            <i class="fas fa-download me-2"></i>Descargar Excel
                        </asp:LinkButton>
                    </div>
                    <div class="mt-3">
                        <small class="text-muted">
                            <i class="fas fa-circle text-success"></i> Última actualización: Hoy 09:30 AM
                        </small>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Reporte por Fechas -->
        <div class="col-lg-6 mb-4">
            <div class="card report-card shadow-sm h-100">
                <div class="card-header bg-light border-bottom">
                    <h5 class="mb-0 text-dark">
                        <i class="fas fa-calendar-alt me-2 text-primary"></i>Por Fechas
                    </h5>
                </div>
                <div class="card-body p-4">
                    <p class="text-muted mb-3 text-center">Genera reportes personalizados por rango de fechas</p>
                    <div class="row g-3">
                        <div class="col-12">
                            <label for="txtFechaInicio" class="form-label fw-bold text-primary">
                                <i class="fas fa-calendar-day me-2"></i>Fecha Inicio
                            </label>
                            <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="form-control form-control-lg border-2" type="date" />
                        </div>
                        <div class="col-12">
                            <label for="txtFechaFin" class="form-label fw-bold text-primary">
                                <i class="fas fa-calendar-day me-2"></i>Fecha Fin  
                            </label>
                            <asp:TextBox runat="server" ID="txtFechaFin" CssClass="form-control form-control-lg border-2" type="date" />
                        </div>
                        <div class="col-12 pt-2">
                            <div class="d-grid">
                                <asp:LinkButton ID="btnReporteByDate1" runat="server" 
                                    CssClass="btn btn-primary btn-rounded btn-lg text-white text-decoration-none" 
                                    OnClick="btnReporteByDate_Click">
                                    <i class="fas fa-file-export me-2"></i>Exportar Excel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
  


</asp:Content>
