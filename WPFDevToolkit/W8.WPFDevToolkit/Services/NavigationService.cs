using PCL.WPFDevToolkit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace W8.WPFDevToolkit.Services
{
    public class NavigationService : INavigationService
    {
        #region Properties
        private readonly Frame frame;
        public Dictionary<string, object> RoutingTable { get; set; }
        #endregion

        #region Constructors
        public NavigationService()
        {
            this.frame = ((Frame)Window.Current.Content);
        }
        #endregion

        #region Methods
        public bool Navigate(string route)
        {
            Type type = (Type)RoutingTable[route];
            return this.frame.Navigate(type);
        }
        public bool Navigate(string route, string parameter)
        {
            Type type = (Type)RoutingTable[route];
            return this.frame.Navigate(type, parameter);
        }
        public void GoBack()    { this.frame.GoBack();                  }
        public void GoForward() { this.frame.GoForward();               }
        public bool CanGoBack   { get { return this.frame.CanGoBack; }  }
        #endregion
    }
}
