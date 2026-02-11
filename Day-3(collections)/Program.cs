// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;

namespace namespace1
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList arr = new ArrayList();

            arr.Add(1);
            arr.Add(2);
            arr.Add("aniket");

            // You can use a foreach loop to see all items if you like:
            // foreach(object i in arr)
            // {
            //    Console.WriteLine(i);
            // }

            IEnumerator a = arr.GetEnumerator();
            Console.WriteLine(a.Current);

            // 1. Move to element '1' (returns true)
            a.MoveNext();

            // 2. Move to element '2' (returns true)
            a.MoveNext();

            // 3. Move to element "aniket" (returns true)
            a.MoveNext();

            // 4. Try to move to the next position. Since there are no more elements,
            //    a.MoveNext() returns false, and the if condition becomes true.
            if (a.MoveNext() == false)
            {
                Console.WriteLine("sfsfs");
            }

        }

    }
}
