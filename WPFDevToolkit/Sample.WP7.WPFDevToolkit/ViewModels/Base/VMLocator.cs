using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PCL.WPFDevToolkit.Services.Design;
using PCL.WPFDevToolkit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WP7.WPFDevToolkit.Services;

namespace Sample.WP7.WPFDevToolkit.ViewModels.Base
{
    public class VMLocator
    {
        static VMLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService>(() => new DesignNavigationService());
            }
            else
            {
                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService((((App)Application.Current).RootFrame))
                {
                    RoutingTable = new Dictionary<string, object>()
                    {
                        {"VHome", new Uri("/Views/VHome.xaml", UriKind.Relative)},
                        {"VInformation", new Uri("/Views/VInformation.xaml", UriKind.Relative)}
                    }
                });
            }
            SimpleIoc.Default.Register<VMHome>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public VMHome Home
        {
            get
            {
                return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<VMHome>();
            }
        }
    }
}