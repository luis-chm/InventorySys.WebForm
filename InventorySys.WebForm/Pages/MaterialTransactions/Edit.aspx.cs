using BussinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace InventorySys.WebForm.Pages.MaterialTransactions
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int MaterialTransactionID = 0;
        MaterialsBL materialsBL = new MaterialsBL();
        MaterialTransactionsBL materialTransactionsBL = new MaterialTransactionsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMaterials();
                CargarMaterialTransaccions();
                MostrarUsuarioActual();
                txtMaterialTransactionQuantity.Attributes["min"] = "0";
                txtMaterialTransactionQuantity.Attributes["oninput"] = "this.value = Math.abs(this.value)";
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
        protected void CargarMaterials(string MaterialID = "")
        {
            List<EntityLayer.Materials> lista = materialsBL.ListMaterials();

            ddlMaterials.DataTextField = "MaterialDescription";
            ddlMaterials.DataValueField = "MaterialID";

            ddlMaterials.DataSource = lista;
            ddlMaterials.DataBind();

            if (MaterialID != "")
                ddlMaterials.SelectedValue = MaterialID;
        }
        protected void CargarMaterialTransaccions()
        {
            if (Request.QueryString["MaterialTransactionID"] != null)
            {
                MaterialTransactionID = Convert.ToInt32(Request.QueryString["MaterialTransactionID"].ToString());

                if (MaterialTransactionID != 0)
                {
                    EntityLayer.MaterialTransactions materialTransaccions = materialTransactionsBL.ObtenerMaterialTransaction(MaterialTransactionID);
                    RadioButtonList1.SelectedValue = materialTransaccions.MaterialTransactionType;
                    txtMaterialTransactionDate.Text = materialTransaccions.MaterialTransactionDate.ToString("yyyy-MM-dd");
                    txtMaterialTransactionQuantity.Text = materialTransaccions.MaterialTransactionQuantity.ToString();
                    CargarMaterials(materialTransaccions.MaterialID.ToString());
                }
                else
                {
                    Response.Redirect("~/Pages/MaterialTransaccions/MaterialTransaccions.aspx");
                }
            }
        }
        protected void btnAactualizar_Click(object sender, EventArgs e)
        {
            if (!SessionHelper.IsUserLoggedIn())
            {
                Alertas("Su sesión ha expirado. Por favor, inicie sesión nuevamente.");
                Response.Redirect("~/Pages/Login/Login.aspx");
                return;
            }
            if (string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue) ||
              string.IsNullOrWhiteSpace(txtMaterialTransactionQuantity.Text) ||
              string.IsNullOrWhiteSpace(txtMaterialTransactionDate.Text) ||
              string.IsNullOrWhiteSpace(ddlMaterials.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                EntityLayer.MaterialTransactions materialTransactions = new EntityLayer.MaterialTransactions()
                {
                    MaterialTransactionID = MaterialTransactionID,
                    MaterialTransactionType = Convert.ToString(RadioButtonList1.SelectedValue),
                    MaterialTransactionQuantity = Convert.ToDouble(txtMaterialTransactionQuantity.Text),
                    MaterialTransactionDate = Convert.ToDateTime(txtMaterialTransactionDate.Text),
                    Material = new EntityLayer.Materials() { MaterialID = Convert.ToInt32(ddlMaterials.SelectedValue) },
                    User = new EntityLayer.Users() { UserID = SessionHelper.GetCurrentUserID() }
                };
                if (MaterialTransactionID != 0)
                {
                    int resultado = materialTransactionsBL.EditarMaterialTransactions(materialTransactions);

                    if (resultado > 0)
                    {
                        string currentUserName = SessionHelper.GetCurrentUserName();
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/MaterialTransactions/MaterialTransactions.aspx");
                        string script = $"alert('Transacción actualizada con éxito por {currentUserName}'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar transaccion");
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