using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using OSVersionInfo;

namespace WPFluent.Composition
{
    public class HwndSystemMenuBehavior : Behavior<Window>
    {

        private const uint WP_SYSTEMMENU = 0x02;
        private const uint WM_SYSTEMMENU = 0xa4;

        private const uint DEF_SYSTEMMENU = 165;

      
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            HideSystemMenu();
        }

        private void HideSystemMenu()
        {
            IntPtr windIntPtr = new WindowInteropHelper(AssociatedObject).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(windIntPtr);
            hwndSource.AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (((msg == WM_SYSTEMMENU) && (wparam.ToInt32() == WP_SYSTEMMENU)) || msg == DEF_SYSTEMMENU)
            {

                handled = true;
            }
            return IntPtr.Zero;
        }

    }
}
