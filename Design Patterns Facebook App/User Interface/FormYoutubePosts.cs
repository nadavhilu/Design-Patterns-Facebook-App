using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Design_Patterns_Facebook_App
{
    public partial class FormYoutubePosts : Form
    {
        private Logic m_Logic;
        private IFacebookFeature m_SelectedFeature = null; // For Strategy Pattern

        private ISerializingStrategy SerializingStrategy { get; set; }

        public FormYoutubePosts(Logic i_Logic)
        {
            if (i_Logic.IsLoggedIn)
            {
                InitializeComponent();
                m_Logic = i_Logic;
                m_Logic.LatestPagesPostsFeature.SelectedPagePost = null;
                m_SelectedFeature = m_Logic.YoutubePostsFeature;
                fetchUserFriendsData();
                SerializingStrategy = SerializerCreator.GetSerializer(eStrategies.XmlSerializing);
            }          
        }
        #region Panels Design Configurations 
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
        #endregion And

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

        private void fetchUserFriendsData()
        {
            List<string> friends = new List<string>();

            if (m_Logic != null)
            {
                friends.Add("Me");
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

        private void buttonShowPosts_Click(object sender, EventArgs e)
        {
            FacebookService.s_CollectionLimit = m_Logic.m_Configuration.MaximumNumberOfYoutubeElements;
            List<ListViewItem> groupOfYoutubeLinks = null;
            try
            {
                if (m_Logic.YoutubePostsFeature == null)
                {
                    throw new UserNotLoggedInException("User Must Log In Before Using This Feature!");
                }
                else
                {
                    groupOfYoutubeLinks = m_Logic.YoutubePostsFeature.GetYoutubeLinksAsListView(m_Logic.SelectedFriend);
                    listViewYoutubePosts.Clear();
                    listViewYoutubePosts.Items.AddRange(groupOfYoutubeLinks.ToArray());
                    initListViewHeadersAndDesign(listViewYoutubePosts, "Youtube Link", "Date");
                }
            }
            catch (UserNotLoggedInException message)
            {
                MessageBox.Show(message.Message);
            }
        }

        private void buttonAddToFavourite_Click(object sender, EventArgs e)
        {
            initListViewHeadersAndDesign(listViewFavouriteLinks, "Link", "Date");

            ListView.SelectedListViewItemCollection items = listViewYoutubePosts.SelectedItems;
            foreach (ListViewItem item in items)
            {
                listViewFavouriteLinks.Items.Add(new ListViewItem(new string[] { item.SubItems[0].Text, item.SubItems[1].Text }));
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

        private void buttonSaveFavouriteListToFile_Click(object sender, EventArgs e)
        {         
            string filePathXml = ShowSaveAsWindow();

            bool isValidFilePathChosen = false;

            if (filePathXml != null)
            {
                isValidFilePathChosen = true;
            }
        
            if (isValidFilePathChosen)
            {
                List<string> listOfLinks = listViewFavouriteLinks.Items.Cast<ListViewItem>()
                .Select(item => item.Text)
                .ToList();

                SerializingStrategy.Serialize(filePathXml, listOfLinks);
                MessageBox.Show("File Successfully Saved.");
            }
        }

        private void buttonOpenFavouriteListFromFile_Click(object sender, EventArgs e)
        {
            fetchFavoriteYoutubeLinksFromXML();
        }

        private void fetchFavoriteYoutubeLinksFromXML()
        {
            XmlStrategy xmlManager = new XmlStrategy();

            string filePathXml = showLoadWindow();

            bool isFilePathChosen = false;

            if (filePathXml != null)
            {
                isFilePathChosen = true;
            }

            if (isFilePathChosen)
            {
                List<string> favouriteLinks = xmlManager.LoadFromXml(filePathXml);

                if (favouriteLinks != null)
                {
                    initListViewHeadersAndDesign(listViewFavouriteLinks, "Youtube Link", "Date");
                    listViewFavouriteLinks.Items.AddRange(favouriteLinks.Select(t => new ListViewItem(t)).ToArray());
                }
            }
        }

        private void buttonRemoveItemFromFavoriteList_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in listViewFavouriteLinks.SelectedItems)
            {
                listViewItem.Remove();
            }
        }

        private void buttonPlayClip_Click(object sender, EventArgs e)
        {
            FormApplicationBrowser formYoutubePlayer = new FormApplicationBrowser(m_Logic.YoutubePostsFeature.SelectedVideo);
            formYoutubePlayer.Text = "Youtube Form";
            formYoutubePlayer.Show();
        }

        private void listViewYoutubePosts_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (listViewYoutubePosts.Items.Count > 0)
            {
                if (listViewYoutubePosts.SelectedItems.Count > 0)
                {
                    m_Logic.YoutubePostsFeature.SelectedVideo = listViewYoutubePosts.SelectedItems[0].Text;
                }
            }
        }

        private void listViewFavouriteLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFavouriteLinks.Items.Count > 0)
            {
                if (listViewFavouriteLinks.SelectedItems.Count > 0)
                {
                    m_Logic.YoutubePostsFeature.SelectedVideo = listViewFavouriteLinks.SelectedItems[0].Text;
                }
            }
        }

        private void buttonShowPosts_MouseEnter(object sender, EventArgs e)
        {
            buttonShowPosts.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonSaveFavouriteListToFile_MouseDown(object sender, MouseEventArgs e)
        {
            buttonSaveFavouriteListToFile.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonOpenFavouriteListFromFile_MouseDown(object sender, MouseEventArgs e)
        {
            buttonOpenFavouriteListFromFile.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonRemoveItemFromFavoriteList_MouseDown(object sender, MouseEventArgs e)
        {
            buttonRemoveItemFromFavoriteList.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonShowPosts_MouseLeave(object sender, EventArgs e)
        {
            buttonShowPosts.BackgroundImage = Properties.Resources.frame1;
        }

        private void buttonAddToFavourite_MouseLeave(object sender, EventArgs e)
        {
            buttonAddToFavourite.BackgroundImage = Properties.Resources.frame1;
        }

        private void buttonAddToFavourite_MouseEnter(object sender, EventArgs e)
        {
            buttonAddToFavourite.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonSaveFavouriteListToFile_MouseEnter(object sender, EventArgs e)
        {
            buttonSaveFavouriteListToFile.BackgroundImage = Properties.Resources.frameBG;
        }

        private void buttonSaveFavouriteListToFile_MouseLeave(object sender, EventArgs e)
        {
            buttonSaveFavouriteListToFile.BackgroundImage = Properties.Resources.frame1;
        }

        private void radioButtonXML_CheckedChanged(object sender, EventArgs e)
        {
            SerializingStrategy = SerializerCreator.GetSerializer(eStrategies.XmlSerializing);
        }

        private void radioButtonJson_CheckedChanged(object sender, EventArgs e)
        {
            SerializingStrategy = SerializerCreator.GetSerializer(eStrategies.JsonSerializing);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            string path = ShowSaveAsWindow();

            if (path != null)
            {
                MessageBox.Show(path);

                DownloadManager downloadManager = new DownloadManager();
                downloadManager.SaveVideoToDisk(m_Logic.YoutubePostsFeature.SelectedVideo, path);
            }
        }   

        private void FormYoutubePosts_DragOver(object sender, DragEventArgs e)
        {
        }  

        private void listViewYoutubePosts_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\mytextfile";
            string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Testfile");
            DownloadManager downloadManager = new DownloadManager();
            downloadManager.SaveVideoToDisk(listViewYoutubePosts.SelectedItems[0].Text, path2);
            this.DoDragDrop(new DataObject(DataFormats.FileDrop, listViewYoutubePosts.SelectedItems[0].Text), DragDropEffects.Scroll);
        }
    }
}
