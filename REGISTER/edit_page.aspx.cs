using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace REGISTER
{
    public partial class edit_page : System.Web.UI.Page
    {
        int test;
        string connectionString = @"Data Source=.;Initial Catalog=newdb;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
                Response.Redirect("list_page.aspx");
            test = Convert.ToInt32(Session["ID"]);


            if (!IsPostBack)
            {
                DropDownListdate_day.Items.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    DropDownListdate_day.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                DropDownListdate_year.Items.Clear();
                for (int i = 1300; i <= 1400; i++)
                {
                    DropDownListdate_year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                Clear();
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int userID = Convert.ToInt32(Request.QueryString["id"]);
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID", sqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("@ID", userID);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        hfUserID.Value = userID.ToString();
                        txtFirstName.Text = dtbl.Rows[0][1].ToString();
                        txtLastName.Text = dtbl.Rows[0][2].ToString();
                        txtContact.Text = dtbl.Rows[0][3].ToString();
                        ddlGender.Items.FindByValue(dtbl.Rows[0][4].ToString()).Selected = true;
                        txtAddress.Text = dtbl.Rows[0][5].ToString();
                    }

                }
                using (SqlConnection sqlCon1 = new SqlConnection(connectionString))
                {
                    sqlCon1.Open();
                    SqlCommand cmd_empty = new SqlCommand("SELECT * FROM regtbl WHERE ID=@test", sqlCon1);
                    cmd_empty.Parameters.AddWithValue("@test", test);
                    using (SqlDataReader reader = cmd_empty.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = String.Format("{0}", reader["FirstName"]);
                            txtLastName.Text = String.Format("{0}", reader["LastName"]);
                            txtContact.Text = String.Format("{0}", reader["Contact"]);
                            ddlGender.Text = String.Format("{0}", reader["Gender"]);
                            txtAddress.Text = String.Format("{0}", reader["Address"]);
                            DropDownListdate_day.Text = String.Format("{0}", reader["date_day"]);
                            DropDownListdate_month.Text = String.Format("{0}", reader["date_month"]);
                            DropDownListdate_year.Text = String.Format("{0}", reader["date_year"]);
                        }
                    }

                    sqlCon1.Close();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                int maxnum = 0;
                sqlCon.Open();
                SqlCommand cmd_empty = new SqlCommand("SELECT count(ID) AS len FROM regtbl", sqlCon);
                int is_empty = Convert.ToInt32(cmd_empty.ExecuteScalar());
                sqlCon.Close();

                if (is_empty != 0)
                {
                    sqlCon.Open();
                    maxnum = 0;
                    SqlCommand cmd = new SqlCommand("SELECT MAX(ID) AS MaxOf FROM regtbl", sqlCon);
                    maxnum = Convert.ToInt32(cmd.ExecuteScalar());
                    maxnum++;
                    sqlCon.Close();
                }
                sqlCon.Open();
                string query = "UPDATE regtbl SET FirstName = @FirstName ,LastName = @LastName ,Contact = @Contact ,Gender = @Gender ,Address = @Address ,date_day = @date_day , date_month = @date_month , date_year = @date_year  WHERE ID=@ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@ID", test);
                sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                sqlCmd.Parameters.AddWithValue("@date_day", Convert.ToInt32(DropDownListdate_day.SelectedValue));
                sqlCmd.Parameters.AddWithValue("@date_month", DropDownListdate_month.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@date_year", Convert.ToInt32(DropDownListdate_year.SelectedValue));

                sqlCmd.ExecuteNonQuery();
                Clear();
            }
            Thread.Sleep(500);
            Session.Abandon();
            Response.Redirect("list_page.aspx");
        }

        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = "";
            hfUserID.Value = "";
        }

        protected void cancelbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("list_page.aspx");
        }
    }
}