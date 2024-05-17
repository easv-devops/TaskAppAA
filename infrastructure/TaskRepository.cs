using Dapper;
using monitoring;
using MySqlConnector;


namespace infrastructure;

public class TaskRepository:ITaskRepository
{
    private readonly MonitorService _monitorService;
    
    private static MySqlConnection GetConnection()
    {
        string connectionString = Utilities.GetConnectionString();
        var connection = new MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }
    public TaskRepository(MonitorService monitorService)
    {
        _monitorService = monitorService;
    }

    public Task CreateTask(string taskName)
    {
        using var connection = GetConnection();

        string sql = $@"
INSERT INTO task_app.tasks (task_name) 
VALUES (@taskName)
RETURNING 
   task_id as {nameof(Task.TaskId)},
    task_name as {nameof(Task.TaskName)};
    
";
        _monitorService.Log.Information("Executing CreateTask query");
        _monitorService.Log.Debug("Creating task: {TaskName}", taskName);
        return connection.QueryFirstOrDefault<Task>(sql, new { taskName });
    }

    public IEnumerable<Task> GetAllTasks()
    {
        _monitorService.Log.Information("Executing get tasks query");
        _monitorService.Log.Debug("Fetching all tasks");

        string sql = $@"
SELECT 
    task_id as {nameof(Task.TaskId)},
  task_name as {nameof(Task.TaskName)}

FROM task_app.tasks;
";
        using var connection = GetConnection();
        return connection.Query<Task>(sql);
    }


    public void DeleteTask(int taskId)
    {
        _monitorService.Log.Information("Executing DeleteTask query");
        _monitorService.Log.Debug("Deleting task with Id: {TaskId}", taskId);

        using var connection = GetConnection();

        string sql = @"
        DELETE FROM task_app.tasks
        WHERE task_id = @taskId;
    ";

        connection.Execute(sql, new { TaskId = taskId });
    }
}