using Caliburn.Micro;
using ExcelToDatabase.Services;
using ExcelToDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExcelToDatabase
{
	public class Bootsrapper: BootstrapperBase
	{
		private SimpleContainer _container = new SimpleContainer();

		public Bootsrapper()
		{
			Initialize(); 
		}

		protected override void Configure()
		{
			_container.Instance(_container);
			_container
				.Singleton<IWindowManager, WindowManager>()
				.Singleton<IEventAggregator, EventAggregator>();

			_container.Singleton<IDialogManagerService, DialogManagerService>();

			GetType().Assembly.GetTypes()
				.Where(type => type.IsClass)
				.Where(type => type.Name.EndsWith("ViewModel"))
				.ToList()
				.ForEach(viewModelType => _container.RegisterPerRequest(
					viewModelType, viewModelType.ToString(), viewModelType));

			GetType().Assembly.GetTypes()
				.Where(type => type.IsClass)
				.Where(type => type.Namespace.Contains("Utils"))
				.ToList()
				.ForEach(viewModelType => _container.RegisterPerRequest(
					viewModelType.GetInterface("I" + viewModelType), viewModelType.ToString(), viewModelType));

		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<MainWindowViewModel>(); 
		}

		protected override object GetInstance(Type service, string key)
		{
			return _container.GetInstance(service, key); 
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}
		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}
	}
}
