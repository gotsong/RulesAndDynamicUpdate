using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Runtime;

namespace WFTransactions
{
    /// <summary>
    /// Service that gets work from activity and 
    /// puts that work in the work batch.  This 
    /// service also implements IPendingWork, so 
    /// it gets called when it is time to commit 
    /// the work batch.
    /// </summary>
	public class TxService : IPendingWork
	{
        public void DoActivityWork(string work)
        {
            //queue up the work item to be handled
            //when the transaction is available
            WorkflowEnvironment.WorkBatch.Add(this, work);
        }

        #region IPendingWork Members

        public void Commit(System.Transactions.Transaction transaction,
            System.Collections.ICollection items)
        {

            //commit the work within the passed in tx
            Console.WriteLine("Transaction info: {0}, {1}",
                transaction.TransactionInformation.LocalIdentifier, 
                transaction.TransactionInformation.Status);
            Console.ForegroundColor = ConsoleColor.Red;
            
            //all items this added for this IPendingWork 
            //instance are passed to the commit method
            foreach (string item in items)
            {
                Console.WriteLine("\tWork item {0}", item);
               
            }
            Console.ResetColor();

        }

        /// <summary>
        /// Signals that the tx has finished
        /// </summary>
        /// <param name="succeeded">Indicates if the 
        /// transaction successfully committed.</param>
        /// <param name="items">The work items added for this 
        /// IPendingWork implementation</param>
        public void Complete(bool succeeded, 
            System.Collections.ICollection items)
        {
            Console.WriteLine("Complete {0} successful",
                (succeeded ? "was" : "was not"));

        }

        /// <summary>
        /// We can indicate if we need the tx to 
        /// commit at this time, asked by the runtime
        /// when there is an opportunity to commit.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool MustCommit(System.Collections.ICollection items)
        {
            return false;
        }

        #endregion
    }
}
