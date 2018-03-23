using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Sannel.House.ThermostatUI.Models;
using Sannel.House.ThermostatUI.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Foundation.Metadata;
using Windows.System.Profile;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.System.Threading;
using GalaSoft.MvvmLight.Threading;

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class WrapperViewModel : ViewModelBase
	{
		private DateTime lastEvent = DateTime.Now;

		public WrapperViewModel()
		{
			ThreadPoolTimer.CreatePeriodicTimer((timer)=> { DispatcherHelper.CheckBeginInvokeOnUI(() => timerTick(timer)); }, TimeSpan.FromMinutes(1));
		}

		private void timerTick(ThreadPoolTimer timer)
		{
			if(lastEvent >= DateTime.Now.AddMinutes(-1))
			{
				IsScreenSaverVisible = Visibility.Visible;
			}
			else
			{
				IsScreenSaverVisible = Visibility.Collapsed;
			}
		}

		public void UserAction()
		{
			lastEvent = DateTime.Now;
			if(IsScreenSaverVisible != Visibility.Collapsed)
			{
				IsScreenSaverVisible = Visibility.Collapsed;
			}
		}

		private Visibility isScreenSaverVisible = Visibility.Collapsed;
		public Visibility IsScreenSaverVisible
		{
			get => isScreenSaverVisible;
			set => Set(nameof(IsScreenSaverVisible), ref isScreenSaverVisible, value);
		}

		public NavigationServiceEx NavigationService => 
			Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<NavigationServiceEx>();

		public void Navigation(NavigationEventArgs s)
		{
			var page = NavigationService.GetNameOfRegisteredPage(s.Content?.GetType());

			IsHomeSelected = false;
			IsSettingsSelected = false;
			IsSystemSelected = false;

			switch (page)
			{
				case Pages.System:
					IsSystemSelected = true;
					break;

				case Pages.Settings:
					IsSettingsSelected = true;
					break;

				default:
					IsHomeSelected = true;
					break;
			}
		}

		public Frame NavigationFrame
		{
			set => NavigationService.Frame = value;
		}


		private ICommand homeCommand;
		public ICommand HomeCommand =>
			homeCommand ?? (homeCommand = new RelayCommand(() => navigateToPage(Pages.Home)));

		private bool isHomeSelected = true;
		public bool IsHomeSelected
		{
			get => isHomeSelected;
			set => Set(nameof(IsHomeSelected), ref isHomeSelected, value);
		}

		private ICommand systemCommand;
		public ICommand SystemCommand =>
			systemCommand ?? (systemCommand = new RelayCommand(() => navigateToPage(Pages.System)));

		private bool isSystemSelected;
		public bool IsSystemSelected
		{
			get => isSystemSelected;
			set => Set(nameof(IsSystemSelected), ref isSystemSelected, value);
		}

		public Visibility IsSystemAvailable => (ApiInformation.IsApiContractPresent("Windows.System.SystemManagementContract", 1, 0)
			&& string.Compare(AnalyticsInfo.VersionInfo.DeviceFamily, "Windows.IoT", true) == 0) ? Visibility.Visible : Visibility.Collapsed;


		private bool isSettingsSelected;
		public bool IsSettingsSelected
		{
			get => isSettingsSelected;
			set => Set(nameof(IsSettingsSelected), ref isSettingsSelected, value);
		}

		private ICommand settingsCommand;
		public ICommand SettingsCommand
			=> settingsCommand ?? (settingsCommand = new RelayCommand(() => navigateToPage(Pages.Settings)));

		private void navigateToPage(Pages page)
		{
			NavigationService.Navigate(page);
		}

	}
}
