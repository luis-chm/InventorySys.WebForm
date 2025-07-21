<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InventorySys.WebForm.Pages.MaterialTransactions.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Editar Transaccion</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/MaterialTransactions/MaterialTransactions.aspx">MaterialTransaccions</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Editar Transaccion</li>
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
                                <asp:Label runat="server" AssociatedControlID="ddlMaterials" CssClass="form-label">Material</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlMaterials" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un material</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                      <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label runat="server" ID="lblUsuarioActual" class="form-label">Editado por:</asp:Label>
                                <asp:TextBox ID="txtUsuarioActual" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtMaterialTransactionDate" CssClass="form-label">Fecha de transaccion</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialTransactionDate" CssClass="form-control" required="required" type="date" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="RadioButtonList1" CssClass="form-label">Tipo de transaccion</asp:Label>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Text="&nbsp;Ingreso" Value="Ingreso"></asp:ListItem>
                                    <asp:ListItem Text="&nbsp;Retiro" Value="Retiro"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtMaterialTransactionQuantity" CssClass="form-label">Cantidad de Material</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialTransactionQuantity" CssClass="form-control" required="required" type="number" step="0.01" />
                            </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnAactualizar" class="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnAactualizar_Click" />
                            &nbsp;&nbsp;&nbsp;
                         <asp:LinkButton runat="server" PostBackUrl="~/Pages/MaterialTransactions/MaterialTransactions.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>
                </div>
    </div>
        </div>
    </div>

</asp:Content>
