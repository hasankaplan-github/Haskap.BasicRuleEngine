using Haskap.BasicRuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class NewStudentMessageRule : IRule<Student, string>
    {
        public int Priority { get; private set; }

        public Student Context { get; private set; }

        public RuleState State { get; private set; }

        public string Result { get; private set; }

        public NewStudentMessageRule(Student context, int priority)
        {
            Context = context;
            Priority = priority;
            State = RuleState.Initialized;
        }

        public string Run()
        {
            State = RuleState.InProgress;

            try
            {
                string message = "";
                var dateTimeNow = DateTime.Now;
                if (Context.RegistrationDate.AddDays(2) >= dateTimeNow)
                {
                    message = "Welcome";
                }

                Result = message;
                State = RuleState.CompletedSuccessfuly;
            }
            catch (Exception)
            {
                State = RuleState.Failed;
                Result = null;
            }

            return Result;
        }

        public bool ShouldRun()
        {
            var shouldRun = true;

            if (shouldRun == false)
            {
                State = RuleState.NotRunable;
            }
            
            return shouldRun;
        }
    }
}
