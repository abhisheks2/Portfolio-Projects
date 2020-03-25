using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;
using System.Data;

namespace DCMS
{
    public partial class MedicineCenter : System.Web.UI.Page
    {
        DataSet d;
        protected void Page_Load(object sender, EventArgs e)
        {
            d = new InventoryDAO().getMedicine();
            if (d != null)
            {
                if (d.Tables[0].Rows.Count != 0)
                {
                    Inventory.DataSource = d;
                    Inventory.DataBind();
                }
                else
                {
                    Inventory.DataSource = null;
                    Inventory.DataBind();
                }
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateInventory.aspx");
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInventory.aspx");
        }

        protected void Inventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.fontWeight = 'bold';");
                e.Row.Attributes.Add("onmouseout", "this.style.fontWeight= 'normal';");
            }
        }
    }
}