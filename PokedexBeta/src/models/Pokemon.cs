using System;
using System.Collections.Generic;

namespace PokedexBeta.src.models
{
	public class Pokemon
	{
		public int pokedexID;
		public String name;
		public float height;
		public float weight;
		public List<PokemonType> types;
		public String pokedexEntry;
		public int hp;
		public int speed;
		public int defence;
		public int attack;
		public int sp_defence;
		public int sp_attack;
		public String species;
		public GrowthRate growthRate;
		public int catchRate;
		public int baseHappiness;
		public int eggCycles;
		public int baseExperience;
		public String imageURL;
		public bool hasForms;
		public String specie_name;
		public List<PokemonAbility> abilities;
		public List<PokemonMove> moves;
		public List<Pokemon> evolvesFrom;
		public List<Pokemon> evolvesTo;
		public List<string> evolvesFromTriggers;
		public List<string> evolvesToTriggers;


		public Pokemon(int pokedexID, String name, float height, float weight, PokemonType type1, PokemonType type2,
		String pokedexEntry, int hp, int speed, int defence, int attack, int sp_defence, int sp_attack,
		String species, GrowthRate growthRate, int catchRate, int baseHappiness, int eggCycles,
		int baseExperience, String imageURL, bool hasForms, String specie_name, List<PokemonAbility> abilities, List<PokemonMove> moves)
		{
			this.pokedexID = pokedexID;
			this.name = name;
			this.height = height;
			this.weight = weight;
			types = new List<PokemonType>();
			types.Add(type1);
			if (type2 != null) {
				types.Add(type2);
            }
			this.pokedexEntry = pokedexEntry;
			this.hp = hp;
			this.speed = speed;
			this.defence = defence;
			this.attack = attack;
			this.sp_defence = sp_defence;
			this.sp_attack = sp_attack;
			this.species = species;
			this.growthRate = growthRate;
			this.catchRate = catchRate;
			this.baseHappiness = baseHappiness;
			this.baseExperience = baseExperience;
			this.eggCycles = eggCycles;
			this.baseExperience = baseExperience;
			this.imageURL = imageURL;
			this.hasForms = hasForms;
			this.specie_name = specie_name;
			this.abilities = abilities;
			this.moves = moves;
		}

		public void SetEvolvesFrom(List<Pokemon> pokemon, List<string> triggers)
        {
			evolvesFrom = pokemon;
			evolvesFromTriggers = triggers;
        }
		public void SetEvolvesTo(List<Pokemon> pokemon, List<string> triggers)
        {
			evolvesTo = pokemon;
			evolvesToTriggers = triggers;
        }
	}
}