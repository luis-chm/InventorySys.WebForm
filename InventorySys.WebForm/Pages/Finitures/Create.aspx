<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.Finitures.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!-- Encabezado -->
<div class="app-content-header">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <h3 class="mb-0">Nuevo Acabado</h3>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-end">
                    <li class="breadcrumb-item"><a href="/Pages/Finitures/Finitures.aspx">Finitures</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Crear Acabado</li>
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
                            <asp:Label runat="server" AssociatedControlID="txtFinitureCode" CssClass="form-label">Código de Acabado</asp:Label>
                            <asp:TextBox runat="server" ID="txtFinitureCode" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtFinitureName" CssClass="form-label">Nombre de Acabado</asp:Label>
                            <asp:TextBox runat="server" ID="txtFinitureName" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="RadioButtonList1" CssClass="form-label">Estado de Acabado</asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" CssClass="form-check">
                                <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <hr />

                        <div class="d-flex gap-2">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/Finitures/Finitures.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>

                    <!-- Imagen decorativa a la derecha -->
                    <div class="col-md-6 d-flex align-items-center justify-content-center">
                        <img src="../../Content/dist/assets/img/finitures.png" alt="Imagen Acabado" class="img-fluid rounded shadow" style="max-height: 300px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
