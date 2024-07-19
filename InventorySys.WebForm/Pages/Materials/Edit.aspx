<%@  Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InventorySys.WebForm.Pages.Materials.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Editar Material</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Materials/Materials.aspx">Materiales</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Editar Material</li>
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
                                <asp:Label runat="server" AssociatedControlID="txtMaterialCode" CssClass="form-label">Codigo de Material</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialCode" CssClass="form-control" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtMaterialDescription" CssClass="form-label">Descripcion de Material</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialDescription" CssClass="form-control" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlCollections" CssClass="form-label">Coleccion</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlCollections" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione una coleccion</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlFinitures" CssClass="form-label">Acabado</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlFinitures" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un acabado</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlFormats" CssClass="form-label">Formato</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlFormats" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un formato</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlSites" CssClass="form-label">Sitio</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlSites" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un sitio</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlUsers" CssClass="form-label">Usuario</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlUsers" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un usuario</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtMaterialIMG" CssClass="form-label">Imagen</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialIMG" CssClass="form-control" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtMaterialReceivedDate" CssClass="form-label">Fecha de arribo</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialReceivedDate" CssClass="form-control" required="required" type="date" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtMaterialStock" CssClass="form-label">Stock</asp:Label>
                                <asp:TextBox runat="server" ID="txtMaterialStock" CssClass="form-control" required="required" type="number" step="0.01" />
                            </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnAactualizar" class="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnAactualizar_Click" />
                            &nbsp;&nbsp;&nbsp;
                         <asp:LinkButton runat="server" PostBackUrl="~/Pages/Materials/Materials.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

