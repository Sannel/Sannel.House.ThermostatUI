using System;

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

using Sannel.House.ThermostatUI.Services;
using Sannel.House.ThermostatUI.Views;

namespace Sannel.House.ThermostatUI.ViewModels
{
	public class ViewModelLocator
	{
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register(() => new NavigationServiceEx());
			Register<WrapperViewModel, WrapperPage>();
			Register<WrapperDetailViewModel, WrapperDetailPage>();
			Register<HomeViewModel, HomePage>();
			Register<SettingsViewModel, SettingsPage>();
		}

		public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

		public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

		public WrapperDetailViewModel WrapperDetailViewModel => ServiceLocator.Current.GetInstance<WrapperDetailViewModel>();

		public WrapperViewModel WrapperViewModel => ServiceLocator.Current.GetInstance<WrapperViewModel>();

		public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

		public void Register<VM, V>()
			where VM : class
		{
			SimpleIoc.Default.Register<VM>();

			NavigationService.Configure(typeof(VM).FullName, typeof(V));
		}
	}
}
