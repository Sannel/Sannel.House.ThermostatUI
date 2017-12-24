using Sannel.House.ThermostatUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ThermostatUI.Interfaces
{
	public interface ISettingControl
	{
		event EventHandler<SettingChangedArgs> SettingChanged;
	}
}
