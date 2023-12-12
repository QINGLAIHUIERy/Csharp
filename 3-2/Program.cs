using System;
using System.Text;
namespace split_abc
{
    class split_abc
    {
         static void Main(string[] args)
         {
            // 指定文件路径
            string inputFilePath = "test02.txt"; 
            // 指定用于判断分割的文本
            string delimiter = "abc";
            // 读取文件
            StreamReader sr = new StreamReader(inputFilePath,Encoding.UTF8);
            // 读取文件文本内容
            String str = sr.ReadToEnd();
            // 关闭文件
            sr.Close();
            // 清楚文本中的回车换行符
            str = str.Replace("\n","").Replace("\r","");
            // 按照指定字符分割文本
            string[] parts = str.Split(delimiter);
            for(int i=0;i<parts.Length;i++)
            {
                // 输出文件路径模板
                string outputFilePath = "output_" + (i+1) + ".txt";
                // 将分割后的内容写入输出文件
                File.WriteAllText(outputFilePath,parts[i],Encoding.UTF8);
            }
         }
    }   
}