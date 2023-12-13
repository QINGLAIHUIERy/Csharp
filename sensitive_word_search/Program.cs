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
            Console.WriteLine("请输入文本");
            string str = Console.ReadLine();
            // 进行敏感词查找和替换
            if(str.Contains(sensitive_word)){
                str = str.Replace(sensitive_word,"Hello XGogh");
            }
            // 输出结果
            Console.WriteLine(str);
        }
    }
}