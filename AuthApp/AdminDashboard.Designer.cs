namespace AuthApp
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tabControl1 = new TabControl();
            createuser = new TabPage();
            label12 = new Label();
            create_btn = new Button();
            password_txt = new TextBox();
            username_txt = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            usercombobox = new ComboBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            panel3 = new Panel();
            statuscombobox = new ComboBox();
            current_status_txt = new TextBox();
            current_status_lbl = new Label();
            changestatus_btn = new Button();
            changestatus_lbl = new Label();
            validatebtn = new Button();
            label8 = new Label();
            user_validationtxt = new TextBox();
            label6 = new Label();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            reset_btn = new Button();
            resetpasstxt = new TextBox();
            Validate_btn = new Button();
            usernametxt = new TextBox();
            new_pass_lbl = new Label();
            label11 = new Label();
            label9 = new Label();
            panel2 = new Panel();
            change_pass_btn = new Button();
            button1 = new Button();
            createuser_btn = new Button();
            logout_btn = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            createuser.SuspendLayout();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-7, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1138, 724);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(createuser);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(344, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 724);
            tabControl1.TabIndex = 1;
            // 
            // createuser
            // 
            createuser.BackColor = Color.SlateGray;
            createuser.Controls.Add(label12);
            createuser.Controls.Add(create_btn);
            createuser.Controls.Add(password_txt);
            createuser.Controls.Add(username_txt);
            createuser.Controls.Add(label5);
            createuser.Controls.Add(label4);
            createuser.Controls.Add(label3);
            createuser.Controls.Add(usercombobox);
            createuser.Controls.Add(label2);
            createuser.Location = new Point(4, 29);
            createuser.Name = "createuser";
            createuser.Padding = new Padding(3);
            createuser.Size = new Size(786, 691);
            createuser.TabIndex = 0;
            createuser.Text = "createuser";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(164, 424);
            label12.Name = "label12";
            label12.Size = new Size(93, 28);
            label12.TabIndex = 8;
            label12.Text = "Password";
            // 
            // create_btn
            // 
            create_btn.Location = new Point(367, 515);
            create_btn.Name = "create_btn";
            create_btn.Size = new Size(106, 29);
            create_btn.TabIndex = 7;
            create_btn.Text = "Create User";
            create_btn.UseVisualStyleBackColor = true;
            create_btn.Click += button1_Click;
            // 
            // password_txt
            // 
            password_txt.Location = new Point(307, 428);
            password_txt.Name = "password_txt";
            password_txt.Size = new Size(217, 27);
            password_txt.TabIndex = 6;
            // 
            // username_txt
            // 
            username_txt.Location = new Point(308, 350);
            username_txt.Name = "username_txt";
            username_txt.Size = new Size(216, 27);
            username_txt.TabIndex = 5;
            username_txt.TextChanged += username_txt_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(178, 425);
            label5.Name = "label5";
            label5.Size = new Size(0, 28);
            label5.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(168, 346);
            label4.Name = "label4";
            label4.Size = new Size(99, 28);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(165, 217);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 2;
            label3.Text = "Select role: ";
            // 
            // usercombobox
            // 
            usercombobox.FormattingEnabled = true;
            usercombobox.Location = new Point(298, 217);
            usercombobox.Name = "usercombobox";
            usercombobox.Size = new Size(226, 28);
            usercombobox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(318, 90);
            label2.Name = "label2";
            label2.Size = new Size(137, 38);
            label2.TabIndex = 0;
            label2.Text = "Add User";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 691);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SlateGray;
            panel3.Controls.Add(statuscombobox);
            panel3.Controls.Add(current_status_txt);
            panel3.Controls.Add(current_status_lbl);
            panel3.Controls.Add(changestatus_btn);
            panel3.Controls.Add(changestatus_lbl);
            panel3.Controls.Add(validatebtn);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(user_validationtxt);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(785, 694);
            panel3.TabIndex = 0;
            // 
            // statuscombobox
            // 
            statuscombobox.FormattingEnabled = true;
            statuscombobox.Location = new Point(332, 449);
            statuscombobox.Name = "statuscombobox";
            statuscombobox.Size = new Size(244, 28);
            statuscombobox.TabIndex = 11;
            // 
            // current_status_txt
            // 
            current_status_txt.Location = new Point(332, 379);
            current_status_txt.Name = "current_status_txt";
            current_status_txt.Size = new Size(244, 27);
            current_status_txt.TabIndex = 10;
            // 
            // current_status_lbl
            // 
            current_status_lbl.AutoSize = true;
            current_status_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            current_status_lbl.Location = new Point(155, 375);
            current_status_lbl.Name = "current_status_lbl";
            current_status_lbl.Size = new Size(135, 28);
            current_status_lbl.TabIndex = 9;
            current_status_lbl.Text = "Current Status";
            // 
            // changestatus_btn
            // 
            changestatus_btn.Location = new Point(366, 505);
            changestatus_btn.Name = "changestatus_btn";
            changestatus_btn.Size = new Size(106, 29);
            changestatus_btn.TabIndex = 8;
            changestatus_btn.Text = "Ok";
            changestatus_btn.UseVisualStyleBackColor = true;
            changestatus_btn.Click += changestatus_btn_Click;
            // 
            // changestatus_lbl
            // 
            changestatus_lbl.AutoSize = true;
            changestatus_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changestatus_lbl.Location = new Point(155, 434);
            changestatus_lbl.Name = "changestatus_lbl";
            changestatus_lbl.Size = new Size(136, 28);
            changestatus_lbl.TabIndex = 6;
            changestatus_lbl.Text = "Change Status";
            // 
            // validatebtn
            // 
            validatebtn.Location = new Point(366, 259);
            validatebtn.Name = "validatebtn";
            validatebtn.Size = new Size(156, 31);
            validatebtn.TabIndex = 5;
            validatebtn.Text = "Validate";
            validatebtn.UseVisualStyleBackColor = true;
            validatebtn.Click += validatebtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(186, 200);
            label8.Name = "label8";
            label8.Size = new Size(99, 28);
            label8.TabIndex = 4;
            label8.Text = "Username";
            // 
            // user_validationtxt
            // 
            user_validationtxt.Location = new Point(321, 201);
            user_validationtxt.Name = "user_validationtxt";
            user_validationtxt.Size = new Size(244, 27);
            user_validationtxt.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(261, 94);
            label6.Name = "label6";
            label6.Size = new Size(270, 38);
            label6.TabIndex = 0;
            label6.Text = "Change User Status";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel4);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 691);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SlateGray;
            panel4.Controls.Add(reset_btn);
            panel4.Controls.Add(resetpasstxt);
            panel4.Controls.Add(Validate_btn);
            panel4.Controls.Add(usernametxt);
            panel4.Controls.Add(new_pass_lbl);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label9);
            panel4.ForeColor = SystemColors.ButtonHighlight;
            panel4.Location = new Point(-4, -26);
            panel4.Name = "panel4";
            panel4.Size = new Size(794, 718);
            panel4.TabIndex = 0;
            // 
            // reset_btn
            // 
            reset_btn.ForeColor = SystemColors.ActiveCaptionText;
            reset_btn.Location = new Point(344, 503);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(106, 29);
            reset_btn.TabIndex = 7;
            reset_btn.Text = "Reset";
            reset_btn.UseVisualStyleBackColor = true;
            reset_btn.Click += reset_btn_Click;
            // 
            // resetpasstxt
            // 
            resetpasstxt.Location = new Point(315, 428);
            resetpasstxt.Name = "resetpasstxt";
            resetpasstxt.Size = new Size(180, 27);
            resetpasstxt.TabIndex = 6;
            // 
            // Validate_btn
            // 
            Validate_btn.ForeColor = SystemColors.ActiveCaptionText;
            Validate_btn.Location = new Point(344, 348);
            Validate_btn.Name = "Validate_btn";
            Validate_btn.Size = new Size(106, 29);
            Validate_btn.TabIndex = 5;
            Validate_btn.Text = "Validate";
            Validate_btn.UseVisualStyleBackColor = true;
            Validate_btn.Click += Validate_btn_Click;
            // 
            // usernametxt
            // 
            usernametxt.Location = new Point(322, 276);
            usernametxt.Name = "usernametxt";
            usernametxt.Size = new Size(193, 27);
            usernametxt.TabIndex = 4;
            // 
            // new_pass_lbl
            // 
            new_pass_lbl.AutoSize = true;
            new_pass_lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            new_pass_lbl.ForeColor = SystemColors.ActiveCaptionText;
            new_pass_lbl.Location = new Point(173, 428);
            new_pass_lbl.Name = "new_pass_lbl";
            new_pass_lbl.Size = new Size(112, 20);
            new_pass_lbl.TabIndex = 3;
            new_pass_lbl.Text = "New password";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(173, 276);
            label11.Name = "label11";
            label11.Size = new Size(121, 20);
            label11.TabIndex = 2;
            label11.Text = "Enter Username";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(282, 91);
            label9.Name = "label9";
            label9.Size = new Size(207, 38);
            label9.TabIndex = 0;
            label9.Text = "Reset Password";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(change_pass_btn);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(createuser_btn);
            panel2.Controls.Add(logout_btn);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(346, 724);
            panel2.TabIndex = 0;
            // 
            // change_pass_btn
            // 
            change_pass_btn.Location = new Point(72, 289);
            change_pass_btn.Name = "change_pass_btn";
            change_pass_btn.Size = new Size(133, 55);
            change_pass_btn.TabIndex = 4;
            change_pass_btn.Text = "Change password";
            change_pass_btn.UseVisualStyleBackColor = true;
            change_pass_btn.Click += change_pass_btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(72, 217);
            button1.Name = "button1";
            button1.Size = new Size(140, 40);
            button1.TabIndex = 3;
            button1.Text = "Change Status";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // createuser_btn
            // 
            createuser_btn.Location = new Point(72, 148);
            createuser_btn.Name = "createuser_btn";
            createuser_btn.Size = new Size(140, 41);
            createuser_btn.TabIndex = 2;
            createuser_btn.Text = "Create User";
            createuser_btn.UseVisualStyleBackColor = true;
            createuser_btn.Click += createuser_btn_Click;
            // 
            // logout_btn
            // 
            logout_btn.Location = new Point(90, 646);
            logout_btn.Name = "logout_btn";
            logout_btn.Size = new Size(122, 44);
            logout_btn.TabIndex = 1;
            logout_btn.Text = "Logout";
            logout_btn.UseVisualStyleBackColor = true;
            logout_btn.Click += logout_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 44);
            label1.Name = "label1";
            label1.Size = new Size(175, 35);
            label1.TabIndex = 0;
            label1.Text = "Dashbaord";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 721);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            createuser.ResumeLayout(false);
            createuser.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TabControl tabControl1;
        private TabPage createuser;
        private TabPage tabPage2;
        private Button logout_btn;
        private Button createuser_btn;
        private Label label2;
        private ComboBox usercombobox;
        private Button create_btn;
        private TextBox password_txt;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button1;
        private Panel panel3;
        private TextBox user_validationtxt;
        private Label label6;
        private Label label8;
        private Button validatebtn;
        private Label changestatus_lbl;
        private Button changestatus_btn;
        private ComboBox statuscombobox;
        private TextBox current_status_txt;
        private Label current_status_lbl;
        private Button change_pass_btn;
        private TabPage tabPage1;
        private Panel panel4;
        private Label label9;
        private Label new_pass_lbl;
        private Label label11;
        private TextBox usernametxt;
        private Button Validate_btn;
        private TextBox resetpasstxt;
        private Button reset_btn;
        private Label label12;
        private Label label13;
        private TextBox username_txt;
    }
}