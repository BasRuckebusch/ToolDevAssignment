using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
	internal class Monster
	{
		public class MonsterInfo
		{
			public string index { get; set; }
			public string name { get; set; }
			public string desc { get; set; }
			public string size { get; set; }
			public string type { get; set; }
			public string subtype { get; set; }
			public string alignment { get; set; }

			public int strength { get; set; }
			public int dexterity { get; set; }
			public int constitution { get; set; }
			public int intelligence { get; set; }
			public int wisdom { get; set; }
			public int charisma { get; set; }

			public string image { get; set; }
		}
	}
}
