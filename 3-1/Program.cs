using System;
using System.Text;
using System.Text.RegularExpressions;
namespace Find_abc_Delete
{
    class Find_abc
    {
        static void Main(string[] args)
        {
            // 指定文件路径
            string path = "test.txt";
            // 读取文件
            StreamReader sr = new StreamReader(path,Encoding.UTF8);
            // 读取文件文本内容
            String str = sr.ReadToEnd();
            // 关闭文件
            sr.Close();
            // 将指定字符"abc"替换为空
            String content= str.Replace("abc","");
            // (覆盖源文件)
            File.WriteAllText(path,content,Encoding.UTF8);
            Console.WriteLine("删除完成");
            Console.ReadLine();
        }
    }
}