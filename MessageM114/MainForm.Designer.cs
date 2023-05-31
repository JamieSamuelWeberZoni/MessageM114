namespace MessageM114
{
    partial class MainForm
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
            this.TextboxMsg = new System.Windows.Forms.TextBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.TextboxIp = new System.Windows.Forms.TextBox();
            this.LabelIp = new System.Windows.Forms.Label();
            this.ButtonWait = new System.Windows.Forms.Button();
            this.ButtonInvite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextboxMsg
            // 
            this.TextboxMsg.Location = new System.Drawing.Point(12, 27);
            this.TextboxMsg.Name = "TextboxMsg";
            this.TextboxMsg.Size = new System.Drawing.Size(340, 23);
            this.TextboxMsg.TabIndex = 0;
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(12, 9);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(95, 15);
            this.LabelMsg.TabIndex = 1;
            this.LabelMsg.Text = "Message to send";
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(358, 27);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(96, 23);
            this.ButtonSend.TabIndex = 2;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // TextboxIp
            // 
            this.TextboxIp.Location = new System.Drawing.Point(12, 136);
            this.TextboxIp.Name = "TextboxIp";
            this.TextboxIp.Size = new System.Drawing.Size(238, 23);
            this.TextboxIp.TabIndex = 3;
            // 
            // LabelIp
            // 
            this.LabelIp.AutoSize = true;
            this.LabelIp.Location = new System.Drawing.Point(12, 118);
            this.LabelIp.Name = "LabelIp";
            this.LabelIp.Size = new System.Drawing.Size(53, 15);
            this.LabelIp.TabIndex = 4;
            this.LabelIp.Text = "IP adress";
            // 
            // ButtonWait
            // 
            this.ButtonWait.Location = new System.Drawing.Point(358, 136);
            this.ButtonWait.Name = "ButtonWait";
            this.ButtonWait.Size = new System.Drawing.Size(96, 23);
            this.ButtonWait.TabIndex = 5;
            this.ButtonWait.Text = "Wait Invite";
            this.ButtonWait.UseVisualStyleBackColor = true;
            this.ButtonWait.Click += new System.EventHandler(this.ButtonWait_Click);
            // 
            // ButtonInvite
            // 
            this.ButtonInvite.Location = new System.Drawing.Point(256, 136);
            this.ButtonInvite.Name = "ButtonInvite";
            this.ButtonInvite.Size = new System.Drawing.Size(96, 23);
            this.ButtonInvite.TabIndex = 6;
            this.ButtonInvite.Text = "Send Invite";
            this.ButtonInvite.UseVisualStyleBackColor = true;
            this.ButtonInvite.Click += new System.EventHandler(this.ButtonInvite_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 171);
            this.Controls.Add(this.ButtonInvite);
            this.Controls.Add(this.ButtonWait);
            this.Controls.Add(this.LabelIp);
            this.Controls.Add(this.TextboxIp);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.LabelMsg);
            this.Controls.Add(this.TextboxMsg);
            this.Name = "MainForm";
            this.Text = "Sender";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TextboxMsg;
        private Label LabelMsg;
        private Button ButtonSend;
        private TextBox TextboxIp;
        private Label LabelIp;
        private Button ButtonWait;
        private Button ButtonInvite;
    }
}