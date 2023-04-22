using PokedexBeta.modals;
using System;
using System.Data.SqlClient;

namespace PokedexBeta
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		static private GrowthRate[] growthRate;
		static private PokemonType[] types;
		static private Pokemon[] pokemon;

		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void Load_Growth_Rate(object sender, EventArgs e)
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
					growthRate = new GrowthRate[count];
					for (int i = 0; i < count; i++) {
						rdr.Read();
						growthRate[i] = new GrowthRate(rdr.GetString(1), rdr.GetString(2));
						label1.Text = label1.Text + "name = " + rdr.GetString(1) + " formula = " + rdr.GetString(2) + "<br />";
					}
				}

				rdr.Close();
				cmd.Dispose();
			}

			conn.Close();
		}
		protected void Load_Types(object sender, EventArgs e)
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
				types = new PokemonType[count + 1];
				label1.Text = "";
				for (int i = 0; i < count; i++) {
					rdr.Read();
					types[i] = new PokemonType(rdr.GetString(1));
					label1.Text = label1.Text + types[i].name + "<br />";
				}
			}

			types[count] = new PokemonType("null");

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
		protected void Load_Pokemon(object sender, EventArgs e)
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
				pokemon = new Pokemon[count];
				label1.Text = "";
				for (int i = 0; i < count; i++) {
					rdr.Read();
					pokemon[i] = new Pokemon(rdr.GetInt32(0), rdr.GetString(1), (float)rdr.GetDouble(2),
						(float)rdr.GetDouble(3), types[rdr.GetInt32(4) - 1], rdr.IsDBNull(5) ? types[types.Length - 1] : types[rdr.GetInt32(5) - 1],
						rdr.GetString(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9),
						rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(12), rdr.IsDBNull(13) ? "null" : rdr.GetString(13),
						growthRate[rdr.GetInt32(14) - 1], rdr.GetInt32(15), rdr.IsDBNull(16) ? -1 : rdr.GetInt32(16),
						rdr.IsDBNull(17) ? -1 : rdr.GetInt32(17), rdr.IsDBNull(18) ? -1 : rdr.GetInt32(18), rdr.GetString(19), rdr.GetBoolean(21),
						rdr.GetString(22)
					);
					label1.Text = label1.Text + rdr.GetString(1) + "<br />";
				}
			}

			rdr.Close();
			cmd.Dispose();

			conn.Close();
		}
	}
}