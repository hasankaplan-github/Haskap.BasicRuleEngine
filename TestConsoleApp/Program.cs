using Haskap.BasicRuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                DateOfBirth = new DateTime(1984, 10, 6),
                FirstName = "Hasan",
                LastName = "Kaplan",
                RegistrationDate = new DateTime(2010, 10, 5)
            };

            var rules = new IRule<Student>[]
            {
                new NewStudentMessageRule(student, 1),
                new OldStudentMessageRule(student, 2),
                new BirthdayMessageRule(student, 1)
            };

            var ruleEngine = new RuleEngine();
            ruleEngine.Run(rules);

            foreach (var rule in rules.Where(x => x.State == RuleState.Completed))
            {
                Console.WriteLine(rule.GetType());
                Console.WriteLine(rule.State);
                Console.WriteLine(rule.Result);
            }
        }
    }
}
