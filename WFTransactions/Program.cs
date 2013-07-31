using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace WFTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {

                //add a peristence service which is 
                //required when using tx scope activity
                SqlWorkflowPersistenceService persist =
                    new SqlWorkflowPersistenceService("database=workflowpersistence;integrated security=SSPI");
                workflowRuntime.AddService(persist);

                //add custom service used by activity
                TxService txService = new TxService();
                workflowRuntime.AddService(txService);

                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(WFTransactions.Workflow1));
                instance.Start();

                //send data to the activity queue
                //and also send a work item and 
                //IPending work to participate in the 
                //tx that is used in the WF instance
                instance.EnqueueItemOnIdle(
                    "waitAct1", "queuedata",
                    txService, 
                    "Work from host"); 

                waitHandle.WaitOne();
            }
        }
    }
}
