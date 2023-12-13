using System;
namespace program3
{
    class Program3
    {
        static void Main(string[] args)
        {
            string input_path = "test.txt";
            string output_path = "output.txt";
            // 读文件
            file_read file_Read = new file_read(input_path);
            to_upper to_Upper = new to_upper();
            delete_figure delete_Figure = new delete_figure();
            split_revers split_Revers = new split_revers();
            file_write file_Write = new file_write(output_path);

            file_Read.DataArrived += (e) =>
            {
                to_Upper.Enqueue(e);
            };
            to_Upper.DataArrived += (e) =>
            {

                delete_Figure.Enqueue(e);
            };
            delete_Figure.DataArrived += (e) =>
            {
                split_Revers.Enqueue(e);
            };
            split_Revers.DataArrived += (e) =>
            {
                file_Write.Enqueue(e);
            };
            file_Read.start();
            Console.ReadLine();
        }

    }
        
}