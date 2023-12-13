using System;
using System.Text;
using System.Threading.Tasks.Dataflow;
namespace sensitive_word_search
{
    class Program
    {
        static void Main(string[] args)
        {

            //构建了一个文件输入,进行文本替换，最后存储到文件并且显示的类
            FileReadBlock fileReadBlock = new FileReadBlock("test.txt");
            SensitiveReplaceBlock sensitiveReplaceBlock = new SensitiveReplaceBlock("Hello world","Hello XGogh");
            FileWriteBlock fileWriteBlock = new FileWriteBlock("output");
            ConsoleWriteBlock consoleWriteBlock = new ConsoleWriteBlock();

            fileReadBlock.DataArrived += (e) =>
            {
                sensitiveReplaceBlock.Enqueue(e);
            };
            sensitiveReplaceBlock.DataArrived += (e) =>
            {
                consoleWriteBlock.Enqueue(e);
                fileWriteBlock.Enqueue(e);
            };
            fileReadBlock.Start();
            Console.ReadLine();
        }
    }
}