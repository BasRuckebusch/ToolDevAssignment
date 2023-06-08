using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
	/// <summary>
	/// Interaction logic for Details.xaml
	/// </summary>
	public partial class Details : Page
	{
		Model.Monster.MonsterInfo monster;
		private MainWindow _parentWindow;
		bool isOnline;
		public Details(string tag, bool iso)
		{
			isOnline = iso;
			InitializeComponent();
			InitializeAsync(tag);
		}

		public Details(MainWindow parentWindow, string tag, bool isOnline) : this(tag, isOnline)
		{
			_parentWindow = parentWindow;
		}

		private async Task InitializeAsync(string tag)
		{

			if (isOnline)
			{
				Repositories.OnlineRepo repository = new Repositories.OnlineRepo();
				monster = await repository.GetMonsterAsync(tag);

				if (!string.IsNullOrEmpty(monster.image))
				{
					//https://www.dnd5eapi.co/api/images/monsters/acolyte.png
					string url = "https://www.dnd5eapi.co" + monster.image;
					BitmapImage bitmap = new BitmapImage();
					bitmap.BeginInit();
					bitmap.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
					bitmap.EndInit();
					MonsterImage.Source = bitmap;
				}
			}
			else
			{
				Repositories.Repository repository = new Repositories.Repository();
				monster = await repository.GetMonsterAsync(tag);
			}

			Title.Text = monster.name;
			Overview.Text = monster.size + " " + monster.type + ", " + monster.alignment;

			Description.Text = monster.desc;

			STR.Text = AbilityMod(monster.strength);
			DEX.Text = AbilityMod(monster.dexterity);
			CON.Text = AbilityMod(monster.constitution);
			INT.Text = AbilityMod(monster.intelligence);
			WIS.Text = AbilityMod(monster.wisdom);
			CHA.Text = AbilityMod(monster.charisma);
		}

		string AbilityMod(int i) 
		{
			string result = "";
			int mod = (i - 10) / 2;

			if (mod >= 0)
			{
				result = i.ToString() + " (+" + mod.ToString() + ")";
			}
			else
			{
				result = i.ToString() + " (-" + mod.ToString() + ")";
			}
			return result;
		}


		private void Back(object sender, RoutedEventArgs e)
		{
			_parentWindow.ViewList(isOnline) ;
		}

	}
}
