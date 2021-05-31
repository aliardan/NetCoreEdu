using System;
using System.Collections.Generic;
using System.Data;
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
            using (var connection = new SqlConnection(_taskDataBaseOptions.ConnectionString))
            {
                await connection.InsertAsync(entity);
            }
            
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

        public async System.Threading.Tasks.Task<Task> GetByIdAsync(Guid id)
        {
            await using var connection = new SqlConnection(_taskDataBaseOptions.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            
            return await connection.QueryFirstAsync<Task>($"SELECT Id, StartTime, EndTime, Interval, Words, WordsFound FROM dbo.Tasks WHERE Id = @Id", parameters);
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
