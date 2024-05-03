using Dapper;
using MySqlConnector;

namespace infrastructure;

public class TaskRepository
{
    private static MySqlConnection GetConnection()
    {
        string connectionString = Utilities.GetConnectionString();
        var connection = new MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }

    public Task CreateTask(string taskName)
    {
        using var connection = GetConnection();

        string sql = $@"
INSERT INTO db.tasks (task_name) 
VALUES (@taskName)
RETURNING 
   task_id as {nameof(Task.TaskId)},
    task_name as {nameof(Task.TaskName)};
    
";
        return connection.QueryFirstOrDefault<Task>(sql, new { taskName });
    }

    public IEnumerable<Task> GetAllTasks()
    {
        string sql = $@"
SELECT 
  task_name as {nameof(Task.TaskName)}

FROM db.tasks;
";
        using var connection = GetConnection();
        return connection.Query<Task>(sql);
    }


    public void DeleteTask(int taskId)
    {
        using var connection = GetConnection();

        string sql = @"
        DELETE FROM db.tasks
        WHERE task_id = @taskId;
    ";

        connection.Execute(sql, new { TaskId = taskId });
    }
}