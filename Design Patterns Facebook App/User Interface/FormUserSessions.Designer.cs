namespace Design_Patterns_Facebook_App
{
    partial class FormUserSessions
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
            this.dataGridViewUserSessions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUserSessions
            // 
            this.dataGridViewUserSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserSessions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewUserSessions.Location = new System.Drawing.Point(0, 7);
            this.dataGridViewUserSessions.Name = "dataGridViewUserSessions";
            this.dataGridViewUserSessions.Size = new System.Drawing.Size(720, 473);
            this.dataGridViewUserSessions.TabIndex = 0;
            // 
            // FormUserSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.Controls.Add(this.dataGridViewUserSessions);
            this.Name = "FormUserSessions";
            this.Text = "FormUserSessions";
            this.Load += new System.EventHandler(this.FormUserSessions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserSessions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUserSessions;
    }
}