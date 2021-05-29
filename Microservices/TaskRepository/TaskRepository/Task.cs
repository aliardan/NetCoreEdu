using System;

namespace TaskRepository
{
    public class Task
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Period { get; set; }
        public string Words { get; set; }
        public int WordsFound { get; set; }
    }
}
