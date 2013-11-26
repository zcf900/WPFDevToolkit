using System;

namespace W8.WPFDevToolkit.UC.PopupControl.Lib
{
    [Flags]
    public enum PopupAnimation
    {
        ControlFlip = 0x1,
        ControlFlyoutRight = 0x2,

        OverlayFade = 0x1 << 16,
    }

    internal static partial class EnumExtensions
    {
        public static bool IsFlagOn(this PopupAnimation value, PopupAnimation flag)
        {
            return (value & flag) == flag;
        }
    }
}
