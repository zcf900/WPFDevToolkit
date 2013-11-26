using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using PCL.WPFDevToolkit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.PCL.WPFDevToolkit.Common
{
    public class CommonCommands
    {
        #region NavigateCommand
        private RelayCommand<string> _navigateCommand;
        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand ?? (_navigateCommand = new RelayCommand<string>(ExecuteNavigateCommand));
            }
        }
        private void ExecuteNavigateCommand(string parameter)
        {
            var _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            _navigationService.Navigate(parameter);
        }
        #endregion
    }
}
