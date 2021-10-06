using Haskap.BasicRuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class OldStudentMessageRule : IRule<Student>
    {
        public int Priority { get; private set; }

        public Student Context { get; private set; }

        public RuleState State { get; private set; }

        public object Result { get; private set; }

        public OldStudentMessageRule(Student context, int priority)
        {
            Context = context;
            Priority = priority;
            State = RuleState.Initialized;
        }

        public object Run()
        {
            State = RuleState.InProgress;

            try
            {
                string message = "";
                var dateTimeNow = DateTime.Now;
                if (Context.RegistrationDate.AddYears(4) <= dateTimeNow)
                {
                    message = "We don't forget you.";
                }

                Result = message;
                State = RuleState.Completed;
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
