using System.Data;

namespace HelloWorld.Interfaces
{
    public interface ICommunicatorFactory
    {
        IDbCommunicator CreateDbConnection(IDbConnection connection);
    }
}
