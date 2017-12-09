using System;

using Sannel.House.ThermostatUI.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Sannel.House.ThermostatUI.Views
{
	public sealed partial class HomePage : Page
	{
		private HomeViewModel ViewModel
		{
			get { return DataContext as HomeViewModel; }
		}

		public HomePage()
		{
			InitializeComponent();
		}
	}
}
