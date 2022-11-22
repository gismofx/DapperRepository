using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRepository
{
    public interface IRepository<TPoco> 
        where TPoco : class
    {
        Func<IDbConnection> ConnectionFactory { get; }
        IDbConnection DbConnection { get; }
        Task<bool> InsertAsync(TPoco item, IDbConnection conn=null, IDbTransaction transaction=null);
        Task<bool> InsertAsync(IEnumerable<TPoco> items, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(TPoco item, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(TPoco item, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<TPoco> FindByIDAsync(string id, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<TPoco>> FindAllAsync(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<TPoco>> SelectAsync(string sql, object param = null, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<TPoco> SelectFirstOrDefaultAsync(string sql, object param = null, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(IEnumerable<TPoco> items, IDbConnection conn = null, IDbTransaction transaction = null);
    }
}
