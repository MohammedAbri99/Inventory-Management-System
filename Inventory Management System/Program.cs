namespace Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //use 2D arry to store s name, price, and quantity.
            string[,] Products = new string[,] { };
            string[,] sales = new string[,] { };
            //suppose wehave only one user. but if we have more than one user we use 2D array.
            string[] users = { "admin", "adminpass" };
            Console.WriteLine("Welcome to the Inventory Management System!");
            #region User Authentication
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please enter your username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                string password = Console.ReadLine();
                //authenticate use input if true we put the flag false to go out from loop.
                flag = (users[0] == username && users[1]==password)?false : true;
                if (flag)
                {
                    Console.WriteLine("Authentication Unsuccessful! Please Try again...");
                }
                else
                {
                    Console.WriteLine($"Authentication successful! Welcome, {username}!"); 
                }
            }
            #endregion

            string menu = "Options:" +
                "1. Add a new product" +
                "2. Update product quantity" +
                "3. Display product list" +
                "4. Record sale" +
                "5. Generate product report" +
                "6. Generate sales report" +
                "7. Exit";
            /*
             * locks varible to close the prgramm, so if user entr 7 then 
             * boolean expretion locks!=7 will be false and goes out from the loop.
             */
            Console.WriteLine(menu);
            int chosie= 0;
            while (chosie !=7)
            {
                Console.Write("Select an operation (1-7): ");
                try
                {
                    chosie = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                switch (chosie)
                {
                    case 1:
                        Console.WriteLine("Enter product name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter product price: ");
                        string price = Console.ReadLine();
                        Console.WriteLine("Enter initial quantity: ");
                        string quant = Console.ReadLine();
                        Products = addProduct(name,price,quant,Products);
                        Console.WriteLine("roduct added successfully!");
                        break;
                    case 2:
                        Console.WriteLine("Enter product name you want to add quantity: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Number of quntity you want to add: ");
                        quant = Console.ReadLine();
                        updateQuantity(name, quant,Products);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }



            }


        }
        //addProduct methos the takes the list of avilable product and add a new one
        //it takes the name,price,quantity as a string since it will string by defult forom compiler
        //
        static string[,] addProduct(string Pro_name,string price,string quantity, string[,] products) 
        {
            int numOfProducts;
            try
            {
                numOfProducts = products.GetLength(0);
                products[numOfProducts, 0] = Pro_name;
                products[numOfProducts, 1] = price;
                products[numOfProducts, 2] = quantity;
            }
            catch
            {
                products[0, 0] = Pro_name;
                products[0, 1] = price;
                products[0, 2] = quantity;

            }
            return products;
        }
        static string[,] updateQuantity(string name,string quant, string[,] pro)
        {
            for (int i = 0; i < pro.GetLength(0); i++)
            {
                if (pro[i, 0].ToLower() == name.ToLower())
                {
                    pro[i, 2] = (Convert.ToInt32(quant) + Convert.ToInt32(pro[i, 2])).ToString();
                }
            }
            return pro;
        }
    }
}