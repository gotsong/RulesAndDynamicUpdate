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
            System.Workflow.Activities.Rules.RuleSetReference rulesetreference1 = new System.Workflow.Activities.Rules.RuleSetReference();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.policyActivity1 = new System.Workflow.Activities.PolicyActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            // 
            // codeActivity3
            // 
            this.codeActivity3.Enabled = false;
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.codeActivity3_ExecuteCode);
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // policyActivity1
            // 
            this.policyActivity1.Name = "policyActivity1";
            rulesetreference1.RuleSetName = "Rule Set1";
            this.policyActivity1.RuleSetReference = rulesetreference1;
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.policyActivity1);
            this.Activities.Add(this.codeActivity2);
            this.Activities.Add(this.codeActivity3);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeActivity3;

        private CodeActivity codeActivity2;

        private PolicyActivity policyActivity1;

        private CodeActivity codeActivity1;
































































































    }
}
