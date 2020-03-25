using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
namespace AutoKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have 5 seconds to choose where to spam!");
            System.Threading.Thread.Sleep(5000);
            try
            {
                //timer1.Interval = int.Parse(textBox2.Text);
                //timer1.Start();
                timer1.Enabled = true;
                int numTime;
                if (int.TryParse(textBox2.Text, out numTime))
                {
                    if (numTime > 0)
                        timer1.Interval = numTime; // second
                }
            }
            catch
            {
                timer1.Enabled = false;
                MessageBox.Show("No input text or time or amount. Check again!", "Ooops");
            }
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void TextBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
            
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void Info_menu_Click(object sender, EventArgs e)
        {
            About baymau = new About();
            baymau.Show();
            //MessageBox.Show("Tool auto spam.\nAuthor : Phan Quang Dai.\nWebsite: https://fangdai.tk\nEmail: pq.dai225@gmail.com");
        }
        private int i = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            SendKeys.Send(textBox1.Text);
            SendKeys.Send("{ENTER}");
            i++;
            if (i>=int.Parse(textBox3.Text))
            {
                timer1.Stop();
            }
        }

        private void Update_menu_Click(object sender, EventArgs e)
        {
            WebRequest wr = WebRequest.Create(new Uri("https://raw.githubusercontent.com/fangdai/AutoKey/master/Version.txt?token=ADG6G3S2DXJAVJBRIM4VHO26QRZE2"));
            WebResponse ws = wr.GetResponse();
            StreamReader sr = new StreamReader(ws.GetResponseStream());

            string currentversion = "1.0.0.0";
            string newversion = sr.ReadToEnd();

            if (currentversion.Contains(newversion))
            {
                Console.WriteLine("Version is up to date!");
            }
            else
            {
                Console.WriteLine("New version is available for download now! Please go to the website and check it out!");
            }
            Console.ReadLine();
        }
    }
}
