using System;

using Sannel.House.ThermostatUI.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sannel.House.ThermostatUI.Views
{
	public sealed partial class WrapperDetailControl : UserControl
	{
		public SampleOrder MasterMenuItem
		{
			get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
			set { SetValue(MasterMenuItemProperty, value); }
		}

		public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(WrapperDetailControl), new PropertyMetadata(null));

		public WrapperDetailControl()
		{
			InitializeComponent();
		}
	}
}
