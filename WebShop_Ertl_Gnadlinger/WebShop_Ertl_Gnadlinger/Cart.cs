using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Ertl_Gnadlinger
{
    internal class Cart
    {
        //----------member variables--------------
        List<Product> CartList = new List<Product>();



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
        //2 for schleifen inereinander die äußere greift auf die items der ShopListe zu,
        // die innere vergleicht die artikelnummern mit den eingegebenen artikelnummern und zieht bei treffer das jeweilige
        // product in die classe Cart


        public void getProduct( List<int> artikleNumbers, Shop LegoShop)
        {
            Product[] ItemList = LegoShop.ShopList;         //shoplist with all items
            int counter = ItemList.Length;                  //counter for number of items

            for (int i = 0; i < counter; i++)
            {
                Product CurrentItem = ItemList[i];                   //picks one item out of the ShopList
                int ShopArticleNumber = CurrentItem.ArtikleNumber;   //picks the article-number out of the current item

                foreach (var item in artikleNumbers)
                {

                    for (int j = 0; j <counter ; j++)
                    {
                        if (item == ItemList[j].ArtikleNumber)           //query if input User is equal to an article number of the current item
                        {
                            CartList.Add(CurrentItem);
                        }

                    }                

                }
                
            }
            



            
            


            
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
