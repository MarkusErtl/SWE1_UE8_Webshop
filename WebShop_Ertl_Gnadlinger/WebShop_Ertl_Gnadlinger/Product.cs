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
        private string _title;
        private string _type;
        private double _price;
        private int _numberOfPieces;


        // 001 Laptop Elektrogerät 299,99€ 20Stk.

        //---------constructor-----------

        public Product(int artikelNumber, string title, string type, double price, int numberOfPieces)
        {
            _artikelNumber = artikelNumber;
            _title = title;
            _type = type;
            _price = price;
            _numberOfPieces = numberOfPieces;

        }


        //----------properties----------

        public int ArtikleNumber
        {
            get { return _artikelNumber; }
        }
        public string Title
        {
            get { return _title; }
        }
        public string Type
        {
            get { return _type; }
        }
        public double Price
        {
            get { return _price; }

        }
        public int NumberOfPieces
        {
            get { return _numberOfPieces; }

            set
            {
                _numberOfPieces = value;
            }
        }
        //----------methods------------

        public override string ToString()
        {
           
           return "\t" +_artikelNumber+ "\t\t" +_title+ "\t\t" +_type+ "\t\t" +_price+ "\t\t\t" + _numberOfPieces;
        }




    }
}
