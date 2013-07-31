using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;
//using CustomActivities;

namespace RulesAndDynamicUpdate
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {

        public class Customer
        {
            public Customer(CustomerLevel level, string customerName, double limit)
            {
                this.level = level;
                this.name = customerName;
                this.spendingLimit = limit;
            }

            public CustomerLevel level;
            public string name;
            public double spendingLimit;
        }

        public class Order
        {
            public double total;
            public List<Item> items;


        }

        public class Item
        {
            public Item(int id, double value)
            {
                ItemID = id;
                cost = value;
            }
            public int ItemID;
            public double cost;
        }



        Customer cust;
        Order order;

        public enum CustomerLevel
        {
            Silver,
            Gold,
            Platinum
        }

        public Workflow1()
        {
            InitializeComponent();

            order = new Order();
            order.total = 101;
            order.items = new List<Item>();
            order.items.Add(new Item(1, 32));
            order.items.Add(new Item(2, 34));
            order.items.Add(new Item(3, 42));

            cust = new Customer(CustomerLevel.Silver, "matt", 200);

        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Order total: {0}  Customer Level: {1}", order.total, cust.level);
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            CodeActivity code = (CodeActivity)sender;
            CompositeActivity parent = code.Parent;

            WorkflowChanges changes = new WorkflowChanges(parent);
            CompositeActivity root = changes.TransientWorkflow;

            //create activities to add
            WriteLineActivity writeLine1 = new WriteLineActivity();
            writeLine1.OutputText = "Dynamically added activity";
            writeLine1.TextColor = ConsoleColor.Red;
            writeLine1.Name = "writeLine1";

            //adding activiy to transient workflow
            root.Activities.Add(writeLine1);



            this.ApplyWorkflowChanges(changes);

        }
    }

    

}
