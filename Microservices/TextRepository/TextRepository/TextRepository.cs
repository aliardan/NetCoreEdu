using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TextRepository
{
    internal class TextRepository : ITextRepository
    {
        private readonly TextDataBaseContext _textDataBaseContext;

        public TextRepository(TextDataBaseContext textDataBaseContext)
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
            await _textDataBaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Text>> CreateMany(IEnumerable<Text> entities)
        {
            var entitiesList = entities.ToList();
            await _textDataBaseContext.Files.AddRangeAsync(entitiesList);
            await _textDataBaseContext.SaveChangesAsync();
            return entitiesList;
        }

        public Task<bool> Update(Text entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMany(IEnumerable<Text> entities)
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
