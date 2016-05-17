using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var f = Fibonacci.Create();

                for (int i = 0; i < f.Length; i++)
                {
                    Console.WriteLine($"{(i + 1)}: {f[i]}");
                }

                var evenValues = f.GetEvens();

                foreach (var item in evenValues)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                var t = f[f.Length];
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.ParamName} => {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NotCalculatedException e)
            {
                Console.WriteLine($"{e.Message} === {e.MyProperty}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }        
            
            Console.ReadLine();
        }
    }
}
