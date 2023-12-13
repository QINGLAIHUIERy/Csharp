using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks.Dataflow;
namespace program3
{
    class Program3
    {
        static void Main(string[] args)
        {
            // 指定输入输出路径
            string inputpath = "test.txt";
            string outputpath = "output.txt";
            // 读取文本内容
            StreamReader sr = new StreamReader(inputpath,Encoding.UTF8);
            string str = sr.ReadToEnd();
            // 关闭文件
            sr.Close();
            // 字符转大写
            var block = new ActionBlock<string>((content)=>{
                str = content.ToUpper();
            });
            
            Console.WriteLine(str);
        }
    }
}