using Sannel.House.Configuration.Common;
using Sannel.House.ThermostatUI.Interfaces;
using Sannel.House.ThermostatUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sannel.House.ThermostatUI.Controls
{
	public abstract class SettingControlBase : UserControl, ISettingControl
	{
		public Setting Setting { get; set; }
		public SettingControlBase(Setting setting)
		{
			Setting = setting;
			this.DataContext = setting;
		}

		public string UpperDisplayName
		{
			get
			{
				return Setting?.DisplayName?.ToUpper();
			}
		}

		public event EventHandler<SettingChangedArgs> SettingChanged;

		public abstract void SetColor(InterfaceColors color);

		protected virtual void InputLostFocus(object sender, RoutedEventArgs e)
		{
			if (sender is TextBox input)
			{
				Setting.Value = input.Text;
				InvokeSettingChanged(Setting, Setting.Value);
			}
			else if(sender is PasswordBox pass)
			{
				Setting.Value = pass.Password;
				InvokeSettingChanged(Setting, Setting.Value);
			}
		}

		protected void InvokeSettingChanged(Setting setting, object value) 
			=> SettingChanged?.Invoke(this, new SettingChangedArgs(setting, value));
	}
}
