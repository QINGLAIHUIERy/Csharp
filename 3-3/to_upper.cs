using System.Threading.Tasks.Dataflow;
// 将字符串转换为大写
public class to_upper
{
    public to_upper()
    {
        _to_upper = new ActionBlock<string>(p => {
            var result = p.ToUpper();
            DataArrived?.Invoke(result);    
        });
    }
    public void Enqueue(string result)
    {
        _to_upper.Post(result);
    }
    public ActionBlock<string> _to_upper;
    public Action<string> DataArrived;
}