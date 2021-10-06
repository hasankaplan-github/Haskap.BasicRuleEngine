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

            Console.WriteLine(newStudentMessageRule.State);

            if (newStudentMessageRule.ShouldRun())
            {
                newStudentMessageRule.Run();
                Console.WriteLine(newStudentMessageRule.State);
                if (newStudentMessageRule.State == RuleState.Completed)
                {
                    Console.WriteLine(newStudentMessageRule.Result);
                }
            }
        }
    }
}
