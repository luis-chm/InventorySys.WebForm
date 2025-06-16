<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master"  AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.Users.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!-- Encabezado -->
<div class="app-content-header">
    <div class="container-fluid">
        <div class="row mb-3">
            <div class="col-sm-6">
                <h3 class="mb-0">Nuevo Usuario</h3>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-end">
                    <li class="breadcrumb-item"><a href="/Pages/Users/Users.aspx">Usuarios</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Crear Usuario</li>
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
                    <!-- Formulario -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="form-label">Nombre de Usuario</asp:Label>
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtUserEmail" CssClass="form-label">Correo Electrónico</asp:Label>
                            <asp:TextBox runat="server" ID="txtUserEmail" CssClass="form-control" TextMode="Email" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="form-label">Contraseña</asp:Label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" required="required" />
                                <button class="btn btn-outline-dark bi bi-eye-slash password-toggle" type="button" id="togglePassword"></button>
                            </div>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlRoles" CssClass="form-label">Rol</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione un rol</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <hr />

                        <div class="d-flex gap-2">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/Users/Users.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                        </div>
                    </div>

                    <!-- Imagen decorativa -->
                    <div class="col-md-6 d-flex align-items-center justify-content-center">
                        <img src="../../Content/dist/assets/img/agregar-usuario.png" alt="Imagen Usuario" class="img-fluid" style="max-height: 300px;" />
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

