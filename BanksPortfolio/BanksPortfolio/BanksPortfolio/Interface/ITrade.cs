using System;
using System.Collections.Generic;
using System.Text;

namespace BanksPortfolio.Interface
{
    public interface ITrade : IPEP
    {
        double Value { get; set; } // indicates the transaction amount in dollars
        string ClientSector { get; set; } //indicates the client´s sector which can be "Public" or "Private" 
        DateTime NextPaymentDate { get; set; } //indicates when the next payment from the client to the bank is expected
        bool IsPoliticalExposed { get; set; }
    }
}
