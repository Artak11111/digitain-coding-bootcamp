using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManager
{
    public class PrintInProgressEventArgs:EventArgs
    {
        public PrintInProgressEventArgs(int printedPagesCount, int pagesCount)
        {
            PrintedPagesCount = printedPagesCount;
            PagesCount = pagesCount;
        }

        public int PrintedPagesCount { get; set; }
        public int PagesCount { get; set; }
        public double Porgress { get { return 100.0*PrintedPagesCount / PagesCount; } }
    }
}
