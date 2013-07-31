#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;

#endregion

namespace RulesAndDynamicUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                //run the business rules demo
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(RulesAndDynamicUpdate.Workflow1));

                //run the dynamic update demo
//                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(RulesAndDynamicUpdate.DynUpdateDemo));
                instance.Start();

                
                waitHandle.WaitOne();
                Console.ReadLine();
            }
        }
    }
}
