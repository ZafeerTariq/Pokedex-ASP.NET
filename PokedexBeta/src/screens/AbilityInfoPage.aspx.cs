using System;
using PokedexBeta.src.models;

namespace PokedexBeta.src.screens
{
    public partial class AbilityInfoPage : System.Web.UI.Page
    {
        protected Ability localAbility;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];
            localAbility = Pokedex.getAbilityByName(name);
        }
    }
}