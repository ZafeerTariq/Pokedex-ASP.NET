using System;
using System.Data.SqlClient;

namespace PokedexBeta.src.screens
{
	public partial class Registration : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(
				"Data Source = DESKTOP-IM1NTKG\\SQLEXPRESS; Initial Catalog = pokedexTesting; Integrated Security = True"
			);
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("insert into user_data values(@fname,@lname,@Username,@Pwd,@Address,@Phone,@gender,@mail)", conn);
				
				cmd.Parameters.AddWithValue("fname", TextBox1.Text);
				cmd.Parameters.AddWithValue("lname", TextBox5.Text);
				cmd.Parameters.AddWithValue("Username", TextBox6.Text);
				cmd.Parameters.AddWithValue("Pwd", TextBox2.Text);
				cmd.Parameters.AddWithValue("Address", TextBox7.Text);
				cmd.Parameters.AddWithValue("Phone", TextBox8.Text);
				cmd.Parameters.AddWithValue("Gender", RadioButtonList1.SelectedValue);
				cmd.Parameters.AddWithValue("mail", TextBox4.Text);
				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();
			}

			Response.Redirect("HomePage.aspx");
		}
	}
}