namespace tests;
using infrastructure;

public class MockTaskRepository : ITaskRepository
{
   private List<Task> tasks = new List<Task>
   {
      new Task
      {
         TaskId = 1,
         TaskName = "code review"
      },
      new Task
      {
         TaskId = 2,
         TaskName = "unit tests for backend"
      }
   };
    
   public void DeleteTask(int taskId)
   {
      var taskToRemove = tasks.FirstOrDefault(t => t.TaskId == taskId);
      if (taskToRemove != null)
      {
         tasks.Remove(taskToRemove);
      }
   }
   
   public bool TaskExists(int taskId)
   {
      return tasks.Any(t => t.TaskId == taskId);
   }
   
   
   public Task CreateTask(string name)
   {

      return new Task
      {
         TaskName = name
      };
   }

   public IEnumerable<Task> GetAllTasks()
   {
      return new List<Task>
      {
         new Task
         {
            TaskName = "code review"
         },
         new Task
         {
            TaskName = "unit tests for backend"
         }

      };
   }
}