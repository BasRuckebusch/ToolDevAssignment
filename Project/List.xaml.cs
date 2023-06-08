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
				Online1.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
			}
			else
			{
				Repositories.Repository repository = new Repositories.Repository();
				monsters = await repository.GetAllMonstersAsync();
				Online1.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			}


			for (int i = 0; i < monsters.Count(); i++)
			{

				TextBlock text = new TextBlock
				{
					Text = monsters.ElementAt(i).name,
					Tag = monsters.ElementAt(i).index.ToString(),
					FontFamily = new System.Windows.Media.FontFamily("'Libre Baskerville', 'Lora', 'Calisto MT', 'Bookman Old Style', Bookman, 'Goudy Old Style', Garamond, 'Hoefler Text', 'Bitstream Charter', Georgia, serif")
				};

				ListView1.Items.Add(text);
			}
		}

		private void Search()
		{
			ListView1.Items.Clear();
			for (int i = 0; i < monsters.Count(); i++)
			{
				if (monsters.ElementAt(i).name.ToLower().Contains(TextBox1.Text.ToLower()))
				{
					TextBlock text = new TextBlock
					{
						Text = monsters.ElementAt(i).name,
						Tag = monsters.ElementAt(i).index.ToString(),
						FontFamily = new System.Windows.Media.FontFamily("'Libre Baskerville', 'Lora', 'Calisto MT', 'Bookman Old Style', Bookman, 'Goudy Old Style', Garamond, 'Hoefler Text', 'Bitstream Charter', Georgia, serif")
					};
					ListView1.Items.Add(text);
				}
			}
		}

		private void SearchClicked(object sender, RoutedEventArgs e)
		{
			Search();
		}

		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			Search();
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
			if (isOnline) 
			{
				Online1.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			}
			else 
			{
				Online1.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
			}

			isOnline = !isOnline;
			Console.WriteLine(isOnline.ToString());
		}
	}
}
