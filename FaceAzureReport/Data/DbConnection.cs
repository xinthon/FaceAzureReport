using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace FaceAzureReport.Data
{
    public class DbConnection : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DbConnection(string connectionString) => _connectionString = connectionString;

        public DbConnection() : this("Data Source=(localdb)\\FaceAzure;Initial Catalog=CB2023091305;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        {
        }

        private void Init()
        {
            if (_connection is not null)
            {
                return;
            }

            _connection = new SqlConnection(_connectionString);
        }

        public IDbConnection GetConnection()
        {
            Init();

            if (_connection.State is not ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}