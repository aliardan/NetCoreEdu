using System;
using FluentMigrator;

namespace TaskRepository.Migrations
{
    [Migration(202105292100)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"CREATE TABLE dbo.Tasks
            (
                Id NVARCHAR(200) NOT NULL PRIMARY KEY,
                StartTime DATETIME2 NOT NULL,
                EndTime DATETIME2 NOT NULL,
                Interval int NOT NULL,
                Words NVARCHAR(200) NOT NULL,
                WordsFound int NOT NULL
            )");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}