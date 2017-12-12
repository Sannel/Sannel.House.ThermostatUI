using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ThermostatUI.IOT
{
	public static class ShutdownHelper
	{
		public static void Shutdown()
		{
			Windows.System.ShutdownManager.BeginShutdown(Windows.System.ShutdownKind.Restart, TimeSpan.FromSeconds(30));
		}
	}
}
