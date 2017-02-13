﻿using System.Data;
using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class RoboCommunicatorFactory : ICommunicatorFactory
    {
        public IDbCommunicator CreateDbConnection(IDbConnection connection)
        {
            return new RoboDbCommunicator(connection);
        }
    }
}