using System.Data.SqlClient;
using System.Collections.Generic;

namespace PokedexBeta.src.models
{
	public class Pokedex
	{
		static public GrowthRate[] allGrowthRates;
		static public PokemonType[] allTypes;
		static public Move[] allMoves;
		static public Pokemon[] allPokemon;
		static public Ability[] allAbilities;

		static public bool loggedIn;

		public Pokedex()
        {
			loggedIn = false;
        }

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
				allTypes = new PokemonType[count];
				for (int i = 0; i < count; i++) {
					rdr.Read();
					allTypes[i] = new PokemonType(rdr.GetString(1));
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void Load_Moves()
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand countCmd = new SqlCommand("select count(*) from moves", conn);
			SqlDataReader countRdr = countCmd.ExecuteReader();

			countRdr.Read();
			int count = countRdr.GetInt32(0);

			countRdr.Close();
			countCmd.Dispose();

			SqlCommand cmd = new SqlCommand("select * from moves", conn);
			SqlDataReader rdr = cmd.ExecuteReader();

			if (rdr.HasRows) {
				allMoves = new Move[count];
				for (int i = 0; i < count; i++) {
					rdr.Read();

					int? effectChance, power, accuracy;
					if (rdr.IsDBNull(4))
						effectChance = null;
					else
						effectChance = rdr.GetInt32(4);

					if (rdr.IsDBNull(7))
						power = null;
					else
						power = rdr.GetInt32(7);

					if (rdr.IsDBNull(3))
						accuracy = null;
					else
						accuracy = rdr.GetInt32(3);
					

					allMoves[i] = new Move(allTypes[rdr.GetInt32(1) - 1], rdr.GetString(2), accuracy,
						effectChance, rdr.GetInt32(5), rdr.GetInt32(6), power, rdr.GetString(8),
						rdr.IsDBNull(9) ? null : rdr.GetString(9)
					);
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void Load_Pokemon()
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS;" +
				"Initial Catalog = pokedexTesting;" +
				"Integrated Security = True;" +
				"MultipleActiveResultSets = true"
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

					//List<PokemonAbility> abilities = getAbilitiesForPokemon(rdr.GetInt32(0), conn);
					//List<PokemonMove> moves = getMovesForPokemon(rdr.GetInt32(0), conn);

					allPokemon[i] = new Pokemon(rdr.GetInt32(0), rdr.GetInt32(20), rdr.GetString(1), (float)rdr.GetDouble(2),
						(float)rdr.GetDouble(3), allTypes[rdr.GetInt32(4) - 1], rdr.IsDBNull(5) ? null : allTypes[rdr.GetInt32(5) - 1]/*allTypes[allTypes.Length - 1] : allTypes[rdr.GetInt32(5) - 1]*/,
						rdr.GetString(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9),
						rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(12), rdr.IsDBNull(13) ? null : rdr.GetString(13),
						allGrowthRates[rdr.GetInt32(14) - 1], rdr.GetInt32(15), rdr.IsDBNull(16) ? -1 : rdr.GetInt32(16),
						rdr.IsDBNull(17) ? -1 : rdr.GetInt32(17), rdr.IsDBNull(18) ? -1 : rdr.GetInt32(18), rdr.GetString(19), rdr.GetBoolean(21),
						rdr.GetString(22), null, null
					);
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void Load_Abilities()
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand countCmd = new SqlCommand("select count(*) from abilities", conn);
			SqlDataReader countRdr = countCmd.ExecuteReader();

			countRdr.Read();
			int count = countRdr.GetInt32(0);

			countRdr.Close();
			countCmd.Dispose();

			SqlCommand cmd = new SqlCommand("select * from abilities", conn);
			SqlDataReader rdr = cmd.ExecuteReader();

			if (rdr.HasRows) {
				allAbilities = new Ability[count];
				for (int i = 0; i < count; i++) {
					rdr.Read();
					allAbilities[i] = new Ability(rdr.GetString(1), rdr.GetString(2));
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void Add_Evolution_Chain()
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			for (int i = 0; i < 1010; i++) {
				Pokemon current = getPokemonByID(i + 1);

				SqlCommand cmd = new SqlCommand("select * from evolution_chain where from_id = @fromid", conn);
				SqlParameter param = new SqlParameter();
				param.ParameterName = "@fromid";
				param.Value = i + 1;
				cmd.Parameters.Add(param);
				SqlDataReader rdr = cmd.ExecuteReader();

				List<Pokemon> evolvesTo = new List<Pokemon>();
				List<string> ToTriggers = new List<string>();
				while (rdr.Read()) {
					evolvesTo.Add(getPokemonByID(rdr.GetInt32(2)));
					ToTriggers.Add(rdr.GetString(3));
				}
				current.SetEvolvesTo(evolvesTo, ToTriggers);

				rdr.Close();
				cmd.Dispose();

				cmd = new SqlCommand("select * from evolution_chain where to_id = @toid", conn);
				param = new SqlParameter();
				param.ParameterName = "@toid";
				param.Value = i + 1;
				cmd.Parameters.Add(param);
				rdr = cmd.ExecuteReader();

				List<Pokemon> evolvesFrom = new List<Pokemon>();
				List<string> fromTriggers = new List<string>();
				while(rdr.Read()) {
					evolvesFrom.Add(getPokemonByID(rdr.GetInt32(1)));
					fromTriggers.Add(rdr.GetString(3));
                }
				current.SetEvolvesFrom(evolvesFrom, fromTriggers);

				rdr.Close();
				cmd.Dispose();
			}

			conn.Close();
		}

		static public List<PokemonAbility> getAbilitiesForPokemon(int id)
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS;" +
				"Initial Catalog = pokedexTesting;" +
				"Integrated Security = True;" +
				"MultipleActiveResultSets = true"
			);
			conn.Open();

			SqlCommand abilityCmd = new SqlCommand("select * from pokemon_abilities where pokemon_id = @id", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@id";
			param.Value = id;

			abilityCmd.Parameters.Add(param);

			SqlDataReader abilityRdr = abilityCmd.ExecuteReader();

			List<PokemonAbility> abilities = new List<PokemonAbility>();
			while (abilityRdr.Read()) {
				int abilityId = abilityRdr.GetInt32(2);

				SqlCommand abilityNameCmd = new SqlCommand("select name from abilities where id = @abilityId", conn);
				SqlParameter nameParam = new SqlParameter();
				nameParam.ParameterName = "@abilityId";
				nameParam.Value = abilityId;

				abilityNameCmd.Parameters.Add(nameParam);

				SqlDataReader nameRdr = abilityNameCmd.ExecuteReader();

				nameRdr.Read();
				string name = nameRdr.GetString(0);

				PokemonAbility temp = new PokemonAbility(getAbilityByName(name), abilityRdr.GetBoolean(3));
				abilities.Add(temp);

				nameRdr.Close();
				abilityNameCmd.Dispose();
			}

			abilityRdr.Close();
			abilityCmd.Dispose();
			conn.Close();
			return abilities;
		}
		static public List<PokemonMove> getMovesForPokemon(int id)
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS;" +
				"Initial Catalog = pokedexTesting;" +
				"Integrated Security = True;" +
				"MultipleActiveResultSets = true"
			);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from moves_learnt where pokemon_id = @id", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@id";
			param.Value = id;
			cmd.Parameters.Add(param);
			SqlDataReader rdr = cmd.ExecuteReader();

			List<PokemonMove> moves = new List<PokemonMove>();
			while (rdr.Read()) {
				int moveId = rdr.GetInt32(2);

				SqlCommand moveNameCmd = new SqlCommand("select name from moves where id = @moveId", conn);
				SqlParameter nameParam = new SqlParameter();
				nameParam.ParameterName = "@moveId";
				nameParam.Value = moveId;
				moveNameCmd.Parameters.Add(nameParam);
				SqlDataReader nameRdr = moveNameCmd.ExecuteReader();

				nameRdr.Read();
				string name = nameRdr.GetString(0);

				int? level;
				if (rdr.IsDBNull(4))
					level = null;
				else
					level = rdr.GetInt32(4);

				PokemonMove temp = new PokemonMove(getMoveByName(name), rdr.GetString(3), level);
				moves.Add(temp);

				nameRdr.Close();
				moveNameCmd.Dispose();
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			return moves;
        }

		public void Load_All_Data()
		{
			Load_Growth_Rate();
			Load_Types();
			Load_Moves();
			Load_Abilities();
			Load_Pokemon();
			//Add_Evolution_Chain();
		}
		
		static public Pokemon getPokemonByID(int id)
		{
			if (id < 10000 && allPokemon[id - 1].pokedexID == id)
				return allPokemon[id - 1];
			else {
				for (int i = 1010; i < allPokemon.Length; i++) {
					if (allPokemon[i].id == id)
						return allPokemon[i];
				}
			}
			return null;
		}
		static public PokemonType getTypeByName(string name)
		{
			for (int i = 0; i < allTypes.Length; i++) {
				if (name == allTypes[i].name) {
					return allTypes[i];
				}
			}
			return null;
		}
		static public Ability getAbilityByName(string name)
        {
			for (int i = 0; i < allAbilities.Length; i++) {
				if (allAbilities[i].name == name) {
					return allAbilities[i];
                }
            }
			return null;
        }
		static public Move getMoveByName(string name)
        {
			for (int i = 0; i < allMoves.Length; i++) {
				if (allMoves[i].name == name) {
					return allMoves[i];
				}
			}
			return null;
		}
	}
}