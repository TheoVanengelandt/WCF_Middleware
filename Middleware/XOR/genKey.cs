using System;
using System.Collections.Generic;

namespace Middleware
{
	class GenKey
	{
		private List<String> keyList = new List<String>();

		public GenKey()
		{
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Char[] stringChars = new char[4];

			for (int i = 0; i < chars.Length; i++)
			{
				stringChars[0] = chars[i];
				for (int y = 0; y < chars.Length; y++)
				{
					stringChars[1] = chars[y];
					for (int u = 0; u < chars.Length; u++)
					{
						stringChars[2] = chars[u];
						for (int x = 0; x < chars.Length; x++)
						{
							stringChars[3] = chars[x];
							keyList.Add(new String(stringChars));
						}
					}
				}
			}
		}

		public List<String> GetList()
		{
			return keyList;
		}
	}
}
