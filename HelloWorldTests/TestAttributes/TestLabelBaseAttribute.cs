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
    public abstract class TestLabelBaseAttribute : TestCategoryBaseAttribute
    {
        private readonly string m_label;

        public override IList<string> TestCategories
        {
            get
            {
                return (IList<string>)new string[1] { this.m_label };
            }
        }

        protected TestLabelBaseAttribute(string label)
        {
            this.m_label = label;
        }
    }
}
