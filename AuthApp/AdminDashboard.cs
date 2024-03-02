using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AuthApp
{
    public partial class AdminDashboard : Form
    {
        string connectionString = "Data Source=shahood-rehan;Initial Catalog=AuthenticationApp;Integrated Security=True;Trust Server Certificate=True";
        DateTime dateTime = DateTime.Now;
        PasswordHashing hashing = new PasswordHashing();
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


            statuscombobox.DataSource = status;
            statuscombobox.Text = "Select status";

            List<string> password_role = new List<string>();
            password_role.Insert(0, "Manager");
            password_role.Insert(1, "Operator");
            password_role.Insert(2, "Engineer");
            reset_pass_cbx.DataSource = password_role;


            current_status_txt.Visible = false;
            current_status_lbl.Visible = false;
            changestatus_lbl.Visible = false;
            statuscombobox.Visible = false;
            changestatus_btn.Visible = false;

            //reset
            new_pass_lbl.Visible = false;
            resetpasstxt.Visible = false;
            reset_btn.Visible = false;


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
            string enteredPassword = password_txt.Text;
            List<string> previousPasswords = GetStoredPasswords();
            bool isValid = !previousPasswords.Any(previousPassword => ValidatePassword(enteredPassword, previousPassword));
            if (!isValid)
            {
                MessageBox.Show("Your password is the same as a previous password.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                PasswordHashing hasher = new PasswordHashing();
                string password = password_txt.Text;
                string hashedPassword = hasher.HashPassword(password);


                string insertUserQuery = "INSERT INTO Users (username, password, active_status, roles, created_at) VALUES (@username, @password, @activestatus, @roles, @created_at)";

                using (SqlCommand cmd = new SqlCommand(insertUserQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", username_txt.Text);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@activestatus", 1);
                    cmd.Parameters.AddWithValue("@roles", usercombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@created_at", dateTime);

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
        private bool ValidatePassword(string enteredPassword, string storedHashedPassword)
        {
            PasswordHashing hasher = new PasswordHashing();
            string hashedEnteredPassword = hasher.HashPassword(enteredPassword);

            return string.Equals(hashedEnteredPassword, storedHashedPassword, StringComparison.OrdinalIgnoreCase);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void changecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private List<string> GetStoredPasswords()
        {
            List<string> previousPasswords = new List<string>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string checkPreviousPasswordsQuery = "SELECT TOP 10 password FROM Users ORDER BY created_at DESC";

                using (SqlCommand checkCmd = new SqlCommand(checkPreviousPasswordsQuery, con))
                {
                    using (SqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            previousPasswords.Add(reader["password"].ToString());
                        }
                    }
                }
            }

            return previousPasswords;
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


                                if (activeStatus == 1)
                                {
                                    current_status_txt.Text = "Active";
                                }
                                else if (activeStatus == 0)
                                {
                                    current_status_txt.Text = "Inactive";
                                }
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


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Users SET active_status = @activestatus WHERE username = @username AND roles = @roles";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (statuscombobox.SelectedIndex == 0)
                        {
                            int active_status;
                            active_status = 1;
                            cmd.Parameters.AddWithValue("@activestatus", active_status);
                        }
                        else if (statuscombobox.SelectedIndex == 1)
                        {
                            int active_status;
                            active_status = 0;
                            cmd.Parameters.AddWithValue("@activestatus", active_status);
                        }

                        cmd.Parameters.AddWithValue("@username", user_validationtxt.Text);
                        cmd.Parameters.AddWithValue("@roles", changecombobox.SelectedValue);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Status updated successfully");
                            user_validationtxt.Clear();
                            current_status_txt.Visible = false;
                            current_status_lbl.Visible = false;
                            changestatus_lbl.Visible = false;
                            statuscombobox.Visible = false;
                            changestatus_btn.Visible = false;

                        }
                        else
                        {
                            MessageBox.Show("Update failed. User not found or role mismatch.");
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

        private void logout_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Validate_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                string query = "SELECT * FROM Users WHERE username = @username AND roles = @roles";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", usernametxt.Text);
                    cmd.Parameters.AddWithValue("@roles", reset_pass_cbx.SelectedValue);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            int activeStatus = Convert.ToInt32(reader["active_status"]);
                            if (activeStatus == 0)
                            {
                                MessageBox.Show("Current status is deactive");
                                new_pass_lbl.Visible = true;
                                resetpasstxt.Visible = true;
                                reset_btn.Visible = true;

                            }
                            else
                            {
                                MessageBox.Show("Current status is active, no need to change the password");


                            }


                        }
                        else
                        {
                            MessageBox.Show("Invalid Username");
                        }
                    }
                }
            }

        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string checkPreviousPasswordsQuery = "SELECT TOP 10 password FROM Users  ORDER BY created_at DESC";

                using (SqlCommand checkCmd = new SqlCommand(checkPreviousPasswordsQuery, con))
                {
                    using (SqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        List<string> previousPasswords = new List<string>();

                        while (reader.Read())
                        {
                            previousPasswords.Add(reader["password"].ToString());
                        }

                        string newPassword = resetpasstxt.Text;

                        if (previousPasswords.Contains(newPassword))
                        {
                            MessageBox.Show("Your password is same as previous password");
                            return;


                        }
                    }
                }

                string query = "UPDATE USERS set password=@password, active_status=@active_status WHERE username=@username AND roles=@roles";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@password", resetpasstxt.Text);
                    cmd.Parameters.AddWithValue("@active_status", 1);
                    cmd.Parameters.AddWithValue("@username", usernametxt.Text);
                    cmd.Parameters.AddWithValue("@roles", reset_pass_cbx.SelectedValue);
                    int rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected > 0)
                    {
                        MessageBox.Show("Password reset successful");
                        MessageBox.Show("Status changed to active");
                        return;
                    }
                }
            }
        }

        private void change_pass_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
