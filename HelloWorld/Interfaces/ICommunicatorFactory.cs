using System.Data;

namespace HelloWorld.Interfaces
{
    public interface ICommunicatorFactory
    {
        IDbCommunicator AccessDb(IDbConnection connection);
    }
}
