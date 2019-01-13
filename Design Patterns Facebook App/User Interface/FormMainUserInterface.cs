using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using static System.Windows.Forms.ListView;
using System.Threading;
using System.Runtime.InteropServices;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

/// <summary>
/// This Form is the main user interface of the application. it is the first screen the user sees
/// when running the app. it is also the way to get to all the other forms.
/// </summary>
/// 
namespace Design_Patterns_Facebook_App
{
    public partial class FormMainUserInterface : Form
    {
        private readonly UserSessionsDatabaseFacade r_ApplicationDatabase;  
        private IFacebookFeature m_SelectedFeature = null; 
        Logic m_Logic;
              
        public FormMainUserInterface()
        {
            m_Logic = new Logic();
            m_SelectedFeature = m_Logic.LatestPagesPostsFeature;
            r_ApplicationDatabase = new UserSessionsDatabaseFacade(m_Logic.GetLoggedInUser);
            InitializeComponent();
            if (UserSessionsDatabaseFacade.IsValidServerConnection)
            {
                buttonConnectionStatus.BackColor = Color.Green;
            }
        }

        #region MakeFormDraggable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        #endregion
        private void buttonFacebookLogin_Click(object sender, EventArgs e)
        {
            if (m_Logic.IsLoggedIn == false)
            {
                bool isValidLogin = m_Logic.Login(); // change to try and catch and in the catch the error message
                if (isValidLogin)
                {
                    FacebookService.s_CollectionLimit = m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements;
                    m_Logic.SelectedFriend = m_Logic.GetLoggedInUser;
                    pictureBoxProfile.ImageLocation = m_Logic.GetLoggedInUser.PictureNormalURL;
                    labelWelcome.Text = "Logged In ( " + m_Logic.GetLoggedInUser.Name + " )";                    
                }
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (m_Logic.IsLoggedIn)
            {
                FacebookService.Logout(new Action(this.Close));
                MessageBox.Show("Logged Out.");
                Application.Exit();
            }
        }

        private void initListViewHeadersAndDesign(ListView io_ListView, string i_FirstHeader, string i_SecondHeader)
        {
            io_ListView.View = View.Details;
            io_ListView.GridLines = true;

            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();

            header1.Text = i_FirstHeader;
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 250;

            header2.TextAlign = HorizontalAlignment.Left;
            header2.Text = i_SecondHeader;
            header2.Width = 150;

            io_ListView.Columns.Add(header1);
            io_ListView.Columns.Add(header2);
        }

        private void initListViewHeadersAndDesign(ListView io_ListView, string i_FirstHeader, string i_SecondHeader, string i_ThirdHeader)
        {
            io_ListView.View = View.Details;
            io_ListView.GridLines = true;

            ColumnHeader header1, header2, header3;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();

            header1.Text = i_FirstHeader;
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 250;

            header2.TextAlign = HorizontalAlignment.Left;
            header2.Text = i_SecondHeader;
            header2.Width = 150;

            header3.TextAlign = HorizontalAlignment.Left;
            header3.Text = i_ThirdHeader;
            header3.Width = 150;

            io_ListView.Columns.Add(header1);
            io_ListView.Columns.Add(header2);
            io_ListView.Columns.Add(header3);
        }

        private string ShowSaveAsWindow()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        private string showLoadWindow()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        private void buttonPostInBrowser_Click(object sender, EventArgs e)
        {
            if (m_Logic.LatestPagesPostsFeature.SelectedPagePost != null)
            {
                FormApplicationBrowser formBrowser = new FormApplicationBrowser(m_Logic.LatestPagesPostsFeature.SelectedPagePost.Link)
                {
                    Text = "Post Browser Form"
                };
                formBrowser.Show();
            }
        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {
            m_Logic.ChosenAppID = textBoxAppID.Text;
        }

        private void FormMainUserInterface_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void FormMainUserInterface_Load_1(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void viewSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserSessions formUserSessions = new FormUserSessions(m_Logic.GetLoggedInUser);
            formUserSessions.Show();
        }

        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonUserSessions_Click(object sender, EventArgs e)
        {
            FormUserSessions formUserSessions = new FormUserSessions(m_Logic.GetLoggedInUser);
            formUserSessions.Show();
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            updateDraggablePosition(sender, e);
        }

        private void panelRight_MouseDown(object sender, MouseEventArgs e)
        {
            updateDraggablePosition(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelLeft_MouseDown(object sender, MouseEventArgs e)
        {
            updateDraggablePosition(sender, e);
        }

        private void pictureBoxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            updateDraggablePosition(sender, e);
        }

        private void updateDraggablePosition(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void buttonLikedPagesManager_Click(object sender, EventArgs e)
        {
            if (m_Logic.IsLoggedIn)
            {
                FormPagesPosts formPagesPosts = new FormPagesPosts(m_Logic);
                formPagesPosts.Show();
            }
        }

        private void buttonYoutubePostsManager_Click(object sender, EventArgs e)
        {
            if (m_Logic.IsLoggedIn)
            {
                FormYoutubePosts formYoutubePosts = new FormYoutubePosts(m_Logic);
                formYoutubePosts.Show();
            }
        }
    }  
}