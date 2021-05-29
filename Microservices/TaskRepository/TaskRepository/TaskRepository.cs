using System;
using System.Collections.Generic;
using RepositoryBase;

namespace TaskRepository
{
    public class TaskRepository : IRepositoryBase<Task>
    {
        public System.Threading.Tasks.Task<Task> CreateAsync(Task entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Task>> CreateMany(IEnumerable<Task> entities)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> DeleteMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Task>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Task> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Restore(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> RestoreMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Update(Task entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> UpdateMany(IEnumerable<Task> entities)
        {
            throw new NotImplementedException();
        }
    }
}
