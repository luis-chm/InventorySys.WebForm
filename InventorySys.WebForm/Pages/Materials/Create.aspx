<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Menu.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="InventorySys.WebForm.Pages.Materials.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

<div class="app-content-header">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <h3 class="mb-0">Nuevo Material</h3>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-end">
                    <li class="breadcrumb-item"><a href="/Pages/Materials/Materials.aspx">Materials</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Crear Material</li>
                </ol>
            </div>
        </div>
    </div>
</div>

<!-- Formulario en dos columnas -->
<div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-10">
            <div class="card p-4">
                <div class="row">
                    <!-- Columna izquierda -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtMaterialCode" CssClass="form-label">Código de Material</asp:Label>
                            <asp:TextBox runat="server" ID="txtMaterialCode" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtMaterialDescription" CssClass="form-label">Descripción de Material</asp:Label>
                            <asp:TextBox runat="server" ID="txtMaterialDescription" CssClass="form-control" required="required" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlCollections" CssClass="form-label">Colección</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlCollections" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione una colección</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlFinitures" CssClass="form-label">Acabado</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlFinitures" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione un acabado</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlFormats" CssClass="form-label">Formato</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlFormats" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione un formato</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlSites" CssClass="form-label">Sitio</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlSites" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione un sitio</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Columna derecha -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlUsers" CssClass="form-label">Usuario</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlUsers" CssClass="form-select">
                                <asp:ListItem Value="">Seleccione un usuario</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="fileUploadImage" CssClass="form-label">Imagen</asp:Label>
                            <asp:FileUpload ID="fileUploadImage" runat="server" OnChange="onFileChange()" />
                        </div>

                        <div class="mb-3">
                            <asp:Image ID="imgMaterialImage" runat="server" ImageUrl="~/UploadedImages/default.jpg" AlternateText="Descripción de la imagen" Width="100px" Height="100px" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtMaterialReceivedDate" CssClass="form-label">Fecha de Arribo</asp:Label>
                            <asp:TextBox runat="server" ID="txtMaterialReceivedDate" CssClass="form-control" TextMode="Date" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtMaterialStock" CssClass="form-label">Stock</asp:Label>
                            <asp:TextBox runat="server" ID="txtMaterialStock" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>
                </div>

                <!-- Botones -->
                <div class="mt-4 text-end">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                    <asp:LinkButton runat="server" PostBackUrl="~/Pages/Materials/Materials.aspx" CssClass="btn btn-warning ms-2">Volver</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</div>

    <script type="text/javascript">
        function onFileChange() {
            var fileUpload = document.getElementById('<%= fileUploadImage.ClientID %>');

              if (fileUpload.files.length > 0) {
                  var file = fileUpload.files[0];
                  var formData = new FormData();
                  formData.append('file', file);

                  fetch('FileUploadHandler.ashx', {
                      method: 'POST',
                      body: formData,
                      headers: {
                          'X-Requested-With': 'XMLHttpRequest'
                      }
                  })
                      .then(response => response.json())
                      .then(data => {
                          // Manejar la respuesta del servidor
                          if (data.result === "success") {
                              // Actualizar la imagen en la página
                              document.getElementById('<%= imgMaterialImage.ClientID %>').src = data.imageUrl;
              } else {
                  alert('Error: ' + data.result);
              }
          })
                    .catch(error => {
                        // Manejar errores
                        alert('Error:', error);
                    });
            }
        }
    </script>
</asp:Content>
