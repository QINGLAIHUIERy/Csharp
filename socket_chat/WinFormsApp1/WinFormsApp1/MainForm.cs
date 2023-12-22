using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Demo
{
    public partial class MainForm : Form
    {
        List<Socket> ClientProxSocketList = new List<Socket>();
        public MainForm()
        {
            // 初始化窗体组件
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IP_content_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 1、创建socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2、绑定端口ip
            socket.Bind(new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text)));

            // 3、开启监听
            // 最多十个等待连接
            socket.Listen(10);

            // 4、开始接收客户端连接
            // 单开线程池，用于不断接收客户端的连接
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), socket);
        }

        public void AcceptClientConnect(object socket)
        {
            // 强转为socket类型
            var serverSocket = socket as Socket;

            this.AppendTextToTxtLog("服务器端开始接收客户端的连接");

            while (true)
            {
                var proxSocket = serverSocket.Accept();
                this.AppendTextToTxtLog(string.Format("客户端：{0}连接上了", proxSocket.RemoteEndPoint.ToString()));
                // 接收到客户端请求后，将客户端Socket添加到列表中
                ClientProxSocketList.Add(proxSocket);

                // 不断接收当前客户端发来的消息
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.RecieveData), proxSocket);
            }

        }

        // 接收客户端消息
        public void RecieveData(object socket)
        {
            var proxSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024 * 2];
            while (true)
            {
                int len = 0;
                try
                {
                    len = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    // 异常退出
                    AppendTextToTxtLog(string.Format("客户端：{0}非正常退出", proxSocket.RemoteEndPoint.ToString()));
                    // 删除当前客户端的socket
                    ClientProxSocketList.Remove(proxSocket);

                    StopConnect(proxSocket);
                    // 结束该线程
                    return;
                }

                if (len <= 0)
                {
                    // 客户端正常退出
                    AppendTextToTxtLog(string.Format("客户端：{0}正常退出", proxSocket.RemoteEndPoint.ToString()));
                    // 删除当前客户端的socket
                    ClientProxSocketList.Remove(proxSocket);

                    StopConnect(proxSocket);
                    // 结束该线程
                    return;
                }
                // 把接收到的数据放到文本框上
                string str = Encoding.Default.GetString(data, 0, len);
                AppendTextToTxtLog(string.Format("接收到客户端：{0}的消息：{1}", proxSocket.RemoteEndPoint.ToString(), str));

            }
        }

        private void StopConnect(Socket proxSocket)
        {
            try
            {
                if (proxSocket.Connected)
                {
                    // 禁用读写功能
                    proxSocket.Shutdown(SocketShutdown.Both);
                    // 设置关闭超时时间
                    proxSocket.Close(10);
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

        #region 发送字符串
        // 发送消息
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            foreach (var proxSocket in ClientProxSocketList)
            {
                if (proxSocket.Connected)
                {
                    // 原始数据
                    byte[] data = Encoding.Default.GetBytes(txtMsg.Text);

                    // 对原始数据进行封装（加上协议头）
                    byte[] result = new byte[data.Length + 1];
                    // 设置当前协议头部字节（1，代表字符串）
                    result[0] = 1;
                    // 拷贝原始数据
                    Buffer.BlockCopy(data, 0, result, 1, data.Length);

                    // 发送数据消息
                    proxSocket.Send(result, 0, result.Length, SocketFlags.None);
                }
            }
        }
        #endregion

        #region 发送闪屏
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var proxSocket in ClientProxSocketList)
            {
                if (proxSocket.Connected)
                {
                    // 发送数据消息--2闪屏
                    proxSocket.Send(new byte[] { 2 }, SocketFlags.None);
                }
            }
        }
        #endregion

        #region 发送文件
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                byte[] data = File.ReadAllBytes(ofd.FileName);
                byte[] result = new byte[data.Length + 1];
                result[0] = 3;
                Buffer.BlockCopy(data, 0, result, 1, data.Length);


                foreach (var proxSocket in ClientProxSocketList)
                {
                    if (!proxSocket.Connected)
                    {
                        continue;
                    }
                    // 发送数据消息--3文件
                    proxSocket.Send(result, SocketFlags.None);
                }
            }

            
        }
        #endregion
    }
}
