using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO.Pipes;

namespace WebShop_Ertl_Gnadlinger
{

    internal class Program
    {
        public enum Menu
        {
            UserData = 1,
            Products,
            Cart,
            EndOfProgramm,
        }

        public enum EnumCart
        {
            order = 1,
            backToproducts,
            delete,
        }

       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           // Ertl Markus       s2210438006     Main mit allen funktionen
           // Gnadlinger Oskar  s2210438007     alle Klassen (Shop, Product, Customer, Cart)

            // - natürlich überschneiden sich die meisten Bereiche -> es wurden mehrere Funktionen im austausch entwickelt.



            Customer User = new Customer(null, null);    //creates a default customer
            Shop LegoShop = new Shop();                  //creates a shop
            LegoShop.refill();                           //refills the shop with predefined items
            Cart LegoCart = new Cart();                  //creates a Shopping-Cart                    

            string menuInput = null;

            Console.WriteLine("*************************\n*Welcome to the Webshop!*\n*************************");
            Console.WriteLine("\nWhat do you want to do?\n");

            bool EndOfProgramm = false;
            do
            {
                try
                {
                    menuInput = MenuInput();      //gets the Input from the user 1,2 or 3             
                    EndOfProgramm = MenuNaviagtion(menuInput, User, LegoShop, LegoCart);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.ToString() + "\n");
                }

                //EndOfProgramm = MenuNaviagtion(menuInput, User, LegoShop, LegoCart);

            } while (!EndOfProgramm);

            Console.ReadKey();

        }

        public static string MenuInput()
        {
            bool success = false;
            string Input;
            do
            {
                Console.WriteLine("\n#The Menu:");
                    Console.WriteLine("\t1 - Enter/change your user data\n\t2 - Product overview\n\t3 - show shopping cart\n\t4 - Exit webshop\n\n Please Enter a number:   ");
                    Input = Console.ReadLine();
                    int numberInput = int.Parse(Input);
                    success = Enum.IsDefined(typeof(Menu), numberInput);

                    if (!success) throw new ArgumentException("\nError, incorrect Input - Try again!\n");
                 
            } while (!success);

            return Input;
        }

        public static bool MenuNaviagtion(string input, Customer user, Shop LegoShop, Cart LegoCart)
        {
            int i = int.Parse(input);//delete
            bool EndOfProgramm = false;
            switch (i)
            {
                case 1:
                    EnterChangeUser(user);
                    

                    break;
                case 2:
                    ProductOverview(user, LegoShop,LegoCart);

                    break;

                case 3:
                    EndOfProgramm = ShoppingCart(LegoCart, LegoShop, user);
                    break;

                case 4:
                    EndOfProgramm = true;
                    Console.WriteLine("\n See you soon\n");
                    break;

                default:
                    throw new ArgumentException("\nError, incorrect Input");

            }

            return EndOfProgramm;
        }

        static public void EnterChangeUser(Customer user)
        {
            string Input;
            bool success = false;
            Console.Clear();
            Console.WriteLine("\nLet's enter/change your user data!\n");

            do
            {
                try
                {
                    if(user.Name == null)   //query if there is already a name entered or not
                    {
                        Console.WriteLine("Please Enter your Name:");
                        Input = Console.ReadLine();
                        user.InputName(Input);              // input verification in the class, method "InputName"

                    }
                    else
                    {
                        Console.WriteLine($"The current Name is: {user.Name}\n");
                        Console.WriteLine("Please enter the new name: ");
                        user.InputName(Console.ReadLine());
                    }
                    
                    if(user.Address == null)
                    {
                        string[] addressArray = new string[4]; //initialises an array if none exists yet
                        addressArray = AddressInput();
                        
                        user.InputAddress(addressArray);   // input verification in the class, method "InputAddress"
                    }
                    else
                    {
                        string[] NewaddressArray = new string[4];

                        Console.WriteLine("\nThe current address is: \n");
                        for (int i = 0; i < user.Address.Length; i++) 
                        {
                            Console.WriteLine("\t" + user.Address[i]);  //shows the user the current address
                        }

                        NewaddressArray = AddressInput();

                        user.InputAddress(NewaddressArray);
                    }

                    success = true;         //if everthing is alright (no exception) the do-while ends
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.ToString() + "\n");
                }

            } while (!success);

            Console.WriteLine("\nVery Good, you changed your data!\n");

           
        }

        public static string[] AddressInput()       //only for the Input of the address, input verification in the class
        {
            string[] InputAddress = new string[4];
                        
                Console.WriteLine("\nPlease Enter your new address:");
                Console.WriteLine("\n-1 Enter your street: ");
                InputAddress[0] = Console.ReadLine();
                Console.WriteLine("-2 Enter your house number: ");
                InputAddress[1] = Console.ReadLine();
                Console.WriteLine("-3 Enter your postler number: ");
                InputAddress[2] = Console.ReadLine();
                Console.WriteLine("-4 Enter your City: ");
                InputAddress[3] = Console.ReadLine();

            return InputAddress;
        }

        public static void ProductOverview(Customer user, Shop LegoShop, Cart LegoCart)
        {
            //produkte werden über klasse shop angelegt -> Oben im Main
            //Aufruf Produkte über klasse shop.product
            Console.Clear();

            bool success = false;
            do
            {
                Console.WriteLine("\nWelcome to the Product Overview!\n");


                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\tnumber\t\ttitle\t\ttype\t\tprice\t\tin stock");
                Console.BackgroundColor = ConsoleColor.Black;

                try
                {
                    int NumberOfProducts = LegoShop.ShopList.Length;
                    for (int i = 0; i < LegoShop.ShopList.Length; i++)
                    {
                        Console.WriteLine(LegoShop.ShopList[i]);
                    }

                    Console.WriteLine("\nWhen you have decided on a product, enter the number and the number of pieces, of the respective product.");
                    Console.WriteLine("Enter 0, if you have finished.");
                    List<Tuple<int, int>> artikleNumbersAndPieces = InputArticleNumbersShop(LegoShop,LegoCart);

                    LegoCart.getProduct(artikleNumbersAndPieces, LegoShop); // method in Cart that compares the article number from the user with the shopList


                    if(artikleNumbersAndPieces.Count > 0)
                    {
                        Console.WriteLine("\nYour selected Items now in the Shopping Cart, select 3 in the Menu to display them.");
                    }   
                    
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    success = false;
                }


            } while (!success);


        }

        
        private static List<Tuple<int,int>> InputArticleNumbersShop(Shop LegoShop,Cart LegoCart)
        {
            List<Tuple<int,int>> articleAndPiecesListInput = new List<Tuple<int,int>>();

            bool check = false;


            Product[] RealItemList = LegoShop.ShopList;
            Tuple<int,int>[] realArticleNumbers = new Tuple<int, int>[LegoShop.ShopList.Length];

            for (int i = 0; i < LegoShop.ShopList.Length; i++)
            {  
                realArticleNumbers[i] = new Tuple<int, int>(RealItemList[i].ArtikleNumber, RealItemList[i].NumberOfPieces);    //gets a list of all articleNumbers and Number of Pieces that are in the Shop
            }


            do
            {
                
                bool Numbercheck = false;
                bool piecesCheck = false;
                int InputNumberInt = 0;
                int InputPiecesInt = 0;
                string InputNumber = null;
                bool checkRealNumbers = false;
                bool checkRealPieces = false;
                int remainingItems = 0;
                do
                {                           //query for the article Number Input
                    checkRealNumbers = false;
                    InputNumberInt = 0;
                    Console.WriteLine("Enter Number or 0 to finish:");
                    InputNumber = Console.ReadLine();
                    if (InputNumber == "0") { break; }      //leaves the do while if the input was 0

                    Numbercheck = int.TryParse(InputNumber, out InputNumberInt);   

                    foreach (var item in realArticleNumbers )
                    {
                        if (item.Item1 == InputNumberInt && item.Item2 > 0) //es muss der warenkorb überprüft werden
                        {
                            if (LegoCart.CartList.Count == 0) //shopping cart is empty
                            {
                                checkRealNumbers = true;
                                break;
                            }
                            else  //shopping cart is not empty
                            {

                                foreach (var itemCart in LegoCart.CartList) //query for the shopping cart (to exclude duplication of use)
                                {
                                    remainingItems = 0;

                                    if (itemCart.Item1.ArtikleNumber != InputNumberInt) //the item in the shopping cart is not the same as selected
                                    {
                                        checkRealNumbers = true;
                                        break;
                                    }
                                    else //if the item is already in the shopping cart it must be checked that it is not selected to often
                                    {
                                        if ((item.Item2 - itemCart.Item2) >= 1) // (Stock - Cart) >= userInput
                                        {
                                            remainingItems = item.Item2 - itemCart.Item2;
                                            checkRealNumbers = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error, there are too many item's of this product selected, look in your shopping cart");
                                        }
                                    }
                                }
                            }
                        }    
                    }

                    if (!Numbercheck||!checkRealNumbers)
                    {
                        Console.WriteLine("Error, please Enter a possible article number.");
                    }                          

                } while (!checkRealNumbers);

                do
                {
                    if (InputNumber == "0") { break; }         //leaves the do while if the input was 0

                    checkRealPieces = false;
                    InputPiecesInt = 0;

                    Console.WriteLine("Enter Number of Pieces:");
                    string InputPieces = Console.ReadLine();
                    

                    piecesCheck = int.TryParse(InputPieces, out InputPiecesInt);
                   

                    foreach (var item in realArticleNumbers)
                    {

                        if (item.Item1 == InputNumberInt)
                        {
                            if (item.Item2 >= InputPiecesInt && InputPiecesInt > 0  &&  item.Item2 > 0  &&  InputPiecesInt>0)
                            {
                                if(LegoCart.CartList.Count == 0) //shopping cart is empty
                                {
                                    checkRealPieces = true;
                                    break;
                                }
                                else if(remainingItems >= InputPiecesInt) // shopping cart is not empty
                                {
                                    checkRealPieces = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error, you have selected more than available, look in your shopping cart!");
                                }
                               
                            }
                        }
                                        
                    }
                    if(!piecesCheck||!checkRealPieces)
                    {
                        Console.WriteLine("Please enter a possible number of pieces");
                    }


                } while (!checkRealPieces);

                if (InputNumberInt == 0 || InputPiecesInt == 0) 
                {
                    check = false;
                    break;
                }
                else
                {
                    articleAndPiecesListInput.Add(new Tuple<int, int>(InputNumberInt,InputPiecesInt));
                }                            

            } while (!check);
                    
           return articleAndPiecesListInput;
        }


        private static bool ShoppingCart(Cart LegoCart,Shop LegoShop, Customer user)
        {
            bool EndOfProgramm = false;

            if (LegoCart.CartList.Count == 0)
            {
                Console.WriteLine("Please select products first!");

            }
            else
            {
                Console.Clear();

                Console.WriteLine("Welcome to your Cart!\n");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\tnumber\t\ttitle\t\ttype\t\tprice\t\tin stock\tselected");
                Console.BackgroundColor = ConsoleColor.Black;

                double totalPrice = 0;
                double shipping = 0.00;

                for (int i = 0; i < LegoCart.CartList.Count; i++)
                {
                    Console.WriteLine(LegoCart.CartList[i].Item1 + "\t\t" + LegoCart.CartList[i].Item2);

                    double currentItemPrice = LegoCart.CartList[i].Item1.Price;
                    int currentSelectedNumber = LegoCart.CartList[i].Item2;

                    totalPrice = totalPrice + (currentItemPrice * currentSelectedNumber);
                }

                if (totalPrice <= 50.0)
                {
                    shipping = 10.00;
                }

                Console.WriteLine($"\n\t\t\t\t\tshipping costs up to 50€:\t\t{shipping}\tEuro ");
                totalPrice += shipping;
                Console.WriteLine($"\t\t\t\t\ttotal costs:\t\t{Math.Round(totalPrice,2)}\tEuro");



                bool success = false;
                int IntInput=0;
                do
                {
                    try
                    {
                        Console.WriteLine("\t1 - order\n\t2 - save for later and back to the menu\n\t3 - cancel and delete the shopping cart\n\n Please Enter a number:   ");
                        IntInput = int.Parse(Console.ReadLine());
                        success = Enum.IsDefined(typeof(EnumCart), IntInput);

                        if (!success) throw new ArgumentException("\nError, incorrect Input - Try again!\n");


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n"+ ex.ToString + "\n");
                        
                    }
                    

                } while (!success);

                switch (IntInput)
                {
                    case 1:
                        
                        if (user.Address == null)
                        {
                            Console.Write("Error, we do not know where the product(s) should be sent to, please enter your name and address\nEnter 1 in the menu.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nThank you for your order!\nSee you soon :D");
                            //reduction numbers of pieces
                            List<Tuple<Product, int>> CartList = LegoCart.CartList;
                            Product[] itemList = LegoShop.ShopList;

                            for (int i = 0; i < itemList.Length; i++)
                            {
                                Product product = itemList[i];

                                foreach (var item in CartList)
                                {
                                    if (item.Item1 == product)
                                    {
                                        int newNumberofPieces = itemList[i].NumberOfPieces - item.Item2; //the number is reduced by the number of pieces selected by the customer

                                        itemList[i].NumberOfPieces = newNumberofPieces;

                                    }
                                }
                            }
                            LegoShop.ShopList = itemList;

                            LegoCart.CartList.Clear();          //clears the shopping cart
                            LegoCart.CartList = new List<Tuple<Product, int>>();
                            //EndOfProgramm = true;
                        }

                        break;

                    case 2:
                        Console.Clear();

                        break;
                        //fertig
                    case 3:
                        Console.WriteLine("You successfully cancelled your order");

                        LegoCart.CartList.Clear();
                        LegoCart.CartList = new List<Tuple<Product, int>>();

                        break;

                    default:
                        break;

                }

            }

            return EndOfProgramm;
        }
    }
}