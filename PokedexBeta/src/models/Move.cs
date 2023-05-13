using System;

namespace PokedexBeta.src.models
{
    public class Move
    {
        public PokemonType type;
        public string name;
        public int? accuracy;
        public int? effectChance;
        public int pp;
        public int priority;
        public int? power;
        public string description;
        public string effectDescription;

        public Move(PokemonType type, string name, int? acc, int? eff, int pp, int priority, int? pow, string des, string effDes)
        {
            this.type = type;
            this.name = name;
            this.accuracy = acc;
            this.effectChance = eff;
            this.pp = pp;
            this.priority = priority;
            this.power = pow;
            this.description = des;
            this.effectDescription = effDes;
        }
    }
}