using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCL.WPFDevToolkit.Services.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// object param is Type on WS Apps and Uri in WP Apps
        /// </summary>
        Dictionary<string, object> RoutingTable { get; set; }
        bool Navigate(string route);
        bool Navigate(string route, string parameter);

        void GoBack();
        void GoForward();
        bool CanGoBack { get; }
    }
}
