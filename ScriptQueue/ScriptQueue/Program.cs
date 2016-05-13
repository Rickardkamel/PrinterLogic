using System;
using System.Printing;
using System.Management;

namespace ScriptQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Retrieving printer queue information using WMI");
            Console.WriteLine("==================================");
            //Query printer queue
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_PrintJob");
            ManagementObjectSearcher query1 = new ManagementObjectSearcher(oq);
            ManagementObjectCollection queryCollection1 = query1.Get();
            foreach (ManagementObject mo in queryCollection1)
            {
                Console.WriteLine("Printer Driver : " + mo["DriverName"].ToString());
                Console.WriteLine("Document Name : " + mo["Document"].ToString());
                Console.WriteLine("Document Owner : " + mo["Owner"].ToString());
                Console.WriteLine("==================================");
                
            }
            Console.ReadKey();
        }

        //private int GetNumberOfPrintJobs()
        //{
        //    LocalPrintServer server = new LocalPrintServer();
        //    PrintQueueCollection queueCollection = server.GetPrintQueues();
        //    PrintQueue printQueue = null;

        //    foreach (PrintQueue pq in queueCollection)
        //    {
        //        if (pq.FullName == PrinterName)
        //            printQueue = pq;
        //    }

        //    int numberOfJobs = 0;
        //    if (printQueue != null)
        //        numberOfJobs = printQueue.NumberOfJobs;

        //    return numberOfJobs;
        //}
    }
}
