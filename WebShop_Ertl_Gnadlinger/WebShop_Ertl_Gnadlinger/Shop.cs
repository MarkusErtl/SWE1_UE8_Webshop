﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Ertl_Gnadlinger
{
    internal class Shop
    {
        //---- member variables-----------

        private Product[] _shopList = new Product[10];

        //---- properties-----

        public Product[] ShopList
        { 
            get { return _shopList; } 

            set { _shopList = value; }
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
            Product item4 = new Product(104, "Lego4", "StarWar",33.99, 12);
            Product item5 = new Product(105, "Lego5", "Creator", 99.99, 18);
            Product item6 = new Product(106, "Lego6", "Polybag", 04.99, 20);
            Product item7 = new Product(107, "Lego7", "Duplo", 50.99, 06);
            Product item8 = new Product(108, "Lego8", "Disney", 77.99, 19);
            Product item9 = new Product(109, "Lego9", "Friends", 60.99, 12);
            Product item10 = new Product(110, "Lego10", "Comics", 45.99, 14);
            //..... bis 10 items oder so ...

            _shopList[0] = item1;
            _shopList[1] = item2;
            _shopList[2] = item3;
            _shopList[3] = item4;
            _shopList[4] = item5;
            _shopList[5] = item6; 
            _shopList[6] = item7;
            _shopList[7] = item8;
            _shopList[8] = item9;
            _shopList[9] = item10;
            


        }

        


    }
}
