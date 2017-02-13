using System.Data;

namespace HelloWorld.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateDbConnection();
    }
}
