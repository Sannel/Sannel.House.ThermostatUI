using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Sannel.House.Configuration;
using Sannel.House.Configuration.Common;
using Sannel.House.ThermostatUI.Models;
using Windows.ApplicationModel;
using Windows.Foundation;

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		ConfigurationConnection connection;

		public SettingsViewModel()
		{
			connection = new ConfigurationConnection();
		}

		public override void Cleanup()
		{
			base.Cleanup();
			connection?.Dispose();
			connection = null;
		}

		public IAsyncOperation<bool> NavigatedToAsync()
		{
			connection?.Dispose();
			connection = new ConfigurationConnection();
			return connection.ConnectAsync();
		}

		public IAsyncAction NavigatedFromAsync()
		{
			return Task.Run(() =>
			{
				connection?.Dispose();
				connection = null;
			}).AsAsyncAction();
		}

		public async Task<IEnumerable<Setting>> GetAllSettingsAsync()
		{
			return (await connection.GetAllSettingsAsync());
		}
		private string GetVersionDescription()
		{
			var package = Package.Current;
			var packageId = package.Id;
			var version = packageId.Version;

			return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
		}

		public async void SettingChanged(Setting setting)
		{
			await connection.UpdateSettingAsync(setting);
		}
	}
}
