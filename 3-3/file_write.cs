using System.Text;
using System.Threading.Tasks.Dataflow;

public class file_write
{
    private string output_path;

    public file_write(string path)
    {
        output_path = path;
        _file_write = new ActionBlock<string>(p=>{
        File.WriteAllText(output_path,p);
        });
    }
    public void Enqueue(string input)
    {
        _file_write.Post(input);
    }
    public ActionBlock<string> _file_write;
}