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


        // public static Customer User1 = new Customer(null, null);

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


            Customer User = new Customer(null, null);    //enters a default customer
            string menuInput;

            Console.WriteLine("*************************\n*Welcome to the Webshop!*\n*************************");

            Console.WriteLine("\nWhat do you want to do?\n");

            try
            {
                menuInput = MenuInput();      //gets the Input from the user 1,2 or 3             
                MenuNaviagtion(menuInput, User);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
            }


        }

        public static string MenuInput()
        {
            bool success = false;
            string Input;
            do
            {
                Console.WriteLine("\t1 - Enter/change your user data\n\t2 - Product overview\n\t3 - show shopping cart\n\n Please Enter a number:   ");
                Input = Console.ReadLine();
                success = Enum.IsDefined(typeof(Menu), Input);

                if (!success) throw new ArgumentException("\nError, incorrect Input - Try again!\n");

            } while (!success);

            return Input;
        }

        public static string MenuNaviagtion(string input, Customer user)
        {
            int i = int.Parse(input);

            switch (i)
            {
                case 1:
                    EnterChangeUser(user);

                    break;
                case 2:

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
                        string[] addressArray = new string[3]; //initialises an array if none exists yet
                        addressArray = AddressInput();
                        
                        user.InputAddress(addressArray);   // input verification in the class, method "InputAddress"
                    }
                    else
                    {
                        string[] NewaddressArray = new string[3];

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

            MenuInput();
        }

        public static string[] AddressInput()       //only for the Input of the address, input verification in the class
        {
            string[] Input = new string[3];
                        
                Console.WriteLine("\nPlease Enter your new address in the following form:");
                Console.WriteLine("\n-1 Enter your street: ");
                Input[0] = Console.ReadLine();
                Console.WriteLine("\n-2 Enter your house number: ");
                Input[1] = Console.ReadLine();
                Console.WriteLine("\n-3 Enter your postler number: ");
                Input[2] = Console.ReadLine();
                Console.WriteLine("\n-4 Enter your City: ");
                Input[3] = Console.ReadLine();

            return Input;
        }






    }
}