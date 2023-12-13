public class Console_Read
{
    public void start()
    {
        Console.WriteLine("请输入文本：");
        string input = Console.ReadLine();
        if (input !="")
        {
            DataArrived?.Invoke(input);
        }
    }
    public Action<string> DataArrived;
}