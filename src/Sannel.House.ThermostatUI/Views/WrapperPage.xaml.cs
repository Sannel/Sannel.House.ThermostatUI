using System;

using Sannel.House.ThermostatUI.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sannel.House.ThermostatUI.Views
{
	public sealed partial class WrapperPage : Page
	{
		private WrapperViewModel ViewModel
		{
			get { return DataContext as WrapperViewModel; }
		}

		public WrapperPage()
		{
			InitializeComponent();
		}

		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			//await ViewModel.LoadDataAsync(WindowStates.CurrentState);
		}
	}
}
