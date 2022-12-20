using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;

namespace WebShop_Ertl_Gnadlinger
{

    internal class Program
    {
        public enum Menu
        {
            UserData = 1,
            Products,
            Cart
        }


       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //---------------------------------------------
            //Menu:
            //    - Nutzerdaten ändern

            //    - Productübersicht
            //        + Produkte warenkorb hinzufügen

            //    - Warenkorb
            //        + Löschen
            //        + Bestellen
            //            * Bestellübersicht
            //                # Bestätigen
            //                # Abbrechen
            //-----------------------------------------------

            //----------Notes:
            // - EnterChangeUser funktion: aufteilen in 2 segmente, neue eingabe und ersetzen -> sonst bei fehler-Wiederholung werden bereits neue daten angezeigt


            
            Customer User = new Customer(null, null);    //creates a default customer
            Shop LegoShop = new Shop();                  //creates a shop
            LegoShop.refill();                           //refills the shop with predefined items
                                                    

            string menuInput;

            Console.WriteLine("*************************\n*Welcome to the Webshop!*\n*************************");
            Console.WriteLine("\nWhat do you want to do?\n");

            bool EndOfProgramm = false;
            do
            {
                try
                {
                    menuInput = MenuInput();      //gets the Input from the user 1,2 or 3             
                    MenuNaviagtion(menuInput, User, LegoShop);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.ToString() + "\n");
                }

            } while (!EndOfProgramm);
           


        }

        public static string MenuInput()
        {
            bool success = false;
            string Input;
            do
            {
                Console.WriteLine("\n#The Menu:");
                    Console.WriteLine("\t1 - Enter/change your user data\n\t2 - Product overview\n\t3 - show shopping cart\n\n Please Enter a number:   ");
                    Input = Console.ReadLine();
                    int numberInput = int.Parse(Input);
                    success = Enum.IsDefined(typeof(Menu), numberInput);

                    if (!success) throw new ArgumentException("\nError, incorrect Input - Try again!\n");
                 
            } while (!success);

            return Input;
        }

        public static string MenuNaviagtion(string input, Customer user, Shop LegoShop)
        {
            int i = int.Parse(input);//delete

            switch (i)
            {
                case 1:
                    EnterChangeUser(user);
                    

                    break;
                case 2:
                    ProductOverview(user, LegoShop);

                    break;

                case 3:

                    break;

                default:
                    throw new ArgumentException("\nError, incorrect Input");

            }

            return "0";
        }

        static public void EnterChangeUser(Customer user)
        {
            string Input;
            bool success = false;
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

        public static void ProductOverview(Customer user, Shop LegoShop) //user Übergabe sinnvoll??
        {
            //produkte werden über klasse shop angelegt -> Oben im Main
            //Aufruf Produkte über klasse shop.product

            bool success = false;
            do
            {
                Console.WriteLine("\nWelcome to the Product Overview!");


                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\tnumber\t\ttitle\t\ttype\t\tprice\t\tin stock");
                Console.BackgroundColor = ConsoleColor.Black;

                int NumberOfProducts = LegoShop.ShopList.Length;
                for (int i = 0; i < LegoShop.ShopList.Length; i++)
                {
                    Console.WriteLine(LegoShop.ShopList[i]);
                }

                Console.WriteLine("When you have decided on a product, enter the number below\n");

                int[] articleNumbers = InputArticleNumbersShop();





            } while (!success);



            //produkt wird ausgewählt -> klasse cart greift auf shop.product zu und übernimmt es 
            // -> muss aber gleicheitig die Stückzahl veringern




        }

        private static int[] InputArticleNumbersShop()
        {
            string input = Console.ReadLine();

            //hier sollen die eingaben vom user auf echtheit überprüft werden, also ob die artikel nummern existieren
            //diese sollen in ein array gespeichert werden
            //die eingabe erfolgt so lange bis der user ein key-buchstaben eingibt


            int[] array = new int[] { 1, 2, 3 };

           return array;
        }



    }
}