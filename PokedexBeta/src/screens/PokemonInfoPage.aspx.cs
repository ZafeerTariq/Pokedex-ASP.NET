using System;
using System.Collections.Generic;
using PokedexBeta.src.models;
using System.Data.SqlClient;

namespace PokedexBeta.src.screens
{
    public partial class info : System.Web.UI.Page
    {
		protected Pokemon localPokemon;
		protected List<Pokemon> evolution;
		protected bool isFav = false;
		protected void Page_Load(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
			localPokemon = Pokedex.getPokemonByID(id);
			localPokemon.abilities = Pokedex.getAbilitiesForPokemon(localPokemon.id);
			localPokemon.moves = Pokedex.getMovesForPokemon(localPokemon.id);

			if (Pokedex.loggedIn) {

				SqlConnection conn = new SqlConnection(
					"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security = True"
				);
				conn.Open();

				SqlCommand cmd = new SqlCommand("select pokemon_id from favourite_pokemon where username = @username and pokemon_id = @id", conn);
				SqlParameter name = new SqlParameter();
				name.ParameterName = "@username";
				name.Value = PokedexUser.username;
				cmd.Parameters.Add(name);

				SqlParameter idParam = new SqlParameter();
				idParam.ParameterName = "@id";
				idParam.Value = localPokemon.id;
				cmd.Parameters.Add(idParam);

				SqlDataReader rdr = cmd.ExecuteReader();

				if (rdr.HasRows) {
					isFav = true;
				}

				rdr.Close();
				cmd.Dispose();
				conn.Close();
			}

			//MakeEvolutionChain();
		}
		protected void favouriteButtonPressed(object sender, EventArgs e)
		{
			if (Pokedex.loggedIn) {
				SqlConnection conn = new SqlConnection(
					"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
				);
				conn.Open();

				SqlCommand cmd = new SqlCommand("insert into favourite_pokemon values (@username, @pokemon_id);", conn);

				SqlParameter name = new SqlParameter();
				name.ParameterName = "@username";
				name.Value = PokedexUser.username;
				
				SqlParameter pokemonID = new SqlParameter();
				pokemonID.ParameterName = "@pokemon_id";
				pokemonID.Value = localPokemon.id;

				cmd.Parameters.Add(name);
				cmd.Parameters.Add(pokemonID);

				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();

				favouriteButton.Text = "Added";
            }
		}
		protected void dislikeButtonPressed(object sender, EventArgs e)
		{
			if (Pokedex.loggedIn) {
				SqlConnection conn = new SqlConnection(
					"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
				);
				conn.Open();

				SqlCommand cmd = new SqlCommand("delete from favourite_pokemon where username = @username and pokemon_id = @id", conn);

				SqlParameter name = new SqlParameter();
				name.ParameterName = "@username";
				name.Value = PokedexUser.username;

				SqlParameter pokemonID = new SqlParameter();
				pokemonID.ParameterName = "@id";
				pokemonID.Value = localPokemon.id;

				cmd.Parameters.Add(name);
				cmd.Parameters.Add(pokemonID);

				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();

				dislikeButton.Text = "Removed";
			}
		}
		protected void Logout_Click(object sender, EventArgs e)
		{
			Pokedex.loggedIn = false;
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