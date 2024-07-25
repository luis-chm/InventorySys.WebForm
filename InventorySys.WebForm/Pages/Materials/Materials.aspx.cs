using BussinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Materials
{
    public partial class Materials : System.Web.UI.Page
    {
        readonly MaterialsBL MaterialsBL = new MaterialsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarMaterials();
        }
        private void MostrarMaterials()
        {

            List<EntityLayer.Materials> lista = MaterialsBL.ListMaterials();
            gvMaterials.DataSource = lista;
            gvMaterials.DataBind();

            gvMaterials.UseAccessibleHeader = true;
            if (gvMaterials.HeaderRow != null)
            {
                gvMaterials.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvMaterials.FooterRow != null)
            {
                gvMaterials.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Materials/Create.aspx?MaterialID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string MaterialID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Materials/Edit.aspx?MaterialID={MaterialID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string MaterialID = btn.CommandArgument;
            EntityLayer.Materials material = MaterialsBL.ObtenerMaterial(Convert.ToInt32(MaterialID));
            if (material != null)
            {
                int respuesta = MaterialsBL.EliminarMaterials(material.MaterialID);
                DeleteImage(material.MaterialIMG);
                if (respuesta > 0)
                {
                    Alertas("El material ha sido eliminado con éxito");
                    MostrarMaterials();
                }
                else
                {
                    Alertas("Ha ocurrido un error al borrar el registro");
                }
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