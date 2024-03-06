using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace AuthApp
{
    public partial class Form1 : Form
    {
        string hashedPasswordFromDB;
        AdminDashboard admin = new AdminDashboard();
        private int failedLoginAttempts = 0;
        private int totalLoginAttempts = 3;
        string connectionString = "Data Source=shahood-rehan;Initial Catalog=AuthenticationApp;Integrated Security=True;Trust Server Certificate=True";
        public Form1()
        {
            InitializeComponent();

            rolecombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> roles = new List<string>();
            roles.Insert(0, "Admin");
            roles.Insert(1, "Manager");
            roles.Insert(2, "Operator");
            roles.Insert(3, "Engineer");

            rolecombobox.DataSource = roles;
            rolecombobox.SelectedIndex = 0;
            rolecombobox.Text = "Select your role";


        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            AdminDashboard admin = new AdminDashboard();
            string username, password;
            string selectedRole = rolecombobox.SelectedItem.ToString();

            if (selectedRole == "Admin")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                ValidateAdmin(username, password);
                login.Dispose();

            }
            else if (selectedRole == "Manager")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                CheckPasswordExpiry(username);
                ValidateManager(username, password);
                login.Dispose();

            }
            else if (selectedRole == "Operator")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                CheckPasswordExpiry(username);
                ValidateOperator(username, password);
                login.Dispose();


            }
            else if (selectedRole == "Engineer")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                CheckPasswordExpiry(username);
                ValidateEngineer(username, password);
                login.Dispose();
            }
            else
            {
                MessageBox.Show("Unknown Role");
            }
        }
        private void ValidateAdmin(string user_name, string pass_word)
        {
            bool passwordValidationResult = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select password from Users where username= @username AND roles='Admin';";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            hashedPasswordFromDB = reader["password"].ToString();

                            passwordValidationResult = ValidatePassword(pass_word, hashedPasswordFromDB);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username");
                        }
                    }
                }
                con.Close();
            }

            if (passwordValidationResult)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select username from Users where username= @username AND roles='Admin';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user_name);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            if (reader.HasRows)
                            {
                                if (usernametxt.Text == user_name)
                                {
                                    MessageBox.Show("Login successful for Admin!");
                                    admin.Show();
                                    usernametxt.Clear();
                                    passwordtxt.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username");
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
        private void ValidateManager(string user_name, string pass_word)
        {
            bool passwordValidationResult = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select password from Users where username= @username AND roles='Manager';";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            hashedPasswordFromDB = reader["password"].ToString();

                            passwordValidationResult = ValidatePassword(pass_word, hashedPasswordFromDB);

                            if (!passwordValidationResult)
                            {
                                failedLoginAttempts++;

                                if (failedLoginAttempts >= 3)
                                {
                                    passwordtxt.Enabled = false;
                                    change_status(user_name, "Manager");
                                }
                                else
                                {
                                    totalLoginAttempts--;
                                    MessageBox.Show("Invalid password. Attempts left #" + totalLoginAttempts);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username");
                        }
                    }
                }
                con.Close();
            }

            if (passwordValidationResult)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select username from Users where username= @username AND roles='Manager';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user_name);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            if (reader.HasRows)
                            {
                                if (usernametxt.Text == user_name)
                                {
                                    MessageBox.Show("Login successful for Manager!");
                                    usernametxt.Clear();
                                    passwordtxt.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username");
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
        private void ValidateOperator(string user_name, string pass_word)
        {
            bool passwordValidationResult = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select password from Users where username= @username AND roles='Operator';";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            hashedPasswordFromDB = reader["password"].ToString();

                            passwordValidationResult = ValidatePassword(pass_word, hashedPasswordFromDB);

                            if (!passwordValidationResult)
                            {
                                failedLoginAttempts++;

                                if (failedLoginAttempts >= 3)
                                {
                                    passwordtxt.Enabled = false;
                                    change_status(user_name, "Operator");
                                }
                                else
                                {
                                    totalLoginAttempts--;
                                    MessageBox.Show("Invalid password. Attempts left #" + totalLoginAttempts);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username");
                        }
                    }
                }
                con.Close();
            }

            if (passwordValidationResult)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select username from Users where username= @username AND roles='Operator';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user_name);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            if (reader.HasRows)
                            {
                                if (usernametxt.Text == user_name)
                                {
                                    MessageBox.Show("Login successful for Operator!");
                                    usernametxt.Clear();
                                    passwordtxt.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username");
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
        private void ValidateEngineer(string user_name, string pass_word)
        {
            bool passwordValidationResult = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select password from Users where username= @username AND roles='Engineer';";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            hashedPasswordFromDB = reader["password"].ToString();

                            passwordValidationResult = ValidatePassword(pass_word, hashedPasswordFromDB);

                            if (!passwordValidationResult)
                            {
                                failedLoginAttempts++;

                                if (failedLoginAttempts >= 3)
                                {
                                    passwordtxt.Enabled = false;
                                    change_status(user_name, "Engineer");
                                }
                                else
                                {
                                    totalLoginAttempts--;
                                    MessageBox.Show("Invalid password. Attempts left #" + totalLoginAttempts);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username");
                        }
                    }
                }
                con.Close();
            }

            if (passwordValidationResult)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select username from Users where username= @username AND roles='Engineer';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user_name);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            if (reader.HasRows)
                            {
                                if (usernametxt.Text == user_name)
                                {
                                    MessageBox.Show("Login successful for Engineer!");
                                    usernametxt.Clear();
                                    passwordtxt.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username");
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }


        private void change_status(string username, string roles)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Users SET active_status = @active_status WHERE username = @username AND roles = @roles";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@active_status", 0);
                        cmd.Parameters.AddWithValue("@roles", roles);
                        int rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            MessageBox.Show("Your id has been locked");
                            MessageBox.Show("Contact administrator for further instructions!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private bool ValidatePassword(string inputPassword, string hashedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedInputBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                return BitConverter.ToString(hashedInputBytes).Replace("-", "").Equals(hashedPassword);
            }
        }
        private void CheckPasswordExpiry(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT LastPasswordChangeDate FROM Users WHERE username = @username;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime lastPasswordChangeDate = Convert.ToDateTime(reader["LastPasswordChangeDate"]);
                            DateTime currentDate = DateTime.Now;

                            if ((currentDate - lastPasswordChangeDate).TotalDays >= 90)
                            {
                                MessageBox.Show("Your password has expired. Please contact the administrator to set a new password.");
                                passwordtxt.Enabled = false;
                            }
                        }
                    }
                }
                con.Close();
            }
        }
    }
}

