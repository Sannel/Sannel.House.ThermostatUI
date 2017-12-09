using System;

using Sannel.House.ThermostatUI.Models;
using Sannel.House.ThermostatUI.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sannel.House.ThermostatUI.Views
{
	public sealed partial class WrapperDetailPage : Page
	{
		private WrapperDetailViewModel ViewModel
		{
			get { return DataContext as WrapperDetailViewModel; }
		}

		public WrapperDetailPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ViewModel.Item = e.Parameter as SampleOrder;
		}
	}
}
