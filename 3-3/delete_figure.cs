using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
// 删除字符串中的数字
public class delete_figure
{

    public delete_figure()
    {
         _delete_figure = new ActionBlock<string>(p=>{
            var result = Regex.Replace(p,"\\d","");
            DataArrived?.Invoke(result);
        });
    }
    public void Enqueue(string input)
    {
        _delete_figure.Post(input);
    }
    public ActionBlock<string> _delete_figure;
    public Action<string> DataArrived;
}