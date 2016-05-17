using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManager
{
    public class Printer
    {
        public event EventHandler PrintStarted;
        public event EventHandler PrintFinished;
        public event EventHandler<PrintInProgressEventArgs> PrintProgress;

        public Printer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int PapersCount { get; private set; }
        public void AddPapers(int count)
        {
            if (count>0)
            {
                PapersCount += count;
            }       
        }

        public void Print(int pagesCount)
        {
            OnPrintStarted();

            for (int i = 0; i < pagesCount; i++)
            {
                PapersCount--;
                OnPrintProgress(i + 1,pagesCount);
            }

            OnPrintFinished();
        }

        protected virtual void OnPrintStarted()
        {
            PrintStarted?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnPrintFinished()
        {
            PrintFinished?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnPrintProgress(int printedCount,int pagesCount)
        {
            var e = new PrintInProgressEventArgs(printedCount, pagesCount);
            PrintProgress?.Invoke(this, e);
        }
    }
}
