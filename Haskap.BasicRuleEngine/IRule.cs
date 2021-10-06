using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.BasicRuleEngine
{
    public interface IRule<TContext>
    {
        int Priority { get; }
        TContext Context { get; }
        RuleState State { get; }
        object Result { get; }


        bool ShouldRun();
        object Run();
    }
}
