﻿using infrastructure;
using Task = infrastructure.Task;

namespace service;

public class TaskService
{
    private readonly TaskRepository _taskRepository;

    public TaskService(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task CreateTask(string taskName)
    {
        return _taskRepository.CreateTask(taskName);
    }

    public IEnumerable<Task> GetAllTasks()
    {
        return _taskRepository.GetAllTasks();
    }

    public void DeleteTask(int taskId)
    {
        _taskRepository.DeleteTask(taskId);
    }
}