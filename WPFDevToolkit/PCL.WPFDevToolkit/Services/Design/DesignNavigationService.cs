using PCL.WPFDevToolkit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCL.WPFDevToolkit.Services.Design
{
    public class DesignNavigationService : INavigationService
    {
        public Dictionary<string, object> RoutingTable
        {
            get
            {
                return new Dictionary<string, object>();
            }
            set
            {
            }
        }

        public bool Navigate(string route)
        {
            return false;
        }

        public bool Navigate(string route, string parameter)
        {
            return false;
        }

        public void GoBack()
        {
        }

        public void GoForward()
        {
        }

        public bool CanGoBack
        {
            get { return false; }
        }
    }
}
