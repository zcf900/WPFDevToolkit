using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sample.PCL.WPFDevToolkit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.PCL.WPFDevToolkit.ViewModels
{
    public class VMUserControlsBase : ViewModelBase
    {
        #region Services

        #endregion

        #region Properties

        #endregion

        #region Constructors
        public VMUserControlsBase()
        {
        }
        #endregion

        #region Commands
        #region CommonCommands
        private CommonCommands _commonCommands = new CommonCommands();
        public CommonCommands CommonCommands { get { return _commonCommands; } set { Set("CommonCommands", ref _commonCommands, value); } }
        #endregion        
        #endregion
    }
}
