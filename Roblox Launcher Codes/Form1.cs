using System;
using WeAreDevs_API;
using System.Threading;
using System.Windows.Forms;

namespace RobloxLauncher
{
    public partial class Launcher : Form
    {
        ExploitAPI api = new ExploitAPI();
        string command;
        bool isConsole = false;
        bool rightLoop = false;
        bool leftLoop = false;

        public Launcher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                api.LaunchExploit();
                label1.Text = "API is attachted.";          
            }
            catch
            {
                throw new Exception("Failed to inject the API.");
            }
        }

        private void Writel()
        {
            command = textBox1.Text;
            textBox1.Text = "";
            richTextBox1.Text = $"{richTextBox1.Text}\n{command}";
        }

        private void wait(int sec)
        {
            Thread.Sleep(sec * 1000);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Writel();

            string[] words = command.Split(':');
            if (words[0] == "log")
            {
                api.SendLuaCScript($"WRDAPI.log({words[2]})");
            }
            else if (words[0] == "error")
            {
                api.SendLuaCScript($"WRDAPI.error({words[2]})");
            }
            else if (words[0] == "error")
            {
                api.SendLuaCScript($"WRDAPI.error({words[2]})");
            }
            else if (words[0] == "infomsg")
            {
                api.SendLuaCScript($"WRDAPI.InfoMsg({words[2]})");
            }
            else if (words[0] == "errormsg")
            {
                api.SendLuaCScript($"WRDAPI.ErrorMsg({words[2]})");
            }
            else
            {
                api.SendCommand(command);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!api.isAPIAttached())
            {
                api.LaunchExploit();
            }
            return;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                api.SendCommand("boxesp");
                api.SendCommand("boxespdistance");
                api.SendCommand("boxespnames");
            } else
            {
                api.SendCommand("boxesp");
                api.SendCommand("boxespdistance");
                api.SendCommand("boxespnames");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                api.SendCommand("boxesplines");
            } else
            {
                api.SendCommand("boxesplines");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                api.SendCommand("boxespteamcheck");
            } else
            {
                api.SendCommand("boxespteamcheck");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isConsole)
            {
                api.SendLuaScript("WRDAPI.ShowConsole()");
                isConsole = true;
            } else
            {
                api.SendLuaScript("WRDAPI.HideConsole()");
                isConsole = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            api.SendCommand("btools me");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            api.SetWalkSpeed("me", int.Parse(textBox2.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            api.SetJumpPower(int.Parse(textBox3.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            api.SendLuaCScript(richTextBox2.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            api.SendCommand($"hipheight me {textBox4.Text}");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] param = textBox5.Text.Split(',', ' ');
            api.SendCommand($"vectorteleport {param[0]} {param[1]} {param[2]}");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            api.TeleportMyCharacterTo(textBox6.Text);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            api.ToggleClickTeleport();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            api.SendCommand($"music {textBox7.Text}");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            leftLoop = true;
            api.SendLuaCScript("MouseButton1Press()");
            wait(int.Parse(textBox8.Text));
            api.SendLuaCScript("MouseButton1Release()");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            rightLoop = true;
            api.SendLuaCScript("MouseButton2Press()");
            wait(int.Parse(textBox9.Text));
            api.SendLuaCScript("MouseButton2Release()");
        }

        //LOOP
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            while (checkBox5.Checked)
            {
                if (leftLoop)
                {
                    api.SendLuaCScript("MouseButton1Press()");
                    wait(int.Parse(textBox8.Text));
                    api.SendLuaCScript("MouseButton1Release()");
                } else if (rightLoop)
                {
                    api.SendLuaCScript("MouseButton2Press()");
                    wait(int.Parse(textBox9.Text));
                    api.SendLuaCScript("MouseButton2Release()");
                }
            }
        }
    }
}
