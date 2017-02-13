using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldTests.TestAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class TestCategoryBaseAttribute : Attribute
    {
        public abstract IList<string> TestCategories { get; }
    }
}
