namespace infrastructure;

public static class Utilities
{
    private static readonly string EnvironmentVariableName = "sqlconn";
    private const string DefaultServer = "localhost";

    public static string BuildConnectionString(
        string server = DefaultServer,
        string database = "",
        string user = "",
        string password = ""
    ) =>
        $"Server={server};Database={database};Uid={user};Pwd={password};";


    public static string GetConnectionString()
    {
        string? connectionString = Environment.GetEnvironmentVariable(EnvironmentVariableName);
        return connectionString ?? BuildConnectionString();
    }
}