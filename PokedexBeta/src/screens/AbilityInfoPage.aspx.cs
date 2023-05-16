using System;
using PokedexBeta.src.models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PokedexBeta.src.screens
{
    public partial class AbilityInfoPage : System.Web.UI.Page
    {
        protected Ability localAbility;
		protected List<Pokemon> pokemon;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];
            localAbility = Pokedex.getAbilityByName(name);

			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security=True"
			);
			conn.Open();

			SqlCommand moveIdCmd = new SqlCommand("select id from abilities where name = @name", conn);
			SqlParameter moveIdParam = new SqlParameter();
			moveIdParam.ParameterName = "@name";
			moveIdParam.Value = localAbility.name;
			moveIdCmd.Parameters.Add(moveIdParam);

			SqlDataReader moveIdRdr = moveIdCmd.ExecuteReader();

			moveIdRdr.Read();
			int id = moveIdRdr.GetInt32(0);

			moveIdRdr.Close();
			moveIdCmd.Dispose();

			SqlCommand cmd = new SqlCommand("select pokemon_id from pokemon_abilities where ability_id = @id", conn);
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@id";
			param.Value = id;
			cmd.Parameters.Add(param);

			SqlDataReader rdr = cmd.ExecuteReader();

			pokemon = new List<Pokemon>();
			while (rdr.Read()) {
				Pokemon temp = Pokedex.getPokemonByID(rdr.GetInt32(0));
				if (!pokemon.Contains(temp)) {
					pokemon.Add(temp);
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
    }
}