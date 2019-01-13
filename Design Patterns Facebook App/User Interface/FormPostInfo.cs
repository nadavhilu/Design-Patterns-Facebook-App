using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using FacebookWrapper.ObjectModel;
using System.Threading;

namespace Design_Patterns_Facebook_App
{
    public partial class FormPostInfo : MaterialForm
    {
        public event EventHandler EventComplained;

        public Post ChosenPost { get; set; }

        public FormPostInfo(Post i_SelectedPost)
        {
            InitializeComponent();
            ChosenPost = i_SelectedPost;
            richTextBoxPostName.Text = ChosenPost.Name + " : " + ChosenPost.CreatedTime + "   (" + ChosenPost.LikedBy.ToList().Count + ") likes" ;
            richTextBoxPostDescription.Text = ChosenPost.Description;
            if (richTextBoxPostDescription.Text == string.Empty)
            {
                richTextBoxPostDescription.Text = "No Description Was Given To This Post";
            }

            pictureBoxPostPic.ImageLocation = ChosenPost.PictureURL;
            foreach (var comment in ChosenPost.Comments)
            {
                richTextBoxPostComments.Text += Environment.NewLine + "(" + comment.LikesCount + ") Likes" + Environment.NewLine + comment.CreatedTime + Environment.NewLine + comment.Message + "\n";
            }
        }

        public void UpdatePostInfo()
        {
            richTextBoxPostName.Text = ChosenPost.Name + " : " + ChosenPost.CreatedTime + ChosenPost;
            richTextBoxPostDescription.Text = ChosenPost.Description;
            if (richTextBoxPostDescription.Text == string.Empty)
            {
                richTextBoxPostDescription.Text = "No Description Was Given To This Post";
            }

            pictureBoxPostPic.ImageLocation = ChosenPost.PictureURL;

            foreach (var comment in ChosenPost.Comments)
            {
                richTextBoxPostComments.Text += Environment.NewLine + "(" + comment.LikesCount + ") Likes" + Environment.NewLine + comment.CreatedTime + Environment.NewLine + comment.Message + "\n";
            }
        }

        private void materialCheckBoxComplain_CheckedChanged(object sender, EventArgs e)
        {
            Thread threadForFetchingPagesPosts = new Thread(() => triggerForFiringEventComplained(sender, e));
            threadForFetchingPagesPosts.Start();

            // TODO: notify observer for change (addObserver(FormPagesPosts)), so when button clicked, database query for searching for existing record of the post name
            // if not exist such, create new one, if does exist, update values of likes\complainers
            // also: checking the number of complainers. if number of complainers is bigger than 10 - send mail to page owner.
            // MailToPage mailToPage = new MailToPage();
            // mailToPage.SendMail("yudhamdani@gmail.com");
        }

        private void triggerForFiringEventComplained(object sender, EventArgs e)
        {
            if (EventComplained != null)
            {
                EventComplained.Invoke(sender, e);
            }
        }
    }
}
