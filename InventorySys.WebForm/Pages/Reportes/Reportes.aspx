<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="InventorySys.WebForm.Pages.Reportes.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Reporte de Materiales</h3>
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
    <!--end::App Content-->
    <div>
        <div class="row align-items-end">
            <div class="col-sm-3">
                <label class="form-label">Fecha Inicio</label>
                <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="form-control" required="required" type="date" />
            </div>

            <div class="col-sm-3">
                <label class="form-label">Fecha Fin</label>
                <asp:TextBox runat="server" ID="txtFechaFin" CssClass="form-control" required="required" type="date" />
            </div>

            <div class="col-sm-2">
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Exportar Excel" OnClick="btnExportExcel_Click"/>
            </div>
        </div>
    </div>
    <hr />
    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Reporte de Transacciones</h3>
                </div>
                <div class="col-md-6 mb-4">
                    <div class="form-outline">
                        <label class="form-label" for="lastName">Last Name</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 mb-4 d-flex align-items-center">
            <div class="form-outline datepicker w-100">
                <label for="birthdayDate" class="form-label">Birthday</label>
            </div>
        </div>
        <hr />
        <div class="app-content-header">
            <!--begin::Container-->
            <div class="container-fluid">
                <!--begin::Row-->
                <div class="row">
                    <div class="col-sm-6">
                        <h3 class="mb-0">Reporte de Movimientos</h3>
                    </div>
                    <div class="col-md-6 mb-4">
                        <div class="form-outline">
                            <label class="form-label" for="lastName">Last Name</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
</asp:Content>
