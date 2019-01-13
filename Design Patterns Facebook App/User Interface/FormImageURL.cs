using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    public partial class FormImageURL : Form
    {
        public FormImageURL(string i_WebsiteLink)
        {
            InitializeComponent();
            makepicture(i_WebsiteLink.Trim());
            pictureBoxImageUrl.Visible = true;
            pictureBoxImageUrl.Image = ByteToImage(picbytes);
        }

        public byte[] picbytes;

        private void makepicture(string url)
        {
            Thread thread = new Thread(delegate ()
            {
                using (WebBrowser browser = new WebBrowser())
                {
                    browser.ScrollBarsEnabled = false;
                    browser.ScriptErrorsSuppressed = true;
                    browser.AllowNavigation = true;
                    browser.Navigate(url);
                    browser.Width = 1024;
                    browser.Height = 1575;
                    browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            using (Bitmap bitmap = new Bitmap(browser.Width, browser.Height))
            {
                browser.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, browser.Width, browser.Height));
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] bytes = stream.ToArray();
                    picbytes = bytes;
                }
            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}
