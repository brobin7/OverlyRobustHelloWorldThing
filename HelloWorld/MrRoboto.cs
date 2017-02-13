using System;
using HelloWorld.Interfaces;
using NLog;

namespace HelloWorld
{
    public class MrRoboto : IRobot
    {
        private readonly ILogger m_logger;
        private readonly ICommunicatorFactory m_communicatorFactory;
        private readonly IConnectionFactory m_connection;
    
        public MrRoboto(ILogger logger, ICommunicatorFactory communicatorFactory, IConnectionFactory connection)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (communicatorFactory == null)
            {
                throw new ArgumentNullException(nameof(communicatorFactory));
            }

            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            m_logger = logger;
            m_communicatorFactory = communicatorFactory;
            m_connection = connection;
        }

        public void Greeting()
        {
            var currentType = GetType().ToString();
            m_logger.Trace($"--> {currentType}" + nameof(Greeting));

            Console.WriteLine("Hello World");
            Console.ReadKey();

            m_logger.Trace($"--> {currentType}" + nameof(Greeting) + " has been completed <--");
        }

        public void WriteToDatabase()
        {
            throw new NotImplementedException();
        }

        public void WriteToConsoleApplication()
        {
            throw new NotImplementedException();
        }
    }
}
