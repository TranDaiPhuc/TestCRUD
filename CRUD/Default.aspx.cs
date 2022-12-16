using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        DataTable data2 = new DataTable();
        DataTable inputdata = new DataTable();
        string[] keyname = { };

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
            gvMain.DataSource = data;
            gvMain.DataKeyNames = keyname;
            gvMain.DataBind();
            gvMain.HeaderRow.BackColor = System.Drawing.Color.Blue;
            gvMain.HeaderRow.ForeColor = System.Drawing.Color.White;
            gvMain.HeaderRow.Cells[0].BackColor = System.Drawing.Color.White;
            gvMain.HeaderRow.Cells[0].ForeColor = System.Drawing.Color.Black;
            ViewState["Data"] = data;
            LoadColor();
        }

        private void LoadColor ()
        {
            List<int> list = (List<int>)ViewState["Checked"];
            for (int i = 0; i < gvMain.Rows.Count; i++)
            {
                if (list[i + (gvMain.PageIndex * gvMain.PageSize)] == 1)
                {
                    gvMain.Rows[i].BackColor = System.Drawing.Color.Gold;
                }
                else
                {
                    gvMain.Rows[i].BackColor = System.Drawing.Color.White;
                }
                gvMain.Rows[i].Cells[0].BackColor = System.Drawing.Color.White;
                gvMain.Rows[i].Cells[0].ForeColor = System.Drawing.Color.Indigo;
            };
        }

        private void ResetCheckedViewState()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                list.Add(0);
            }
            ViewState["Checked"] = list;
        }

        private void ShiftCheckedViewState(int index)
        {
            List<int> list = (List<int>)ViewState["Checked"];

            list.RemoveAt(index);
            list.Add(0);

            ViewState["Checked"] = list;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Edit"] = -1;
                ViewState["Page"] = 0;
                ResetCheckedViewState();
                LoadSQL();
            }
        }

        protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> list = (List<int>)ViewState["Checked"];
            if (list[gvMain.SelectedIndex + (gvMain.PageIndex * gvMain.PageSize)] == 0)
            {
                list[gvMain.SelectedIndex + (gvMain.PageIndex * gvMain.PageSize)] = 1;
            }
            else
            {
                list[gvMain.SelectedIndex + (gvMain.PageIndex * gvMain.PageSize)] = 0;
            }

            //string output = string.Join(" | ", list);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + string + "');", true);
            ViewState["Checked"] = list;
            gvMain.SelectedIndex = -1;
            LoadSQL();
        }

        protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMain.EditIndex = e.NewEditIndex;
            ViewState["Edit"] = gvMain.EditIndex;
            ViewState["Page"] = gvMain.PageIndex;
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + gvMain.EditIndex + "');", true);
            LoadSQL();
        }

        protected void gvMain_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            data2 = (DataTable)ViewState["Data"];
            GridViewRow row = gvMain.Rows[e.RowIndex];
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + gvMain.Cells[1].Controls[2] + "');", true);
            string PO = (row.Cells[1].Controls[1] as TextBox).Text;
            string Model_Name = (row.Cells[2].Controls[1] as TextBox).Text;
            string Model_Number = (row.Cells[3].Controls[1] as TextBox).Text;
            string Article = (row.Cells[4].Controls[1] as TextBox).Text;
            string Quantity = (row.Cells[5].Controls[1] as TextBox).Text;
            string Lean = (row.Cells[6].Controls[1] as TextBox).Text;
            string Planned_Date = (row.Cells[7].Controls[1] as TextBox).Text;
            string CRD = (row.Cells[8].Controls[1] as TextBox).Text;
            string PD = (row.Cells[9].Controls[1] as TextBox).Text;
            string Country = (row.Cells[10].Controls[1] as TextBox).Text;
            string Onhand = (row.Cells[11].Controls[1] as TextBox).Text;

            using (sqlsconnection = new SqlConnection(sqls))
            {
                if (!string.IsNullOrWhiteSpace(PO))
                {
                    sqlsconnection.Open();
                    inputdata = new DataTable();
                    sqlscommand = new SqlCommand(" Update Schedule " +
                        " Set PO = @PO, " +
                        " Model_Name = @Model_Name, " +
                        " Model_Number = @Model_Number, " +
                        " Article = @Article, " +
                        " Order_Quantity = @Quantity, " +
                        " Building = @Lean, " +
                        " Planned_Date = @Planned_Date, " +
                        " CFD = @CRD, " +
                        " PD = @PD, " +
                        " Country = @Country, " +
                        " Onhand = @Onhand " +
                        " Where PO = @OldPO " +
                        " IF @@ROWCOUNT = 0 " +
                        " INSERT INTO [Schedule] (PO, Model_Name, Model_Number, Article, Order_Quantity, Building, Planned_Date, CFD, PD, Country, Onhand) " +
                        " VALUES ( @PO, @Model_Name, @Model_Number, @Article, @Quantity, @Lean, @Planned_Date, @CRD, @PD, @Country, @Onhand ) ", sqlsconnection);
                    sqlscommand.Parameters.AddWithValue("@PO", PO);
                    sqlscommand.Parameters.AddWithValue("@Model_Name", Model_Name);
                    sqlscommand.Parameters.AddWithValue("@Model_Number", Model_Number);
                    sqlscommand.Parameters.AddWithValue("@Article", Article);
                    sqlscommand.Parameters.AddWithValue("@Quantity", Quantity);
                    sqlscommand.Parameters.AddWithValue("@Lean", Lean);
                    sqlscommand.Parameters.AddWithValue("@Planned_Date", Planned_Date);
                    sqlscommand.Parameters.AddWithValue("@CRD", CRD);
                    sqlscommand.Parameters.AddWithValue("@PD", PD);
                    sqlscommand.Parameters.AddWithValue("@Country", Country);
                    sqlscommand.Parameters.AddWithValue("@Onhand", Onhand);
                    sqlscommand.Parameters.AddWithValue("@OldPO", data2.Rows[e.RowIndex + (gvMain.PageIndex * gvMain.PageSize)]["PO"]);
                    sqlscommand.ExecuteNonQuery();
                    sqlsconnection.Close();
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ViewState["OldPO"] + "');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "", ". . . PO was " + PO + " edited successfully", false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", ". . . No PO inputted", false);
                }
            }
            
            if (data2.Rows[e.RowIndex + (gvMain.PageIndex * gvMain.PageSize)]["PO"].ToString() != PO)
            {
                ResetCheckedViewState();
            }
            data2.Reset();
            ViewState["Edit"] = -1;
            ViewState["Page"] = 0;
            gvMain.SelectedIndex = -1;
            gvMain.EditIndex = -1;
            LoadSQL();
        }

        protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //nothing for now
        }

        protected void gvMain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ViewState["Edit"] = -1;
            ViewState["Page"] = 0;
            gvMain.SelectedIndex = -1;
            gvMain.EditIndex = -1;
            LoadSQL();
        }

        protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            data2 = (DataTable)ViewState["Data"];
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + data2.Rows[e.RowIndex]["PO"] + "');", true);
            using (sqlsconnection = new SqlConnection(sqls))
            {
                sqlsconnection.Open();
                sqlscommand = new SqlCommand(" Delete from Schedule Where PO = @PO ", sqlsconnection);
                sqlscommand.Parameters.AddWithValue("@PO", data2.Rows[e.RowIndex]["PO"]);
                sqlscommand.ExecuteNonQuery();
                sqlsconnection.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "", ". . . PO " + data2.Rows[e.RowIndex]["PO"] + " was deleted successfully", false);
            }
            data2.Reset();
            ShiftCheckedViewState(e.RowIndex + gvMain.PageIndex);
            LoadSQL();
        }

        protected void gvMain_PageIndexChanged(object sender, EventArgs e)
        {
            //do nothing for now
        }

        protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMain.PageIndex = e.NewPageIndex;
            if (gvMain.PageIndex != (Int32)ViewState["Page"])
            {
                gvMain.EditIndex = -1;
            }
            else
            {
                gvMain.EditIndex = (Int32)ViewState["Edit"];
            }
            LoadSQL();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> list = (List<int>)ViewState["Checked"];
            data2 = (DataTable)ViewState["Data"];
            for (int i = 0; i < data2.Rows.Count; i++)
            {
                if (list[i] == 1)
                {
                    using (sqlsconnection = new SqlConnection(sqls))
                    {
                        sqlsconnection.Open();
                        inputdata = new DataTable();
                        sqlscommand = new SqlCommand(" Delete from Schedule Where PO = @PO ", sqlsconnection);
                        sqlscommand.Parameters.AddWithValue("@PO", data2.Rows[i]["PO"]);
                        sqlscommand.ExecuteNonQuery();
                        sqlsconnection.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "", ". . . Selected PO was deleted successfully", false);
                    }
                }
            }
            data2.Reset();
            ResetCheckedViewState();
            LoadSQL();
        }

        protected void btnInverse_Click(object sender, EventArgs e)
        {
            List<int> list = (List<int>)ViewState["Checked"];

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = Math.Abs(list[i] - 1);
            }

            ViewState["Checked"] = list;
            LoadSQL();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["Edit"] = -1;
            ViewState["Page"] = 0;
            gvMain.SelectedIndex = -1;
            gvMain.EditIndex = -1;
            ResetCheckedViewState();
            LoadSQL();
        }

        protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                GridViewRow row = gvMain.FooterRow;
                string PO = (row.Cells[1].Controls[1] as TextBox).Text;
                string Model_Name = (row.Cells[2].Controls[1] as TextBox).Text;
                string Model_Number = (row.Cells[3].Controls[1] as TextBox).Text;
                string Article = (row.Cells[4].Controls[1] as TextBox).Text;
                string Quantity = (row.Cells[5].Controls[1] as TextBox).Text;
                string Lean = (row.Cells[6].Controls[1] as TextBox).Text;
                string Planned_Date = (row.Cells[7].Controls[1] as TextBox).Text;
                string CRD = (row.Cells[8].Controls[1] as TextBox).Text;
                string PD = (row.Cells[9].Controls[1] as TextBox).Text;
                string Country = (row.Cells[10].Controls[1] as TextBox).Text;
                string Onhand = (row.Cells[11].Controls[1] as TextBox).Text;
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + PO + "|" + Model_Name + Model_Number + "|" + Article + "|" + Quantity + "|" + Lean + "|" + Planned_Date + "|" + CRD + "|" + PD + "|" + Country + "|" + Onhand +"');", true);
                using (sqlsconnection = new SqlConnection(sqls))
                {
                    if (!string.IsNullOrWhiteSpace(PO))
                    {
                        sqlsconnection.Open();
                        inputdata = new DataTable();
                        sqlscommand = new SqlCommand(" Update Schedule " +
                            " Set PO = @PO, " +
                            " Model_Name = @Model_Name, " +
                            " Model_Number = @Model_Number, " +
                            " Article = @Article, " +
                            " Order_Quantity = @Quantity, " +
                            " Building = @Lean, " +
                            " Planned_Date = @Planned_Date, " +
                            " CFD = @CRD, " +
                            " PD = @PD, " +
                            " Country = @Country, " +
                            " Onhand = @Onhand " +
                            " Where PO = @PO " +
                            " IF @@ROWCOUNT = 0 " +
                            " INSERT INTO [Schedule] (PO, Model_Name, Model_Number, Article, Order_Quantity, Building, Planned_Date, CFD, PD, Country, Onhand) " +
                            " VALUES ( @PO, @Model_Name, @Model_Number, @Article, @Quantity, @Lean, @Planned_Date, @CRD, @PD, @Country, @Onhand ) ", sqlsconnection);
                        sqlscommand.Parameters.AddWithValue("@PO", PO);
                        sqlscommand.Parameters.AddWithValue("@Model_Name", Model_Name);
                        sqlscommand.Parameters.AddWithValue("@Model_Number", Model_Number);
                        sqlscommand.Parameters.AddWithValue("@Article", Article);
                        sqlscommand.Parameters.AddWithValue("@Quantity", Quantity);
                        sqlscommand.Parameters.AddWithValue("@Lean", Lean);
                        sqlscommand.Parameters.AddWithValue("@Planned_Date", Planned_Date);
                        sqlscommand.Parameters.AddWithValue("@CRD", CRD);
                        sqlscommand.Parameters.AddWithValue("@PD", PD);
                        sqlscommand.Parameters.AddWithValue("@Country", Country);
                        sqlscommand.Parameters.AddWithValue("@Onhand", Onhand);
                        sqlscommand.ExecuteNonQuery();
                        sqlsconnection.Close();
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ViewState["OldPO"] + "');", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "", ". . . PO was " + PO + " added successfully", false);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", ". . . No PO inputted", false);
                    }
                }


                ResetCheckedViewState();
                LoadSQL();
            }
        }
    }
}