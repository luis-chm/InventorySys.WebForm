<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.Roles.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Nuevo Rol</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Roles/Roles.aspx">Roles</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Crear Rol</li>
                    </ol>
                </div>
                <!-- /.Start col -->
            </div>
            <!-- /.row (main row) -->
        </div>
        <!--end::Container-->
    </div>
    <!--end::App Content-->
  <div class="container">
    <div class="row justify-content-center">
        <div class="col-md-10">
            <div class="card p-4">
                <div class="row">
                    <!-- Formulario a la izquierda -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="txtRoleName" class="form-label">Nombre de Rol</label>
                            <asp:TextBox runat="server" ID="txtRoleName" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Estado de Rol</label><br />
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" CssClass="form-check">
                                <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <hr />

                        <div class="d-flex gap-2">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/Roles/Roles.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>

                    <!-- Imagen a la derecha -->
                    <div class="col-md-6 d-flex align-items-center justify-content-center">
                        <img src="../../Content/dist/assets/img/rol-del-usuario.png" alt="Imagen Rol" class="img-fluid" style="max-height: 250px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
