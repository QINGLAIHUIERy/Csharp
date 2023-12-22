using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SocketClient
{
    public partial class MainFrm : Form
    {
        public Socket ClientSocket { get; set; }
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 客户端连接服务器端
            // 创建socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket = socket;

            // Connect服务器
            try
            {
                socket.Connect(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务器失败，请重新连接...");
                return;
            }

            // 发送消息和接收消息
            Thread thread = new Thread(new ParameterizedThreadStart(RecieveData));
            // 设置为后台线程(随主线程的退出而退出)
            thread.IsBackground = true;
            thread.Start(ClientSocket);
        }

        #region 客户端接收数据
        // 接收消息
        public void RecieveData(object socket)
        {
            var clientSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024 * 2];
            while (true)
            {
                int len = 0;
                try
                {
                    len = clientSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    // 异常退出
                    AppendTextToTxtLog(string.Format("服务器端：{0}非正常退出", clientSocket.RemoteEndPoint.ToString()));

                    // 停止链接
                    StopContnet();

                    // 结束该线程
                    return;
                }

                if (len <= 0)
                {
                    // 服务器端正常退出
                    AppendTextToTxtLog(string.Format("服务器端：{0}正常退出", clientSocket.RemoteEndPoint.ToString()));

                    // 停止链接
                    StopContnet();

                    // 结束该线程
                    return;
                }
                //判断服务器传来的数据类型（1为字符串，2为闪屏，3为文件）
                // 字符串
                if (data[0] == 1)
                {
                    string strmsg = ProcessReceiveString(data);
                    AppendTextToTxtLog(string.Format("接收到服务器端：{0}的消息：{1}", clientSocket.RemoteEndPoint.ToString(), strmsg));
                }
                // 闪屏
                else if (data[0] == 2)
                {
                    Shake();
                }
                else if (data[0] == 3)
                {
                    ProcessReceiveFile(data,len);
                }
            }
        }
        #endregion

        #region 处理接收的文件
        public void ProcessReceiveFile(byte[] data,int len)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "txt";
                sfd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                // 跨线程
                this.Invoke(new Action(() =>
                    {
                        if (sfd.ShowDialog(this) != DialogResult.OK)
                        {
                            return;
                        }
                    }));
                

                // 拷贝
                byte[] fileData = new byte[len - 1];
                Buffer.BlockCopy(data, 1, fileData, 0, len - 1);

                File.WriteAllBytes(sfd.FileName, fileData);
            }
        }
        #endregion

        public void Shake()
        {
            // 确保在UI线程上出发窗体抖动事件
            this.Invoke((MethodInvoker)delegate { OnShake(); });
        }

        #region 闪屏
        public void OnShake()
        {
            // 首先标记窗体的原始坐标
            Point oldLocation = this.Location;
            Random r = new Random();

            for (int i = 0; i < 30; i++)
            {
                    this.Location = new Point(r.Next(oldLocation.X - 5, oldLocation.X + 5),
                    r.Next(oldLocation.Y - 5, oldLocation.Y + 5));
                    Thread.Sleep(50);
                    // 移动完成之后回到原始位置
                    this.Location = oldLocation;
                
            }
        }
        #endregion

        #region 处理接收到的字符串
        public string ProcessReceiveString(byte[] data)
        {
            // 把接收到的数据放到文本框上
            string str = Encoding.Default.GetString(data, 1, data.Length-1);
            return str;
        }
        #endregion

        private void StopContnet()
        {
            try
            {
                if (ClientSocket.Connected)
                {
                    // 禁用读写功能
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    // 设置关闭超时时间
                    ClientSocket.Close(10);
                }
            }
            catch (Exception ex)
            {

            }
        }

        // 往日志文本框上增加数据
        public void AppendTextToTxtLog(string txt)
        {
            // 跨线程
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(s =>
                {
                    this.txtLog.Text = string.Format("{0}\r\n{1}", s, txtLog.Text);
                }), txt);
            }
            // 非跨线程
            else
            {
                this.txtLog.Text = string.Format("{0}\r\n{1}", txt, txtLog.Text);
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (ClientSocket.Connected)
            {
                byte[] data = Encoding.Default.GetBytes(txtMsg.Text);
                // 发送数据消息
                ClientSocket.Send(data, 0, data.Length, SocketFlags.None);
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 判断是否连接，若连接，则关闭
            StopContnet();
        }
    }
}
