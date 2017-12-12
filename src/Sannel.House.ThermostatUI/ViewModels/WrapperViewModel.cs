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

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class WrapperViewModel : ViewModelBase
	{
		public NavigationServiceEx NavigationService
		{
			get
			{
				return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
			}
		}

		private const string NarrowStateName = "NarrowState";
		private const string WideStateName = "WideState";

		private VisualState _currentState;

		private SampleOrder _selected;

		public SampleOrder Selected
		{
			get { return _selected; }
			set { Set(ref _selected, value); }
		}

		public Visibility IsSystemAvailable => (ApiInformation.IsApiContractPresent("Windows.System.SystemManagementContract", 1, 0)
			&& string.Compare(AnalyticsInfo.VersionInfo.DeviceFamily, "Windows.IoT", true) == 0) ? Visibility.Visible : Visibility.Collapsed;

		private ICommand shutdownCommand;

		public ICommand ShutdownCommand
		{
			get
			{
				return shutdownCommand ?? (shutdownCommand = new RelayCommand(shutdown));
			}
		}

		private void shutdown()
		{
			Windows.System.ShutdownManager.BeginShutdown(Windows.System.ShutdownKind.Restart, TimeSpan.FromSeconds(30));
		}

		private ICommand _itemClickCommand;

		public ICommand ItemClickCommand
		{
			get
			{
				if (_itemClickCommand == null)
				{
					_itemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
				}

				return _itemClickCommand;
			}
		}

		private ICommand _stateChangedCommand;

		public ICommand StateChangedCommand
		{
			get
			{
				if (_stateChangedCommand == null)
				{
					_stateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
				}

				return _stateChangedCommand;
			}
		}

		public WrapperViewModel()
		{
		}

		private void OnStateChanged(VisualStateChangedEventArgs args)
		{
			_currentState = args.NewState;
		}

		private void OnItemClick(ItemClickEventArgs args)
		{
			SampleOrder item = args?.ClickedItem as SampleOrder;
			if (item != null)
			{
				if (_currentState.Name == NarrowStateName)
				{
					NavigationService.Navigate(typeof(WrapperDetailViewModel).FullName, item);
				}
				else
				{
					Selected = item;
				}
			}
		}
	}
}
