using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(0, 3));
            }

            foreach (var item in list)
            {

            }

            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            Console.ReadKey();
        }
    }
}
