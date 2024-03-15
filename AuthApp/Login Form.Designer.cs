namespace AuthApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            exit_btn = new Button();
            label4 = new Label();
            rolecombobox = new ComboBox();
            loginbtn = new Button();
            passwordtxt = new TextBox();
            usernametxt = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(exit_btn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(rolecombobox);
            panel1.Controls.Add(loginbtn);
            panel1.Controls.Add(passwordtxt);
            panel1.Controls.Add(usernametxt);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1024, 768);
            panel1.TabIndex = 0;
            // 
            // exit_btn
            // 
            exit_btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit_btn.Location = new Point(490, 505);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(118, 48);
            exit_btn.TabIndex = 8;
            exit_btn.Text = "Exit";
            exit_btn.UseVisualStyleBackColor = true;
            exit_btn.Click += exit_btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(199, 204);
            label4.Name = "label4";
            label4.Size = new Size(148, 28);
            label4.TabIndex = 7;
            label4.Text = "Select your role";
            // 
            // rolecombobox
            // 
            rolecombobox.FormattingEnabled = true;
            rolecombobox.Location = new Point(388, 204);
            rolecombobox.Name = "rolecombobox";
            rolecombobox.Size = new Size(263, 28);
            rolecombobox.TabIndex = 6;
            rolecombobox.Text = "Select your role";
            // 
            // loginbtn
            // 
            loginbtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginbtn.Location = new Point(333, 506);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(124, 41);
            loginbtn.TabIndex = 5;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // passwordtxt
            // 
            passwordtxt.BorderStyle = BorderStyle.None;
            passwordtxt.Location = new Point(388, 414);
            passwordtxt.Multiline = true;
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(263, 34);
            passwordtxt.TabIndex = 4;
            passwordtxt.TextChanged += passwordtxt_TextChanged;
            // 
            // usernametxt
            // 
            usernametxt.BorderStyle = BorderStyle.None;
            usernametxt.Location = new Point(388, 353);
            usernametxt.Multiline = true;
            usernametxt.Name = "usernametxt";
            usernametxt.Size = new Size(263, 34);
            usernametxt.TabIndex = 3;
            usernametxt.TextChanged += usernametxt_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(199, 406);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(199, 346);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(388, 110);
            label1.Name = "label1";
            label1.Size = new Size(198, 38);
            label1.TabIndex = 0;
            label1.Text = "Authentication";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Login Form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox passwordtxt;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button loginbtn;
        private Label label4;
        private ComboBox rolecombobox;
        private Button exit_btn;
        public TextBox usernametxt;
    }
}
