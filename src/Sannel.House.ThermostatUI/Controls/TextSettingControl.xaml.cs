using Sannel.House.Configuration.Common;
using Sannel.House.ThermostatUI.Interfaces;
using Sannel.House.ThermostatUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Sannel.House.ThermostatUI.Controls
{
	public sealed partial class TextSettingControl : UserControl, ISettingControl
	{
		public Setting Setting { get; set; }
		public TextSettingControl(Setting setting)
		{
			Setting = setting;
			this.DataContext = setting;
			this.InitializeComponent();
		}

		public event EventHandler<SettingChangedArgs> SettingChanged;

		private void input_TextChanged(object sender, TextChangedEventArgs e) 
			=> SettingChanged?.Invoke(this, new SettingChangedArgs(Setting, Setting.Value));
	}
}
