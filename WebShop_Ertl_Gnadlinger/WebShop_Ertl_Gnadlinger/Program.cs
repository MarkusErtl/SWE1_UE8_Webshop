﻿namespace WebShop_Ertl_Gnadlinger
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


            Customer person = new Customer(null,null);      //enters a default customer
            string menuInput;

            Console.WriteLine("*************************\n*Welcome to the Webshop!*\n*************************");

            Console.WriteLine("\nWhat do you want to do?\n");

            try
            {
                menuInput = MenuInput();      //gets the Input from the user 1,2 or 3             
                MenuNaviagtion(menuInput);
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
            do {
                Console.WriteLine("\t1 - Enter/change your user data\n\t2 - Product overview\n\t3 - show shopping cart\n\n Please Enter a number:   ");
                Input = Console.ReadLine();
                success = Enum.IsDefined(typeof(Menu), Input);

                if (!success) throw new ArgumentException("\nError, incorrect Input - Try again!\n");

            } while (!success);

            return Input;
        }

        public static string MenuNaviagtion(string input)
        {
            int i = int.Parse(input);

            switch (i)
            {
                case 1:
                    EnterChangeUser();

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

        static public void EnterChangeUser();
        {
        if(Customer.Name == null)
            {
            

            }else{



            }

        





    }
}