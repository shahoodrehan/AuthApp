using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AuthApp
{
    public partial class Form1 : Form
    {
        
        string hashedPasswordFromDB;
        AdminDashboard admin = new AdminDashboard();
        private int failedLoginAttempts = 0;
        private int totalLoginAttempts = 3;
        public static string logged_user;
        private readonly string _connectionString;
        
        public Dictionary<string, string> Roles { get; private set; }
        public Form1()
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

            ///
            string json_;
            using (StreamReader reader = new StreamReader("roles.json"))
            {
                json = reader.ReadToEnd();
            }

            var config_ = JsonSerializer.Deserialize<RolesConfig>(json);
            Roles = config_.Roles;
        
            //ReadRolesFromConfig();

            if (Roles != null)
            {
                rolecombobox.DropDownStyle = ComboBoxStyle.DropDownList;
                rolecombobox.DataSource = Roles.ToList();
                rolecombobox.DisplayMember = "Value";
                rolecombobox.ValueMember = "Key";
                rolecombobox.SelectedIndex = 0;
                rolecombobox.Text = "Select your role";
            }
            else
            {
                MessageBox.Show("Error: Roles data could not be loaded.");
            }
        }
        
        private void loginbtn_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            AdminDashboard admin = new AdminDashboard();
            string username = usernametxt.Text;
            string password = passwordtxt.Text;
            string selectedRoleKey = rolecombobox.SelectedValue?.ToString();
    
            if (string.IsNullOrEmpty(selectedRoleKey))
            {
                MessageBox.Show("Please select a role.");
                return;
            }
            switch (selectedRoleKey)
            {
                case "Admin":
                    logged_user = username;
                    ValidateUser(username, password);
                    admin.Show();
                    break;
                case "Manager":
                    CheckPasswordExpiry(username);
                    ValidateUser(username, password);
                    break;
                case "Operator":
                    CheckPasswordExpiry(username);
                    ValidateUser(username, password);
                    break;
                case "Engineer":
                    CheckPasswordExpiry(username);
                    ValidateUser(username, password);
                    break;
                default:
                    MessageBox.Show("Unknown Role");
                    break;
            }
           
        }
       
        private void ValidateUser(string user_name, string pass_word)
        {
            bool passwordValidationResult = false;
            bool userFound = false;

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "Select password from Users where username = @username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            userFound = true;
                            reader.Read();
                            hashedPasswordFromDB = reader["password"].ToString();
                            passwordValidationResult = ValidatePassword(pass_word, hashedPasswordFromDB);
                        }
                    }
                }
                con.Close();

            }
            if (!passwordValidationResult)
            {
                failedLoginAttempts++;

                if (failedLoginAttempts >= 3)
                {
                    passwordtxt.Enabled = false;
                    //no dynamic behavior??
                    change_status(user_name);
                }
                else
                {
                    totalLoginAttempts--;
                    MessageBox.Show("Invalid password. Attempts left #" + totalLoginAttempts);
                }
            }
            else
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "Select username from Users where username= @username";

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
                                    MessageBox.Show("Login successful!");
                                    this.Hide();

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
            if (!userFound)
            {
                MessageBox.Show("Incorrect username.");
                return;
            }
            


        }
        

        private void change_status(string username)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "UPDATE Users SET active_status = @active_status WHERE username = @username ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@active_status", 0);
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
            using (var con = new SqlConnection(_connectionString))
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

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
        }
    }
}

