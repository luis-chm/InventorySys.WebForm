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
<div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-10">
            
            <!-- Tarjeta: Reporte General -->
            <div class="card shadow p-4 mb-4">
                <div class="card-header bg-light">
                    <h5 class="mb-0">Reporte General de Materiales</h5>
                </div>
                <div class="card-body text-center">
                    <asp:Button ID="btnReporteGeneral" runat="server" Text="Descargar Excel" CssClass="btn btn-success px-4 py-2" Width="100%" OnClick="btnReporteGeneral_Click" />
                </div>
            </div>

            <!-- Tarjeta: Reporte por Fechas -->
            <div class="card shadow p-4 mb-4">
                <div class="card-header bg-light">
                    <h5 class="mb-0">Reporte por Rango de Fechas</h5>
                </div>
                <div class="card-body">
                    <div class="row g-3 align-items-end">
                        <div class="col-md-4">
                            <label for="txtFechaInicio" class="form-label">Fecha Inicio</label>
                            <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="form-control" type="date" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtFechaFin" class="form-label">Fecha Fin</label>
                            <asp:TextBox runat="server" ID="txtFechaFin" CssClass="form-control" type="date" />
                        </div>
                        <div class="col-md-4 d-grid">
                            <asp:Button ID="btnReporteByDate" runat="server" Text="Exportar Excel" CssClass="btn btn-success py-2" OnClick="btnReporteByDate_Click" />
                        </div>
                    </div>
                </div>
            </div>



</asp:Content>
