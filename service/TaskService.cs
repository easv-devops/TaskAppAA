using infrastructure;
using monitoring;
using Task = infrastructure.Task;

namespace service;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly MonitorService _monitorService;

    public TaskService(ITaskRepository taskRepository, MonitorService monitorService)
    {
        _taskRepository = taskRepository;
        _monitorService = monitorService;
    }

    public Task CreateTask(string taskName)
    {
        _monitorService.Log.Information("Entered Method CreateTask in TaskService");
        return _taskRepository.CreateTask(taskName);
    }

    public IEnumerable<Task> GetAllTasks()
    {
        _monitorService.Log.Information("Entered Method GetAllTasks in TaskService");
        return _taskRepository.GetAllTasks();
    }

    public void DeleteTask(int taskId)
    {
        _monitorService.Log.Information("Entered Method DeleteTask in TaskService");
        _taskRepository.DeleteTask(taskId);
    }
}