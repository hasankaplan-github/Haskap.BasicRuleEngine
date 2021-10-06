using Haskap.BasicRuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class BirthdayMessageRule : IRule<Student>
    {
        public int Priority { get; private set; }

        public Student Context { get; private set; }

        public RuleState State { get; private set; }

        public object Result { get; private set; }

        public BirthdayMessageRule(Student context, int priority)
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
                Result = "Happy Birthday.";
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
            var dateTimeNow = DateTime.Now;
            if (Context.DateOfBirth.Day == dateTimeNow.Day && Context.DateOfBirth.Month == dateTimeNow.Month)
            {
                return true;
            }

            State = RuleState.NotRunable;
            return false;
        }
    }
}
