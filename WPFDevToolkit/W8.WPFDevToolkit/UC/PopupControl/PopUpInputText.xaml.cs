using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W8.WPFDevToolkit.UC.PopupControl.Lib;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace W8.WPFDevToolkit.UC.PopupControl
{
    public sealed partial class PopUpInputText : UserControl, IPopupControl
    {
        #region Properties
        private Popup m_popup;
        public class Popup : PopupHelperWithResult<string, PopUpInputText>
        {
        }
        #endregion

        #region Constructors
        public PopUpInputText()
        {
            this.InitializeComponent();
        }
        #endregion

        #region IPopupControl Methods
        public void SetParent(PopupHelper parent)
        {
            m_popup = (Popup)parent;
        }
        public void Closed(PopupCloseAction closeAction) { }
        public void Opened() { }
        #endregion

        #region ButtonEvents
        private void CancelResult(object sender, RoutedEventArgs e)
        {
            m_popup.Result = null;
            var dummy = m_popup.CloseAsync();
        }
        private void AcceptResult(object sender, RoutedEventArgs e)
        {
            m_popup.Result = resultTextBox.Text;
            var dummy = m_popup.CloseAsync();
        }
        #endregion        
    }
}
