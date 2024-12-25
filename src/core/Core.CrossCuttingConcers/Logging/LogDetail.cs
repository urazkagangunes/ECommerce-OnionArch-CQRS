namespace Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string FullName { get; set; } = default!;
    public string MethodName { get; set; } = default!;
    public string User { get; set; } = default!;
    public List<LogParameter> Parameters { get; set; } = new List<LogParameter>();

    public LogDetail(string fullName, string methodName, string user, List<LogParameter> paramaters)
    {
        FullName = fullName;
        MethodName = methodName;
        User = user;
        Parameters = paramaters;
    }

    public LogDetail()
    {
    }
}