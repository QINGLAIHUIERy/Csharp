/// <summary>
/// 文件读取类
/// </summary>
public class FileReadBlock
{
    private string _path;
    public FileReadBlock(string path)
    {
        _path = path;
    }

    public void Start()
    {
        using (StreamReader sr = new StreamReader(_path))
        {
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                DataArrived?.Invoke(line);
            } 
        }
    }
    public Action<string> DataArrived;
}
