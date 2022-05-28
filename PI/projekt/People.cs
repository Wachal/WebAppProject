using System;
using System.Net;

namespace projekt
{
    class People
    {

        public People(string _firstName, string _lastName, string _phoneNumber){
            FirstName = _firstName;
            LastName = _lastName;
            PhoneNumber = _phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    }
}


