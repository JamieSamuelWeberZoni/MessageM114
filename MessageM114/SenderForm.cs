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
    public partial class SenderForm : Form
    {
        Sender senderManager;
        public SenderForm()
        {
            InitializeComponent();
            senderManager = new Sender();
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            if (senderManager.VerifyIp(tbx_ip.Text))
            {
                if (await senderManager.SendMessage(tbx_ip.Text, tbx_msg.Text))
                {
                    MessageBox.Show("Message sent successfully");
                }
                else
                {
                    MessageBox.Show("An error occured, verify that the ip you wrote is right and that the person is waiting for a message");
                }
            }
            else
            {
                MessageBox.Show("The format of the IP is incorrect, it should be XX.XX.XX.XX where XX is a number between 0 and 255");
            }
        }
    }
}
