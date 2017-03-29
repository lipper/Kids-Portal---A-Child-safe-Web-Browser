using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser1
{
    public partial class Form1 : Form
    {
        string homepage = "http://google.com";
        public Form1()
        {

            InitializeComponent();
        //    FormBorderStyle = FormBorderStyle.None;
     //   WindowState = FormWindowState.Maximized;
     navBar.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            navBar.Enabled = false;
            browser.Navigate(homepage);
            settings.Show();
            settings.Visible = false;

        }

        Form2 settings = new Form2();
        
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                navBar.Enabled = false;
                if (navBar.Text=="settings") {
                    navBar.Text = "http://";


                    settings.Visible = true;          
                    navBar.Enabled = true;



                }
                else if (passURL(navBar.Text))
                {
                    browser.Navigate(navBar.Text);
                }

            }

           
        }

        private Boolean passURL(String text)
        {
            if (!(text.Contains(".com") || text.Contains(".org") || text.Contains(".net"))|| text.Contains(' '))
            {
                if (text.Contains(' '))
                {
                    string newText = "";
                    string[] words = navBar.Text.Split(' ');

                    for (int x = 0; x < words.Length; x++)
                    {
                        newText += words[x] + '+';
                    }
                }


                browser.Navigate("https://www.google.com.ph/search?q=" + navBar.Text);
                return false;
            }
            return true;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            navBar.Enabled = true;
            navBar.Text = e.Url.ToString();
            if (browser.DocumentText.Contains("sex"))
            {
                MessageBox.Show("Inappropriate Page! - sex");
            }
        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.CurrentProgress > 0)
            {

              
                try
                {
                    int v = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
                    if (v > 100) v = 100;

                    progressBar.Value = v;
                }
                catch
                {
                   
                }
               
            }
        }

        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            settings.Visible = true;


        }
    }
}
