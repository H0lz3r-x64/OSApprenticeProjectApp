using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace WpfApplication.Utilities
{
    internal class WindowBlurEffect
    {
        [DllImport("user32.dll")]
        internal static extern void SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private uint _blurOpacity;
        public double BlurOpacity
        {
            get { return _blurOpacity; }
            set { _blurOpacity = (uint)value; EnableBlur(); }
        }

        private uint _blurBackgroundColor = 0x000000;
        public SolidColorBrush BlurBackgroundFromSolidColorBrush
        {
            get
            {
                Color color = Color.FromArgb((byte)((_blurBackgroundColor & 0xFF000000) >> 24), (byte)((_blurBackgroundColor & 0x00FF0000) >> 16),
                             (byte)((_blurBackgroundColor & 0x0000FF00) >> 8), (byte)(_blurBackgroundColor & 0x000000FF));
                return new SolidColorBrush(color);
            }
            set
            {
                SolidColorBrush brush = (SolidColorBrush)value;
                _blurBackgroundColor = (uint)((brush.Color.A << 24) | (brush.Color.R << 16) | (brush.Color.G << 8) | brush.Color.B); EnableBlur();
            }
        }

        public string BlurBackgroundFromHex
        {
            get { return string.Format("{0:X6}", _blurBackgroundColor); }
            set { _blurBackgroundColor = Convert.ToUInt32(value.Replace("#", ""), 16); EnableBlur(); }
        }

        private Window _window { get; set; }
        private AccentState _accentState { get; set; }

        internal void EnableBlur()
        {
            var accent = new AccentPolicy();
            accent.AccentState = _accentState;
            accent.GradientColor = (_blurOpacity << 24) | (_blurBackgroundColor & 0xFFFFFF);

            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(new WindowInteropHelper(_window).Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        internal WindowBlurEffect(Window window, AccentState accentState)
        {
            _window = window;
            _accentState = accentState;
            EnableBlur();
        }

        public void DisableBlur()
        {
            var windowHelper = new WindowInteropHelper(_window);
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_DISABLED;

            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
    }
}
