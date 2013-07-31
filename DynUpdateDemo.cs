using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace RulesAndDynamicUpdate
{
	public sealed partial class DynUpdateDemo: SequentialWorkflowActivity
	{
		public DynUpdateDemo()
		{
			InitializeComponent();
		}

        private void TheUpdateCode_ExecuteCode(object sender, EventArgs e)
        {
            CodeActivity code = sender as CodeActivity;

            //climb the hiearchy to get the workflow root
            CompositeActivity root = code.Parent.Parent.Parent;

            //get the workflow changes
            WorkflowChanges changes = new WorkflowChanges(root);
            CompositeActivity troot = changes.TransientWorkflow;

            //create activities to add
            SequenceActivity thirdBranch = new SequenceActivity();

            WriteLineActivity writeLine3 = new WriteLineActivity();
            writeLine3.OutputText = "Third branch (Dynamically Added)";
            writeLine3.TextColor = ConsoleColor.Red;
            writeLine3.Name = "writeLine3";

            thirdBranch.Activities.Add(writeLine3);

            ParallelActivity parallel = troot.GetActivityByName("parallelWrite") as ParallelActivity;

            parallel.Activities.Add(thirdBranch);

            this.ApplyWorkflowChanges(changes);
        }
	}

}
