using System;
using System.Net;

namespace projekt
{
    class CardEntrie
    {

        public CardEntrie(string _cardNumber, bool _isWorking){
            CardNumber = _cardNumber;
            IsWorking = _isWorking;
        }

        public string CardNumber { get; set; }
        public bool IsWorking {get; set;}

    }
}


