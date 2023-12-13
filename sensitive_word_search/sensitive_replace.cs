using System.Threading.Tasks.Dataflow;

/// 敏感词替换类
/// </summary>
public class SensitiveReplaceBlock
{
    private string _oldValue;
    private string _newValue;
    public SensitiveReplaceBlock(string oldValue,string newValue)
    {
        _oldValue = oldValue;
        _newValue = newValue;
        _Process = new ActionBlock<string>(p => {
            var result= p.Replace(_oldValue, _newValue);
            DataArrived?.Invoke(result);
        });
    }
    public void Enqueue(string result)
    {
        // DataArrived?.Invoke(result.Replace(_oldValue, _newValue));
        _Process.Post(result);
    }
    private ActionBlock<string> _Process;
    public Action<string> DataArrived;
}
