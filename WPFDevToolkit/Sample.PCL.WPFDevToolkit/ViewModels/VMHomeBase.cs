using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PCL.WPFDevToolkit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.PCL.WPFDevToolkit.ViewModels
{
    public class VMHomeBase : ViewModelBase
    {
        #region Properties
        protected INavigationService _navigationService;
        #endregion

        #region Constructors
        public VMHomeBase(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }        
        #endregion

        #region Commands
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
            _navigationService.Navigate(parameter);
        }
        #endregion
        #endregion
    }
}
