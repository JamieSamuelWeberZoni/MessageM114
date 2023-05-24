/**
 * Project      : Message M114
 * File         : ReceiveForm.cs
 * Description  : A programm that receives and send encrypted messages, this main form
 * Authors      : Ballanfat Jeremy, Weber Jamie
 * Date         : 24 May 2023
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageM114
{
    public partial class ReceiveForm : Form
    {

        Receive receive = new Receive();

        public ReceiveForm()
        {
            
            InitializeComponent();

            receive.createIPEndpoint();

            receive.listener();

        }
    }
}
