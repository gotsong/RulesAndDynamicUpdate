using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;

namespace WFTransactions
{
	public class TxActivity:Activity
	{

        public string WorkToDo { get; set; }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            //get the custom service which will add 
            //this work to the work batch
            executionContext.GetService<TxService>(
                ).DoActivityWork(
                this.WorkToDo);

            return ActivityExecutionStatus.Closed;
        }
	}
}
