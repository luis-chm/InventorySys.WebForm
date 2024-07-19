using BussinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.MaterialTransactions
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int MaterialTransactionID = 0;
        MaterialsBL materialsBL = new MaterialsBL();
        UsersBL usersBL = new UsersBL();
        MaterialTransactionsBL materialTransactionsBL = new MaterialTransactionsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMaterials();
                CargarUsuarios();
                CargarMaterialTransaccions();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
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
        protected void CargarUsuarios(string UserID = "")
        {
            List<EntityLayer.Users> lista = usersBL.ListUsers();

            ddlUsers.DataTextField = "UserName";
            ddlUsers.DataValueField = "UserID";

            ddlUsers.DataSource = lista;
            ddlUsers.DataBind();

            if (UserID != "")
                ddlUsers.SelectedValue = UserID;
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
                    CargarUsuarios(materialTransaccions.UserID.ToString());
                }
                else
                {
                    Response.Redirect("~/Pages/MaterialTransaccions/MaterialTransaccions.aspx");
                }
            }
        }
        protected void btnAactualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue) ||
              string.IsNullOrWhiteSpace(txtMaterialTransactionQuantity.Text) ||
              string.IsNullOrWhiteSpace(txtMaterialTransactionDate.Text) ||
              string.IsNullOrWhiteSpace(ddlMaterials.SelectedValue) ||
              string.IsNullOrWhiteSpace(ddlUsers.SelectedValue))
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
                    User = new EntityLayer.Users() { UserID = Convert.ToInt32(ddlUsers.SelectedValue) },
                };
                if (MaterialTransactionID != 0)
                {
                    int resultado = materialTransactionsBL.EditarMaterialTransactions(materialTransactions);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/MaterialTransactions/MaterialTransactions.aspx");
                        string script = $"alert('Transaccion actualizada con éxito'); window.location.href='{url}';";
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

                throw ex;
            }
        }
    }
}