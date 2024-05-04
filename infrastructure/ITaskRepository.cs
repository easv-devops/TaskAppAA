namespace infrastructure;

public interface ITaskRepository
{
    Task CreateTask(string taskName);
    IEnumerable<Task> GetAllTasks();
    void DeleteTask(int taskId);
}