using BussinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Materials
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int MaterialID = 0;
        private static string Old_MaterialIMG = string.Empty;
        MaterialsBL MaterialsBL = new MaterialsBL();
        CollectionsBL collectionsBL = new CollectionsBL();
        FinituresBL finituresBL = new FinituresBL();
        FormatsBL formatsBL = new FormatsBL();
        SitesBL sitesBL = new SitesBL();
        UsersBL usersBL = new UsersBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCollections();
                CargarFinitures();
                CargarFormats();
                CargarSites();
                CargarUsers();
                CargarMaterial();
            }
           
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarCollections(string CollectionID = "")
        {
            List<EntityLayer.Collections> lista = collectionsBL.ListCollections();

            ddlCollections.DataTextField = "CollectionName";
            ddlCollections.DataValueField = "CollectionID";

            ddlCollections.DataSource = lista;
            ddlCollections.DataBind();

            if (CollectionID != "")
                ddlCollections.SelectedValue = CollectionID;
        }
        protected void CargarFinitures(string FinitureID = "")
        {
            List<EntityLayer.Finitures> lista = finituresBL.ListFinitures();

            ddlFinitures.DataTextField = "FinitureName";
            ddlFinitures.DataValueField = "FinitureID";

            ddlFinitures.DataSource = lista;
            ddlFinitures.DataBind();

            if (FinitureID != "")
                ddlFinitures.SelectedValue = FinitureID;
        }
        protected void CargarFormats(string FormatID = "")
        {
            List<EntityLayer.Formats> lista = formatsBL.ListFormats();

            ddlFormats.DataTextField = "FormatName";
            ddlFormats.DataValueField = "FormatID";

            ddlFormats.DataSource = lista;
            ddlFormats.DataBind();

            if (FormatID != "")
                ddlFormats.SelectedValue = FormatID;
        }
        protected void CargarSites(string SiteID = "")
        {
            List<EntityLayer.Sites> lista = sitesBL.ListSites();

            ddlSites.DataTextField = "SiteName";
            ddlSites.DataValueField = "SiteID";

            ddlSites.DataSource = lista;
            ddlSites.DataBind();

            if (SiteID != "")
                ddlSites.SelectedValue = SiteID;
        }
        protected void CargarUsers(string UserID = "")
        {
            List<EntityLayer.Users> lista = usersBL.ListUsers();

            ddlUsers.DataTextField = "UserName";
            ddlUsers.DataValueField = "UserID";

            ddlUsers.DataSource = lista;
            ddlUsers.DataBind();

            if (UserID != "")
                ddlSites.SelectedValue = UserID;
        }

        protected void CargarMaterial()
        {
            if (Request.QueryString["MaterialID"] != null)
            {
                MaterialID = Convert.ToInt32(Request.QueryString["MaterialID"].ToString());
                if (MaterialID != 0)
                {
                    EntityLayer.Materials Materials = MaterialsBL.ObtenerMaterial(MaterialID);
                    txtMaterialCode.Text = Materials.MaterialCode;
                    txtMaterialDescription.Text = Materials.MaterialDescription;
                    CargarCollections(Materials.CollectionID.ToString());
                    CargarFinitures(Materials.CollectionID.ToString());
                    CargarFormats(Materials.CollectionID.ToString());
                    CargarSites(Materials.CollectionID.ToString());
                    txtMaterialReceivedDate.Text = Materials.MaterialReceivedDate.ToString("yyyy-MM-dd");
                    txtMaterialStock.Text = Materials.MaterialStock.ToString();
                    CargarUsers(Materials.CollectionID.ToString());
                    Old_MaterialIMG = Materials.MaterialIMG;
                    imgMaterialImage.ImageUrl = "~/UploadedImages/" + Old_MaterialIMG;
                }
                else
                {
                    Response.Redirect("~/Pages/Materials/Materials.aspx");
                }
            }
        }
        protected void btnAactualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaterialCode.Text) ||
                string.IsNullOrWhiteSpace(txtMaterialDescription.Text) ||
                string.IsNullOrWhiteSpace(ddlCollections.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlFinitures.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlFormats.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlSites.SelectedValue) ||
                string.IsNullOrWhiteSpace(txtMaterialReceivedDate.Text) ||
                string.IsNullOrWhiteSpace(txtMaterialStock.Text) ||
                string.IsNullOrWhiteSpace(ddlUsers.SelectedValue)
                )
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                 string MaterialIMG = string.Empty;
                if (fileUploadImage.HasFile)
                {
                    // Validar la extensión del archivo
                    string fileExtension = Path.GetExtension(fileUploadImage.FileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        Alertas("El archivo seleccionado no es una imagen válida.");
                        return;
                    }
                    string fileName = Path.GetFileName(fileUploadImage.PostedFile.FileName);

                    // Definir la ruta de destino en la carpeta del proyecto
                    string uploadPath = Server.MapPath("~/UploadedImages/");
                    string fullPath = Path.Combine(uploadPath, fileName);

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    // Guardar el archivo en la carpeta
                    fileUploadImage.SaveAs(fullPath);
                    MaterialIMG = fileName;
                }
                if (string.IsNullOrWhiteSpace(MaterialIMG))
                {
                    MaterialIMG = Old_MaterialIMG;
                }
                else {
                    // elimina la vieja imagen de la carpeta de imagenes
                    DeleteImage(Old_MaterialIMG);
                }

                EntityLayer.Materials Materials = new EntityLayer.Materials()
                {
                    MaterialID = MaterialID,
                    MaterialCode = txtMaterialCode.Text,
                    MaterialDescription = txtMaterialDescription.Text,
                    Collection = new EntityLayer.Collections() { CollectionID = Convert.ToInt32(ddlCollections.SelectedValue) },
                    Finiture = new EntityLayer.Finitures() { FinitureID = Convert.ToInt32(ddlFinitures.SelectedValue) },
                    Format = new EntityLayer.Formats() { FormatID = Convert.ToInt32(ddlFormats.SelectedValue) },
                    Site = new EntityLayer.Sites() { SiteID = Convert.ToInt32(ddlSites.SelectedValue) },
                    MaterialIMG = MaterialIMG,
                    MaterialReceivedDate = Convert.ToDateTime(txtMaterialReceivedDate.Text),
                    MaterialStock = Convert.ToDouble(txtMaterialStock.Text),
                    User = new EntityLayer.Users() { UserID = Convert.ToInt32(ddlUsers.SelectedValue) },
                };
                if (MaterialID != 0)
                {
                    int resultado = MaterialsBL.EditarMaterials(Materials);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Materials/Materials.aspx");
                        string script = $"alert('Material actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar material");
                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void DeleteImage(string fileName)
        {
            try
            {
                // Construir la ruta completa del archivo
                string filePath = HttpContext.Current.Server.MapPath("~/UploadedImages/" + fileName);

                // Verificar si el archivo existe
                if (File.Exists(filePath))
                {
                    // Eliminar el archivo
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine(ex.ToString());
            }
        }

    }
}