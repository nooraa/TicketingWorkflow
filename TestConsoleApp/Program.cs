using System;
using Ticketing.Workflow.Domain;

namespace TestConsoleApp
{
    class Program
    {
        static TicketingWorkflowDBContext dbContext;
        static IEFDataReader iEFReader;
        static void Main(string[] args)
        {
            dbContext = new TicketingWorkflowDBContext(null);
            iEFReader = new EFDataReader();
            iEFReader.GetSubCategories();
            Console.WriteLine("Hello World!");
        }
    }
}
