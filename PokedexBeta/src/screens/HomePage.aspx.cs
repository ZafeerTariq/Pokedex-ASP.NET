using PokedexBeta.src.models;
using System;
using System.Data.SqlClient;

namespace PokedexBeta
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		static Pokedex pokedex = new Pokedex();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack) {
				pokedex.Load_All_Data();

				string[] typeNames = new string[Pokedex.allTypes.Length];
				typeNames[0] = "All";
				for (int i = 0; i < Pokedex.allTypes.Length - 1; i++) {
					typeNames[i + 1] = Pokedex.allTypes[i].name;
				}

				typeList.DataSource = typeNames;
				typeList.DataBind();
			}
        }
		protected void Logout_Click(object sender, EventArgs e)
        {
			Pokedex.loggedIn = false;
		}
	}
}