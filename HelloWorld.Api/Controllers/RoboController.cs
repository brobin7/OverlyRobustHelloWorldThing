using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HelloWorld.Interfaces;

namespace HelloWorld.Api.Controllers
{
    public class RoboController : ApiController
    {
        private readonly IRobot m_robot;

        public RoboController(IRobot robot)
        {
            if (robot == null)
            {
                throw new ArgumentNullException(nameof(robot));
            }

            m_robot = robot;
        }

        [HttpGet]
        [Route("api/greetings")]
        public IHttpActionResult GreetingsGet()
        {
            m_robot.Greeting();
            return Ok();
        }

        [HttpPost]
        [Route("api/ConsoleWrite")]
        public IHttpActionResult PostToConsole()
        {
            m_robot.WriteToConsoleApplication();
            return Ok();
        }

        [HttpPost]
        [Route("api/DbWrite")]
        public IHttpActionResult PostToDb()
        {
            m_robot.WriteToDatabase();
            return Ok();
        }

    }
}