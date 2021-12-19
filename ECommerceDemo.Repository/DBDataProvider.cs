using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ECommerceDemo.Repository
{
    public class DBDataProvider : IDisposable
    {
        private readonly IDbConnection _connection;

        #region Connection
        public DBDataProvider()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionStr"].ConnectionString);
        }

        #endregion

        #region synchronous

        public T GetEntity<T>(string sql, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, IDbTransaction dbTransaction = null)
           where T : class, new()
        {
            try
            {
                T entity = _connection.QueryFirstOrDefault<T>(sql, parameters, dbTransaction, null, commandType);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetEntityList<T>(string sql, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure,
           IDbTransaction dbTransaction = null) where T : class, new()
        {
            try
            {
                IEnumerable<T> entityList = _connection.Query<T>(sql, parameters, dbTransaction, commandType: commandType);
                return entityList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
