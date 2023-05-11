using System;

namespace PokedexBeta.src.models
{
    public class GrowthRate
    {
        public String name;
        public String formula;

        public GrowthRate(String name, String formula)
        {
            this.name = name;
            this.formula = formula;
        }

        public void print()
        {
            Console.WriteLine("name = " + this.name + " formula = " + this.formula);
        }
    }
}