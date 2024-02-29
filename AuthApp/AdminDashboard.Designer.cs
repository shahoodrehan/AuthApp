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
            label7 = new Label();
            changecombobox = new ComboBox();
            user_validationtxt = new TextBox();
            label6 = new Label();
            panel2 = new Panel();
            button1 = new Button();
            createuser_btn = new Button();
            logout_btn = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            createuser.SuspendLayout();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-6, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1012, 724);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(createuser);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(306, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(706, 724);
            tabControl1.TabIndex = 1;
            // 
            // createuser
            // 
            createuser.BackColor = Color.SlateGray;
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
            createuser.Size = new Size(698, 691);
            createuser.TabIndex = 0;
            createuser.Text = "createuser";
            // 
            // create_btn
            // 
            create_btn.Location = new Point(287, 576);
            create_btn.Name = "create_btn";
            create_btn.Size = new Size(94, 29);
            create_btn.TabIndex = 7;
            create_btn.Text = "Create User";
            create_btn.UseVisualStyleBackColor = true;
            create_btn.Click += button1_Click;
            // 
            // password_txt
            // 
            password_txt.Location = new Point(297, 426);
            password_txt.Name = "password_txt";
            password_txt.Size = new Size(193, 27);
            password_txt.TabIndex = 6;
            // 
            // username_txt
            // 
            username_txt.Location = new Point(298, 350);
            username_txt.Name = "username_txt";
            username_txt.Size = new Size(192, 27);
            username_txt.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(158, 425);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 4;
            label5.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(149, 346);
            label4.Name = "label4";
            label4.Size = new Size(99, 28);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(158, 213);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 2;
            label3.Text = "Select role: ";
            // 
            // usercombobox
            // 
            usercombobox.FormattingEnabled = true;
            usercombobox.Location = new Point(297, 217);
            usercombobox.Name = "usercombobox";
            usercombobox.Size = new Size(201, 28);
            usercombobox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(283, 90);
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
            tabPage2.Size = new Size(698, 691);
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
            panel3.Controls.Add(label7);
            panel3.Controls.Add(changecombobox);
            panel3.Controls.Add(user_validationtxt);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(698, 694);
            panel3.TabIndex = 0;
            // 
            // statuscombobox
            // 
            statuscombobox.FormattingEnabled = true;
            statuscombobox.Location = new Point(285, 506);
            statuscombobox.Name = "statuscombobox";
            statuscombobox.Size = new Size(217, 28);
            statuscombobox.TabIndex = 11;
            // 
            // current_status_txt
            // 
            current_status_txt.Location = new Point(285, 457);
            current_status_txt.Name = "current_status_txt";
            current_status_txt.Size = new Size(217, 27);
            current_status_txt.TabIndex = 10;
            // 
            // current_status_lbl
            // 
            current_status_lbl.AutoSize = true;
            current_status_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            current_status_lbl.Location = new Point(129, 453);
            current_status_lbl.Name = "current_status_lbl";
            current_status_lbl.Size = new Size(135, 28);
            current_status_lbl.TabIndex = 9;
            current_status_lbl.Text = "Current Status";
            // 
            // changestatus_btn
            // 
            changestatus_btn.Location = new Point(315, 562);
            changestatus_btn.Name = "changestatus_btn";
            changestatus_btn.Size = new Size(94, 29);
            changestatus_btn.TabIndex = 8;
            changestatus_btn.Text = "Ok";
            changestatus_btn.UseVisualStyleBackColor = true;
            changestatus_btn.Click += changestatus_btn_Click;
            // 
            // changestatus_lbl
            // 
            changestatus_lbl.AutoSize = true;
            changestatus_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changestatus_lbl.Location = new Point(128, 491);
            changestatus_lbl.Name = "changestatus_lbl";
            changestatus_lbl.Size = new Size(136, 28);
            changestatus_lbl.TabIndex = 6;
            changestatus_lbl.Text = "Change Status";
            // 
            // validatebtn
            // 
            validatebtn.Location = new Point(315, 322);
            validatebtn.Name = "validatebtn";
            validatebtn.Size = new Size(139, 31);
            validatebtn.TabIndex = 5;
            validatebtn.Text = "Validate";
            validatebtn.UseVisualStyleBackColor = true;
            validatebtn.Click += validatebtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(137, 255);
            label8.Name = "label8";
            label8.Size = new Size(99, 28);
            label8.TabIndex = 4;
            label8.Text = "Username";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(157, 190);
            label7.Name = "label7";
            label7.Size = new Size(107, 28);
            label7.TabIndex = 3;
            label7.Text = "Select Role";
            // 
            // changecombobox
            // 
            changecombobox.FormattingEnabled = true;
            changecombobox.Location = new Point(285, 187);
            changecombobox.Name = "changecombobox";
            changecombobox.Size = new Size(217, 28);
            changecombobox.TabIndex = 2;
            changecombobox.SelectedIndexChanged += changecombobox_SelectedIndexChanged;
            // 
            // user_validationtxt
            // 
            user_validationtxt.Location = new Point(285, 255);
            user_validationtxt.Name = "user_validationtxt";
            user_validationtxt.Size = new Size(217, 27);
            user_validationtxt.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(232, 94);
            label6.Name = "label6";
            label6.Size = new Size(270, 38);
            label6.TabIndex = 0;
            label6.Text = "Change User Status";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(createuser_btn);
            panel2.Controls.Add(logout_btn);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(308, 724);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(64, 217);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 3;
            button1.Text = "Change Status";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // createuser_btn
            // 
            createuser_btn.Location = new Point(64, 148);
            createuser_btn.Name = "createuser_btn";
            createuser_btn.Size = new Size(124, 41);
            createuser_btn.TabIndex = 2;
            createuser_btn.Text = "Create User";
            createuser_btn.UseVisualStyleBackColor = true;
            createuser_btn.Click += createuser_btn_Click;
            // 
            // logout_btn
            // 
            logout_btn.Location = new Point(80, 646);
            logout_btn.Name = "logout_btn";
            logout_btn.Size = new Size(108, 44);
            logout_btn.TabIndex = 1;
            logout_btn.Text = "Logout";
            logout_btn.UseVisualStyleBackColor = true;
            logout_btn.Click += logout_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(53, 44);
            label1.Name = "label1";
            label1.Size = new Size(175, 35);
            label1.TabIndex = 0;
            label1.Text = "Dashbaord";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(panel1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            createuser.ResumeLayout(false);
            createuser.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private TextBox username_txt;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button1;
        private Panel panel3;
        private ComboBox changecombobox;
        private TextBox user_validationtxt;
        private Label label6;
        private Label label8;
        private Label label7;
        private Button validatebtn;
        private Label changestatus_lbl;
        private Button changestatus_btn;
        private ComboBox statuscombobox;
        private TextBox current_status_txt;
        private Label current_status_lbl;
    }
}