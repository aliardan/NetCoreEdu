using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using FluentMigrator.Builders.Schema.Column;
using Microsoft.Extensions.Options;
using RepositoryBase;
using TaskRepository.Migrations;

namespace TaskRepository
{
    public class TaskRepository : IRepositoryBase<Task>
    {
        private readonly TaskDataBaseOptions _taskDataBaseOptions;

        public TaskRepository(IOptions<TaskDataBaseOptions> taskDataBaseOptions)
        {
            _taskDataBaseOptions = taskDataBaseOptions.Value;
        }

        public async System.Threading.Tasks.Task<Task> CreateAsync(Task entity)
        {
            await using var connection = new SqlConnection(_taskDataBaseOptions.ConnectionString);
            await connection.InsertAsync(entity);
            return entity;
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
