<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.Sites.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Nuevo Sitio</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Sites/Sites.aspx">Sites</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Crear Sitio</li>
                    </ol>
                </div>
                <!-- /.Start col -->
            </div>
            <!-- /.row (main row) -->
        </div>
        <!--end::Container-->
    </div>
    <!--end::App Content-->
    <div class="container mt-5">
        <div class="row justify-content-start">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center"></h3>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtSiteName" CssClass="form-label">Nombre del Sitio</asp:Label>
                                <asp:TextBox runat="server" ID="txtSiteName" CssClass="form-control" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtSiteLocation" CssClass="form-label">Locacion del Sitio</asp:Label>
                                <asp:TextBox runat="server" ID="txtSiteLocation" CssClass="form-control" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="RadioButtonList1" CssClass="form-label">Estado del Sitio</asp:Label>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            &nbsp;&nbsp;&nbsp;
                     <asp:LinkButton runat="server" PostBackUrl="~/Pages/Sites/Sites.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
