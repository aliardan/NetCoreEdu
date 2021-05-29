using System;
using Dapper.Contrib.Extensions;

namespace TaskRepository
{
    public class Task
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Interval { get; set; }
        public string Words { get; set; }
        public int WordsFound { get; set; }
    }
}
