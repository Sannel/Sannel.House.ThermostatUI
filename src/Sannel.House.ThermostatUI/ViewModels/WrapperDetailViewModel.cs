using System;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Sannel.House.ThermostatUI.Models;
using Sannel.House.ThermostatUI.Services;

using Windows.UI.Xaml;

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class WrapperDetailViewModel : ViewModelBase
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

		private SampleOrder _item;

		public SampleOrder Item
		{
			get { return _item; }
			set { Set(ref _item, value); }
		}

		public WrapperDetailViewModel()
		{
		}

		private void OnStateChanged(VisualStateChangedEventArgs args)
		{
			if (args.OldState.Name == NarrowStateName && args.NewState.Name == WideStateName)
			{
				NavigationService.GoBack();
			}
		}
	}
}
