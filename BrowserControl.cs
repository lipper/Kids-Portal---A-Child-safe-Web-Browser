using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser1
{
    class BrowserControl
    {

        String[] urls = { "iexplore", "chrome", "firefox", "opera" };
        public void checkOtherBrowser(CheckBox[] boxes)
        {
            for (int x = 0; x < boxes.Length; x++)
            {
                if (boxes[x].Checked)
                {

                    Process[] runningProcess = Process.GetProcesses();
                    for (int i = 0; i < runningProcess.Length; i++)
                    {
                        // compare equivalent process by their name
                        if (runningProcess[i].ProcessName == urls[x])
                        {
                            // kill  running process
                            MessageBox.Show("Web Browser Detected: " + urls[x] + "\n Browser Terminated.");
                            try
                            {
                                runningProcess[i].Kill();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                        }
                    }
                }

            }


        }
    }
}
