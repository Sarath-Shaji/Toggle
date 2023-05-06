using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string log = "select count(Id) from EmployeeTab where Username ='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = obj.Fn_Scalar(log);

            if (cid == "1")
            {

                //string selid = "select Id from EmployeeTab where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                //string id = obj.Fn_Scalar(selid);
                //Session["userid"] = id;
                //Response.Redirect("Home.aspx");

                string emprole = "select Role from EmployeeTab where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                string role = obj.Fn_Scalar(emprole);
                if (role == "Employee")
                {
                    Response.Redirect("HomeEmp.aspx");
                }
                else if(role=="Manager")
                {
                    Response.Redirect("HomeMngr.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Label2.Text = "Login Failed";
            }
            
        }
            
        }
    }
