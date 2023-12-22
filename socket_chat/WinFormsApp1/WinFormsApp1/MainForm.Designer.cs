namespace Chat_Demo
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
            IP = new Label();
            Port = new Label();
            btnStart = new Button();
            txtIP = new TextBox();
            txtPort = new TextBox();
            txtLog = new TextBox();
            txtMsg = new TextBox();
            btnSendMsg = new Button();
            btnSendShake = new Button();
            btnSendFile = new Button();
            SuspendLayout();
            // 
            // IP
            // 
            IP.AutoSize = true;
            IP.Location = new Point(64, 32);
            IP.Name = "IP";
            IP.Size = new Size(26, 20);
            IP.TabIndex = 0;
            IP.Text = "IP:";
            IP.Click += label1_Click;
            // 
            // Port
            // 
            Port.AutoSize = true;
            Port.Location = new Point(270, 32);
            Port.Name = "Port";
            Port.Size = new Size(44, 20);
            Port.TabIndex = 1;
            Port.Text = "Port:";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(525, 29);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 2;
            btnStart.Text = "启动";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(123, 29);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 3;
            txtIP.Text = "127.0.0.1";
            txtIP.TextChanged += IP_content_TextChanged;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(341, 29);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 4;
            txtPort.Text = "8080";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(64, 71);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(555, 325);
            txtLog.TabIndex = 5;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(64, 432);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(402, 27);
            txtMsg.TabIndex = 6;
            // 
            // btnSendMsg
            // 
            btnSendMsg.Location = new Point(525, 432);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(94, 29);
            btnSendMsg.TabIndex = 7;
            btnSendMsg.Text = "发送字符串";
            btnSendMsg.UseVisualStyleBackColor = true;
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // btnSendShake
            // 
            btnSendShake.Location = new Point(409, 476);
            btnSendShake.Name = "btnSendShake";
            btnSendShake.Size = new Size(94, 29);
            btnSendShake.TabIndex = 8;
            btnSendShake.Text = "发送闪屏";
            btnSendShake.UseVisualStyleBackColor = true;
            btnSendShake.Click += button1_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.Location = new Point(525, 476);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(94, 29);
            btnSendFile.TabIndex = 9;
            btnSendFile.Text = "发送文件";
            btnSendFile.UseVisualStyleBackColor = true;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 557);
            Controls.Add(btnSendFile);
            Controls.Add(btnSendShake);
            Controls.Add(btnSendMsg);
            Controls.Add(txtMsg);
            Controls.Add(txtLog);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(btnStart);
            Controls.Add(Port);
            Controls.Add(IP);
            Name = "MainForm";
            Text = "服务端";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IP;
        private Label Port;
        private Button btnStart;
        private TextBox txtIP;
        private TextBox txtPort;
        private TextBox txtLog;
        private TextBox txtMsg;
        private Button btnSendMsg;
        private Button btnSendShake;
        private Button btnSendFile;
    }
}