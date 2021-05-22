using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileRepository
{
    internal class FileRepository : IFileRepository
    {
        public Task<File> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<File>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<File> CreateAsync(File entity)
        {
            return Task.FromResult(new File("","", Guid.NewGuid()));
        }

        public Task<IEnumerable<File>> CreateMany(IEnumerable<File> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(File entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMany(IEnumerable<File> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Restore(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RestoreMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
