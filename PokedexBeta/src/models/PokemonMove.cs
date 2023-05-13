using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexBeta.src.models
{
    public class PokemonMove
    {
        public Move move;
        public string learnMethod;
        public int? learnAtLevel;

        public PokemonMove(Move move, string learn, int? learntAt)
        {
            this.move = move;
            this.learnMethod = learn;
            this.learnAtLevel = learntAt;
        }
    }
}