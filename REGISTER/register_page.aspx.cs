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
    
    public partial class register_page : System.Web.UI.Page
    {

        byte[] msg;

        string connectionString = @"Data Source=.;Initial Catalog=newdb;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
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

                string query = "INSERT INTO regtbl (ID,FirstName,LastName,Contact,Gender,Address,date_day,date_month,date_year) VALUES (@ID,@FirstName,@LastName,@Contact,@Gender,@Address,@date_day,@date_month,@date_year)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                msg = System.Text.Encoding.UTF8.GetBytes(txtLastName.Text);
                sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value) + maxnum);
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
                lblSuccessMessage.Text = "Submitted Successfully";
            }

        }

        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = "";
            hfUserID.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }

        protected void editbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("list_page.aspx");
        }
    }
}