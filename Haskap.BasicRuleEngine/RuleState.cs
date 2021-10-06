using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.BasicRuleEngine
{
    public enum RuleState
    {
        Initialized,
        InProgress,
        NotRunable,
        Failed,
        CompletedSuccessfuly
    }
}
