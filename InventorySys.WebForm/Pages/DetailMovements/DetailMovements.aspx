<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="DetailMovements.aspx.cs" Inherits="InventorySys.WebForm.Pages.DetailMovements.DetailMovements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Detalles de Transacciones</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Inicio">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Detalles de Transacciones</li>
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
                <br />
                <div class="row">
                    <div class="col-11">
                        <asp:GridView ID="gvDetailMovements" CssClass="table table-bordered dataTables1" runat="server" AutoGenerateColumns="False" class="table table-bordered">

                            <Columns>
                                <asp:TemplateField HeaderText="Codigo Material">
                                    <ItemTemplate>
                                        <%# Eval("MaterialTransaction.Material.MaterialCode") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripcion Material">
                                    <ItemTemplate>
                                        <%# Eval("MaterialTransaction.Material.MaterialDescription") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha de la transaccion">
                                    <ItemTemplate>
                                        <%# Eval("MaterialTransaction.MaterialTransactionDate", "{0:yyyy-MM-dd}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo de transaccion">
                                    <ItemTemplate>
                                        <%# Eval("MaterialTransaction.MaterialTransactionType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DetInitBalance" HeaderText="Cantidad Inicial" />
                                <asp:BoundField DataField="DetCantEntry" HeaderText="Cantidad Ingresada" />
                                <asp:BoundField DataField="DetCantExit" HeaderText="Cantidad Retirada" />
                                <asp:BoundField DataField="DetCurrentBalance" HeaderText="Cantidad Actual" />
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
