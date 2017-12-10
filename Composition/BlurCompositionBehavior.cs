using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using OSVersionInfo;

namespace WPFluent.Composition
{
    internal enum AccentState
    {
        ACCENT_DISABLED = 1,
        ACCENT_ENABLE_GRADIENT = 0,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }

    public class BlurCompositionBehavior : Behavior<Window>
    {
        private bool _isBlurEnabled = false;

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        protected override void OnAttached()
        {
            base.OnAttached();

            if (OsCurrentInfo.IsWin10.HasValue && OsCurrentInfo.IsWin10.Value)
                AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (_isBlurEnabled)
                AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!_isBlurEnabled)
                EnableBlur();
        }

        internal void EnableBlur()
        {
            var windowHelper     = new WindowInteropHelper(AssociatedObject);

            var accent           = new AccentPolicy { AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND};

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr        = Marshal.AllocHGlobal(accentStructSize);

            Marshal.StructureToPtr(accent, accentPtr, false);

            var data             = new WindowCompositionAttributeData
            {
                Attribute        = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                SizeOfData       = accentStructSize,
                Data             = accentPtr
            };
            
            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            _isBlurEnabled = true;

            Marshal.FreeHGlobal(accentPtr);
        }
    }
}
