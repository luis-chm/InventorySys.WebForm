using BussinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;

namespace InventorySys.WebForm.Pages.Materials
{
    public partial class Create : System.Web.UI.Page
    {
        private static int MaterialID = 0;
        CollectionsBL collectionsBL = new CollectionsBL();
        FinituresBL finituresBL = new FinituresBL();
        FormatsBL formatsBL = new FormatsBL();
        SitesBL sitesBL = new SitesBL();
        MaterialsBL MaterialsBL = new MaterialsBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCollections();
                CargarFinitures();
                CargarFormats();
                CargarSites();
                MostrarUsuarioActual();

                //Limitar a NUM no negativos
                txtMaterialStock.Attributes["min"] = "0";
                txtMaterialStock.Attributes["oninput"] = "this.value = Math.abs(this.value)";
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        private void MostrarUsuarioActual()
        {
            if (SessionHelper.IsUserLoggedIn())
            {
                var usuario = SessionHelper.GetCurrentUser();
                txtUsuarioActual.Text = usuario.UserName;
                txtUsuarioActual.Visible = true;
            }
        }
        protected void CargarCollections()
        {
            List<EntityLayer.Collections> lista = collectionsBL.ListCollections();

            ddlCollections.DataTextField = "CollectionName";
            ddlCollections.DataValueField = "CollectionID";

            ddlCollections.DataSource = lista;
            ddlCollections.DataBind();
        }
        protected void CargarFinitures()
        {
            List<EntityLayer.Finitures> lista = finituresBL.ListFinitures();

            ddlFinitures.DataTextField = "FinitureName";
            ddlFinitures.DataValueField = "FinitureID";

            ddlFinitures.DataSource = lista;
            ddlFinitures.DataBind();
        }
        protected void CargarFormats()
        {
            List<EntityLayer.Formats> lista = formatsBL.ListFormats();

            ddlFormats.DataTextField = "FormatName";
            ddlFormats.DataValueField = "FormatID";

            ddlFormats.DataSource = lista;
            ddlFormats.DataBind();
        }
        protected void CargarSites()
        {
            List<EntityLayer.Sites> lista = sitesBL.ListSites();

            ddlSites.DataTextField = "SiteName";
            ddlSites.DataValueField = "SiteID";

            ddlSites.DataSource = lista;
            ddlSites.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!SessionHelper.IsUserLoggedIn())
            {
                Alertas("Su sesión ha expirado. Por favor, inicie sesión nuevamente.");
                Response.Redirect("~/Pages/Login/Login.aspx");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaterialCode.Text) ||
                string.IsNullOrWhiteSpace(txtMaterialDescription.Text) ||
                string.IsNullOrWhiteSpace(ddlCollections.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlFinitures.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlFormats.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlSites.SelectedValue) ||
                !fileUploadImage.HasFile ||
                string.IsNullOrWhiteSpace(txtMaterialReceivedDate.Text) ||
                string.IsNullOrWhiteSpace(txtMaterialStock.Text)
                )
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            // Validar la extensión del archivo
            string fileExtension = Path.GetExtension(fileUploadImage.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
            {
                Alertas("El archivo seleccionado no es una imagen válida.");
                return;
            }

            try
            {

                string fileName = Path.GetFileName(fileUploadImage.PostedFile.FileName);
                string uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmss}_{fileName}";
                // Definir la ruta de destino en la carpeta del proyecto
                string uploadPath = Server.MapPath("~/UploadedImages/");
                string fullPath = Path.Combine(uploadPath, uniqueFileName);


                // Crear la carpeta si no existe
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Guardar el archivo en la carpeta
                fileUploadImage.SaveAs(fullPath);
                // Validar que el stock sea un número positivo
                if (!double.TryParse(txtMaterialStock.Text, out double stock) || stock < 0)
                {
                    Alertas("El stock debe ser un número mayor o igual a 0.");
                    return;
                }
                //obtener datos digitados
                EntityLayer.Materials Materials = new EntityLayer.Materials()
                {
                    MaterialID = MaterialID,
                    MaterialCode = txtMaterialCode.Text,
                    MaterialDescription = txtMaterialDescription.Text,
                    Collection = new EntityLayer.Collections() { CollectionID = Convert.ToInt32(ddlCollections.SelectedValue) },
                    Finiture = new EntityLayer.Finitures() { FinitureID = Convert.ToInt32(ddlFinitures.SelectedValue) },
                    Format = new EntityLayer.Formats() { FormatID = Convert.ToInt32(ddlFormats.SelectedValue) },
                    Site = new EntityLayer.Sites() { SiteID = Convert.ToInt32(ddlSites.SelectedValue) },
                    MaterialIMG = fileName,
                    MaterialReceivedDate = Convert.ToDateTime(txtMaterialReceivedDate.Text),
                    MaterialStock = Convert.ToDouble(txtMaterialStock.Text),
                    User = new EntityLayer.Users() { UserID = SessionHelper.GetCurrentUserID() }
                };
                if (MaterialID == 0)
                {
                    int resultado = MaterialsBL.CrearMaterials(Materials);

                    if (resultado > 0)
                    {
                        string currentUserName = SessionHelper.GetCurrentUserName();
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Materials/Materials.aspx");
                        string script = $"alert('Material ingresado con éxito por {currentUserName}'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar material");
                    }
                }
            }

            catch (Exception ex)
            {
                Alertas($"Error: {ex.Message}");
            }
        }
    }
}