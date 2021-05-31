using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaskService.Controllers
{
    [ApiController]
    public class TaskServiceController
    {
        private readonly TaskService.TaskService _taskService;
        public TaskServiceController(TaskService.TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("[controller]")]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] TaskApiModel taskApiModel)
        {
            return await _taskService.CreateTask(taskApiModel.StartTime, taskApiModel.EndTime, taskApiModel.IntervalMin, taskApiModel.Words);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<int>> GetResult([FromRoute] Guid id)
        {
            return await _taskService.GetTaskResult(id);
        }

        public class TaskApiModel
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public int IntervalMin { get; set; }
            public string[] Words { get; set; }
        }
    }
}
