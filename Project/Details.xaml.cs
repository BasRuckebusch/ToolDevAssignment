﻿using System;
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
			}
			else
			{
				Repositories.Repository repository = new Repositories.Repository();
				monster = await repository.GetMonsterAsync(tag);
			}
			Title.Text = monster.name;
		}

		private void Back(object sender, RoutedEventArgs e)
		{
			_parentWindow.ViewList(isOnline) ;
		}

	}
}
