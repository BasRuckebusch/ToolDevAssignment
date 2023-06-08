using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
	internal class OnlineRepo : MonsterRepo
	{

		private string endPoint = "https://www.dnd5eapi.co/api/monsters/";

		List<MonsterOverview> monsters;
		Monster.MonsterInfo monster;

		public async Task<List<MonsterOverview>> GetAllMonstersAsync()
		{
			List<MonsterOverview> result = new List<MonsterOverview>();
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(endPoint);
				response.EnsureSuccessStatusCode();
				Task<String> responseTask = response.Content.ReadAsStringAsync();
				string responseTaskString = responseTask.Result;
				JObject jobj = JsonConvert.DeserializeObject<JObject>(responseTaskString);
				List<MonsterOverview> temp = jobj.SelectToken("results").ToObject<List<MonsterOverview>>();
				result = temp;
			}
			await Task.Delay(200);
			monsters = result;
			return result;
		}

		public async Task<Monster.MonsterInfo> GetMonsterAsync(string name)
		{

			Monster.MonsterInfo result = null;
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(endPoint + $"{name.ToLower()}");
				response.EnsureSuccessStatusCode();
				Task<String> responseTask = response.Content.ReadAsStringAsync();
				string responseTaskString = responseTask.Result;
				JObject jobj = JsonConvert.DeserializeObject<JObject>(responseTaskString);
				result = jobj.ToObject<Monster.MonsterInfo>();
			}
			await Task.Delay(100);
			monster = result;
			return result;
		}
	}
}
