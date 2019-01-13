namespace Design_Patterns_Facebook_App
{
    public partial class FormApplicationBrowser
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
            this.webBrowserYoutubeBrowserPlayer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserYoutubeBrowserPlayer
            // 
            this.webBrowserYoutubeBrowserPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserYoutubeBrowserPlayer.Location = new System.Drawing.Point(0, 0);
            this.webBrowserYoutubeBrowserPlayer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserYoutubeBrowserPlayer.Name = "webBrowserYoutubeBrowserPlayer";
            this.webBrowserYoutubeBrowserPlayer.Size = new System.Drawing.Size(875, 409);
            this.webBrowserYoutubeBrowserPlayer.TabIndex = 0;
            // 
            // FormApplicationBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 409);
            this.Controls.Add(this.webBrowserYoutubeBrowserPlayer);
            this.Name = "FormApplicationBrowser";
            this.Text = "FromYoutubePlayer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserYoutubeBrowserPlayer;
    }
}