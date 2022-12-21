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
            //gets Address from main like a = { Street, house number, post code, city}
            // array kommt als string
            //komplette überprüfung, jedes Element
            


            if (addressInput[0].All(char.IsLetter))
            { }
            else
            {
                throw new ArgumentException("Your street should only incloude letters");
            }
           

            if (addressInput[1].All(char.IsLetterOrDigit))
            { }
            else
            {
                throw new ArgumentException("Your house number should only incloude numbers or letters");
            }

            if (addressInput[2].All(char.IsNumber))
            { }
            else
            {
                throw new ArgumentException("Your street should only incloude numbers");
            }

            if (addressInput[3].All(char.IsLetter))
            { }
            else
            {
                throw new ArgumentException("Your street should only incloude letters");
            }

            _address = addressInput;
        }



    }
}
