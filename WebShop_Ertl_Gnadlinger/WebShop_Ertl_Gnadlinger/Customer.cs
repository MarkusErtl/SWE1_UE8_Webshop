using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Ertl_Gnadlinger
{
    internal class Customer
    {

        //----------member variables-----
        string _name;
        string[] _address;


        //---------default constructor---------

        public Customer(string name, string[] address)
        {
            _name = null;
            _address = null;
        }



        //--------properties---------------

        public string Name
        {
            get { return _name; }
        }

        public string[] Address
        {
            get { return _address; }
        }


        //---------methods------------

        public void InputName(string nameInput)
        {
            bool success = false;

            do
            {
                //abfrage Namen
                //korrekte eingabe?
                    //Nein exeption


            } while (success);  //gehört ein !success

            _name = nameInput;

        }

        public void InputAddress(string[] addressInput)
        {
            //gets Address from main like a = { Street, house number, postler number, city}
           // array kommt als string
           //komplette überprüfung, jedes Element
           //grtfjzrd- zacher Hund


            _address = addressInput;
        }



    }
}
