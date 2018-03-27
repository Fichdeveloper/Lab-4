using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Test_proj_C
{
    class Program
    {
        static void Main(string[] args)
        {
           
            LinkedList<int> list = new LinkedList<int>();

            Random random = new Random();

            for (int i=1;i<=4;i++)
            {
                list.AddLast(i);      
            }


            Console.WriteLine("Before insert");
            list.ShowList(list);
            list.Insert(2,4);
            Console.WriteLine();
            Console.WriteLine("After insert");
            list.ShowList(list);
        }
    }
}
