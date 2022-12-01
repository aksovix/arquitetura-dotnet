﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq.Expressions;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly string connectionString;
        public ItemRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ToDoDb");
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            IEnumerable<Item> result;
            var query = "select * from Items";
            using (var con = new SqlConnection(connectionString))
            {   
                try
                {
                    con.Open();
                    result = await con.QueryAsync<Item>(query);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return result;
            };

        }

        public async Task AddAsync(Item item)
        {
            var query = "insert into Items(Id, Description, Done, CreatedAt) values(@Id, @Description, @Done, @CreatedAt)";
            using (var con = new SqlConnection(connectionString))
            {    
                try
                {
                    con.Open();
                    await con.ExecuteAsync(query, item);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };
        }

        public async Task UpdateAsync(Item item)
        {
            var count = 0;
            var query = "update Items set Description = @Description, Done = @Done where id = @Id";
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    count = await con.ExecuteAsync(query, item);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };
        }

        public async Task DeleteAsync(Guid Id)
        {
            var count = 0;
            var query = "delete from Items where id = @Id";
            var parameter = new { Id = Id };
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    count = await con.ExecuteAsync(query, parameter);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };
        }

        public async Task<Item> getAsync(Guid Id)
        {
            Item result;
            var query = "select * from Items where Id = @Id";
            var parameter = new { Id = Id };
            using (var con = new SqlConnection(connectionString))
            {

                try
                {
                    con.Open();
                    result = await con.QueryFirstOrDefaultAsync<Item>(query, parameter);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return result;
            }
        }

    }
}
