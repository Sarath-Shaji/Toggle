using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Project
{
    public partial class ViewProjectsMngr : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid_Bind();
            }

        }

        public void Grid_Bind()
        {
            string sel = "select * from ProjTab";
            DataSet ds = obj.Fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Grid_Bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Console.WriteLine(GridView1.DataKeys);
            GridView1.EditIndex = e.NewEditIndex;
            Grid_Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int usrid = Convert.ToInt32(GridView1.DataKeys[i].Value);

            TextBox TextBox1 = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
            TextBox TextBox2 = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            TextBox TextBox3 = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];


            string upd = "update ProjTab set ProjName='" + TextBox1.Text + "' ,ProjTime='" + TextBox2.Text + "',ProjDesc='" + TextBox3.Text + "' where ProjId="+usrid+" ";
            int b = obj.Fn_Nonquery(upd);

            GridView1.EditIndex = -1;
            Grid_Bind();
        }
    }



}