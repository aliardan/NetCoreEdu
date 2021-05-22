﻿using System;
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

        public async Task<File> GetByIdAsync(Guid id)
        {
           return await _textDataBaseContext.Files.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<File>> GetAllAsync()
        {
            return await _textDataBaseContext.Files.ToListAsync();
        }

        public async Task<File> CreateAsync(File entity)
        { 
            await _textDataBaseContext.Files.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<File>> CreateMany(IEnumerable<File> entities)
        {
            await _textDataBaseContext.Files.AddRangeAsync(entities);
            return entities;
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
