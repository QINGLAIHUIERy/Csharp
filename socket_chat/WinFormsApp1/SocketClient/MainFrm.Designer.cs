namespace SocketClient
{
    partial class MainFrm
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
            btnSendMsg = new Button();
            txtMsg = new TextBox();
            txtLog = new TextBox();
            txtPort = new TextBox();
            txtIP = new TextBox();
            btnStart = new Button();
            Port = new Label();
            IP = new Label();
            SuspendLayout();
            // 
            // btnSendMsg
            // 
            btnSendMsg.Location = new Point(513, 420);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(94, 29);
            btnSendMsg.TabIndex = 15;
            btnSendMsg.Text = "发送";
            btnSendMsg.UseVisualStyleBackColor = true;
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(52, 420);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(402, 27);
            txtMsg.TabIndex = 14;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(52, 59);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(555, 325);
            txtLog.TabIndex = 13;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(329, 17);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 12;
            txtPort.Text = "8080";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(111, 17);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 11;
            txtIP.Text = "127.0.0.1";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(513, 17);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 10;
            btnStart.Text = "连接";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Port
            // 
            Port.AutoSize = true;
            Port.Location = new Point(258, 20);
            Port.Name = "Port";
            Port.Size = new Size(44, 20);
            Port.TabIndex = 9;
            Port.Text = "Port:";
            // 
            // IP
            // 
            IP.AutoSize = true;
            IP.Location = new Point(52, 20);
            IP.Name = "IP";
            IP.Size = new Size(26, 20);
            IP.TabIndex = 8;
            IP.Text = "IP:";
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 505);
            Controls.Add(btnSendMsg);
            Controls.Add(txtMsg);
            Controls.Add(txtLog);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(btnStart);
            Controls.Add(Port);
            Controls.Add(IP);
            Name = "MainFrm";
            Text = "客户端";
            FormClosed += MainFrm_FormClosed;
            Load += MainFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSendMsg;
        private TextBox txtMsg;
        private TextBox txtLog;
        private TextBox txtPort;
        private TextBox txtIP;
        private Button btnStart;
        private Label Port;
        private Label IP;
    }
}