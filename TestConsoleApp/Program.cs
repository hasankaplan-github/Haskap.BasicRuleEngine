using Haskap.BasicRuleEngine;
using System;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                DateOfBirth = new DateTime(1984, 1, 1),
                FirstName = "Hasan",
                LastName = "Kaplan",
                RegistrationDate = new DateTime(2021, 10, 5)
            };

            var newStudentMessageRule = new NewStudentMessageRule(student, 1);
            var oldStudentMessageRule = new OldStudentMessageRule(student, 2);

            var rules = new IRule<Student>[] 
            { 
                newStudentMessageRule, 
                oldStudentMessageRule 
            };

            var ruleEngine = new RuleEngine();
            ruleEngine.Run(rules);

            foreach (var rule in rules)
            {
                Console.WriteLine(rule.GetType());
                Console.WriteLine(rule.State);

                if (rule.State == RuleState.Completed)
                {
                    Console.WriteLine(rule.Result);
                }
            }
        }
    }
}
