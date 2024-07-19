using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.MaterialTransactions
{
    public partial class Create : System.Web.UI.Page
    {
        private static int MaterialTransactionID = 0;
        MaterialsBL materialsBL = new MaterialsBL();
        UsersBL usersBL = new UsersBL();
        MaterialTransactionsBL MaterialTransactionsBL = new MaterialTransactionsBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMaterials();
                CargarUsuarios();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarMaterials()
        {
            List<EntityLayer.Materials> lista = materialsBL.ListMaterials();

            ddlMaterials.DataTextField = "MaterialDescription";
            ddlMaterials.DataValueField = "MaterialID";

            ddlMaterials.DataSource = lista;
            ddlMaterials.DataBind();
        }
        protected void CargarUsuarios()
        {
            List<EntityLayer.Users> lista = usersBL.ListUsers();

            ddlUsers.DataTextField = "UserName";
            ddlUsers.DataValueField = "UserID";

            ddlUsers.DataSource = lista;
            ddlUsers.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue) ||
                string.IsNullOrWhiteSpace(txtMaterialTransactionQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtMaterialTransactionDate.Text) ||
                string.IsNullOrWhiteSpace(ddlMaterials.SelectedValue)||
                string.IsNullOrWhiteSpace(ddlUsers.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                EntityLayer.MaterialTransactions MaterialTransactions = new EntityLayer.MaterialTransactions()
                {
                    MaterialTransactionID = MaterialTransactionID,
                    MaterialTransactionType = Convert.ToString(RadioButtonList1.SelectedValue),
                    MaterialTransactionQuantity = Convert.ToDouble(txtMaterialTransactionQuantity.Text),
                    MaterialTransactionDate = Convert.ToDateTime(txtMaterialTransactionDate.Text),
                    Material = new EntityLayer.Materials() { MaterialID = Convert.ToInt32(ddlMaterials.SelectedValue) },
                    User = new EntityLayer.Users() { UserID = Convert.ToInt32(ddlUsers.SelectedValue) },
                };
                if (MaterialTransactionID == 0)
                {
                    int resultado = MaterialTransactionsBL.CrearMaterialTransactions(MaterialTransactions);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/MaterialTransactions/MaterialTransactions.aspx");
                        string script = $"alert('Transaccion ingresada con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar transaccion");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}