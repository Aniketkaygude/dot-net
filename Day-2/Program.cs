
using System;

namespace namespace1
{
    class Accen {


        public int empno{ get; set; }
        public string empname { get; set; }

          
       
    }

    internal class Program
    {

        public static void Main(string[] args)
        {
            Accen a = new Accen() { empno = 12, empname = "aniket" };
            //Console.WriteLine($"empname --> {a.empname} \nempno --> {a.empno}");

            int[] arr = { 1, 2 };
            int[] arr2 = new int[2] { 1, 2 };
            arr = new int[] { 3, 4, 5 };
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //foreach (int i in arr2)
            //{
            //    Console.Write(i + " ");
            //}

            try {
                Console.Write("Enter number--> ");
                int n = Convert.ToInt32( Console.ReadLine());
                int b = 10 / n;
                Console.WriteLine("Result -->{0} ", b);
               
            }
            catch (Exception e) {
                Console.WriteLine("\nError --> " + e.Message);
                Console.WriteLine("\nError --> " + e.StackTrace);
                //Console.WriteLine("\nError --> " + e.Message);
                //Console.WriteLine("\nError --> " + e.Message);

            }
            finally
            {
                Console.WriteLine("\n\nProgram ended");
            }


        }

    }

}