using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class SystemViewModel : ViewModelBase
	{
		private ICommand shutdown;
		public ICommand Shutdown 
			=> shutdown ?? (shutdown = new RelayCommand(shutdownAction));

		private void shutdownAction() 
			=> ShutdownManager.BeginShutdown(ShutdownKind.Shutdown, TimeSpan.FromMilliseconds(0));

		private ICommand restart;
		public ICommand Restart
			=> restart ?? (restart = new RelayCommand(restartAction));

		private void restartAction() 
			=> ShutdownManager.BeginShutdown(ShutdownKind.Restart, TimeSpan.FromMilliseconds(0));
	}
}
