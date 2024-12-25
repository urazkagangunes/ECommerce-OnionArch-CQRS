namespace Core.CrossCuttingConcerns.Logging;

public class LogParameter
{
    public string Name { get; set; } = default!;
    public object Value { get; set; } = default!;
    public string Type { get; set; } = default!;

    public LogParameter()
    {
        
    }

    public LogParameter(string name, object value, string type)
    {
        Name = name; 
        Value = value; 
        Type = type;
    }
}