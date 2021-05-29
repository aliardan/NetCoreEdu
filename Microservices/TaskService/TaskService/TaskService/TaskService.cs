using System;
using System.Threading.Tasks;
using RepositoryBase;

namespace TaskService.TaskService
{
    public class TaskService
    {
        private readonly IRepositoryBase<TaskRepository.Task> _repositoryBase;

        public TaskService(IRepositoryBase<TaskRepository.Task> repositoryBase)
        {
            _repositoryBase = repositoryBase;
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
                Interval = intervalMin,
                Words = wordString
            };

            await _repositoryBase.CreateAsync(task);
            return id;
        }
    }
}
