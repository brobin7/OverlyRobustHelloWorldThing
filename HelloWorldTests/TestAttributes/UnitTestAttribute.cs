using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldTests.TestAttributes
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Event | AttributeTargets.Delegate)]
    public sealed class UnitTestAttribute : TestLabelBaseAttribute
    {
        public UnitTestAttribute()
          : base("Unit")
        {
        }
    }
}
