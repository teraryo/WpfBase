using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfBase
{
    public static class NavigationService
    {
        internal static void Navigate(Type type ,params dynamic[] param)
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                var types = new Type[param.Length];
                for (int i = 0; i < param.Length; i++)
                {
                    var t = param[0];
                    types[i] = t.GetType();
                }
                var cons = type.GetConstructor(types);
                if (cons == null) return;
                var page = cons.Invoke(param);
                MainWindow.Navigate(page);
            });
        }
        internal static void Navigate(Type type, ViewModelBase vm)
        {
            MainWindow.Dispatcher.Invoke(() =>
            {           
                var cons = type.GetConstructor(new Type[]{});
                if (cons == null) return;
                var page = cons.Invoke(new object[] { });
                ((Page) page).DataContext = vm;
                MainWindow.Navigate(page);
            });
        }

        public static NavigationWindow MainWindow { get; set; }
    }
}
