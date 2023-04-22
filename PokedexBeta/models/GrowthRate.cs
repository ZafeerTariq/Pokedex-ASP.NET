using System;

namespace PokedexBeta.modals
{
    public class GrowthRate
    {
        private String name;
        private String formula;

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