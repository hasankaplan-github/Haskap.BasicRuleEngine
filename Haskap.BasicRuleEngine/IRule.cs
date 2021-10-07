using System.Threading.Tasks;

namespace Haskap.BasicRuleEngine
{
    public interface IRule<TContext>
    {
        int Priority { get; }
        TContext Context { get; }
        RuleState State { get; }
        object Result { get; }


        Task<bool> ShouldRunAsync();
        Task<object> RunAsync();
    }
}
