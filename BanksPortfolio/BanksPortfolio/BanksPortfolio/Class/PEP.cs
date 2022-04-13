using BanksPortfolio.Interface;
using BanksPortfolio.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanksPortfolio.Class
{
    public class PEP
    {
        private int _Id;
        int Id { get => _Id; set => _Id = value; }
        public Person PersonExposed { get; set; }
    }
}
