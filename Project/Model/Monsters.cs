using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
	public class Monsters
	{
		public int count { get; set; }
		public MonsterOverview[] results { get; set; }
	}

	public class MonsterOverview
	{
		public string index { get; set; }
		public string name { get; set; }
		public string url { get; set; }
	}
}
