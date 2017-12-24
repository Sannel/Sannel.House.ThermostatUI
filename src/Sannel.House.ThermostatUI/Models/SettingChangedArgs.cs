using Sannel.House.Configuration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ThermostatUI.Models
{
	public sealed class SettingChangedArgs : EventArgs
	{
		public SettingChangedArgs(Setting setting, object value)
		{
			Setting = setting;
			Value = value;
		}

		public Setting Setting { get; set; }
		public object Value { get; set; }
	}
}
