using System;

using System.ComponentModel;

using System.Linq;

using System.Windows.Forms;


namespace Browser1
{
    public partial class KidsPortal : Form
    {

        public string[] homepage = { "https://www.google.com", "http://www.kiddle.co/", "http://www.kidrex.org/", "" };
        Boolean firstCheck = true;
        string[] search = { "https://www.google.com.ph/search?q=", "http://www.kiddle.co/s.php?q=", "http://www.kidrex.org/results/?q=", "https://www.google.com.ph/search?q=" };
        ToolTip toolTip = new ToolTip();
      public Settings settings;
        Checker check;
        BrowserControl browControl;
        public int set = 2;


        public KidsPortal()
        {
            InitializeComponent();


            WebBrowserHelper.FixBrowserVersion(this.browser.Name);
            navBar.KeyDown += new KeyEventHandler(tb_KeyDown);
            browser.IsWebBrowserContextMenuEnabled = false;
          browser.AllowWebBrowserDrop = false;
            // FormBorderStyle = FormBorderStyle.None;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            settings = new Settings(this);
            check = new Browser1.Checker();
            browControl = new BrowserControl();
            browser.Navigate(homepage[set]);
            settings.Show();
            settings.Visible = false;
            timer1.Start();
        }

        public void goHomepage()
        {
            progressBar.Value = 0;
            browser.Navigate(homepage[set]);

        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                start();

            }


        }

        private void start()
        {
            progressBar.Value = 0;
            if (navBar.Text == "settings")
            {
                navBar.Text = "http://";


                settings.Visible = true;



            }
            else if (passURL(navBar.Text))
            {
                browser.Navigate(navBar.Text);
            }
            firstCheck = true;
        }

        private void checkTerms()
        {

            check.checkTerms(this);

        }
        private void checkOtherBrowser()
        {
            CheckBox[] browsers = new CheckBox[4];
            browsers[0] = settings.b1;
            browsers[1] = settings.b2;
            browsers[2] = settings.b4;
            browsers[3] = settings.b5;

            browControl.checkOtherBrowser(browsers);
        }


        private Boolean passURL(String text)
        {

            string newText = "";
            if (!(text.Contains(".com") || text.Contains(".org") || text.Contains(".net")) || text.Contains(' '))
            {
                if (text.Contains(' '))
                {
                    string[] words = navBar.Text.Split(' ');

                    for (int x = 0; x < words.Length; x++)
                    {
                        newText += words[x] + '+';
                    }
                }

                browser.Navigate(search[set] + newText.TrimEnd('+'));

                return false;
            }
            return true;

        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

            settings.Visible = true;

        }




        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            settings.Visible = true;


        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            navBar.Text = e.Url.AbsoluteUri.ToString();
            if(navBar.Text.Contains("javascript")|| navBar.Text.Contains("about:blank"))
            {
            }else
            settings.historyBox.Text += DateTime.Now.ToString() + "   " + browser.Url.AbsoluteUri+ "\n";


            if (firstCheck)
            {
                checkTerms();
                firstCheck = false;
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
                    per.Text = v + "%";
                    progressBar.Value = v;
                }
                catch
                {

                }

            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("View Bookmark", bookmark);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("View History", history);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("View settings panel", settingss);
        }

        private void settingss_Click(object sender, EventArgs e)
        {

            settings.Visible = true;
        }


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            start();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            goHomepage();
        }

        private void hometool(object sender, EventArgs e)
        {
            toolTip.Show("Go to homepage", pictureBox2);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            browser.GoBack();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            browser.GoForward();
        }

        private void left(object sender, EventArgs e)
        {
            toolTip.Show("Previous page", pictureBox1);

        }

        private void right(object sender, EventArgs e)
        {

            toolTip.Show("Next page", pictureBox3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            checkTerms();
            checkOtherBrowser();

        }


        public void changeTick(int j)
        {
            if (j == 0)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
                timer1.Interval = j;
            }
        }

        private void browser_NewWindow(object sender, CancelEventArgs e)
        {

        }

        private void browser_FileDownload(object sender, EventArgs e)
        {
           
        }
    }
}
