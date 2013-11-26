using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W8.WPFDevToolkit.UC.PopupControl;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sample.W8.WPFDevToolkit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopUpInputText.Popup();
            var popupHelper = (PopupHelper)popup;
            var control = (PopUpInputText)popupHelper.Control;
            control.layoutValues.Title = "Introduce tu peso(Kg):";
            control.UpdateLayoutValues();
            var result = await popup.ShowAsync();
        }
    }
}
