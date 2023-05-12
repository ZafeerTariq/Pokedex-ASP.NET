using System;

namespace PokedexBeta.src.models
{
	public static class Helper
	{
		public static string firstCharToUpper(string str)
        {
			string ret = str;
			if (str[0] >= 'a' && str[0] <= 'z')
				ret = char.ToUpper(str[0]) + str.Substring(1);
			return ret;
        }
	}
}