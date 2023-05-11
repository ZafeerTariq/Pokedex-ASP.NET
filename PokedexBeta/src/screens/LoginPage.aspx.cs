using System;
using System.Data.SqlClient;

namespace PokedexBeta.src.screens
{
	public partial class LockScreen : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			try {
				SqlConnection conn = new SqlConnection("Data Source = FARAN\\SQLEXPRESS; Initial Catalog = Pokedex_Final; Integrated Security=True");
				
				string uid = TextBox1.Text;
				string pass = TextBox2.Text;
				
				conn.Open();
				
				string qry = "select * from userdata where Username='" + uid + "' and Pwd='" + pass + "'";
				
				SqlCommand cmd = new SqlCommand(qry, conn);
				SqlDataReader rdr = cmd.ExecuteReader();
				
				if (rdr.Read()) {
					//Label4.Text = "Login Sucess......!!";
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
	}
}
