using System.Text;

public class file_read
{
    private string _path;
    public file_read(string path)
    {
        _path=path;
    }
    public void start()
    {
        using (StreamReader sr = new StreamReader(_path))
        {
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                DataArrived?.Invoke(line);
            }
        }     
    }
    public Action<string> DataArrived;
}