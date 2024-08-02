<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="InventorySys.WebForm.Views.Users.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.2.2/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Usuarios</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Inicio">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Users</li>
                    </ol>
                </div>
                <!-- /.Start col -->
            </div>
            <!-- /.row (main row) -->
        </div>
        <!--end::Container-->
    </div>
    <!--end::App Content-->
    <div class="card">
        <div class="card-body">
            <div style="margin-left: 15px;">
                <div class="row">
                    <div class="col-12">
                        <asp:LinkButton runat="server" OnClick="btnNuevo_Click" CssClass="btn btn-success">
                    <i class="bi bi-plus-lg"></i> Nuevo
                        </asp:LinkButton>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-11">
                        <asp:GridView ID="gvUsers" CssClass="table table-bordered dataTables1" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="ID de Usuario" />
                                <asp:BoundField DataField="UserName" HeaderText="Nombre de usuario" />
                                <asp:BoundField DataField="UserEmail" HeaderText="Email" />
                                <asp:TemplateField HeaderText="Contraseña">
                                    <ItemTemplate>
                                        <label class="password"><%# new string('*', Eval("UserEncryptedPassword").ToString().Length) %></label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre de Rol">
                                    <ItemTemplate>
                                        <%# Eval("Role.RoleName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <div class="d-flex justify-content-center">
                                            <asp:LinkButton runat="server" OnClick="btnEditar_Click" CssClass="btn btn-sm btn-primary"
                                                CommandArgument='<% #Eval("UserID") %>'><i class="bi bi-pencil-square"></i> Editar</asp:LinkButton>&nbsp;

                                        <asp:LinkButton runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-sm btn-danger"
                                            OnClientClick="return confirm('¿Deseas eliminar al usuario?')"
                                            CommandArgument='<% #Eval("UserID") %>'><i class="bi bi-trash3"></i> Eliminar</asp:LinkButton>&nbsp;
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('.dataTables1').DataTable({
                language: {
                    url: '../../Content/dist/js/es-MX.json'
                },
                stripeClasses: [],
                headerCallback: function (thead, data, start, end, display) {
                    $(thead).find('th').css({
                        'background-color': '#333',
                        'color': 'white',
                        'text-align': 'center'
                    });
                },
                dom: "Bfrtip",
                buttons: [
                    {
                        extend: 'excelHtml5',
                        text: 'Exportar Excel',
                        filename: 'Reporte Usuarios',
                        title: 'Lista de Usuarios',
                        exportOptions: {
                            columns: [0, 1, 2, 3]
                        }
                    }
                ]
            });

            // Aplica el estilo después de la inicialización
            $('.buttons-excel').addClass('btn btn-info');
        });
    </script>
</asp:Content>
