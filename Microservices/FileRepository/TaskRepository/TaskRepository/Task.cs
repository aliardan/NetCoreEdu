using System;

namespace TaskRepository
{
    class Task
    {
        public Task(DateTime startTime, DateTime endTime, TimeSpan period)
        {
            StartTime = startTime;
            EndTime = endTime;
            Period = period;
        }

        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Period { get; }
    }
}
