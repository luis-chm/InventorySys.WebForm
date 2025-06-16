<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.Sites.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Encabezado -->
<div class="app-content-header">
    <div class="container-fluid">
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
        </div>
    </div>
</div>

<!-- Contenido -->
<div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-10">
            <div class="card p-4">
                <div class="row">
                    <!-- Formulario a la izquierda -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtSiteName" CssClass="form-label">Nombre del Sitio</asp:Label>
                            <asp:TextBox runat="server" ID="txtSiteName" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtSiteLocation" CssClass="form-label">Ubicación del Sitio</asp:Label>
                            <asp:TextBox runat="server" ID="txtSiteLocation" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="RadioButtonList1" CssClass="form-label">Estado del Sitio</asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" CssClass="form-check">
                                <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <hr />

                        <div class="d-flex gap-2">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/Sites/Sites.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>

                    <!-- Imagen decorativa a la derecha -->
                    <div class="col-md-6 d-flex align-items-center justify-content-center">
                        <img src="../../Content/dist/assets/img/site.png" alt="Imagen Sitio" class="img-fluid rounded shadow" style="max-height: 250px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
