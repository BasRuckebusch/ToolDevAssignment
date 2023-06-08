using System;
using System.Collections.Generic;
using System.Linq;
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
	/// Interaction logic for List.xaml
	/// </summary>
	public partial class List : Page
	{
		private MainWindow _parentWindow;

		bool isOnline = false;

		List<Model.MonsterOverview> monsters;
		Model.Monster.MonsterInfo monster;

		public List(MainWindow parentWindow, bool isOnline) : this(isOnline)
		{
			_parentWindow = parentWindow;
		}

		public List(bool iso)
		{
			isOnline = iso;
			InitializeComponent();

			Initialize();
		}

		private async void Initialize()
		{
			
			if (isOnline)
			{
				Repositories.OnlineRepo repository = new Repositories.OnlineRepo();
				monsters = await repository.GetAllMonstersAsync();
			}
			else
			{
				Repositories.Repository repository = new Repositories.Repository();
				monsters = await repository.GetAllMonstersAsync();
			}


			for (int i = 0; i < monsters.Count(); i++)
			{
				TextBlock text = new TextBlock();
				text.Text = monsters.ElementAt(i).name;
				text.Tag = monsters.ElementAt(i).index.ToString();

				ListView1.Items.Add(text);
			}
		}

		private void Search(object sender, RoutedEventArgs e)
		{
			ListView1.Items.Clear();
			for (int i = 0; i < monsters.Count(); i++)
			{
				if (monsters.ElementAt(i).name.ToLower().Contains(TextBox1.Text.ToLower()))
				{
					TextBlock text = new TextBlock();
					text.Text = monsters.ElementAt(i).name;
					text.Tag = monsters.ElementAt(i).index.ToString();
					ListView1.Items.Add(text);
				}
			}
		}

		private void listView_Click(object sender, RoutedEventArgs e)
		{
			var item = (sender as ListView).SelectedItem;
			if (item != null)
			{
				string tag = ((TextBlock)item).Tag.ToString();

				_parentWindow.ViewDetail(tag, isOnline);	
			}
		}
		private void Online(object sender, RoutedEventArgs e)
		{
			isOnline = !isOnline;
			Console.WriteLine(isOnline.ToString());
		}
	}
}
