using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.BasicRuleEngine
{
    public class RuleEngine
    {
        public async Task RunAsync<TContext>(params IRule<TContext>[] rules)
        {
            var orderedRules = rules.OrderBy(x => x.Priority);
            foreach (var rule in orderedRules)
            {
                if (await rule.ShouldRunAsync())
                {
                    await rule.RunAsync();
                }
            }
        }
    }
}
