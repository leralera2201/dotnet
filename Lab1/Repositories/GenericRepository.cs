using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Dapper;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Repositories
{
    public abstract class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : IBaseEntity<TId>
    {
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly bool _isSoftDelete;

        public GenericRepository(IConnectionFactory connectionFactory, string tableName, bool isSoftDelete)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _isSoftDelete = isSoftDelete;
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = _connectionFactory.GetSqlConnection)
            {
                var values = new { table_name = _tableName };
                return connection.Query<TEntity>("GetAllRecordsFromTable", values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public TEntity GetOneById(TId id)
        {
            using (var connection = _connectionFactory.GetSqlConnection)
            {
                var values = new { table_name = _tableName, id };
                return connection.QuerySingle<TEntity>("GetRecordFromTableById", values, commandType: CommandType.StoredProcedure);
            }
        }
        
        public void DeleteById(TId id)
        {
            using (var connection = _connectionFactory.GetSqlConnection)
            {
                var values = new { table_name = _tableName, id };
                connection.Query("DeleteFromTableById", values, commandType: CommandType.StoredProcedure);
            }
        }

        public void Create(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(ToSnakeCase));
            var stringOfProperties = string.Join(", ", columns.Select(e => entity.GetType().GetProperty(e).GetValue(entity, null)).Select(s => $"'{s}'"));
            
            using (var connection = _connectionFactory.GetSqlConnection)
            {
                var values = new {table_name = _tableName, colums = stringOfColumns, properties = stringOfProperties};
                connection.Query("InsertEntityIntoTable", values, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(TEntity entity)
        {
            var columns = GetColumns();
            var fields = string.Join(", ", columns.Select(e => $"{ToSnakeCase(e)}='{entity.GetType().GetProperty(e).GetValue(entity, null)}'"));
            using (var connection = _connectionFactory.GetSqlConnection)
            {
                var values = new { table_name = _tableName, id = entity.Id, fields };
                connection.Query("UpdateEntityInsideTable", values, commandType: CommandType.StoredProcedure);
            }
        }
        
        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }
        
        public static string ToSnakeCase(string str) 
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("_", pattern.Matches(str)).ToLower();
        }
    }
}