using PrintManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer HP = new Printer("HP");
            Action<int> Wait = System.Threading.Thread.Sleep;

            HP.PrintStarted += (sender, e) => { Wait(1000);  Console.WriteLine($"{(sender as Printer)?.Name} Print Started."); };
            HP.PrintFinished += (sender, e) => { Wait(1000); Console.WriteLine($"{(sender as Printer)?.Name} Print Finished."); };
            HP.PrintProgress += (sender, e) => {
                Wait(1000); Console.WriteLine($"{(sender as Printer)?.Name} Printing {e.PrintedPagesCount} of {e.PagesCount} [{e.Porgress}%].");
            };

            HP.AddPapers(2);
            HP.Print(4);
        }
    }
}
