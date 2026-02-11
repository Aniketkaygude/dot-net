using System;
using System.Collections;


namespace namespace1
{
    delegate void Mydelegate();
    delegate int mydelegate2( int a, int b );

   

    class Accenture
    {
       public void show() {

            Console.WriteLine("show from accenture ");
        }
        public int add( int a , int b)
        {
             
            return a + b;
        }
    }

    internal class Program
    {

        public static void Main(string[] args)
        {   
            Accenture a  = new Accenture(); 
             Mydelegate d = new Mydelegate(a.show);

            mydelegate2 d2 = new mydelegate2(a.add);
         Console.WriteLine(  d2(100 , 21));
        }

    }





}
