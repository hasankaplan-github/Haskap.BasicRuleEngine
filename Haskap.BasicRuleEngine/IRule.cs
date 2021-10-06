using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.BasicRuleEngine
{
    public interface IRule<TContext, TResult>
    {
        int Priority { get; }
        TContext Context { get; }
        RuleState State { get; }
        TResult Result { get; }


        bool ShouldRun();
        TResult Run();
    }
}
