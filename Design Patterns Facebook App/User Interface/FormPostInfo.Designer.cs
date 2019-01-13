namespace Design_Patterns_Facebook_App
{
    partial class FormPostInfo
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
            this.richTextBoxPostDescription = new System.Windows.Forms.RichTextBox();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBoxComplain = new MaterialSkin.Controls.MaterialCheckBox();
            this.richTextBoxPostName = new System.Windows.Forms.RichTextBox();
            this.richTextBoxPostComments = new System.Windows.Forms.RichTextBox();
            this.labelPostComments = new System.Windows.Forms.Label();
            this.pictureBoxPostPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPic)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxPostDescription
            // 
            this.richTextBoxPostDescription.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBoxPostDescription.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPostDescription.Location = new System.Drawing.Point(56, 129);
            this.richTextBoxPostDescription.Name = "richTextBoxPostDescription";
            this.richTextBoxPostDescription.Size = new System.Drawing.Size(470, 138);
            this.richTextBoxPostDescription.TabIndex = 0;
            this.richTextBoxPostDescription.Text = "";  
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(130, 286);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(93, 30);
            this.materialCheckBox1.TabIndex = 1;
            this.materialCheckBox1.Text = "Nice Post!";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            // 
            // materialCheckBoxComplain
            // 
            this.materialCheckBoxComplain.AutoSize = true;
            this.materialCheckBoxComplain.Depth = 0;
            this.materialCheckBoxComplain.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBoxComplain.Location = new System.Drawing.Point(346, 286);
            this.materialCheckBoxComplain.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBoxComplain.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBoxComplain.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBoxComplain.Name = "materialCheckBoxComplain";
            this.materialCheckBoxComplain.Ripple = true;
            this.materialCheckBoxComplain.Size = new System.Drawing.Size(88, 30);
            this.materialCheckBoxComplain.TabIndex = 2;
            this.materialCheckBoxComplain.Text = "Complain";
            this.materialCheckBoxComplain.UseVisualStyleBackColor = true;
            this.materialCheckBoxComplain.CheckedChanged += new System.EventHandler(this.materialCheckBoxComplain_CheckedChanged);
            // 
            // richTextBoxPostName
            // 
            this.richTextBoxPostName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBoxPostName.Location = new System.Drawing.Point(56, 78);
            this.richTextBoxPostName.Name = "richTextBoxPostName";
            this.richTextBoxPostName.Size = new System.Drawing.Size(470, 33);
            this.richTextBoxPostName.TabIndex = 3;
            this.richTextBoxPostName.Text = "";
            // 
            // richTextBoxPostComments
            // 
            this.richTextBoxPostComments.Location = new System.Drawing.Point(541, 137);
            this.richTextBoxPostComments.Name = "richTextBoxPostComments";
            this.richTextBoxPostComments.Size = new System.Drawing.Size(371, 126);
            this.richTextBoxPostComments.TabIndex = 4;
            this.richTextBoxPostComments.Text = "";
            // 
            // labelPostComments
            // 
            this.labelPostComments.AutoSize = true;
            this.labelPostComments.Font = new System.Drawing.Font("AR ESSENCE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostComments.Location = new System.Drawing.Point(669, 78);
            this.labelPostComments.Name = "labelPostComments";
            this.labelPostComments.Size = new System.Drawing.Size(116, 23);
            this.labelPostComments.TabIndex = 5;
            this.labelPostComments.Text = "Post Comments";
            // 
            // pictureBoxPostPic
            // 
            this.pictureBoxPostPic.Location = new System.Drawing.Point(541, 78);
            this.pictureBoxPostPic.Name = "pictureBoxPostPic";
            this.pictureBoxPostPic.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxPostPic.TabIndex = 6;
            this.pictureBoxPostPic.TabStop = false;
            // 
            // FormPostInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1078, 407);
            this.Controls.Add(this.pictureBoxPostPic);
            this.Controls.Add(this.labelPostComments);
            this.Controls.Add(this.richTextBoxPostComments);
            this.Controls.Add(this.richTextBoxPostName);
            this.Controls.Add(this.materialCheckBoxComplain);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.richTextBoxPostDescription);
            this.Name = "FormPostInfo";
            this.Text = "FormPostInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxPostDescription;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBoxComplain;
        private System.Windows.Forms.RichTextBox richTextBoxPostName;
        private System.Windows.Forms.RichTextBox richTextBoxPostComments;
        private System.Windows.Forms.Label labelPostComments;
        private System.Windows.Forms.PictureBox pictureBoxPostPic;
    }
}