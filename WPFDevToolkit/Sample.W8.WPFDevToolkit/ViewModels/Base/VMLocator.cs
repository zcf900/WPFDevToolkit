using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PCL.WPFDevToolkit.Services.Design;
using PCL.WPFDevToolkit.Services.Interfaces;
using Sample.W8.WPFDevToolkit.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W8.WPFDevToolkit.Services;

namespace Sample.W8.WPFDevToolkit.ViewModels.Base
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
                //SimpleIoc.Default.Register<INavigationService>(() => new NavigationService((((App)Application.Current).RootFrame))
                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService()
                {
                    RoutingTable = new Dictionary<string, object>()
                    {
                        {"VHome", typeof(VHome)},
                        {"VUserControls", typeof(VUserControls)},
                    }
                });
                SimpleIoc.Default.Register<VMHome>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public VMHome Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMHome>();
            }
        }
    }
}
