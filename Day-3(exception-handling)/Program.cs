// See https://aka.ms/new-console-template for more information

namespace namespace1
{

    class IndexOutOfBound : Exception {
               public string msg { get; }
        public IndexOutOfBound(string msg):base("index out aniket array")
        {
            this.msg = msg;
        }
        }  

        class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int []arr = { 1 };
                throw new IndexOutOfBound("\n\n array is out size 1");
            }
            catch (IndexOutOfBound e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.msg);
            }

         }
    }
}



