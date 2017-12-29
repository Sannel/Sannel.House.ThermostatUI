using System;

using Sannel.House.ThermostatUI.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Sannel.House.ThermostatUI.Controls;
using Sannel.House.ThermostatUI.Interfaces;
using Sannel.House.ThermostatUI.Models;
using System.Collections.Generic;

namespace Sannel.House.ThermostatUI.Views
{
	public sealed partial class SettingsPage : Page
	{
		private SettingsViewModel ViewModel
		{
			get { return DataContext as SettingsViewModel; }
		}

		//// TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere

		public SettingsPage()
		{
			InitializeComponent();
		}

		private void clearControlls()
		{
			foreach(var s in SettingControls.Children)
			{
				if(s is ISettingControl t)
				{
					t.SettingChanged -= settingChanged;
				}
			}
			SettingControls.Children.Clear();
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			clearControlls();
			await ViewModel.NavigatedToAsync();
			var result = await ViewModel.GetAllSettingsAsync();
			var queue = new Queue<string>();
			foreach(var item in result)
			{
				SettingControlBase control = null;
				switch (item.SettingType)
				{
					case Configuration.Common.SettingType.String:
						control = new TextSettingControl(item);
						break;
					case Configuration.Common.SettingType.Uri:
						control = new UrlSettingControl(item);
						break;
					case Configuration.Common.SettingType.Password:
						control = new PasswordSettingControl(item);
						break;
					case Configuration.Common.SettingType.Integer:
						control = new IntegerSettingControl(item);
						break;
				}

				if (control != null)
				{
					if(queue.Count == 0)
					{
						foreach(var s in Enum.GetNames(typeof(InterfaceColors)))
						{
							queue.Enqueue(s);
						}
					}

					control.SettingChanged += settingChanged;
					SettingControls.Children.Add(control);
					var value = queue.Dequeue();
					if(Enum.TryParse<InterfaceColors>(value, out var q))
					{
						control.SetColor(q);
					}
				}
			}
		}

		protected override async void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			clearControlls();
			await ViewModel.NavigatedFromAsync();
		}

		private void settingChanged(object sender, Models.SettingChangedArgs e)
		{
			ViewModel.SettingChanged(e.Setting);
		}
	}
}
