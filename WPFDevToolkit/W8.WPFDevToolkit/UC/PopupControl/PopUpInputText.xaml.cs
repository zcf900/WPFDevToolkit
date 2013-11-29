using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W8.WPFDevToolkit.UC.PopupControl.Lib;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
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
        public VMPopUpInputText layoutValues;
        #endregion

        #region Constructors
        public PopUpInputText()
        {
            layoutValues = new VMPopUpInputText();
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
        private async void AcceptResult(object sender, RoutedEventArgs e)
        {

            var result = resultTextBox.Text;
            if (string.IsNullOrEmpty(result))
            {
                string title = "Error";
                string message = "TextBox can not be null or empty";
                if (!string.IsNullOrEmpty(layoutValues.ErrorEmptyTitle)) title = layoutValues.ErrorEmptyTitle;
                if (!string.IsNullOrEmpty(layoutValues.ErrorEmptyMessage)) message = layoutValues.ErrorEmptyMessage;
                MessageDialog messageDialog = new MessageDialog(message, title);
                await messageDialog.ShowAsync();
                return;
            }
            if (result.Equals(layoutValues.DefaultNoValidResult))
            {
                string title = "Error";
                string message = "TextBox can not be dafault value";
                if (!string.IsNullOrEmpty(layoutValues.ErrorEmptyTitle)) title = layoutValues.ErrorDafaultTitle;
                if (!string.IsNullOrEmpty(layoutValues.ErrorEmptyMessage)) message = layoutValues.ErrorEmptyMessage;
                MessageDialog messageDialog = new MessageDialog(message, title);
                await messageDialog.ShowAsync();
            }
            m_popup.Result = result;
            var dummy = m_popup.CloseAsync();
        }
        #endregion

        #region Class
        public class Popup : PopupHelperWithResult<string, PopUpInputText>
        {
        }
        public class VMPopUpInputText
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string SuggestedResult { get; set; }
            public string DefaultNoValidResult { get; set; }
            public string AcceptButtonContent { get; set; }
            public string CancelButtonContent { get; set; }
            public Color PopupBackgroundColor { get; set; }
            public Color PopupForegroundColor { get; set; }
            public Color TextBoxForegroundColor { get; set; }
            public Color SuggestedPopupForegroundColor { get; set; }
            public Color PopupBackBackgroundColor { get; set; }

            public string ErrorEmptyTitle { get; set; }
            public string ErrorEmptyMessage { get; set; }
            public string ErrorDafaultTitle { get; set; }
            public string ErrorDafaultMessage { get; set; }
        }
        #endregion

        #region Other
        public void UpdateLayoutValues()
        {

            if (!string.IsNullOrEmpty(layoutValues.Title)) txtTitle.Text = layoutValues.Title;
            if (!string.IsNullOrEmpty(layoutValues.Description)) txtDescription.Text = layoutValues.Description;

            if (!string.IsNullOrEmpty(layoutValues.SuggestedResult)) resultTextBox.Text = layoutValues.SuggestedResult;
            else if (!string.IsNullOrEmpty(layoutValues.DefaultNoValidResult)) resultTextBox.Text = layoutValues.DefaultNoValidResult;
            if (!layoutValues.PopupBackgroundColor.Equals(default(Color)))
            {
                this.Resources["PopupBackground"] = new SolidColorBrush(layoutValues.PopupBackgroundColor);
                mainGrid.Background = this.Resources["PopupBackground"] as SolidColorBrush;
            }
            if (!layoutValues.PopupForegroundColor.Equals(default(Color)))
            {
                txtTitle.Foreground = new SolidColorBrush(layoutValues.PopupForegroundColor);
                txtDescription.Foreground = new SolidColorBrush(layoutValues.PopupForegroundColor);
                resultTextBox.Background = new SolidColorBrush(layoutValues.PopupForegroundColor);
                resultTextBox.BorderBrush = new SolidColorBrush(layoutValues.PopupForegroundColor);
                btnCancel.Foreground = new SolidColorBrush(layoutValues.PopupForegroundColor);
                btnCancel.BorderBrush = new SolidColorBrush(layoutValues.PopupForegroundColor);
                btnAccept.Foreground = new SolidColorBrush(layoutValues.PopupForegroundColor);
                btnAccept.BorderBrush = new SolidColorBrush(layoutValues.PopupForegroundColor);
            }
            if (!layoutValues.SuggestedPopupForegroundColor.Equals(default(Color)))
            {
                btnAccept.Background = new SolidColorBrush(layoutValues.SuggestedPopupForegroundColor);
            }
            if (!layoutValues.TextBoxForegroundColor.Equals(default(Color)))
            {
                resultTextBox.Foreground = new SolidColorBrush(layoutValues.TextBoxForegroundColor);
            }
            if (!layoutValues.PopupBackBackgroundColor.Equals(default(Color)))
            {
                backGrid.Background = new SolidColorBrush(layoutValues.PopupBackBackgroundColor);
            }
        }
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Enter)) AcceptResult(null, null);
            base.OnKeyDown(e);
        }
        #endregion

        private void mainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (e.PreviousSize.Height > 0)
            {
                var screenHeight = Window.Current.Bounds.Height;

                resultTextBox.MaxHeight = screenHeight - 320;
                var newBackGridHeight = backGrid.MaxHeight + (e.NewSize.Height - e.PreviousSize.Height);
                if (newBackGridHeight < screenHeight)
                {
                    backGrid.MaxHeight += e.NewSize.Height - e.PreviousSize.Height;
                }
                else
                {
                }
            }
        }
    }
}
