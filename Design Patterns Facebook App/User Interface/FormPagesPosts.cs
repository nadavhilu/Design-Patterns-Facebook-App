﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Design_Patterns_Facebook_App
{
    public partial class FormPagesPosts : Form
    {
        private FormPostInfo m_FormPostInfo;
        private Logic m_Logic;
        private IFacebookFeature m_SelectedFeature = null; 
        public List<ListViewItem> m_GroupOfLatestLikedPagesPosts;

        public FormPagesPosts(Logic i_Logic)
        {
            m_Logic = i_Logic;
            if (i_Logic.IsLoggedIn)
            {
                m_Logic.LatestPagesPostsFeature.SelectedPagePost = null;
                m_SelectedFeature = m_Logic.LatestPagesPostsFeature;
                InitializeComponent();
                fetchUserFriendsData();      
            }
        }

        public void updatePagesPostsDB(object sender, EventArgs e)
        {
            UserSessionsDatabaseFacade facade = new UserSessionsDatabaseFacade(m_Logic.GetLoggedInUser);
            facade.UpdatePagesPostsTableComplains(m_Logic.LatestPagesPostsFeature.SelectedPagePost);
            if (facade.IsRowExist(m_Logic.LatestPagesPostsFeature.SelectedPagePost))
            {
                if (facade.IsPagesPostsTableMailTime(m_Logic.LatestPagesPostsFeature.SelectedPagePost))
                {
                    MessageBox.Show("Now sending mail for reaching " + (m_Logic.m_Configuration.NumberOfComplainsNeededForMail).ToString() + " complains");
                    MailToPage mailToPage = new MailToPage();
                    mailToPage.SendMail(MailToPage.sr_PageOwnerMail, m_Logic.m_Configuration.NumberOfComplainsNeededForMail); // change to Page.Owner.Email
                }
            }
        }
        // MailToPage mailToPage = new MailToPage();
        // mailToPage.SendMail("yudhamdani@gmail.com");

        private void FormPagesPosts_Load(object sender, EventArgs e)
        {
        }

        #region Panel Design Configuraion
        private bool isTopPanelDragged = false;
        private bool isLeftPanelDragged = false;
        private bool isRightPanelDragged = false;
        private bool isBottomPanelDragged = false;
        private bool isTopBorderPanelDragged = false;

        private bool isRightBottomPanelDragged = false;
        private bool isLeftBottomPanelDragged = false;
        private bool isRightTopPanelDragged = false;
        private bool isLeftTopPanelDragged = false;

        private bool isWindowMaximized = false;
        private Point offset;
        private Size _normalWindowSize;
        private Point _normalWindowLocation = Point.Empty;
        
        private void TopBorderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTopBorderPanelDragged = true;
            }
            else
            {
                isTopBorderPanelDragged = false;
            }
        }

        private void TopBorderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y < this.Location.Y)
            {
                if (isTopBorderPanelDragged)
                {
                    if (this.Height < 50)
                    {
                        this.Height = 50;
                        isTopBorderPanelDragged = false;
                    }
                    else
                    {
                        this.Location = new Point(this.Location.X, this.Location.Y + e.Y);
                        this.Height = this.Height - e.Y;
                    }
                }
            }
        }

        private void TopBorderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isTopBorderPanelDragged = false;
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTopPanelDragged = true;
                Point pointStartPosition = this.PointToScreen(new Point(e.X, e.Y));
                offset = new Point();
                offset.X = this.Location.X - pointStartPosition.X;
                offset.Y = this.Location.Y - pointStartPosition.Y;
            }
            else
            {
                isTopPanelDragged = false;
            }

            if (e.Clicks == 2)
            {
                isTopPanelDragged = false;
                maxButton_Click(sender, e);
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTopPanelDragged)
            {
                Point newPoint = TopPanel.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(offset);
                this.Location = newPoint;

                if (this.Location.X > 2 || this.Location.Y > 2)
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.Location = _normalWindowLocation;
                        this.Size = _normalWindowSize;
                        toolTip1.SetToolTip(maxButton, "Maximize");
                        maxButton.CFormState = MinMaxButton.CustomFormState.Normal;
                        isWindowMaximized = false;
                    }
                }
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isTopPanelDragged = false;
            if (this.Location.Y <= 5)
            {
                if (!isWindowMaximized)
                {
                    _normalWindowSize = this.Size;
                    _normalWindowLocation = this.Location;

                    Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                    this.Location = new Point(0, 0);
                    this.Size = new System.Drawing.Size(rect.Width, rect.Height);
                    toolTip1.SetToolTip(maxButton, "Restore Down");
                    maxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
                    isWindowMaximized = true;
                }
            }
        }

        private void LeftPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Location.X <= 0 || e.X < 0)
            {
                isLeftPanelDragged = false;
                this.Location = new Point(10, this.Location.Y);
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    isLeftPanelDragged = true;
                }
                else
                {
                    isLeftPanelDragged = false;
                }
            }
        }

        private void LeftPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < this.Location.X)
            {
                if (isLeftPanelDragged)
                {
                    if (this.Width < 100)
                    {
                        this.Width = 100;
                        isLeftPanelDragged = false;
                    }
                    else
                    {
                        this.Location = new Point(this.Location.X + e.X, this.Location.Y);
                        this.Width = this.Width - e.X;
                    }
                }
            }
        }

        private void LeftPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftPanelDragged = false;
        }

        private void RightPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isRightPanelDragged = true;
            }
            else
            {
                isRightPanelDragged = false;
            }
        }

        private void RightPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isRightPanelDragged)
            {
                if (this.Width < 100)
                {
                    this.Width = 100;
                    isRightPanelDragged = false;
                }
                else
                {
                    this.Width = this.Width + e.X;
                }
            }
        }

        private void RightPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isRightPanelDragged = false;
        }

        private void BottomPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isBottomPanelDragged = true;
            }
            else
            {
                isBottomPanelDragged = false;
            }
        }

        private void BottomPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isBottomPanelDragged)
            {
                if (this.Height < 50)
                {
                    this.Height = 50;
                    isBottomPanelDragged = false;
                }
                else
                {
                    this.Height = this.Height + e.Y;
                }
            }
        }

        private void BottomPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isBottomPanelDragged = false;
        }
        #endregion

        private void fetchUserFriendsData()
        {
            List<string> friends = new List<string>();
            friends.Add("Me");
            if (m_Logic != null)
            {
                foreach (User friend in m_Logic.GetLoggedInUser.Friends)
                {
                    friends.Add(friend.Name);
                }

                listViewFriendChooser.View = View.List;
                foreach (string friend in friends)
                {
                    listViewFriendChooser.Items.Add(new ListViewItem(new string[] { friend }));
                }
            }
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maxButton_Click(object sender, EventArgs e)
        {
            if (isWindowMaximized)
            {
                this.Location = _normalWindowLocation;
                this.Size = _normalWindowSize;
                toolTip1.SetToolTip(maxButton, "Maximize");
                maxButton.CFormState = MinMaxButton.CustomFormState.Normal;
                isWindowMaximized = false;
            }
            else
            {
                _normalWindowSize = this.Size;
                _normalWindowLocation = this.Location;

                Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(0, 0);
                this.Size = new System.Drawing.Size(rect.Width, rect.Height);
                toolTip1.SetToolTip(maxButton, "Restore Down");
                maxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
                isWindowMaximized = true;
            }
        }

        private void _CloseButton_Click(object sender, EventArgs e)
        {
            ProgressBar.UI.Stop();
            this.Close();
        }

        private void RightBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            isRightBottomPanelDragged = true;
        }

        private void RightBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isRightBottomPanelDragged)
            {
                if (this.Width < 100 || this.Height < 50)
                {
                    this.Width = 100;
                    this.Height = 50;
                    isRightBottomPanelDragged = false;
                }
                else
                {
                    this.Width = this.Width + e.X;
                    this.Height = this.Height + e.Y;
                }
            }
        }

        private void RightBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            isRightBottomPanelDragged = false;
        }

        private void RightBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            RightBottomPanel_1_MouseDown(sender, e);
        }

        private void RightBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            RightBottomPanel_1_MouseMove(sender, e);
        }

        private void RightBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            RightBottomPanel_1_MouseUp(sender, e);
        }

        private void LeftBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            isLeftBottomPanelDragged = true;
        }

        private void LeftBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < this.Location.X)
            {
                if (isLeftBottomPanelDragged || this.Height < 50)
                {
                    if (this.Width < 100)
                    {
                        this.Width = 100;
                        this.Height = 50;
                        isLeftBottomPanelDragged = false;
                    }
                    else
                    {
                        this.Location = new Point(this.Location.X + e.X, this.Location.Y);
                        this.Width = this.Width - e.X;
                        this.Height = this.Height + e.Y;
                    }
                }
            }
        }

        private void LeftBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftBottomPanelDragged = false;
        }

        private void LeftBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            LeftBottomPanel_1_MouseDown(sender, e);
        }

        private void LeftBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            LeftBottomPanel_1_MouseMove(sender, e);
        }

        private void LeftBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            LeftBottomPanel_1_MouseUp(sender, e);
        }

        private void RightTopPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            isRightTopPanelDragged = true;
        }

        private void RightTopPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y < this.Location.Y || e.X < this.Location.X)
            {
                if (isRightTopPanelDragged)
                {
                    if (this.Height < 50 || this.Width < 100)
                    {
                        this.Height = 50;
                        this.Width = 100;
                        isRightTopPanelDragged = false;
                    }
                    else
                    {
                        this.Location = new Point(this.Location.X, this.Location.Y + e.Y);
                        this.Height = this.Height - e.Y;
                        this.Width = this.Width + e.X;
                    }
                }
            }
        }

        private void RightTopPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            isRightTopPanelDragged = false;
        }

        private void RightTopPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            RightTopPanel_1_MouseDown(sender, e);
        }

        private void RightTopPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            RightTopPanel_1_MouseMove(sender, e);
        }

        private void RightTopPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            RightTopPanel_1_MouseUp(sender, e);
        }

        private void LeftTopPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            isLeftTopPanelDragged = true;
        }

        private void LeftTopPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < this.Location.X || e.Y < this.Location.Y)
            {
                if (isLeftTopPanelDragged)
                {
                    if (this.Width < 100 || this.Height < 50)
                    {
                        this.Width = 100;
                        this.Height = 100;
                        isLeftTopPanelDragged = false;
                    }
                    else
                    {
                        this.Location = new Point(this.Location.X + e.X, this.Location.Y);
                        this.Width = this.Width - e.X;
                        this.Location = new Point(this.Location.X, this.Location.Y + e.Y);
                        this.Height = this.Height - e.Y;
                    }
                }
            }
        }

        private void LeftTopPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftTopPanelDragged = false;
        }

        private void LeftTopPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            LeftTopPanel_1_MouseDown(sender, e);
        }

        private void LeftTopPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            LeftTopPanel_1_MouseMove(sender, e);
        }

        private void LeftTopPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            LeftTopPanel_1_MouseUp(sender, e);
        }

        private void WindowTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            TopPanel_MouseDown(sender, e);
        }

        private void WindowTextLabel_MouseMove(object sender, MouseEventArgs e)
        {
            TopPanel_MouseMove(sender, e);
        }

        private void WindowTextLabel_MouseUp(object sender, MouseEventArgs e)
        {
            TopPanel_MouseUp(sender, e);
        }

        private void shapedButton5_Click(object sender, EventArgs e)
        {
            Close();
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

        private void listViewPagesPosts_DoubleClick(object sender, EventArgs e)
        {
            var firstSelectedItem = listViewPagesPosts.SelectedItems[0].Text;
            m_FormPostInfo = new FormPostInfo(m_Logic.LatestPagesPostsFeature.SelectedPagePost);
            m_FormPostInfo.EventComplained += new EventHandler(this.updatePagesPostsDB);
            m_FormPostInfo.Show();               
        }

        private void listViewPagesPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCurrentPostChosen();
        }

        private void updateCurrentPostChosen()
        {
            string chosenPost = null;
            List<Post> postsOfLikedPages = m_Logic.LatestPagesPostsFeature.GetListOfUserLikedPagesPosts(m_Logic.SelectedFriend);
            chosenPost = getListViewSelectedPagePostToString();
            foreach (Post post in postsOfLikedPages)
            {
                if (post.Name == chosenPost)
                {
                    m_Logic.LatestPagesPostsFeature.SelectedPagePost = post;
                }
            }
        }

        private string getListViewSelectedPagePostToString()
        {
            string chosenPost = null;
            ListView.SelectedListViewItemCollection items = listViewPagesPosts.SelectedItems;
            foreach (ListViewItem item in items)
            {
                chosenPost = item.Text;
            }

            return chosenPost;
        }

        private void listViewFriendChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCurrentFriendChosen();
        }

        private string getListViewUserFriendsSelectedItemToString()
        {
            string chosenFriend = null;
            ListView.SelectedListViewItemCollection items = listViewFriendChooser.SelectedItems;
            foreach (ListViewItem item in items)
            {
                chosenFriend = item.Text;
            }

            return chosenFriend;
        }

        private void updateCurrentFriendChosen()
        {
            string chosenFriend = null;

            chosenFriend = getListViewUserFriendsSelectedItemToString();
            if (chosenFriend == "Me")
            {
                m_Logic.SelectedFriend = m_Logic.GetLoggedInUser;
            }
            else
            {
                foreach (User friend in m_Logic.GetLoggedInUser.Friends)
                {
                    if (friend.Name == chosenFriend)
                    {
                        m_Logic.SelectedFriend = friend;
                    }
                }
            }
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
   
        private void buttonShowPostInBrowser_Click(object sender, EventArgs e)
        {
            if (m_Logic.LatestPagesPostsFeature.SelectedPagePost != null)
            {
               // FormImageURL formImageURL = new FormImageURL(m_Logic.LatestPagesPostsFeature.SelectedPagePost.Link);
               // formImageURL.Show();
                FormApplicationBrowser formBrowser = new FormApplicationBrowser(m_Logic.LatestPagesPostsFeature.SelectedPagePost.Link);
                formBrowser.Text = "Post Browser Form";
                formBrowser.Show();
            }
        }

        private void buttonShowPostInBrowser_MouseEnter(object sender, EventArgs e)
        {
            buttonShowPostInBrowser.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonShowPostInBrowser_MouseLeave(object sender, EventArgs e)
        {
            buttonShowPostInBrowser.BackgroundImage = Properties.Resources.frame1;
        }

        private void updateListViewPagesPosts()
        {
            listViewPagesPosts.Clear();
            listViewPagesPosts.Items.AddRange(m_GroupOfLatestLikedPagesPosts.ToArray());
            initListViewHeadersAndDesign(listViewPagesPosts, "Post", "Date");
        }
        
        private void buttonPagesPosts_Click(object sender, EventArgs e)
        {
            ProgressBar.UI.Start(this);
            Thread threadForFetchingPagesPosts = new Thread(() => fetchPagesPostsFromFacebook());
            threadForFetchingPagesPosts.Start();
        }

        private void fetchPagesPostsFromFacebook()
        {
            FacebookService.s_CollectionLimit = m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements;
            try
            {
                if (m_Logic.YoutubePostsFeature == null)
                {
                    throw new UserNotLoggedInException("User Must Log In Before Using This Feature!");
                }
                else
                {
                    m_Logic.LatestPagesPostsFeature.GetListViewItemsOfLikedPageLatestPosts(m_Logic.SelectedFriend, ref m_GroupOfLatestLikedPagesPosts, bunifuMaterialTextbox1.Text);
                }
            }
            catch (UserNotLoggedInException message)
            {
                MessageBox.Show(message.Message);
            }

            listViewPagesPosts.Invoke(new Action(() => updateListViewPagesPosts())); 
            ProgressBar.UI.Stop();
        }

        private void textBoxSearchFilter_TextChanged(object sender, EventArgs e)
        {
            Thread threadForFetchingPagesPosts = new Thread(() => fetchPagesPostsFromFacebook());
            threadForFetchingPagesPosts.Start();
          ////  m_Logic.LatestPagesPostsFeature.GetListViewItemsOfLikedPageLatestPosts(m_Logic.SelectedFriend, ref m_GroupOfLatestLikedPagesPosts, textBoxSearchFilter.Text);
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            Thread threadForFetchingPagesPosts = new Thread(() => fetchPagesPostsFromFacebook());
            threadForFetchingPagesPosts.Start();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements = 50;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements = 40;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements = 30;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements = 20;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            m_Logic.m_Configuration.MaximumNumberOfLatestPagesPostsElements = 10;
        }
    }
}
