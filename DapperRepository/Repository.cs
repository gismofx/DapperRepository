using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;


namespace DapperRepository
{
    public class Repository<TPoco> : IRepository<TPoco>
            where TPoco : class
    {
        public IDbConnection DbConnection
        {
            get { return ConnectionFactory(); }
        }

        //private readonly SqlConnectionConfiguration _configuration;
        private IConfiguration _configuration;

        private Func<IDbConnection> _ConnectionFactory=null;

        public Func<IDbConnection> ConnectionFactory
        {
            get =>_ConnectionFactory; 
            private set =>  _ConnectionFactory = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionFactory">A Function which returns a new instance of IDbConnection-
        /// See ServiceCollectionExtensions.AddDbConnectionInstantiatorForRepositories</param>
        public Repository(Func<IDbConnection> connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(TPoco item, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    await conn.InsertAsync<TPoco>(item);
                }
            }
            else
            {
                await conn.InsertAsync<TPoco>(item, transaction);
            }
            return true;
        }

        public async Task<bool> UpdateAsync(TPoco item, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    await conn.UpdateAsync<TPoco>(item);
                }
            }
            else
            {
                await conn.UpdateAsync<TPoco>(item, transaction);
            }
            return true;
        }

        public async Task<bool> UpdateAsync(IEnumerable<TPoco> items, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    await conn.UpdateAsync(items);
                }
            }
            else
            {
                await conn.UpdateAsync(items, transaction);
            }
            return true;
        }

        public async Task<bool> DeleteAsync(TPoco item, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    await conn.DeleteAsync<TPoco>(item);
                }
            }
            else
            {
                await conn.DeleteAsync<TPoco>(item, transaction);
            }
            return true;
        }

        public async Task<TPoco> FindByIDAsync(string id, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            TPoco result;
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    result = await conn.GetAsync<TPoco>(id);
                }
            }
            else
            {
                result = await conn.GetAsync<TPoco>(id);
            }
            return result;
        }

        public async Task<List<TPoco>> FindAllAsync(IDbConnection conn = null, IDbTransaction transaction = null)
        {
            IEnumerable<TPoco> result;
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    result = await conn.GetAllAsync<TPoco>();
                }
            }
            else
            {
                result = await conn.GetAllAsync<TPoco>(transaction);
            }
            return result.ToList();
        }

        public async Task<List<TPoco>> SelectAsync(string sql, object param=null, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            IEnumerable<TPoco> result;
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    result = await conn.QueryAsync<TPoco>(sql, param);
                }
            }
            else
            {
                result = await conn.QueryAsync<TPoco>(sql, param, transaction);
            }
            return result.ToList();
        }

        public async Task<TPoco> SelectFirstOrDefaultAsync(string sql, object param = null, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            TPoco result;
            if (conn is null)
            {
                using (conn = DbConnection)
                {
                    result = await conn.QueryFirstOrDefaultAsync<TPoco>(sql, param);
                }
            }
            else
            {
                result = await conn.QueryFirstOrDefaultAsync<TPoco>(sql, param, transaction);
            }
            return result;
        }

    }
}
