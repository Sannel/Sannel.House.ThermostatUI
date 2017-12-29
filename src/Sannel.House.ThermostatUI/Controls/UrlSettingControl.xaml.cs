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
	public sealed partial class UrlSettingControl : SettingControlBase
	{
		public UrlSettingControl(Setting setting) : base(setting)
		{
			this.InitializeComponent();
		}

		protected override void InputLostFocus(object sender, RoutedEventArgs e)
		{
			if(sender is TextBox input)
			{
				var u = input.Text;

				if (Uri.TryCreate(u, UriKind.Absolute, out var i))
				{
					Setting.Value = i.ToString();
					InvokeSettingChanged(Setting, Setting.Value);
				}
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
