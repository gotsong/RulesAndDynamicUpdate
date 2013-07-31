using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace WFTransactions
{
    /// <summary>
    /// Very basic activity that waits for data
    /// and responds when data arrives on the queue
    /// </summary>
	public class ReceivingActivity : Activity
	{

        protected override void Initialize(IServiceProvider provider)
        {
            base.Initialize(provider);
            WorkflowQueuingService qService = (WorkflowQueuingService)provider.GetService(typeof(WorkflowQueuingService));

            if(!qService.Exists(QualifiedName))
                qService.CreateWorkflowQueue(QualifiedName, false);
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            executionContext.GetService<
                WorkflowQueuingService>(
                ).GetWorkflowQueue(QualifiedName
                ).QueueItemAvailable += OnEvent;
            return ActivityExecutionStatus.Executing;
        }

        protected void OnEvent(object sender, QueueEventArgs e)
        {
            string input = ((ActivityExecutionContext)sender).GetService<WorkflowQueuingService>().GetWorkflowQueue(QualifiedName).Dequeue().ToString();
            Console.WriteLine("Data arrived {0}", input);

            ((ActivityExecutionContext)sender).CloseActivity();

        }
	}
}
