using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.BasicRuleEngine
{
    public class RuleEngine
    {
        public void Run<TContext>(params IRule<TContext>[] rules)
        {
            var orderedRules = rules.OrderBy(x => x.Priority);
            foreach (var rule in orderedRules)
            {
                if (rule.ShouldRun())
                {
                    rule.Run();
                }
            }
        }
    }
}
