using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InventorySys.WebForm.Pages.Materials
{
    /// <summary>
    /// Descripción breve de FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    var postedFile = context.Request.Files[0];
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string targetPath = context.Server.MapPath("~/UploadedImages/") + fileName;

                    // Crear el directorio si no existe
                    if (!Directory.Exists(context.Server.MapPath("~/UploadedImages/")))
                    {
                        Directory.CreateDirectory(context.Server.MapPath("~/UploadedImages/"));
                    }

                    // Guardar el archivo
                    postedFile.SaveAs(targetPath);

                    // Retornar la ruta de la imagen como JSON
                    context.Response.Write("{\"result\":\"success\",\"imageUrl\":\"/UploadedImages/" + fileName + "\"}");
                }
                else
                {
                    context.Response.Write("{\"result\":\"No file selected or uploaded.\"}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones y retornar un error JSON
                context.Response.Write("{\"result\":\"File upload failed: " + ex.Message + "\"}");
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}