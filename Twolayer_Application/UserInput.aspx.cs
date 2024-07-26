using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Twolayer_Application
{
    public partial class UserInput : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            string p = "~/Photo/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string strinsert= "insert into Twolayer  values('"+txtname.Text+"',"+txtage.Text+ ",'" + txtadd.Text + "','" + p + "','" + txtuser.Text + "','" + txtpass.Text + "')";
            int i=ob.Fn_ExeNonQuery(strinsert);
            if (i == 1) {
                Label1.Text = "Inserted Successfully";
                    }
        }

        protected void txtuser_TextChanged(object sender, EventArgs e)
        {

            string s = "select Count(*) from Twolayer where Username='" + txtuser.Text + "'";
            string j = ob.Fn_ExecuteScalar(s).ToString();
            int check = Convert.ToInt32(j);
            if (check > 0)
            {
                Label2.Visible = true;
                Label2.Text = "User Exists";
            }
        }


        
    }
}