using System.Threading.Tasks.Dataflow;
// 按照ABC进行分割，对分割后的数据进行倒序拼接
public class split_revers
{

    public split_revers()
    {
        _split_revers = new ActionBlock<string>(p=>{
            string[] parts = p.Split("ABC");
            string result =string.Join("",parts.Reverse());
            DataArrived?.Invoke(result);
        });
    }
    public void Enqueue(string input)
    {
        _split_revers.Post(input);
    }
    public ActionBlock<string> _split_revers;
    public Action<string> DataArrived;
}