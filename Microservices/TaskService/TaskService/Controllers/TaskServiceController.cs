using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<Guid>> CreateTask(
            [FromBody] DateTime startTime,
            [FromBody] DateTime endTime,
            [FromBody] int intervalMin,
            [FromBody] string[] words)
        {
            return await _taskService.CreateTask(startTime, endTime, intervalMin, words);
        }
    }
}
