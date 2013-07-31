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

namespace WFTransactions
{
	partial class Workflow1
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
            this.writeLineActivity4 = new WFTransactions.WriteLineActivity();
            this.txActivity2 = new WFTransactions.TxActivity();
            this.txActivity1 = new WFTransactions.TxActivity();
            this.writeLineActivity3 = new WFTransactions.WriteLineActivity();
            this.writeLineActivity2 = new WFTransactions.WriteLineActivity();
            this.writeLineActivity5 = new WFTransactions.WriteLineActivity();
            this.waitAct1 = new WFTransactions.ReceivingActivity();
            this.transactionScopeActivity1 = new System.Workflow.ComponentModel.TransactionScopeActivity();
            this.writeLineActivity1 = new WFTransactions.WriteLineActivity();
            // 
            // writeLineActivity4
            // 
            this.writeLineActivity4.Color = System.ConsoleColor.Green;
            this.writeLineActivity4.Name = "writeLineActivity4";
            this.writeLineActivity4.OutputText = "Last activity in TX scope";
            // 
            // txActivity2
            // 
            this.txActivity2.Name = "txActivity2";
            this.txActivity2.WorkToDo = "More work to do";
            // 
            // txActivity1
            // 
            this.txActivity1.Name = "txActivity1";
            this.txActivity1.WorkToDo = "First work from activity";
            // 
            // writeLineActivity3
            // 
            this.writeLineActivity3.Color = System.ConsoleColor.Green;
            this.writeLineActivity3.Name = "writeLineActivity3";
            this.writeLineActivity3.OutputText = "Inside tx";
            // 
            // writeLineActivity2
            // 
            this.writeLineActivity2.Color = System.ConsoleColor.Cyan;
            this.writeLineActivity2.Name = "writeLineActivity2";
            this.writeLineActivity2.OutputText = "ending workflow";
            // 
            // writeLineActivity5
            // 
            this.writeLineActivity5.Color = System.ConsoleColor.Cyan;
            this.writeLineActivity5.Name = "writeLineActivity5";
            this.writeLineActivity5.OutputText = "After wait activity, before complete";
            // 
            // waitAct1
            // 
            this.waitAct1.Name = "waitAct1";
            // 
            // transactionScopeActivity1
            // 
            this.transactionScopeActivity1.Activities.Add(this.writeLineActivity3);
            this.transactionScopeActivity1.Activities.Add(this.txActivity1);
            this.transactionScopeActivity1.Activities.Add(this.txActivity2);
            this.transactionScopeActivity1.Activities.Add(this.writeLineActivity4);
            this.transactionScopeActivity1.Name = "transactionScopeActivity1";
            this.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // writeLineActivity1
            // 
            this.writeLineActivity1.Color = System.ConsoleColor.Magenta;
            this.writeLineActivity1.Name = "writeLineActivity1";
            this.writeLineActivity1.OutputText = "Starting workflow";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.writeLineActivity1);
            this.Activities.Add(this.transactionScopeActivity1);
            this.Activities.Add(this.waitAct1);
            this.Activities.Add(this.writeLineActivity5);
            this.Activities.Add(this.writeLineActivity2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private WriteLineActivity writeLineActivity3;
        private WriteLineActivity writeLineActivity2;
        private TransactionScopeActivity transactionScopeActivity1;
        private WriteLineActivity writeLineActivity4;
        private TxActivity txActivity1;
        private ReceivingActivity waitAct1;
        private WriteLineActivity writeLineActivity5;
        private TxActivity txActivity2;
        private WriteLineActivity writeLineActivity1;















    }
}
