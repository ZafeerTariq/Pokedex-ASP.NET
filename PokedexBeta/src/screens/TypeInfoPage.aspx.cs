using System;
using PokedexBeta.src.models;

namespace PokedexBeta.src.screens
{
	public partial class TypeInfoPage : System.Web.UI.Page
	{
		protected PokemonType localType;
		protected void Page_Load(object sender, EventArgs e)
		{
			string name = Request.QueryString["name"];
			localType = Pokedex.getTypeByName(name);
			
		}
	}
}