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
        List<Product> _cartList = new List<Product>();



        //----------properties----------

        public List<Product> CartList           //propertie to get the User Input of items he/she/it wants
        {
            get { return _cartList; }
        }

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


        public void getProduct(List<Tuple<int, int>> artikleNumbers, Shop LegoShop)
        {
            //überarbeitung - List besteht jetzt aus einem Tupel (artikelnummer und Stückzahl)


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
                            _cartList.Add(CurrentItem);              //List with all item but unsorted
                        }
                        //blablabla
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
