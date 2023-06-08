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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			NavFrame.NavigationService.Navigate(new List(this, false));
		}

		public void ViewDetail(string tag, bool isOnline)
		{
			NavFrame.NavigationService.Navigate(new Details(this, tag, isOnline));
		}
		public void ViewList(bool isOnline)
		{
			NavFrame.NavigationService.Navigate(new List(this, isOnline));
		}
	}
}
