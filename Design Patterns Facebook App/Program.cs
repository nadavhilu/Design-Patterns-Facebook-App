using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainUserInterface());
        }
    } 
}
