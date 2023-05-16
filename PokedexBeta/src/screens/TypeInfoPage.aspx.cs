using System;
using PokedexBeta.src.models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PokedexBeta.src.screens
{
	public partial class TypeInfoPage : System.Web.UI.Page
	{
		protected PokemonType localType;
		protected int numberOfPokemon;
		protected int numberOfMoves;

		protected List<PokemonType> superEffectiveAttack;
		protected List<PokemonType> notVeryEffectiveAttack;
		protected List<PokemonType> noEffectAttack;
		protected List<PokemonType> superEffectiveDefence;
		protected List<PokemonType> notVeryEffectiveDefence;
		protected List<PokemonType> noEffectDefence;

		protected void Page_Load(object sender, EventArgs e)
		{
			string name = Request.QueryString["name"];
			localType = Pokedex.getTypeByName(name);
			
			LoadNumberOfPokemon(name);
			LoadNumberOfMoves(name);

			superEffectiveAttack = LoadAttackTypeRelations(name, 2);
			notVeryEffectiveAttack = LoadAttackTypeRelations(name, 0.5f);
			noEffectAttack = LoadAttackTypeRelations(name, 0);

			superEffectiveDefence = LoadDefenceTypeRelations(name, 2);
			notVeryEffectiveDefence = LoadDefenceTypeRelations(name, 0.5f);
			noEffectDefence = LoadDefenceTypeRelations(name, 0);
		}
		protected void LoadNumberOfPokemon(string typeName)
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select id from types where name = @name", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@name";
			param.Value = typeName;
			cmd.Parameters.Add(param);

			SqlDataReader rdr = cmd.ExecuteReader();
			rdr.Read();
			int id = rdr.GetInt32(0);

			rdr.Close();
			cmd.Dispose();

			cmd = new SqlCommand("select count(*) from pokemon where type1 = @id or type2 = @id", conn);
			param = new SqlParameter();
			param.ParameterName = "@id";
			param.Value = id;
			cmd.Parameters.Add(param);

			rdr = cmd.ExecuteReader();
			rdr.Read();
			numberOfPokemon = rdr.GetInt32(0);

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void LoadNumberOfMoves(string typeName)
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select id from types where name = @name", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@name";
			param.Value = typeName;
			cmd.Parameters.Add(param);

			SqlDataReader rdr = cmd.ExecuteReader();
			rdr.Read();
			int id = rdr.GetInt32(0);

			rdr.Close();
			cmd.Dispose();

			cmd = new SqlCommand("select count(*) from moves where type = @id", conn);
			param = new SqlParameter();
			param.ParameterName = "@id";
			param.Value = id;
			cmd.Parameters.Add(param);

			rdr = cmd.ExecuteReader();
			rdr.Read();
			numberOfMoves = rdr.GetInt32(0);

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected List<PokemonType> LoadAttackTypeRelations(string typeName, float multiplier)
        {
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select id from types where name = @name", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@name";
			param.Value = typeName;
			cmd.Parameters.Add(param);

			SqlDataReader rdr = cmd.ExecuteReader();
			rdr.Read();
			int id = rdr.GetInt32(0);

			rdr.Close();
			cmd.Dispose();

			cmd = new SqlCommand(
				"select * from type_relations " +
				"join types on damage_to = types.id " +
				"where damage_from = @id and multiplier = @multiplier",
				conn
			);
			SqlParameter param1 = new SqlParameter();
			param1.ParameterName = "@id";
			param1.Value = id;
			cmd.Parameters.Add(param1);
			
			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@multiplier";
			param2.Value = multiplier;
			cmd.Parameters.Add(param2);

			List<PokemonType> temp = new List<PokemonType>();
			rdr = cmd.ExecuteReader();
			while(rdr.Read()) {
				temp.Add(Pokedex.getTypeByName(rdr.GetString(5)));
            }

			rdr.Close();
			cmd.Dispose();

			conn.Close();

			return temp;
		}
		protected List<PokemonType> LoadDefenceTypeRelations(string typeName, float multiplier)
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select id from types where name = @name", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@name";
			param.Value = typeName;
			cmd.Parameters.Add(param);

			SqlDataReader rdr = cmd.ExecuteReader();
			rdr.Read();
			int id = rdr.GetInt32(0);

			rdr.Close();
			cmd.Dispose();

			cmd = new SqlCommand(
				"select * from type_relations " +
				"join types on damage_from = types.id " +
				"where damage_to = @id and multiplier = @multiplier",
				conn
			);
			SqlParameter param1 = new SqlParameter();
			param1.ParameterName = "@id";
			param1.Value = id;
			cmd.Parameters.Add(param1);

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@multiplier";
			param2.Value = multiplier;
			cmd.Parameters.Add(param2);

			List<PokemonType> temp = new List<PokemonType>();
			rdr = cmd.ExecuteReader();
			while (rdr.Read()) {
				temp.Add(Pokedex.getTypeByName(rdr.GetString(5)));
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();

			return temp;
		}
		protected void Logout_Click(object sender, EventArgs e)
		{
			Pokedex.loggedIn = false;
		}
	}
}