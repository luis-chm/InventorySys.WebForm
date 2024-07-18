<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Collections.aspx.cs" Inherits="InventorySys.WebForm.Pages.Collections.Collections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <li class="breadcrumb-item active" aria-current="page">Collections</li>
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
                        <asp:GridView ID="gvCollections" CssClass="table table-bordered dataTables1" runat="server" AutoGenerateColumns="False" class="table table-bordered">

                            <Columns>
                                <asp:BoundField DataField="CollectionID" HeaderText="ID de Coleccion" />
                                <asp:BoundField DataField="CollectionName" HeaderText="Nombre de coleccion" />
                                <asp:BoundField DataField="CollectionEffect" HeaderText="Efecto de coleccion" />                                                           
                                <asp:TemplateField HeaderText="Estado de coleccion">
                                    <ItemTemplate>
                                        <span class='<%# Convert.ToBoolean(Eval("CollectionActive")) ? "bi bi-check-circle text-success" : "bi bi-x-circle text-danger" %>'></span>
                                          <%# Convert.ToBoolean(Eval("CollectionActive")) ? "Activo" : "Inactivo" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <div class="d-flex justify-content-center">
                                            <asp:LinkButton runat="server" OnClick="btnEditar_Click" CssClass="btn btn-sm btn-primary"
                                                CommandArgument='<% #Eval("CollectionID") %>'><i class="bi bi-pencil-square"></i> Editar</asp:LinkButton>&nbsp;

                                        <asp:LinkButton runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-sm btn-danger"
                                            OnClientClick="return confirm('¿Deseas eliminar la coleccion?')"
                                            CommandArgument='<% #Eval("CollectionID") %>'><i class="bi bi-trash3"></i> Eliminar</asp:LinkButton>&nbsp;
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
            $('.dataTables1').DataTable({
                language: {
                    url: '../../Content/dist/js/es-MX.json'
                },
                stripeClasses: [], // Clases de estilos para filas alternas
                headerCallback: function (thead, data, start, end, display) {
                    $(thead).find('th').css({
                        'background-color': '#333', // Estilo de fondo del encabezado
                        'color': 'white', // Color del texto del encabezado
                        'text-align': 'center' // Centrar el texto del encabezado
                    });
                }
            });
        });
    </script>

</asp:Content>
