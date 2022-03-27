using System;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityModel.Repositories.Interfaces
{
    public interface IPgRepository<TType>
    {
        Task<TType> ExecuteSingle(CommandDefinition command);
        Task<IEnumerable<TType>> ExecuteMany(CommandDefinition command);
    }
}
