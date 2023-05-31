using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**
 * Project      : Message M114
 * File         : SenderForm.cs
 * Description  : A programm that receives and send encrypted messages, this is the form to send messages
 * Authors      : Ballanfat Jeremy, Weber Jamie
 * Date         : 24 May 2023
**/
namespace MessageM114
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The manager that send things
        /// </summary>
        MessagesManager manager;
        public MainForm()
        {
            InitializeComponent();
            manager = new MessagesManager();
        }

        private async void ButtonInvite_Click(object sender, EventArgs e)
        {
            TextboxIp.Enabled = false;
            ButtonInvite.Enabled = false;
            ButtonWait.Enabled = false;
            if (manager.VerifyIp(TextboxIp.Text))
            {
                bool isOk = await manager.SendInvite(TextboxIp.Text);
                if (isOk)
                {
                    MessageBox.Show("Connection successfully created");
                }
                else
                {
                    MessageBox.Show("Couldn't connect, make sure you put the right ip address and that the other person is waiting for an invite");
                    TextboxIp.Enabled = true;
                    ButtonInvite.Enabled = true;
                    ButtonWait.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("The format of the IP is incorrect, it should be XX.XX.XX.XX where XX is a number between 0 and 255");
                TextboxIp.Enabled = true;
                ButtonInvite.Enabled = true;
                ButtonWait.Enabled = true;
            }
        }

        private async void ButtonWait_Click(object sender, EventArgs e)
        {
            TextboxIp.Enabled = false;
            ButtonInvite.Enabled = false;
            ButtonWait.Enabled = false;
            MessageBox.Show("You are currently waiting for an invite to conversation, please wait");
            bool isOk = await manager.AwaitInvite();
            if (isOk)
            {
                MessageBox.Show("Connection successfully created");
            }
            else
            {
                MessageBox.Show("Couldn't connect, try again");
                TextboxIp.Enabled = true;
                ButtonInvite.Enabled = true;
                ButtonWait.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextboxMsg.Enabled = false;
            ButtonSend.Enabled = false;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {

        }
    }
}
