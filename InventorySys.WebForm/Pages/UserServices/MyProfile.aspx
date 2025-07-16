<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="InventorySys.WebForm.Pages.UserServices.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="app-content-header">
        <!--begin::Container-->
        <div class="container-fluid">
            <!--begin::Row-->
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Mi Perfil</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Pages/Inicio">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Mi Perfil</li>
                    </ol>
                </div>
                <!-- /.Start col -->
            </div>
            <!-- /.row (main row) -->
        </div>
        <!--end::Container-->
    </div>
    <section class="vh-40 gradient-custom">
        <div class="container py-5 h-40">
            <div class="row justify-content-center align-items-center h-40">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5">Mi Informacion</h3>
                            <div class="row">
                                <div class="col-md-6 mb-4">
                                    <div class="form-outline">
                                        <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control form-control-lg" disabled="true"></asp:TextBox>
                                        <label class="form-label" for="txtUserID">User ID</label>
                                    </div>
                                </div>
                                <div class="col-md-6 mb-4">
                                    <div class="form-outline">
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-control-lg" disabled="true"></asp:TextBox>
                                        <label class="form-label" for="txtUserName">Nombre de Usuario</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 mb-4">
                                    <div class="form-outline">
                                        <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control form-control-lg" disabled="true"></asp:TextBox>
                                        <label class="form-label" for="txtUserEmail">Email</label>
                                    </div>
                                </div>
                                <div class="col-md-6 mb-4">
                                    <div class="form-outline">                                                                                                               
                                        <asp:TextBox runat="server" ID="txtUserEncryptedPassword" CssClass="form-control" disabled="true"></asp:TextBox>                                
                                        <label class="form-label" for="txtUserEncryptedPassword">Password</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-outline">
                                        <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control form-control-lg" disabled="true"></asp:TextBox>
                                        <label class="form-label" for="txtRoleName">Nombre de Rol</label>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-4 pt-2">
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/Inicio" CssClass="btn btn-warning">Volver</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
