namespace Design_Patterns_Facebook_App
{
    partial class FormImageURL
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
            this.pictureBoxImageUrl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageUrl)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImageUrl
            // 
            this.pictureBoxImageUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImageUrl.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImageUrl.Name = "pictureBoxImageUrl";
            this.pictureBoxImageUrl.Size = new System.Drawing.Size(684, 365);
            this.pictureBoxImageUrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxImageUrl.TabIndex = 0;
            this.pictureBoxImageUrl.TabStop = false;
            // 
            // FormImageURL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 365);
            this.Controls.Add(this.pictureBoxImageUrl);
            this.Name = "FormImageURL";
            this.Text = "FormImageURL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageUrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImageUrl;
    }
}