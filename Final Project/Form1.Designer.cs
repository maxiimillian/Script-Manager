namespace Final_Project
{
    partial class Form1
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
            this.lblSave = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.styleManager1 = new MetroSet_UI.Components.StyleManager();
            this.lstBoxProcesses = new System.Windows.Forms.ListBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.inputName = new System.Windows.Forms.TextBox();
            this.lstBoxTest = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.lblSave.Font = new System.Drawing.Font("Bahnschrift Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.ForeColor = System.Drawing.Color.White;
            this.lblSave.Location = new System.Drawing.Point(457, 14);
            this.lblSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSave.MinimumSize = new System.Drawing.Size(200, 0);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(200, 23);
            this.lblSave.TabIndex = 4;
            this.lblSave.Text = "Create New Save";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(458, 47);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 18);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.ForeColor = System.Drawing.Color.White;
            this.lblFile.Location = new System.Drawing.Point(458, 93);
            this.lblFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(35, 18);
            this.lblFile.TabIndex = 7;
            this.lblFile.Text = "File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(457, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.MinimumSize = new System.Drawing.Size(351, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Saved Files";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MinimumSize = new System.Drawing.Size(351, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Active Processes";
            // 
            // styleManager1
            // 
            this.styleManager1.CustomTheme = "C:\\Users\\frogg\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.styleManager1.MetroForm = this;
            this.styleManager1.Style = MetroSet_UI.Enums.Style.Custom;
            this.styleManager1.ThemeAuthor = "Narwin";
            this.styleManager1.ThemeName = "MetroDark";
            // 
            // lstBoxProcesses
            // 
            this.lstBoxProcesses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.lstBoxProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxProcesses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstBoxProcesses.ForeColor = System.Drawing.Color.White;
            this.lstBoxProcesses.FormattingEnabled = true;
            this.lstBoxProcesses.ItemHeight = 18;
            this.lstBoxProcesses.Location = new System.Drawing.Point(44, 70);
            this.lstBoxProcesses.Name = "lstBoxProcesses";
            this.lstBoxProcesses.Size = new System.Drawing.Size(348, 432);
            this.lstBoxProcesses.TabIndex = 21;
            this.lstBoxProcesses.DoubleClick += new System.EventHandler(this.lstBoxProcesses_DoubleClick);
            // 
            // btnFile
            // 
            this.btnFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.btnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile.FlatAppearance.BorderSize = 0;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.ForeColor = System.Drawing.Color.White;
            this.btnFile.Location = new System.Drawing.Point(527, 87);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(129, 30);
            this.btnFile.TabIndex = 23;
            this.btnFile.Text = "Browse";
            this.btnFile.UseVisualStyleBackColor = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(459, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(197, 36);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputName
            // 
            this.inputName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.inputName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputName.ForeColor = System.Drawing.Color.White;
            this.inputName.Location = new System.Drawing.Point(527, 45);
            this.inputName.MinimumSize = new System.Drawing.Size(2, 30);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(129, 26);
            this.inputName.TabIndex = 25;
            // 
            // lstBoxTest
            // 
            this.lstBoxTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.lstBoxTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxTest.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lstBoxTest.ForeColor = System.Drawing.Color.White;
            this.lstBoxTest.FormattingEnabled = true;
            this.lstBoxTest.ItemHeight = 18;
            this.lstBoxTest.Location = new System.Drawing.Point(459, 265);
            this.lstBoxTest.Name = "lstBoxTest";
            this.lstBoxTest.Size = new System.Drawing.Size(349, 234);
            this.lstBoxTest.TabIndex = 26;
            this.lstBoxTest.DoubleClick += new System.EventHandler(this.lstBoxTest_DoubleClick);
            this.lstBoxTest.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoxTest_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(884, 623);
            this.Controls.Add(this.lstBoxTest);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lstBoxProcesses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSave);
            this.Font = new System.Drawing.Font("Bahnschrift Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroSet_UI.Components.StyleManager styleManager1;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ListBox lstBoxProcesses;
        private System.Windows.Forms.ListBox lstBoxTest;
    }
}

