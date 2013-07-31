using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.ComponentModel;

namespace RulesAndDynamicUpdate
{
	public class WriteLineActivity : Activity
	{
        public static DependencyProperty TextColorProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TextColor", typeof(ConsoleColor), typeof(WriteLineActivity));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ConsoleColor TextColor
        {
            get
            {
                return ((ConsoleColor)(base.GetValue(WriteLineActivity.TextColorProperty)));
            }
            set
            {
                base.SetValue(WriteLineActivity.TextColorProperty, value);
            }
        }
        public static DependencyProperty OutputTextProperty = System.Workflow.ComponentModel.DependencyProperty.Register("OutputText", typeof(string), typeof(WriteLineActivity));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string OutputText
        {
            get
            {
                return ((string)(base.GetValue(WriteLineActivity.OutputTextProperty)));
            }
            set
            {
                base.SetValue(WriteLineActivity.OutputTextProperty, value);
            }
        }


        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.ForegroundColor = TextColor;
            Console.WriteLine(OutputText);
            Console.ResetColor();

            return ActivityExecutionStatus.Closed;

        }
	}
}
