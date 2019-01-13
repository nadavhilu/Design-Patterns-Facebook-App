using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App.User_Interface
{
    public partial class FormAlternative : Form
    {
        public FormAlternative()
        {
            InitializeComponent();
        }

        private void buttonFavouriteList_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
        }

        private void buttonShowYoutubePosts_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
        }
    }
}
