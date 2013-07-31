using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;
using System.ComponentModel;

namespace WFTransactions
{
	public class WriteLineActivity : Activity
	{

        public string OutputText { get; set; }

        public ConsoleColor Color { get; set; }


        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(OutputText);
            Console.ResetColor();
            return ActivityExecutionStatus.Closed;
        }
	}
}
