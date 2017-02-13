using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class RoboDbCommunicator : IDbCommunicator
    {
        private readonly WeakReference<IDbConnection> m_connection;

        public RoboDbCommunicator(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            m_connection = ConstructWeakReference(connection);
        }

        private IDbConnection Connection => ResolveWeakReference(m_connection);  
        
        public Task<T> QuerySingleAsync<T>(CommandDefinition command)
        {
            return Connection.QuerySingleAsync<T>(command.CommandText, command.Parameters, command.Transaction, command.CommandTimeout, command.CommandType);
        }
        
        public Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command)
        {
            return Connection.QueryAsync<T>(command);
        }

        public Task<int> ExecuteAsync(CommandDefinition command)
        {
            return Connection.ExecuteAsync(command);
        }

        private static WeakReference<T> ConstructWeakReference<T>(T reference) where T : class
        {
            if (reference != null)
            {
                return new WeakReference<T>(reference);
            }  

            return null;
        }

        private static T ResolveWeakReference<T>(WeakReference<T> weakReference) where T : class
        {
            if (weakReference == null)
            {
                return default(T);
            }

            T target;
            if (!weakReference.TryGetTarget(out target))
            {
                throw new ObjectDisposedException("reference");
            }

            return target;
        }
    }
}
