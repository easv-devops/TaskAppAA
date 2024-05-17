using monitoring;
using NUnit.Framework;
using service;

namespace tests;

public class UnitTests
{
    [Test]
    public void GetAllTasksReturnsAllTasks()
    {
        //Arrange
        var mockRepository = new MockTaskRepository();
        var monitorService = new MonitorService();
        var taskService = new TaskService(mockRepository, monitorService);

        //Act
        var tasks = taskService.GetAllTasks();

        //Assert
        Assert.IsNotNull(tasks);
        Assert.AreEqual(2, tasks.Count()); 
    }
    
    
    
    [Test]
    public void TaskCanSuccessfullyBeCreated()
    {
        //Arrange
        var mockRepository = new MockTaskRepository();
        var monitorService = new MonitorService();
        var taskService = new TaskService(mockRepository, monitorService);

        //Act
        string taskName = "create frontend";
        var createdTask = taskService.CreateTask(taskName:taskName);

        //Assert
        Assert.IsNotNull(createdTask);
        Assert.AreEqual(taskName, createdTask.TaskName); 
    }
    
    
    
    [Test]
    public void TaskCanSuccessfullyBeDeleted()
    {
        //Arrange
        var mockRepository = new MockTaskRepository();
        var monitorService = new MonitorService();
        var taskService = new TaskService(mockRepository, monitorService);

        //Act
        taskService.DeleteTask(taskId:1);

        //Assert
        Assert.IsFalse(mockRepository.TaskExists(1));
    }

}




