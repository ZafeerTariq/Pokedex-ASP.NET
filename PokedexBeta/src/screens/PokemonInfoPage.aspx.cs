using System;
using System.Web;
using System.Text.Json;
using PokedexBeta.src.models;

namespace PokedexBeta.src.screens
{
    public partial class info : System.Web.UI.Page
    {
		protected Pokemon localPokemon;
		protected void Page_Load(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
			localPokemon = Pokedex.getPokemonByID(id);
		}
	}
}