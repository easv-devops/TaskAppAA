using Microsoft.AspNetCore.Mvc;
using service;
using Task = infrastructure.Task;

namespace api.Controllers;

public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    //Create a task 
    [HttpPost]
    [Route("/api/task")]
    public Task Post([FromBody] CreateTaskRequestDto dto)
    {
        HttpContext.Response.StatusCode = StatusCodes.Status201Created;
        return _taskService.CreateTask(dto.TaskName);
    }

    //Get all tasks
    [HttpGet]
    [Route("/api/tasks")]
    public IEnumerable<Task> GetAllTasks()
    {
        return _taskService.GetAllTasks();
    }


    //Delete a task
    [HttpDelete]
    [Route("/api/tasks/{taskId}")]
    public void Delete([FromRoute] int taskId)
    {
        _taskService.DeleteTask(taskId);
    }
}

public class CreateTaskRequestDto
{
    public string TaskName { get; set; }
}