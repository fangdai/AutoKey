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
using System.Runtime.InteropServices; //Movealbe Form
namespace AutoKey
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.menuStrip1.BackColor = Color.Black;
            this.menuStrip1.ForeColor = Color.Lime;
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
            WebRequest wr = WebRequest.Create(new Uri("https://raw.githubusercontent.com/fangdai/AutoKey/master/Version.txt"));
            WebResponse ws = wr.GetResponse();
            StreamReader sr = new StreamReader(ws.GetResponseStream());

            string currentversion = "1.0.0.1\n";
            string newversion = sr.ReadToEnd();

            if (currentversion.Contains(newversion))
            {
                MessageBox.Show("Version is up to date!");
            }
            else
            {
                MessageBox.Show("New version is available for download now! Please go to the website and check it out!");
            }
            Console.ReadLine();
        }

        private void TheCodeBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.ForeColor = Color.Lime;
            this.textBox1.BackColor = Color.Black;
            this.textBox2.ForeColor = Color.Lime;
            this.textBox2.BackColor = Color.Black;
            this.textBox3.ForeColor = Color.Lime;
            this.textBox3.BackColor = Color.Black;
            this.BackColor = Color.Black;
            this.ForeColor = Color.Lime;
            this.menuStrip1.BackColor = Color.Black;
            this.menuStrip1.ForeColor = Color.Lime;

        }

        private void BasicStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.ForeColor = Color.Yellow;
            this.textBox1.BackColor = Color.Red;
            this.textBox2.ForeColor = Color.Yellow;
            this.textBox2.BackColor = Color.Red;
            this.textBox3.ForeColor = Color.Yellow;
            this.textBox3.BackColor = Color.Red;
            this.menuStrip1.ForeColor = Color.Yellow;
            this.menuStrip1.BackColor = Color.Red;
            this.BackColor = Color.Red;
            this.ForeColor = Color.Yellow;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        //Movealbe Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //Moveable Form
    }
}
