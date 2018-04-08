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

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			ViewModel.NavigationFrame = NavigationFrame;
			ViewModel.NavigationService.Navigate(Pages.Home);
			NavigationFrame.Navigated += (o, s) =>
			{
				ViewModel.Navigation(s);
			};
			//await ViewModel.LoadDataAsync(WindowStates.CurrentState);
		}

		private void page_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) 
			=> ViewModel.UserAction();

		private void page_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e) 
			=> ViewModel.UserAction();
	}
}
