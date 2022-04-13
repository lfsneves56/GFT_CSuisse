using System;
using System.Collections.Generic;
using System.Text;

namespace BanksPortfolio.Objects
{
    public class Person
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Luis Neves";
        public string Email { get; } = "lfsneves56@gmail.com";
        public string Phone { get; } = "+5524999145757";
        public bool Exposed { get; } = true;
    }
}
