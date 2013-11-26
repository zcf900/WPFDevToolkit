using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W8.WPFDevToolkit.UC.PopupControl.Lib
{
    public interface IPopupControl
    {
        void SetParent(PopupHelper parent);
        void Closed(PopupCloseAction closeAction);
        void Opened();
    }
}
