using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Sannel.House.Configuration.Common;

using Windows.ApplicationModel;

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		public async Task<IEnumerable<Setting>> GetAllSettingsAsync()
		{
			var connection = new Sannel.House.Configuration.ConfigurationConnection();

			return await connection.GetAllSettingsAsync();
		}
		private string GetVersionDescription()
		{
			var package = Package.Current;
			var packageId = package.Id;
			var version = packageId.Version;

			return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
		}
	}
}
