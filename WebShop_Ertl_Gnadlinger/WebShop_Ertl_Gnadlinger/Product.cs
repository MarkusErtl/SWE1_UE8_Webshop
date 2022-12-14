using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Ertl_Gnadlinger
{
    internal class Product
    {
        //---------membervariable---------

        private int _artikelNumber;
        private double _price;
        private string _title;



        //---------constructor-----------

        public Product (int artikelNumber, double price, string title)
        {
            artikelNumber = _artikelNumber;
            price = _artikelNumber;
            title = _title;


        }


        //----------properties----------

        public int ArtikleNumber
        {
            get { return _artikelNumber; }

        }

        public double Price
        {
            get { return _price; }
        }

        public string Title
        {
            get { return _title; }
        }

    }
}
