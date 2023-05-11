using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexBeta.src.models
{
    public class Ability
    {
        public string name;
        public string description;

        public Ability(string name, string des)
        {
            this.name = name;
            this.description = des;
        }
    }
}