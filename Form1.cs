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
using VkNet;
using VkNet.Model.RequestParams;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private static long UserId;
        private static string Token = null;
        private static string NameID = null;
        private static string SurnameID = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void VkAuth(string login, string pass)
        {
            string url = "https://oauth.vk.com/authorize?client_id=5818397&redirect_uri=https://oauth.vk.com/blank.html&scope=messages&display=popup&response_type=token&v=5.62&revoke=1";
            Form2 form2 = new Form2();
            form2.Show();
            WebBrowser browser = (WebBrowser)form2.Controls["webBrowser1"];
            browser.Navigate(url);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VkAuth(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader UserIdGet = new StreamReader(File.Open("User_ID.txt", FileMode.Open));
            UserId = Convert.ToInt64(UserIdGet.ReadLine());
            UserIdGet.Close();
            StreamReader TokenGet = new StreamReader(File.Open("Token.txt", FileMode.Open));
            Token = TokenGet.ReadLine();
            TokenGet.Close();
            var vk = new VkApi();
            vk.Authorize(Token, UserId, 0);
            var NameGet = vk.Users.Get(UserId);
            NameID = NameGet.FirstName;
            SurnameID = NameGet.LastName;
            label1.Text = "Успешно авторизованно со страницы:" + NameID + " " + SurnameID + ".";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader UserIdGet = new StreamReader(File.Open("User_ID.txt", FileMode.Open));
            UserId = Convert.ToInt64(UserIdGet.ReadLine());
            UserIdGet.Close();
            StreamReader TokenGet = new StreamReader(File.Open("Token.txt", FileMode.Open));
            Token = TokenGet.ReadLine();
            TokenGet.Close();
            var vk = new VkApi();
            vk.Authorize(Token, UserId, 0);
            var col = vk.Messages.Send(new MessagesSendParams
            {
                UserId = UserId,
                Message = "Привет, aloha, belissimo",
            });
        }
    }
}
