using Azure.Identity;
using Microsoft.Data.SqlClient;
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
            string username, password;
            string selectedRole = rolecombobox.SelectedItem.ToString();

            if (selectedRole == "Admin")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                ValidateAdmin(username, password);

            }
            else if (selectedRole == "Manager")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;


            }
            else if (selectedRole == "Operator")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;


            }
            else if (selectedRole == "Engineer")
            {
                username = usernametxt.Text;
                password = passwordtxt.Text;
                ValidateEngineer(username, password);
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
                            // Invalid username or password for Engineer role
                            failedLoginAttempts++;

                            if (failedLoginAttempts >= 3)
                            {

                                passwordtxt.Enabled = false;
                                MessageBox.Show("Password disabled. Contact admin to reset your password.");
                            }
                            else
                            {
                                totalLoginAttempts--;
                                MessageBox.Show("Invalid username or password. Attempt's left #" + totalLoginAttempts);
                            }
                        }
                    }
                }
            }
        }
    }
}

