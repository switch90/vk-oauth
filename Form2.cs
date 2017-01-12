using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static string token;
        public static string id;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                string url = webBrowser1.Url.ToString();
                string l = url.Split('#')[1];
                if (l[0] == 'a')
                {
                    token = l.Split('&')[0].Split('=')[1];
                    id = l.Split('=')[3];
                    StreamWriter SW = new StreamWriter(new FileStream("User_ID.txt", FileMode.Create, FileAccess.Write));
                    SW.Write(id);
                    SW.Close();
                    StreamWriter SW2 = new StreamWriter(new FileStream("Token.txt", FileMode.Create, FileAccess.Write));
                    SW2.Write(token);
                    SW2.Close();
                    if (token != "")
                    {
                        this.Hide();
                        MessageBox.Show("Авторизация удалась");
                    }
                }
            }

            catch
            {


            }
        }
    }
}

