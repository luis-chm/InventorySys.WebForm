<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InventorySys.WebForm.Pages.Users.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Editar Usuario</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Users/Users.aspx">Users</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Editar Usuario</li>
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
                                <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="form-label">Nombre de Usuario</asp:Label>
                                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtUserEmail" CssClass="form-label">Correo Electrónico</asp:Label>
                                <asp:TextBox runat="server" ID="txtUserEmail" CssClass="form-control" TextMode="Email" required="required" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="form-label">Contraseña</asp:Label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" required="required"></asp:TextBox>
                                    <button class="btn btn-outline-dark bi bi-eye-slash password-toggle" type="button" id="togglePassword"></button>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlRoles" CssClass="form-label">Rol</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un rol</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnAactualizar" class="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnAactualizar_Click" />
                            &nbsp;&nbsp;&nbsp;
                         <asp:LinkButton runat="server" PostBackUrl="~/Pages/Users/Users.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>
                </div>
    </div>
        </div>
    </div>

    <script>
        const togglePassword = document.querySelector('#togglePassword');
        const password = document.querySelector('#<%= txtPassword.ClientID %>');

        togglePassword.addEventListener('click', function (e) {
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            this.classList.toggle('bi-eye');
            this.classList.toggle('bi-eye-slash');
        });
    </script>

</asp:Content>
