using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AuthApp
{ 
    public partial class AdminDashboard : Form
    {
        private readonly string _connectionString;


        DateTime dateTime = DateTime.Now;
        PasswordHashing hashing = new PasswordHashing();

        public AdminDashboard()
        {
            InitializeComponent();
            //connectionstring
            string json;
            using (StreamReader reader = new StreamReader("AuthApp.json"))
            {
                json = reader.ReadToEnd();
            }

            var config = JsonSerializer.Deserialize<Config>(json);
            _connectionString = config.ConnectionString;


            //Initialization of different components
            usercombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> roles = new List<string>();
            roles.Insert(0, "Manager");
            roles.Insert(1, "Operator");
            roles.Insert(2, "Engineer");
            usercombobox.DataSource = roles;
            usercombobox.SelectedIndex = 0;
            usercombobox.Text = "Select your role";


            List<string> status = new List<string>();
            status.Insert(0, "Active");
            status.Insert(1, "Deactive");
            statuscombobox.DataSource = status;
            statuscombobox.Text = "Select status";



            current_status_txt.Visible = false;
            current_status_lbl.Visible = false;
            changestatus_lbl.Visible = false;
            statuscombobox.Visible = false;
            changestatus_btn.Visible = false;
            new_pass_lbl.Visible = false;
            resetpasstxt.Visible = false;
            reset_btn.Visible = false;

        }

        private void createuser_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int passlength = password_txt.TextLength;
            if (passlength < 8)
            {
                MessageBox.Show("Your password must be 8 digits long");
                return;
            }

            string enteredPassword = password_txt.Text;
            List<string> previousPasswords = GetStoredPasswords();
            bool isValid = !previousPasswords.Any(previousPassword => ValidatePassword(enteredPassword, previousPassword));
            if (!isValid)
            {
                MessageBox.Show("Your password is the same as a previous password.");
                return;
            }

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                PasswordHashing hasher = new PasswordHashing();
                string password = password_txt.Text;
                string hashedPassword = hasher.HashPassword(password);

                string insertUserQuery = "INSERT INTO Users (username, password, active_status, roles, created_at, LastPasswordChangeDate) VALUES (@username, @password, @activestatus, @roles, @created_at, @LastPasswordChangeDate)";

                using (SqlCommand cmd = new SqlCommand(insertUserQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", username_txt.Text);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@activestatus", 1);
                    cmd.Parameters.AddWithValue("@roles", usercombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@created_at", dateTime);
                    cmd.Parameters.AddWithValue("@LastPasswordChangeDate", dateTime);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0 && !string.IsNullOrEmpty(username_txt.Text) && !string.IsNullOrEmpty(hashedPassword) && usercombobox.SelectedValue != null)
                    {
                        MessageBox.Show("User added successfully!");

                    }
                    else
                    {
                        MessageBox.Show("All fields must be filled! Error adding user.");
                    }
                }
            }

            //logs
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Get the values after inserting the user to ensure they are updated
                string[] selectedValues = { usercombobox.SelectedValue?.ToString(), username_txt.Text };
                string newValues = string.Join(",", selectedValues);

                using (SqlCommand command = new SqlCommand("InsertActivityLog", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EventType", "Insertion of a new user");
                    command.Parameters.AddWithValue("@UserRole", "Admin");
                    command.Parameters.AddWithValue("@AppUser", Form1.username_admin);
                    command.Parameters.AddWithValue("@OldValues", "None");
                    command.Parameters.AddWithValue("@NewValues", newValues);

                    command.ExecuteNonQuery();
                    username_txt.Clear();
                    password_txt.Clear();
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


        private List<string> GetStoredPasswords()
        {
            List<string> previousPasswords = new List<string>();

            using (var con = new SqlConnection(_connectionString))
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
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE username = @username ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user_validationtxt.Text);


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
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Users SET active_status = @activestatus WHERE username = @username ";

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
                     

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Status updated successfully");

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


            using (var connection = new SqlConnection(_connectionString))
            {
                string[] old_values = { current_status_txt.Text, user_validationtxt.Text};
                string oldvalues = string.Join(",", old_values);
                string[] new_values = { statuscombobox.SelectedValue.ToString(), user_validationtxt.Text };
                string newvalues = string.Join(",", new_values);
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertActivityLog", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Set the parameters
                    command.Parameters.AddWithValue("@EventType", "Change user status");
                    command.Parameters.AddWithValue("@UserRole", "Admin");
                    command.Parameters.AddWithValue("@AppUser", Form1.username_admin);
                    command.Parameters.AddWithValue("@OldValues", oldvalues);
                    command.Parameters.AddWithValue("@NewValues", newvalues);
                    command.ExecuteNonQuery();
                    user_validationtxt.Clear();
                }
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Validate_btn_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {

                con.Open();
                string query = "SELECT * FROM Users WHERE username = @username ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", usernametxt.Text);
     

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
            int passlength = resetpasstxt.TextLength;
            if (passlength < 8)
            {
                MessageBox.Show("Your password must be 8 digits long");
                return;
            }
            string enteredPassword = resetpasstxt.Text;
            List<string> previousPasswords = GetStoredPasswords();
            bool isValid = !previousPasswords.Any(previousPassword => ValidatePassword(enteredPassword, previousPassword));
            if (!isValid)
            {
                MessageBox.Show("Your password is the same as a previous password.");
                return;
            }

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                PasswordHashing hasher = new PasswordHashing();
                string password = resetpasstxt.Text;
                string hashedPassword = hasher.HashPassword(password);

                string query = "UPDATE USERS SET password=@password, active_status=@active_status WHERE username=@username ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", usernametxt.Text);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@active_status", 1);
                    cmd.Parameters.AddWithValue("@created_at", dateTime);
                    cmd.Parameters.AddWithValue("@LastPasswordChangeDate", dateTime);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password reset successful");
                        MessageBox.Show("Status changed to active");


                        string logAction = "Update password";
                        string userRole = "Admin";
                        string userName = Form1.username_admin;


                        string oldValues = "Password is encrypted";
                        string newValues = "Password is encrypted";

                        string insertLogQuery = "INSERT INTO Runtime_Auditing (DateTime, EventType, UserRole, AppUser, OldValues, NewValues) " +
                                                "VALUES (@DateTime, @EventType, @userRole, @AppUser, @oldValues, @newValues)";

                        using (SqlCommand logCmd = new SqlCommand(insertLogQuery, con))
                        {
                            logCmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                            logCmd.Parameters.AddWithValue("@EventType", logAction);
                            logCmd.Parameters.AddWithValue("@userRole", userRole);
                            logCmd.Parameters.AddWithValue("@AppUser", userName);
                            logCmd.Parameters.AddWithValue("@oldValues", oldValues);
                            logCmd.Parameters.AddWithValue("@newValues", newValues);

                            logCmd.ExecuteNonQuery();
                        }
                        usernametxt.Clear();
                        resetpasstxt.Clear();
                        new_pass_lbl.Hide();
                        resetpasstxt.Hide();
                        reset_btn.Hide();
                        return;
                    }
                }
                con.Close();
            }
        }

        private void change_pass_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_txt_TextChanged(object sender, EventArgs e)
        {
            password_txt.PasswordChar = '*';
        }

        private void password_txt_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
