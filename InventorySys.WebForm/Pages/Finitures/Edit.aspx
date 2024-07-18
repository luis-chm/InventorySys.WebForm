<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InventorySys.WebForm.Pages.Finitures.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="app-content-header">
    <!--begin::Container-->
    <div class="container-fluid">
        <!--begin::Row-->
        <div class="row">
            <div class="col-sm-6">
                <h3 class="mb-0">Editar Acabado</h3>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-end">
                    <li class="breadcrumb-item"><a href="/Pages/Finitures/Finitures.aspx">Finitures</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Editar Acabado</li>
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
                            <asp:Label runat="server" AssociatedControlID="txtFinitureCode" CssClass="form-label">Codigo de Acabado</asp:Label>
                            <asp:TextBox runat="server" ID="txtFinitureCode" CssClass="form-control" required="required" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="txtFinitureName" CssClass="form-label">Nombre de Acabado</asp:Label>
                            <asp:TextBox runat="server" ID="txtFinitureName" CssClass="form-control" required="required" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="RadioButtonList1" CssClass="form-label">Estado de Acabado</asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div>
                        <hr />                                        
                        <asp:Button ID="btnActualizar" class="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                        &nbsp;&nbsp;&nbsp;
                     <asp:LinkButton runat="server" PostBackUrl="~/Pages/Finitures/Finitures.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
