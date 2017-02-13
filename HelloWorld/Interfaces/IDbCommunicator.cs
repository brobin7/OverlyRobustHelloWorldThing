using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace HelloWorld.Interfaces
{
    public interface IDbCommunicator
    {
        Task<T> QuerySingleOrDefaultAsync<T>(CommandDefinition command);
        Task<T> QuerySingleAsync<T>(CommandDefinition command);
        Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command);
        Task<int> ExecuteAsync(CommandDefinition command);
    }
}
