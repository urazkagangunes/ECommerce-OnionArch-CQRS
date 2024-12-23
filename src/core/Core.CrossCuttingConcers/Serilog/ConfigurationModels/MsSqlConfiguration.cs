namespace Core.CrossCuttingConcers.Serilog.ConfigurationModels;

public class MsSqlConfiguration
{
    public string ConnectionString { get; set; } = default!;
    public string TableName { get; set; } = default!;
    public bool AutoCreateSqlTable { get; set; }

    public MsSqlConfiguration()
    {

    }

    public MsSqlConfiguration(string connectionString, string tableName, bool autoCreateSqlTable)
    {
        ConnectionString = connectionString;
        TableName = tableName;
        AutoCreateSqlTable = autoCreateSqlTable;
    }
}