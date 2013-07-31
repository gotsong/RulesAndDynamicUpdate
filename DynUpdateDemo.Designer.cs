using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace RulesAndDynamicUpdate
{
	partial class DynUpdateDemo
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.writeLineActivity2 = new RulesAndDynamicUpdate.WriteLineActivity();
            this.TheUpdateCode = new System.Workflow.Activities.CodeActivity();
            this.writeLineActivity1 = new RulesAndDynamicUpdate.WriteLineActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.writeLineActivity3 = new RulesAndDynamicUpdate.WriteLineActivity();
            this.parallelWrite = new System.Workflow.Activities.ParallelActivity();
            // 
            // writeLineActivity2
            // 
            this.writeLineActivity2.Name = "writeLineActivity2";
            this.writeLineActivity2.OutputText = "Second branch";
            this.writeLineActivity2.TextColor = System.ConsoleColor.Green;
            // 
            // TheUpdateCode
            // 
            this.TheUpdateCode.Name = "TheUpdateCode";
            this.TheUpdateCode.ExecuteCode += new System.EventHandler(this.TheUpdateCode_ExecuteCode);
            // 
            // writeLineActivity1
            // 
            this.writeLineActivity1.Name = "writeLineActivity1";
            this.writeLineActivity1.OutputText = "First branch";
            this.writeLineActivity1.TextColor = System.ConsoleColor.Green;
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.writeLineActivity2);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.writeLineActivity1);
            this.sequenceActivity1.Activities.Add(this.TheUpdateCode);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // writeLineActivity3
            // 
            this.writeLineActivity3.Name = "writeLineActivity3";
            this.writeLineActivity3.OutputText = "After parallel activity";
            this.writeLineActivity3.TextColor = System.ConsoleColor.Green;
            // 
            // parallelWrite
            // 
            this.parallelWrite.Activities.Add(this.sequenceActivity1);
            this.parallelWrite.Activities.Add(this.sequenceActivity2);
            this.parallelWrite.Name = "parallelWrite";
            // 
            // DynUpdateDemo
            // 
            this.Activities.Add(this.parallelWrite);
            this.Activities.Add(this.writeLineActivity3);
            this.Name = "DynUpdateDemo";
            this.CanModifyActivities = false;

		}

		#endregion

        private WriteLineActivity writeLineActivity2;
        private CodeActivity TheUpdateCode;
        private WriteLineActivity writeLineActivity1;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private WriteLineActivity writeLineActivity3;
        private ParallelActivity parallelWrite;





    }
}
