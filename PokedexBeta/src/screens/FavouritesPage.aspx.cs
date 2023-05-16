using System;
using System.Collections.Generic;
using PokedexBeta.src.models;
using System.Data.SqlClient;

namespace PokedexBeta.src.screens
{
	public partial class FavouritesPage : System.Web.UI.Page
	{
		protected List<Pokemon> pokemon;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Pokedex.loggedIn) {
				pokemon = new List<Pokemon>();

				SqlConnection conn = new SqlConnection(
					"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
				);
				conn.Open();

				SqlCommand cmd = new SqlCommand("select pokemon_id from favourite_pokemon where username = @username", conn);
				SqlParameter param = new SqlParameter();
				param.ParameterName = "@username";
				param.Value = PokedexUser.username;
				cmd.Parameters.Add(param);

				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read()) {
					pokemon.Add(Pokedex.getPokemonByID(rdr.GetInt32(0)));
				}
			}
		}
		protected void Logout_Click(object sender, EventArgs e)
		{
			Pokedex.loggedIn = false;
		}
	}
}