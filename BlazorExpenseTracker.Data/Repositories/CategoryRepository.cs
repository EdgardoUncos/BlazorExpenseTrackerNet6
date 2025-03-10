﻿using BlazorExpenseTracker.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SqlConfiguration _connectionString;

        public CategoryRepository(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected SqlConnection dbConecction()
        {
            return new SqlConnection(_connectionString.ConnectionString);

        }

        public async Task<bool> DeleteCategory(int id)
        {
            var db = dbConecction();
            var sql = "DELETE FROM Categories WHERE Id = @Id";

            try
            {
                var result = await db.ExecuteAsync(sql, new { Id = id });
                return result > 0;
            }
            catch (Exception)
            {

                return false;
            }
    

        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var db = dbConecction();
            var sql = "SELECT Id, Name FROM Categories";

            return await db.QueryAsync<Category>(sql, new { });
        }

        
        public async Task<Category> GetCategoryDetails(int id)
        {
            var db = dbConecction();
            var sql = "SELECT Id, Name From Categories WHERE Id = @Id";

            return await db.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
        }

       
        public async Task<bool> InsertCategory(Category category)
        {
            var db = dbConecction();
            var sql = "INSERT INTO Categories (Name) VALUES (@Name)";

            var result = await db.ExecuteAsync(sql, new { category.Name });

            return result > 0;
        }

        
        public async Task<bool> UpdateCategory(Category category)
        {
            var db = dbConecction();

            var sql = "UPDATE Categories SET Name = @Name WHERE Id = @Id";

            var resutl = await db.ExecuteAsync(sql, new { category.Name, category.Id });

            return resutl > 0;
        }
    }
}
