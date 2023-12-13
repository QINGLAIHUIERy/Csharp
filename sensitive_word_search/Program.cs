using System;
using System.Text;
namespace sensitive_word_search
{
    class Program
    {
        static void Main(string[] args)
        {
            // 支持中文字符的输入输出
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            // 确定敏感词
            string sensitive_word = "Hello world";
            // 手动输入文本
            // Console.WriteLine("请输入文本");
            // string str = Console.ReadLine();
            // 读取文本文件
            StreamReader sr = new StreamReader("test.txt",Encoding.UTF8);
            string str = sr.ReadToEnd();
            // 进行敏感词查找和替换
            if(str.Contains(sensitive_word)){
                str = str.Replace(sensitive_word,"Hello XGogh");
            }
            // 输出结果
            Console.WriteLine(str);
        }
    }
}