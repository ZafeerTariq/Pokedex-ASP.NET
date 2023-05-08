using System;
using System.Web;
using PokedexBeta.src.models;
using System.Text.Json;

namespace PokedexBeta.src.components
{
	public partial class PokmonCard : System.Web.UI.Page
	{
		protected Pokemon localPokemon;
		protected void Page_Load(object sender, EventArgs e)
		{
			localPokemon = HttpContext.Current.Items["localPokemon"] as Pokemon;
			imgBox.Src = localPokemon.imageURL;
		}
	}
}