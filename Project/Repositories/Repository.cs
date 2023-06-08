using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
	internal class Repository : MonsterRepo
	{
		List<MonsterOverview> monsters;
		Monster.MonsterInfo monster;

		public async Task<List<MonsterOverview>> GetAllMonstersAsync()
		{
			List<MonsterOverview> result = new List<MonsterOverview>();
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			var resourceName = "Project.Resources.monsters.json";
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (var reader = new StreamReader(stream))
				{ 
					string json = reader.ReadToEnd();
					JObject jobj = JsonConvert.DeserializeObject<JObject>(json);
					List<MonsterOverview> temp = jobj.SelectToken("results").ToObject<List<MonsterOverview>>();
					result = temp;
				}
			}
			await Task.Delay(300);
			monsters = result;
			return result;
		}

		public async Task<Monster.MonsterInfo> GetMonsterAsync(string name)
		{
			Monster.MonsterInfo result = null;
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			var resourceName = $"Project.Resources.{name.ToLower()}.json";
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (var reader = new StreamReader(stream))
				{
					string json = reader.ReadToEnd();
					JObject jobj = JsonConvert.DeserializeObject<JObject>(json);
					result = jobj.ToObject<Monster.MonsterInfo>();
				}
			}
			await Task.Delay(100);
			monster = result;
			return result;
		}
	}
}
