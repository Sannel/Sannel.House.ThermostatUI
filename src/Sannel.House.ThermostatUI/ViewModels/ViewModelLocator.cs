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
			Register<WrapperViewModel, WrapperPage>(Pages.Wrapper);
			Register<HomeViewModel, HomePage>(Pages.Home);
			Register<SettingsViewModel, SettingsPage>(Pages.Settings);
			Register<SystemViewModel, SystemPage>(Pages.System);
		}

		public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

		public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

		public WrapperDetailViewModel WrapperDetailViewModel => ServiceLocator.Current.GetInstance<WrapperDetailViewModel>();

		public WrapperViewModel WrapperViewModel => ServiceLocator.Current.GetInstance<WrapperViewModel>();

		public SystemViewModel SystemViewModel => ServiceLocator.Current.GetInstance<SystemViewModel>();

		public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

		public void Register<VM, V>(Pages p)
			where VM : class
		{
			SimpleIoc.Default.Register<VM>();

			NavigationService.Configure(p, typeof(V));
		}
	}
}
