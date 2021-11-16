using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace REGISTER
{
    public partial class search_page : System.Web.UI.Page
    {
       string connectionString = @"Data Source=.;Initial Catalog=newdb;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM regtbl WHERE FirstName LIKE N'" + search_first.Text + "' OR LastName LIKE N'" + search_last.Text + "' ", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["ID"] = gvPhoneBook.DataKeys[e.NewEditIndex].Value.ToString().Trim();
            Response.Redirect("edit_page.aspx");
        }
        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM regtbl WHERE ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("register_page.aspx");
        }

        protected void listbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("list_page.aspx");
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
                PopulateGridview();
        }
    }
}