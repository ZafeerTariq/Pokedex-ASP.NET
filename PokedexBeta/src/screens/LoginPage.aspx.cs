using System;
using System.Data.SqlClient;
using PokedexBeta.src.models;

namespace PokedexBeta.src.screens
{
	public partial class LockScreen : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security = True"
			);
			try {
				string uid = TextBox1.Text;
				string pass = TextBox2.Text;

				conn.Open();
				
				string qry = "select * from user_data where username='" + uid + "' and pwd='" + pass + "'";
				
				SqlCommand cmd = new SqlCommand(qry, conn);
				SqlDataReader rdr = cmd.ExecuteReader();
				if (rdr.Read()) {
					//Label4.Text = "Login Sucess......!!";
					Pokedex.loggedIn = true;
					PokedexUser.name = rdr.GetString(1) + " " + rdr.GetString(2);
					PokedexUser.username = rdr.GetString(3);
					PokedexUser.gender = rdr.GetString(6);
					Response.Redirect("HomePage.aspx");
				}
				else {
					Label4.Text = "UserId & Password Is not correct Try again..!!";
				}

				rdr.Close();
				cmd.Dispose();
				conn.Close();
			}
			catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("RegistrationPage.aspx");
		}
	}
}
