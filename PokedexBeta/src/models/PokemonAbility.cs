using System;

namespace PokedexBeta.src.models
{
	public class PokemonAbility
	{
		public Ability ability;
		public bool isHidden;

		public PokemonAbility(Ability ability, bool hidden)
		{
			this.ability = ability;
			this.isHidden = hidden;
		}
	}
}