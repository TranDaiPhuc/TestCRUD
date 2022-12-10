using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class _Default : Page
    {
        string sqls = ConfigurationManager.ConnectionStrings["sqlscon"].ConnectionString;
        SqlConnection sqlsconnection;
        SqlCommand sqlscommand;
        SqlDataAdapter sqldata;
        DataTable data = new DataTable();
        DataTable inputdata = new DataTable();
        string[] keyname = { "PO", "Model_Name", "Model_Number", "Article", "Quantity", "Lean", "Planned_Date", "CRD", "PD", "Country", "Onhand" };

        private void LoadSQL()
        {
            using (sqlsconnection = new SqlConnection(sqls))
            {
                data = new DataTable();
                sqlscommand = new SqlCommand(" Select TOP 20 " +
                    " PO, Model_Name, Model_Number,Article, Order_Quantity as Quantity, Building as Lean, Planned_Date, CFD as CRD, PD, Country, Onhand " +
                    " From Schedule " +
                    " Order by PO ", sqlsconnection);
                sqldata = new SqlDataAdapter(sqlscommand);
                data.Reset();
                sqldata.Fill(data);
                
            }
            GridView1.DataSource = data;
            GridView1.DataKeyNames = keyname;
            GridView1.DataBind();
            GridView1.HeaderRow.BackColor = System.Drawing.Color.Black;
            GridView1.HeaderRow.ForeColor = System.Drawing.Color.White;
            GridView1.HeaderRow.Cells[0].BackColor = System.Drawing.Color.White;
            GridView1.HeaderRow.Cells[0].ForeColor = System.Drawing.Color.Black;
        }

        private void ClearData()
        {
            LoadSQL();
            LoadInfo(" ");
        }

        private void LoadInfo(string PO)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                row.ForeColor = System.Drawing.Color.Black;
            }

            using (sqlsconnection = new SqlConnection(sqls))
            {
                sqlsconnection.Open();
                inputdata = new DataTable();
                sqlscommand = new SqlCommand(" Select PO, Model_Name, Model_Number,Article, Order_Quantity as Quantity, Building as Lean, Planned_Date, CFD as CRD, PD, Country, Onhand " +
                    " From Schedule " +
                    " Where PO = '" + PO + "'", sqlsconnection);
                sqldata = new SqlDataAdapter(sqlscommand);
                inputdata.Reset();
                sqldata.Fill(inputdata);
                sqlsconnection.Close();
            }

            if (inputdata.Rows.Count > 0)
            {
                TextBox1.Text = inputdata.Rows[0]["PO"].ToString();
                TextBox2.Text = inputdata.Rows[0]["Model_Name"].ToString();
                TextBox3.Text = inputdata.Rows[0]["Model_Number"].ToString();
                TextBox4.Text = inputdata.Rows[0]["Article"].ToString();
                TextBox5.Text = inputdata.Rows[0]["Quantity"].ToString();
                TextBox6.Text = inputdata.Rows[0]["Lean"].ToString();
                TextBox7.Text = inputdata.Rows[0]["Planned_Date"].ToString();
                TextBox8.Text = inputdata.Rows[0]["CRD"].ToString();
                TextBox9.Text = inputdata.Rows[0]["PD"].ToString();
                TextBox10.Text = inputdata.Rows[0]["Country"].ToString();
                TextBox11.Text = inputdata.Rows[0]["Onhand"].ToString();

                GridView1.SelectedRow.BackColor = System.Drawing.Color.Blue;
                GridView1.SelectedRow.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSQL();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (sqlsconnection = new SqlConnection(sqls))
            {
                if (!string.IsNullOrWhiteSpace(TextBox1.Text))
                {
                    sqlsconnection.Open();
                    inputdata = new DataTable();
                    sqlscommand = new SqlCommand(" Update Schedule " +
                        " Set PO = '" + TextBox1.Text + "', " +
                        " Model_Name = '" + TextBox2.Text + "', " +
                        " Model_Number = '" + TextBox3.Text + "', " +
                        " Article = '" + TextBox4.Text + "', " +
                        " Order_Quantity = '" + TextBox5.Text + "', " +
                        "Building = '" + TextBox6.Text + "', " +
                        "Planned_Date = '" + TextBox7.Text + "', " +
                        "CFD = '" + TextBox8.Text + "', " +
                        "PD = '" + TextBox9.Text + "', " +
                        "Country = '" + TextBox10.Text + "', " +
                        "Onhand = '" + TextBox11.Text + "' " +
                        " Where PO = '" + TextBox1.Text + "' " +
                        " IF @@ROWCOUNT = 0 " +
                        " INSERT INTO [Schedule] (PO, Model_Name, Model_Number, Article, Order_Quantity, Building, Planned_Date, CFD, PD, Country, Onhand) " +
                        " VALUES ( '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox7.Text + "', '" + TextBox8.Text + "', '" + TextBox9.Text + "', '" + TextBox10.Text + "', '" + TextBox11.Text + "') ", sqlsconnection);
                    sqlscommand.ExecuteNonQuery();
                    sqlsconnection.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "", "PO '" + TextBox1.Text + "' was edited successfully", false);
                }
                    
            }
            LoadSQL();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInfo(GridView1.SelectedRow.Cells[1].Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (sqlsconnection = new SqlConnection(sqls))
            {
                if (GridView1.SelectedRow != null)
                {
                    sqlsconnection.Open();
                    inputdata = new DataTable();
                    sqlscommand = new SqlCommand(" Update Schedule " +
                        " Set PO = '" + TextBox1.Text + "', " +
                        " Model_Name = '" + TextBox2.Text + "', " +
                        " Model_Number = '" + TextBox3.Text + "', " +
                        " Article = '" + TextBox4.Text + "', " +
                        " Order_Quantity = '" + TextBox5.Text + "', " +
                        "Building = '" + TextBox6.Text + "', " +
                        "Planned_Date = '" + TextBox7.Text + "', " +
                        "CFD = '" + TextBox8.Text + "', " +
                        "PD = '" + TextBox9.Text + "', " +
                        "Country = '" + TextBox10.Text + "', " +
                        "Onhand = '" + TextBox11.Text + "' " +
                        " Where PO = '" + GridView1.SelectedRow.Cells[1].Text + "' " +
                        " IF @@ROWCOUNT = 0 " +
                        " INSERT INTO [Schedule] (PO, Model_Name, Model_Number, Article, Order_Quantity, Building, Planned_Date, CFD, PD, Country, Onhand) " +
                        " VALUES ( '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox7.Text + "', '" + TextBox8.Text + "', '" + TextBox9.Text + "', '" + TextBox10.Text + "', '" + TextBox11.Text + "') ", sqlsconnection);
                    sqlscommand.ExecuteNonQuery();
                    sqlsconnection.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "", "PO '" + GridView1.SelectedRow.Cells[1].Text + "' was edited successfully", false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "No PO selected", false);
                }

            }
            GridView1.SelectedIndex = -1;
            LoadSQL();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (sqlsconnection = new SqlConnection(sqls))
            {
                if (GridView1.SelectedRow != null)
                {
                    sqlsconnection.Open();
                    inputdata = new DataTable();
                    sqlscommand = new SqlCommand(" Delete from Schedule Where PO = '" + GridView1.SelectedRow.Cells[1].Text + "' ", sqlsconnection);
                    sqlscommand.ExecuteNonQuery();
                    sqlsconnection.Close();
                    ClientScript.RegisterStartupScript(this.GetType(),"","PO '" + GridView1.SelectedRow.Cells[1].Text + "' was deleted successfully", false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "No PO selected", false);
                }
            }
            GridView1.SelectedIndex = -1;
            ClearData();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1.SelectedIndex = -1;
            ClearData();
        }
    }
}