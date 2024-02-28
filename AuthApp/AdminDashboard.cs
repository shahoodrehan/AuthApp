using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

            users.Insert(0, "Manager");
            users.Insert(1, "Operator");
            users.Insert(2, "Engineer");

            changecombobox.DataSource = users;
            changecombobox.SelectedIndex = 0;

            List<string> status = new List<string>();
            status.Insert(0, "Active");
            status.Insert(1, "Deactive");
            status.Insert(2, "Select Status");

            statuscombobox.DataSource = status;
            statuscombobox.SelectedIndex = 2;

            current_status_txt.Visible = false;
            current_status_lbl.Visible = false;
            changeStatus_lbl.Visible = false;
            changestatus_btn.Visible = false;
            statuscombobox.Visible = false;


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
                con.Close();
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
                    string query = "SELECT User_id, username, active_status FROM Users WHERE username = @username AND roles = @roles;";

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
                                if (activeStatus == 0)
                                {
                                    current_status_txt.Text = "Deactive";
                                }
                                else if (activeStatus == 1)
                                {
                                    current_status_txt.Text = "Active";
                                }
                                current_status_txt.Visible = true;

                                statuscombobox.Visible = true;
                                current_status_lbl.Visible = true;
                                changeStatus_lbl.Visible = true;
                                password_txt.Visible = true;
                                changestatus_btn.Visible = true;

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

        private void changestatus_btn_Click(object sender, EventArgs e)
        {

            string query = "UPDATE Users SET active_status = @newActiveStatus WHERE username = @username AND roles = @roles;";
            int active, deactive;
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (statuscombobox.SelectedValue == "Active")
                    {
                        active = 1;
                        cmd.Parameters.AddWithValue("@newActiveStatus", active);
                    }
                    else
                    {
                        deactive = 0;
                        cmd.Parameters.AddWithValue("@newActiveStatus", deactive);
                    }
          
                    cmd.Parameters.AddWithValue("@username", user_validationtxt.Text);
                    cmd.Parameters.AddWithValue("@roles", changecombobox.SelectedValue);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                con.Close();
            }


        }
    }
}
