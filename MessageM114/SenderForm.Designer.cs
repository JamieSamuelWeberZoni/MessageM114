namespace MessageM114
{
    partial class SenderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbx_msg = new System.Windows.Forms.TextBox();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.tbx_ip = new System.Windows.Forms.TextBox();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbx_msg
            // 
            this.tbx_msg.Location = new System.Drawing.Point(12, 27);
            this.tbx_msg.Name = "tbx_msg";
            this.tbx_msg.Size = new System.Drawing.Size(343, 23);
            this.tbx_msg.TabIndex = 0;
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Location = new System.Drawing.Point(12, 9);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(95, 15);
            this.lbl_msg.TabIndex = 1;
            this.lbl_msg.Text = "Message to send";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(259, 127);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(96, 32);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tbx_ip
            // 
            this.tbx_ip.Location = new System.Drawing.Point(12, 136);
            this.tbx_ip.Name = "tbx_ip";
            this.tbx_ip.Size = new System.Drawing.Size(241, 23);
            this.tbx_ip.TabIndex = 3;
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(12, 118);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(53, 15);
            this.lbl_ip.TabIndex = 4;
            this.lbl_ip.Text = "IP adress";
            // 
            // SenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 171);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.tbx_ip);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.tbx_msg);
            this.Name = "SenderForm";
            this.Text = "Sender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbx_msg;
        private Label lbl_msg;
        private Button btn_send;
        private TextBox tbx_ip;
        private Label lbl_ip;
    }
}