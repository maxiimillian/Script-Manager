namespace Script_Manager
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
            this.lstBoxProcesses = new System.Windows.Forms.ListBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.inputName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstBoxProcesses
            // 
            this.lstBoxProcesses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.lstBoxProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxProcesses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstBoxProcesses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBoxProcesses.ForeColor = System.Drawing.Color.White;
            this.lstBoxProcesses.FormattingEnabled = true;
            this.lstBoxProcesses.ItemHeight = 18;
            this.lstBoxProcesses.Location = new System.Drawing.Point(16, 52);
            this.lstBoxProcesses.Name = "lstBoxProcesses";
            this.lstBoxProcesses.Size = new System.Drawing.Size(348, 378);
            this.lstBoxProcesses.TabIndex = 21;
            this.lstBoxProcesses.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstBoxProcesses_MeasureItem);
            this.lstBoxProcesses.SelectedIndexChanged += new System.EventHandler(this.lstBoxProcesses_SelectedIndexChanged);
            this.lstBoxProcesses.DoubleClick += new System.EventHandler(this.lstBoxProcesses_DoubleClick);
            this.lstBoxProcesses.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoxProcesses_MouseUp);
            // 
            // btnFile
            // 
            this.btnFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.btnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile.FlatAppearance.BorderSize = 0;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.ForeColor = System.Drawing.Color.White;
            this.btnFile.Location = new System.Drawing.Point(12, 12);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(29, 26);
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
            this.btnSave.Location = new System.Drawing.Point(311, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 26);
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
            this.inputName.Location = new System.Drawing.Point(47, 12);
            this.inputName.MinimumSize = new System.Drawing.Size(2, 30);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(258, 26);
            this.inputName.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(376, 442);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lstBoxProcesses);
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
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ListBox lstBoxProcesses;
    }
}

