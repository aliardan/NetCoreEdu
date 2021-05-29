using System;
using System.Threading.Tasks;

namespace TaskService.TaskService
{
    public class TaskService
    {
        private readonly TaskRepository.TaskRepository _taskRepository;

        public TaskService(TaskRepository.TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Guid> CreateTask(DateTime startTime, DateTime endTime, int intervalMin, string[] words)
        {
            Guid id = Guid.NewGuid();
            var wordString = string.Join(" ", words);
            var task = new TaskRepository.Task
            {
                Id = id,
                StartTime = startTime,
                EndTime = endTime,
                Period = intervalMin,
                Words = wordString
            };

            await _taskRepository.CreateAsync(task);
            return id;
        }
    }
}
