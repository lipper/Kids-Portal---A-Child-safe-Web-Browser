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
        public Settings()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
