using BanksPortfolio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanksPortfolio.Objects
{
    public class Trade : ITrade
    {
        public Trade()
        {
            _Trades = new List<Trade>();
        }

        List<Trade> _Trades;
        public List<Trade> Trades { get; set; }
        double _Value;
        string _ClientSector;
        DateTime _NextPaymentDate;
        eCategories _Category;
        bool _IsPoliticalExposed;

        public double Value { get => _Value; set => _Value = value; }
        public string ClientSector { get => _ClientSector; set => _ClientSector = value; }
        public DateTime NextPaymentDate { get => _NextPaymentDate; set => _NextPaymentDate = value; }
        public eCategories Category { get => _Category; set => _Category = value; }
        public bool IsPoliticalExposed { get => _IsPoliticalExposed; set => _IsPoliticalExposed = value; }

        public Person GetPerson(int id)
        {
            return new Person();
        }
    }
}
