using Sannel.House.Configuration.Common;
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
	public sealed partial class IntegerSettingControl : SettingControlBase
	{
		public IntegerSettingControl(Setting setting) : base(setting)
		{
			this.InitializeComponent();
			Input.Text = setting.Value?.ToString();
		}

		protected override void InputLostFocus(object sender, RoutedEventArgs e)
		{
			if(int.TryParse(Input.Text, out var i))
			{
				Setting.Value = i;
				InvokeSettingChanged(Setting, i);
			}
		}

		public override void SetColor(InterfaceColors color)
		{
			if (App.Current.Resources[$"{color}TextBox"] is Style style)
			{
				Input.Style = style;
			}
		}
	}
}
