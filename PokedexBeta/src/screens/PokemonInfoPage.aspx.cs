using System;
using System.Collections.Generic;
using PokedexBeta.src.models;

namespace PokedexBeta.src.screens
{
    public partial class info : System.Web.UI.Page
    {
		protected Pokemon localPokemon;
		protected List<Pokemon> evolution;
		protected void Page_Load(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
			localPokemon = Pokedex.getPokemonByID(id);
			//MakeEvolutionChain();
		}
		protected void MakeEvolutionChain()
        {
			evolution = new List<Pokemon>();
			getEvolvesFromList(localPokemon, ref evolution);
			getEvolvesToList(localPokemon, ref evolution);
        }
		private void getEvolvesFromList(Pokemon curr, ref List<Pokemon> evolution)
        {
			for (int i = 0; i < curr.evolvesFrom.Count; i++) {
				getEvolvesFromList(curr.evolvesFrom[i], ref evolution);
            }
			evolution.Add(curr);
		}
		private void getEvolvesToList(Pokemon curr, ref List<Pokemon> evolution)
        {
			evolution.Add(curr);
			for (int i = 0; i < curr.evolvesTo.Count; i++) {
				getEvolvesToList(curr.evolvesTo[i], ref evolution);
			}
		}
	}
}