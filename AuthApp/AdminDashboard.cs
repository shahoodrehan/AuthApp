using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthApp
{
    public partial class AdminDashboard : Form
    {
        string connectionString = "Data Source=shahood-rehan;Initial Catalog=AuthenticationApp;Integrated Security=True;Trust Server Certificate=True";

        public AdminDashboard()
        {
            InitializeComponent();
            usercombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> roles = new List<string>();
            roles.Insert(0, "Manager");
            roles.Insert(1, "Operator");
            roles.Insert(2, "Engineer");

            usercombobox.DataSource = roles;
            usercombobox.SelectedIndex = 0;
            usercombobox.Text = "Select your role";

            List<string> users = new List<string>();
            users.Insert(0, "Engineer");
            users.Insert(1, "Manager");
            users.Insert(2, "Operator");

            changecombobox.DataSource = users;
            changecombobox.SelectedIndex = 0;

            List<string> status = new List<string>();
            status.Insert(0, "Active");
            status.Insert(1, "Deactive");
            status.Insert(2, "Select Status");

            statuscombobox.DataSource= status;
            statuscombobox.SelectedIndex = 2;

            current_status_txt.Visible = false;
            current_status_lbl.Visible=false;
            changestatus_lbl.Visible=false;
         statuscombobox.Visible=false;
            changestatus_btn.Visible=false;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void createuser_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "INSERT INTO Users (username, password, active_status, roles) VALUES (@username, @password, @activestatus, @roles)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username_txt.Text);
                    cmd.Parameters.AddWithValue("@password", password_txt.Text);
                    cmd.Parameters.AddWithValue("@activestatus", 1);
                    cmd.Parameters.AddWithValue("@roles", usercombobox.SelectedValue);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Error adding user.");
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void changecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void validatebtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE username = @username AND roles = @roles";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user_validationtxt.Text);
                        cmd.Parameters.AddWithValue("@roles", changecombobox.SelectedValue);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int activeStatus = Convert.ToInt32(reader["active_status"]);
                                current_status_txt.Visible = true;

                                statuscombobox.Visible = true;
                                current_status_lbl.Visible = true;
                                changestatus_lbl.Visible = true;
                                password_txt.Visible = true;
                                changestatus_btn.Visible = true;
                                current_status_txt.Text = activeStatus.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}
