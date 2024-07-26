using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Twolayer_Application
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string sel = "select Count(Id) from Twolayer where Username='" + TextBox1.Text + "'and Password ='"+TextBox2.Text+"'";
            string cid = ob.Fn_ExecuteScalar(sel);
            
            if (cid == "1")
            {

               // int id1 = 0;
               string sl= "select Id from Twolayer where Username='" + TextBox1.Text + "'and Password ='" + TextBox2.Text + "'";
                string cid1 = ob.Fn_ExecuteScalar(sl);
                //SqlDataReader d = ob.Fn_ExecuteReader(sl);
                ////dr- containing information retrieved from a database query.
                //while (d.Read())//while (dr.Read()): This loop iterates through each row in the DataReader's result set
                //{
                //    id1=Convert.ToInt32(d["id"].ToString());


                //}
                Session["uid"] = cid1;
                //Response.Redirect("Displayuser.aspx");
                Response.Redirect("GridViewPage.aspx");

            }
            else
            {
                Label1.Text = "Invalid Username or Password";
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
;           
        }
    }
}