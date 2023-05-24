/**
 * Project      : Message M114
 * File         : MainForm.cs
 * Description  : A programm that receives and send encrypted messages, this main form
 * Authors      : Ballanfat Jeremy, Weber Jamie
 * Date         : 24 May 2023
**/
namespace MessageM114
{
    public partial class MainForm : Form
    {
        SenderForm senderForm;

        public MainForm()
        {
            InitializeComponent();
            senderForm = new SenderForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            senderForm.Show();
        }
    }
}