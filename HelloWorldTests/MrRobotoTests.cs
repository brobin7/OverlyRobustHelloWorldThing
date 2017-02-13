using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using HelloWorld;
using HelloWorld.Interfaces;
using HelloWorldTests.TestAttributes;
\
using Moq;
using NLog;

namespace HelloWorldTests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class MrRobotoTests
    {
        [TestMethod, UnitTest]
        public void MrRobotoTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockCommunicator = new Mock<ICommunicatorFactory>();
            var mockConnection = new Mock<IConnectionFactory>();

            var robot = new MrRoboto(mockLogger.Object, mockCommunicator.Object, mockConnection.Object);

            Assert.IsNotNull(robot);
        }

        [TestMethod, UnitTest, ExpectedException(typeof(ArgumentNullException))]
        public void MrRobotoNoLoggerTest()
        {
            var mockCommunicator = new Mock<ICommunicatorFactory>();
            var mockConnection = new Mock<IConnectionFactory>();

            var robot = new MrRoboto(null, mockCommunicator.Object, mockConnection.Object);
        }
        [TestMethod, UnitTest, ExpectedException(typeof(ArgumentNullException))]
        public void MrRobotoNoCommunicatorTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockConnection = new Mock<IConnectionFactory>();

            var robot = new MrRoboto(mockLogger.Object, null, mockConnection.Object);
        }

        [TestMethod, UnitTest, ExpectedException(typeof(IConnectionFactory))]
        public void MrRobotoNoConnnectionFactoryTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockCommunicator = new Mock<ICommunicatorFactory>();

            var robot = new MrRoboto(mockLogger.Object, mockCommunicator.Object, null);
        }

        [TestMethod, UnitTest]
        public void GreetingTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockCommunicator = new Mock<ICommunicatorFactory>();
            var mockConnection = new Mock<IConnectionFactory>();

            var robot = new MrRoboto(mockLogger.Object, mockCommunicator.Object, mockConnection.Object);
           // robot.Greeting();

            //todo: google how to unit test/assert on a console call function...someday...
        }

        [TestMethod, UnitTest, ExpectedException(typeof(NotImplementedException))]
        public void WriteToDatabaseTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockCommunicator = new Mock<ICommunicatorFactory>();
            var mockConnection = new Mock<IConnectionFactory>();

            var robot = new MrRoboto(mockLogger.Object, mockCommunicator.Object, mockConnection.Object);

            robot.WriteToDatabase();
        }

        [TestMethod, UnitTest, ExpectedException(typeof(NotImplementedException))]
        public void WriteToConsoleApplicationTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockCommunicator = new Mock<ICommunicatorFactory>();
            var mockConnection = new Mock<IConnectionFactory>();

            var robot = new MrRoboto(mockLogger.Object, mockCommunicator.Object, mockConnection.Object);
            robot.WriteToConsoleApplication();
        }
    }
}