using System.Drawing;

namespace Design_Patterns_Facebook_App
{
    public partial class FormMainUserInterface
    {
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainUserInterface));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageListLoginLogout = new System.Windows.Forms.ImageList(this.components);
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonFacebookLogin = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonUserSessions = new System.Windows.Forms.Button();
            this.buttonLikedPagesManager = new System.Windows.Forms.Button();
            this.buttonYoutubePostsManager = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelDbConnection = new System.Windows.Forms.Label();
            this.buttonConnectionStatus = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new Design_Patterns_Facebook_App.ProfilePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "youtube.png");
            this.imageList1.Images.SetKeyName(1, "play2.jpg");
            this.imageList1.Images.SetKeyName(2, "play.png");
            this.imageList1.Images.SetKeyName(3, "button_export-to-excel.png");
            this.imageList1.Images.SetKeyName(4, "button_show-my-events.png");
            this.imageList1.Images.SetKeyName(5, "button_export-to-excel (2).png");
            this.imageList1.Images.SetKeyName(6, "button_export-to-excel.jpg");
            this.imageList1.Images.SetKeyName(7, "button.png");
            this.imageList1.Images.SetKeyName(8, "exportToExcel.png");
            this.imageList1.Images.SetKeyName(9, "buttonYoutubeLinks.png");
            this.imageList1.Images.SetKeyName(10, "buttonyoutube.png");
            this.imageList1.Images.SetKeyName(11, "frame1.jpg");
            this.imageList1.Images.SetKeyName(12, "remove2.png");
            this.imageList1.Images.SetKeyName(13, "FacebookButton_post-image.jpg");
            this.imageList1.Images.SetKeyName(14, "logout.png");
            this.imageList1.Images.SetKeyName(15, "buttonDelete.jpg");
            this.imageList1.Images.SetKeyName(16, "openFile.jpg");
            // 
            // imageListLoginLogout
            // 
            this.imageListLoginLogout.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLoginLogout.ImageStream")));
            this.imageListLoginLogout.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLoginLogout.Images.SetKeyName(0, "FacebookButton_post-image.jpg");
            this.imageListLoginLogout.Images.SetKeyName(1, "logout.png");
            // 
            // buttonLogout
            // 
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout.ImageIndex = 1;
            this.buttonLogout.ImageList = this.imageListLoginLogout;
            this.buttonLogout.Location = new System.Drawing.Point(284, 266);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(184, 33);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonFacebookLogin
            // 
            this.buttonFacebookLogin.FlatAppearance.BorderSize = 0;
            this.buttonFacebookLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFacebookLogin.ImageIndex = 0;
            this.buttonFacebookLogin.ImageList = this.imageListLoginLogout;
            this.buttonFacebookLogin.Location = new System.Drawing.Point(284, 207);
            this.buttonFacebookLogin.Name = "buttonFacebookLogin";
            this.buttonFacebookLogin.Size = new System.Drawing.Size(184, 33);
            this.buttonFacebookLogin.TabIndex = 0;
            this.buttonFacebookLogin.UseVisualStyleBackColor = true;
            this.buttonFacebookLogin.Click += new System.EventHandler(this.buttonFacebookLogin_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(173, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(455, 106);
            this.pictureBoxLogo.TabIndex = 50;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseDown);
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(284, 154);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(190, 20);
            this.textBoxAppID.TabIndex = 51;
            this.textBoxAppID.TextChanged += new System.EventHandler(this.textBoxAppID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "Enter App ID or leave empty for default ID";
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(65)))), ((int)(((byte)(126)))));
            this.buttonCloseForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCloseForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseForm.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseForm.ForeColor = System.Drawing.Color.White;
            this.buttonCloseForm.Location = new System.Drawing.Point(724, 9);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(45, 38);
            this.buttonCloseForm.TabIndex = 56;
            this.buttonCloseForm.Text = "X";
            this.buttonCloseForm.UseVisualStyleBackColor = false;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(65)))), ((int)(((byte)(126)))));
            this.panelTop.Controls.Add(this.button2);
            this.panelTop.Controls.Add(this.buttonCloseForm);
            this.panelTop.Controls.Add(this.pictureBoxLogo);
            this.panelTop.Location = new System.Drawing.Point(-5, -3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(785, 126);
            this.panelTop.TabIndex = 57;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(65)))), ((int)(((byte)(126)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(673, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 38);
            this.button2.TabIndex = 60;
            this.button2.Text = "__";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(65)))), ((int)(((byte)(126)))));
            this.panelRight.Location = new System.Drawing.Point(714, 118);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(66, 366);
            this.panelRight.TabIndex = 58;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseDown);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(65)))), ((int)(((byte)(126)))));
            this.panelLeft.Location = new System.Drawing.Point(-2, 118);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(60, 385);
            this.panelLeft.TabIndex = 59;
            this.panelLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseDown);
            // 
            // buttonUserSessions
            // 
            this.buttonUserSessions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUserSessions.BackgroundImage")));
            this.buttonUserSessions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUserSessions.FlatAppearance.BorderSize = 0;
            this.buttonUserSessions.Font = new System.Drawing.Font("Century", 12F);
            this.buttonUserSessions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonUserSessions.Location = new System.Drawing.Point(493, 305);
            this.buttonUserSessions.Name = "buttonUserSessions";
            this.buttonUserSessions.Size = new System.Drawing.Size(184, 149);
            this.buttonUserSessions.TabIndex = 60;
            this.buttonUserSessions.Text = "User Sessions";
            this.buttonUserSessions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonUserSessions.UseVisualStyleBackColor = true;
            this.buttonUserSessions.Click += new System.EventHandler(this.buttonUserSessions_Click);
            // 
            // buttonLikedPagesManager
            // 
            this.buttonLikedPagesManager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLikedPagesManager.BackgroundImage")));
            this.buttonLikedPagesManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLikedPagesManager.FlatAppearance.BorderSize = 0;
            this.buttonLikedPagesManager.Font = new System.Drawing.Font("Century", 12F);
            this.buttonLikedPagesManager.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLikedPagesManager.Location = new System.Drawing.Point(284, 305);
            this.buttonLikedPagesManager.Name = "buttonLikedPagesManager";
            this.buttonLikedPagesManager.Size = new System.Drawing.Size(184, 149);
            this.buttonLikedPagesManager.TabIndex = 62;
            this.buttonLikedPagesManager.Text = "Manage Liked Pages ";
            this.buttonLikedPagesManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonLikedPagesManager.UseVisualStyleBackColor = true;
            this.buttonLikedPagesManager.Click += new System.EventHandler(this.buttonLikedPagesManager_Click);
            // 
            // buttonYoutubePostsManager
            // 
            this.buttonYoutubePostsManager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonYoutubePostsManager.BackgroundImage")));
            this.buttonYoutubePostsManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYoutubePostsManager.FlatAppearance.BorderSize = 0;
            this.buttonYoutubePostsManager.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonYoutubePostsManager.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonYoutubePostsManager.Location = new System.Drawing.Point(79, 305);
            this.buttonYoutubePostsManager.Name = "buttonYoutubePostsManager";
            this.buttonYoutubePostsManager.Size = new System.Drawing.Size(184, 149);
            this.buttonYoutubePostsManager.TabIndex = 64;
            this.buttonYoutubePostsManager.Text = "Facebook Youtube Posts Manager";
            this.buttonYoutubePostsManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonYoutubePostsManager.UseVisualStyleBackColor = true;
            this.buttonYoutubePostsManager.Click += new System.EventHandler(this.buttonYoutubePostsManager_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(65)))), ((int)(((byte)(126)))));
            this.panel1.Location = new System.Drawing.Point(-5, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 60);
            this.panel1.TabIndex = 60;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelWelcome.Location = new System.Drawing.Point(489, 248);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(0, 20);
            this.labelWelcome.TabIndex = 65;
            // 
            // labelDbConnection
            // 
            this.labelDbConnection.AutoSize = true;
            this.labelDbConnection.BackColor = System.Drawing.Color.Transparent;
            this.labelDbConnection.Font = new System.Drawing.Font("Modern No. 20", 9F);
            this.labelDbConnection.Location = new System.Drawing.Point(533, 285);
            this.labelDbConnection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDbConnection.Name = "labelDbConnection";
            this.labelDbConnection.Size = new System.Drawing.Size(134, 15);
            this.labelDbConnection.TabIndex = 66;
            this.labelDbConnection.Text = "SQL Database Connection";
            // 
            // buttonConnectionStatus
            // 
            this.buttonConnectionStatus.BackColor = System.Drawing.Color.Red;
            this.buttonConnectionStatus.Location = new System.Drawing.Point(508, 284);
            this.buttonConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConnectionStatus.Name = "buttonConnectionStatus";
            this.buttonConnectionStatus.Size = new System.Drawing.Size(24, 19);
            this.buttonConnectionStatus.TabIndex = 67;
            this.buttonConnectionStatus.UseVisualStyleBackColor = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxProfile.Location = new System.Drawing.Point(545, 166);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(93, 74);
            this.pictureBoxProfile.TabIndex = 68;
            this.pictureBoxProfile.TabStop = false;
            // 
            // FormMainUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(780, 512);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.buttonConnectionStatus);
            this.Controls.Add(this.labelDbConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.buttonYoutubePostsManager);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.buttonLikedPagesManager);
            this.Controls.Add(this.buttonUserSessions);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.textBoxAppID);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonFacebookLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMainUserInterface";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Text = "Facebook Desktop Manager";
            this.Load += new System.EventHandler(this.FormMainUserInterface_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageListLoginLogout;
        private System.Windows.Forms.Button buttonFacebookLogin;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCloseForm;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonUserSessions;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonLikedPagesManager;
        private System.Windows.Forms.Button buttonYoutubePostsManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelDbConnection;
        private System.Windows.Forms.Button buttonConnectionStatus;
        private ProfilePictureBox pictureBoxProfile;
    }
}