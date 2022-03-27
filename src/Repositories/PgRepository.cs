using Dapper;
using EntityModel.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    public class PgRepository<TType> : IPgRepository<TType>
    {
        private readonly IConfiguration _config;

        public PgRepository(IConfiguration config)
        {
            _config = config;
        }

        public NpgsqlConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_config.GetConnectionString("DbConnectionString"));
            }
        }

        public async Task<TType> ExecuteSingle(CommandDefinition command) {
            using (var conn = Connection)
            {
                conn.Open();
                return await Connection.QueryFirstOrDefaultAsync<TType>(command);
            }
        }

        public async Task<IEnumerable<TType>> ExecuteMany(CommandDefinition command) {
            using (var conn = Connection)
            {
                conn.Open();
                return await Connection.QueryAsync<TType>(command);
            }
        }
    }
}
