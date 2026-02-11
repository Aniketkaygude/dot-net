
using ClassLibrary1;
namespace ConsoleApp1 {


    public class Program {

        static ShopingContext context;
        
        static Program()
        {
            context = new ShopingContext();
        }

        static public void AddCategories()
        {

            Console.Write("enter category-->");
            string name = Console.ReadLine();

            Category c = new Category();
            c.CategoryName = name;

            context.Categories.Add(c);
            context.SaveChanges();
            Console.WriteLine("Category added success fully");

        }


        static public void DisplayCategories()
        {

            Console.WriteLine("Here are  categories");

            List<Category> categories = context.Categories.ToList();

            foreach (Category c in categories)
            {
                Console.WriteLine(c.CategoryId + "\t" + c.CategoryName);
            }

        }

        static public void AddProduct()
        {

            Console.Write("enter product name --> ");
            string name = Console.ReadLine();

            Console.Write("enter product price --> ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.Write("enter category id  --> ");
            int CatId = Convert.ToInt32(Console.ReadLine());


            Product p = new Product();
            p.ProductName = name; p.Price = price;
            p.CategoryId = CatId;

            context.Products.Add(p);
            context.SaveChanges();
            Console.WriteLine("product added success fully");

        }


        static public void DisplayProduct()
        {

            Console.WriteLine("Here are  Products");

            List<Product> Products = context.Products.ToList();

            foreach (Product p  in Products)
            {
                Console.WriteLine(p.ProductId + "\t" + p.ProductName +"\t" + p.Price);
            }


        }

        static void Main(string[] args)
        {

            //AddCategories();
            //Console.WriteLine("\n");
            //Console.ReadKey();
            //DisplayCategories();


            AddProduct();
            Console.WriteLine("\n");
            Console.ReadKey();
            DisplayProduct();


        }

    }
}