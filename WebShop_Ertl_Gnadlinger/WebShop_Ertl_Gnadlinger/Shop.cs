using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Ertl_Gnadlinger
{
    internal class Shop
    {
        //---- member variables-----------

        private Product[] _shopList = new Product[9];

        //---- properties-----

        public Product[] ShopList
        { 
            get { return _shopList; } 
        }

        //----- constructor-----
        public Shop()
        {
          
        }



        //-----methods---------
        public void refill()
        {

            // 001 Laptop Elektrogerät 299,99€ 20Stk.
            // int string string       double  int 

            //Product[] _shopList = new Product[9];

            
            Product item1 = new Product(101, "Lego1", "Ideas", 09.99, 10);
            Product item2 = new Product(102, "Lego2", "Marvel", 14.99, 05);
            Product item3 = new Product(103, "Lego3", "City", 16.99, 15);
            //..... bis 10 items oder so ...
            
            _shopList[0] = item1;
            _shopList[1] = item2;
            _shopList[2] = item3;


        }

        


    }
}
