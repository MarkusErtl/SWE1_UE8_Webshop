using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Ertl_Gnadlinger
{
    internal class Cart
    {
        //----------member variables--------------
        List<Product> products;



        //----------properties----------

        //public Product Products
        //{
        //    get { return products; }
        //}

        //-----constructor---------
        public Cart()
        { }


        //-----------methods--------------

        //methode :
        //es wird die artikelnummer übergeben z.b. 003
        //es soll das dazugehörige objekte der klasse Product zurück gegeben werden

        public void getProduct( List<string> artikleNumbers, Shop LegoShop)
        {
            Product[] ItemList = LegoShop.ShopList;
            int counter = ItemList.Length;

            for (int i = 0; i < counter; i++)
            {
                Product CurrentItem = ItemList[i];
                int ShopArticleNumber = CurrentItem.ArtikleNumber;

                foreach (var item in artikleNumbers)
                {
                  //  if ( item == ShopArticleNumber) //datentypen nicht gleich


                }

                
                
            }
            



            //2 for schleifen inereinander die äußere greift auf die items der ShopListe zu,
            // die innere vergleicht die artikelnummern mit den eingegebenen artikelnummern und zieht bei treffer das jeweilige
            // product in die classe Cart



            
        }



        //public string AddProduct(Product)
        //{
        //    //Adds a new Product

        //}






        public void clear()
        {
            //clears the shopping cart


        }

        public double CalculatePrice()
        {


            return 0;
        }



    }
}
