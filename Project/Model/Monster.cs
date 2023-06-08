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

			public ArmorClass[] armor_class { get; set; }

			public int hit_points { get; set; }
			public string hit_dice { get; set; }
			public string hit_points_roll { get; set; }

			public Speed speed { get; set; }

			public int strength { get; set; }
			public int dexterity { get; set; }
			public int constitution { get; set; }
			public int intelligence { get; set; }
			public int wisdom { get; set; }
			public int charisma { get; set; }

			public string image { get; set; }


		}
		public class ArmorClass
		{
			public string type { get; set; }
			public int value { get; set; }
		}

		public class Speed
		{
			public string walk { get; set; }
			public string fly { get; set; }
			public string climb { get; set; }
			public string swim { get; set; }
			public string burrow { get; set; }

		}
	}
}
