using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Twolayer_Application
{
    public partial class GridViewPage : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Gridbind();
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {


            try
            {
                GridViewRow r = GridView1.Rows[e.NewSelectedIndex];
                Label1.Text = r.Cells[3].Text;
                Image1.ImageUrl = r.Cells[6].Text;
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                Response.Write("Error: " + ex.Message);
            }
            //Cells[5].Text;

        }
        public void Gridbind()
        {
            string sl = "select * from Twolayer ";
            DataSet ds = ob.Fn_Exeadpter(sl);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Gridbind();
        }
    }
}