using Azure.Identity;
using Microsoft.Data.SqlClient;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AuthApp
{
    public partial class Form1 : Form
    {
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
                ValidateManager(username, password);
                login.Dispose();

            }
            else if (selectedRole == "Operator")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                ValidateOperator(username, password);
                login.Dispose();


            }
            else if (selectedRole == "Engineer")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT username, password FROM Users WHERE username = @username AND password = @password AND roles = 'Admin';";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", pass_word);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (usernametxt.Text == user_name)
                            {
                                if (passwordtxt.Text == pass_word)
                                {
                                    MessageBox.Show("Login successful for Admin!");

                                }
                                else
                                {

                                    MessageBox.Show("Invalid password");
                                }
                            }
                            else if (usernametxt.Text != user_name)
                            {
                                MessageBox.Show("Invalid Username");
                            }

                        }

                    }
                }
                con.Close();
            }
        }
        private void ValidateManager(string user_name, string pass_word)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select username, password from Users where username= @username AND password=@password AND roles='Manager';";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", pass_word);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            if (usernametxt.Text == user_name)
                            {
                                if (passwordtxt.Text == pass_word)
                                {
                                    MessageBox.Show("Login successful for Manager!");
                                }
                                else
                                {

                                    MessageBox.Show("Invalid password");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username");
                            }

                        }
                        else
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
                                MessageBox.Show("Invalid username or password. Attempt's left #" + totalLoginAttempts);
                            }
                        }
                    }
                }
                con.Close();
            }
        }
        private void ValidateOperator(string user_name, string pass_word)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select username, password from Users where username= @username AND password=@password AND roles='Operator';";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", pass_word);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            if (usernametxt.Text == user_name)
                            {
                                if (passwordtxt.Text == pass_word)
                                {
                                    MessageBox.Show("Login successful for Operator!");
                                }
                                else
                                {

                                    MessageBox.Show("Invalid password");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username");
                            }

                        }
                        else
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
                                MessageBox.Show("Invalid username or password. Attempt's left #" + totalLoginAttempts);
                            }
                        }
                    }
                }
                con.Close();
            }
        }
        private void ValidateEngineer(string user_name, string pass_word)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select username, password from Users where username= @username AND password=@password AND roles='Engineer';";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", pass_word);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            if (usernametxt.Text == user_name)
                            {
                                if (passwordtxt.Text == pass_word)
                                {
                                    MessageBox.Show("Login successful for Engineer!");
                                }
                                else
                                {

                                    MessageBox.Show("Invalid password");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username");
                            }

                        }
                        else
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
                                MessageBox.Show("Invalid username or password. Attempt's left #" + totalLoginAttempts);
                            }
                        }
                    }
                }
                con.Close();
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
    }
}

