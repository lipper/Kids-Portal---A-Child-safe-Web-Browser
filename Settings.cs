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
    public partial class Settings : Form
    {
        KidsPortal kp;
        public Settings(KidsPortal kp)
        {
            this.kp = kp;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
   
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            custom.Enabled = true;
            kp.homepage[3] = custom.Text; 
            kp.set = 3;
            kp.goHomepage();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            custom.Enabled = false;
            kp.set = 0;
            kp.goHomepage();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            custom.Enabled = false;
            kp.set = 2;
            kp.goHomepage();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            custom.Enabled = false;
            kp.set = 1;
            kp.goHomepage();
        }

        private void custom_TextChanged(object sender, EventArgs e)
        {
            if (custom.Text.Contains(" "))
            {
                MessageBox.Show("Invalid URL!\n\nMust not include spaces!", "Kids Portal - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                custom.Text="http://google.com";
                
                kp.set = 0;
                kp.goHomepage();
            }
            else
            {
                kp.homepage[3] = custom.Text;
                kp.set = 3;
                kp.goHomepage();
            }
            }

        ColorDialog colorDialog1 = new ColorDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
               kp.tableLayoutPanel1.BackColor = color;
                panel1.BackColor = color;
                kp.tableLayoutPanel2.BackColor = color;
                kp.panel1.BackColor = color;
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            kp.changeTick(1000);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

            kp.changeTick(5000);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

            kp.changeTick(15000);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            kp.changeTick(30000);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

            kp.changeTick(60000);
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            kp.changeTick(0);
        }

        
    }
}
