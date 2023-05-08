using System;
using System.Data.SqlClient;

namespace PokedexBeta.src.models
{
    public class Pokedex
    {
        static public GrowthRate[] allGrowthRates;
        static public PokemonType[] allTypes;
        static public Pokemon[] allPokemon;

		protected void Load_Growth_Rate()
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand countCmd = new SqlCommand("select count(*) from growth_rate", conn);
			SqlDataReader countRdr = countCmd.ExecuteReader();

			if (countRdr.HasRows) {
				countRdr.Read();
				int count = countRdr.GetInt32(0);

				countRdr.Close();
				countCmd.Dispose();

				SqlCommand cmd = new SqlCommand("select * from growth_rate", conn);
				SqlDataReader rdr = cmd.ExecuteReader();

				if (rdr.HasRows) {
					allGrowthRates = new GrowthRate[count];
					for (int i = 0; i < count; i++) {
						rdr.Read();
						allGrowthRates[i] = new GrowthRate(rdr.GetString(1), rdr.GetString(2));
					}
				}

				rdr.Close();
				cmd.Dispose();
			}

			conn.Close();
		}
		protected void Load_Types()
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand countCmd = new SqlCommand("select count(*) from types", conn);
			SqlDataReader countRdr = countCmd.ExecuteReader();

			countRdr.Read();
			int count = countRdr.GetInt32(0);

			countRdr.Close();
			countCmd.Dispose();

			SqlCommand cmd = new SqlCommand("select * from types", conn);
			SqlDataReader rdr = cmd.ExecuteReader();

			if (rdr.HasRows) {
				allTypes = new PokemonType[count + 1];
				for (int i = 0; i < count; i++) {
					rdr.Read();
					allTypes[i] = new PokemonType(rdr.GetString(1));
				}
			}

			allTypes[count] = new PokemonType("null");

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void Load_Pokemon()
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand countCmd = new SqlCommand("select count(*) from pokemon", conn);
			SqlDataReader countRdr = countCmd.ExecuteReader();

			countRdr.Read();
			int count = countRdr.GetInt32(0);

			countRdr.Close();
			countCmd.Dispose();

			SqlCommand cmd = new SqlCommand("select * from pokemon", conn);
			SqlDataReader rdr = cmd.ExecuteReader();

			if (rdr.HasRows) {
				allPokemon = new Pokemon[count];
				for (int i = 0; i < count; i++) {
					rdr.Read();
					allPokemon[i] = new Pokemon(rdr.GetInt32(0), rdr.GetString(1), (float)rdr.GetDouble(2),
						(float)rdr.GetDouble(3), allTypes[rdr.GetInt32(4) - 1], rdr.IsDBNull(5) ? allTypes[allTypes.Length - 1] : allTypes[rdr.GetInt32(5) - 1],
						rdr.GetString(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9),
						rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(12), rdr.IsDBNull(13) ? "null" : rdr.GetString(13),
						allGrowthRates[rdr.GetInt32(14) - 1], rdr.GetInt32(15), rdr.IsDBNull(16) ? -1 : rdr.GetInt32(16),
						rdr.IsDBNull(17) ? -1 : rdr.GetInt32(17), rdr.IsDBNull(18) ? -1 : rdr.GetInt32(18), rdr.GetString(19), rdr.GetBoolean(21),
						rdr.GetString(22)
					);
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		public void Load_All_Data()
        {
			Load_Growth_Rate();
			Load_Types();
			Load_Pokemon();
        }
		static public Pokemon getPokemonByID(int id)
        {
			if (allPokemon[id - 1].pokedexID == id)
				return allPokemon[id - 1];
			else {
				foreach (Pokemon pokemon in allPokemon) {
					if (pokemon.pokedexID == id)
						return pokemon;
                }
            }
			return null;
        }
	}
}