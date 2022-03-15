using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using static WPF_Shortcut_Glassmorphism.AcrylicBlur;

namespace WPF_Shortcut_Glassmorphism
{
    class WindowBlurEffect
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
        internal static void EnableBlur(Window window)
        {
            WindowInteropHelper windowHelper = new(window);
            AccentPolicy accent = new();


            //To enable blur behind the window
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            WindowCompositionAttributeData data = new();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
        internal WindowBlurEffect(Window window) => EnableBlur(window);

    }
}
