<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.MaterialTransactions.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

<!-- Encabezado -->
<div class="app-content-header">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <h3 class="mb-0">Nueva Transacción</h3>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-end">
                    <li class="breadcrumb-item"><a href="/Pages/MaterialTransactions/MaterialTransactions.aspx">Transacciones de Material</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Crear Transacción</li>
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
                            <asp:Label runat="server" AssociatedControlID="ddlMaterials" CssClass="form-label">Material</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlMaterials" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione un material</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                            <div class="mb-3">
                                <asp:Label runat="server" ID="lblUsuarioActual" class="form-label">Registrado por:</asp:Label>
                                <asp:TextBox ID="txtUsuarioActual" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtMaterialTransactionDate" CssClass="form-label">Fecha de transacción</asp:Label>
                            <asp:TextBox runat="server" ID="txtMaterialTransactionDate" CssClass="form-control" required="required" type="date" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="RadioButtonList1" CssClass="form-label">Tipo de transacción</asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="form-check">
                                <asp:ListItem Text="Ingreso" Value="Ingreso" />
                                <asp:ListItem Text="Retiro" Value="Retiro" />
                            </asp:RadioButtonList>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtMaterialTransactionQuantity" CssClass="form-label">Cantidad de Material</asp:Label>
                            <asp:TextBox runat="server" ID="txtMaterialTransactionQuantity" CssClass="form-control" required="required" type="number" step="0.01" />
                        </div>

                        <hr />

                        <div class="d-flex gap-2">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/MaterialTransactions/MaterialTransactions.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>

                    <!-- Imagen decorativa a la derecha -->
                    <div class="col-md-6 d-flex align-items-center justify-content-center">
                        <img src="../../Content/dist/assets/img/transacciones.png" alt="Imagen Transacción" class="img-fluid rounded shadow" style="max-height: 250px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
