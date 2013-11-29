using GalaSoft.MvvmLight.Command;
using Sample.PCL.WPFDevToolkit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W8.WPFDevToolkit.UC.PopupControl;
using W8.WPFDevToolkit.UC.PopupControl.Lib;
using Windows.UI;

namespace Sample.W8.WPFDevToolkit.ViewModels
{
    public class VMUserControls : VMUserControlsBase
    {
        #region Services

        #endregion

        #region Properties
        private string _userName;
        public string UserName { get { return _userName; } set { Set("UserName", ref _userName, value); } }
        #endregion

        #region Constructors
        public VMUserControls()
        {
        }
        #endregion

        #region Commands
        #region PopUpInputTextCommand
        private RelayCommand<string> _popUpInputTextCommand;
        public RelayCommand<string> PopUpInputTextCommand
        {
            get
            {
                return _popUpInputTextCommand ?? (_popUpInputTextCommand = new RelayCommand<string>(ExecutePopUpInputTextCommand));
            }
        }
        private async void ExecutePopUpInputTextCommand(string parameter)
        {
            var popup = new PopUpInputText.Popup();
            var popupHelper = (PopupHelper)popup;
            var control = (PopUpInputText)popupHelper.Control;
            control.layoutValues.Title = "Introduce tu nombre";
            control.layoutValues.Description = "Introduce tu nombre sin apellidos con la primera letra en mayúscula.";
            //control.layoutValues.PopupBackgroundColor = Colors.Olive;
            //control.layoutValues.PopupForegroundColor = Colors.LightSalmon;
            //control.layoutValues.SuggestedPopupForegroundColor = Colors.OrangeRed;
            //control.layoutValues.TextBoxForegroundColor = Colors.Black;
            //control.layoutValues.PopupBackBackgroundColor = Colors.White;
            control.UpdateLayoutValues();
            UserName = await popup.ShowAsync();
        }
        #endregion
        #endregion
    }
}
