using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FileRepository
{
    internal class FileRepository : IFileRepository
    {
        private readonly TextDataBaseContext _textDataBaseContext;

        public FileRepository(TextDataBaseContext textDataBaseContext)
        {
            _textDataBaseContext = textDataBaseContext;
        }

        public async Task<Text> GetByIdAsync(Guid id)
        {
           return await _textDataBaseContext.Files.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<Text>> GetAllAsync()
        {
            return await _textDataBaseContext.Files.ToListAsync();
        }

        public async Task<Text> CreateAsync(Text entity)
        { 
            await _textDataBaseContext.Files.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Text>> CreateMany(IEnumerable<Text> entities)
        {
            var entitiesList = entities.ToList();
            await _textDataBaseContext.Files.AddRangeAsync(entitiesList);
            return entitiesList;
        }

        public async Task<bool> Update(Text entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMany(IEnumerable<Text> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Restore(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RestoreMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
