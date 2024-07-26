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
    public partial class Displayuser : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select * from Twolayer where Id="+Session["uid"]+"";
            SqlDataReader dr = ob.Fn_ExecuteReader(sel);
            while (dr.Read())
            {
                TextBox1.Text = dr["Name"].ToString();
                TextBox2.Text = dr["Age"].ToString();
                TextBox3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["Photo"].ToString();
                TextBox4.Text = dr["Username"].ToString();
                TextBox5.Text = dr["Password"].ToString();

            }
            DataSet ds = ob.Fn_Exeadpter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            DataTable dt = ob.Fn_Exedatatable(sel);
            DataList1.DataSource = dt;
            DataList1.DataBind();


        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}