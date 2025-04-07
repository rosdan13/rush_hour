using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Rush_Hour
{
    public static class PageSwitch
    {
        public static MainWindow MainWindow;
        private static Page CurrentPage;

        public static void Switch(Page NewPage)
        {
            MainWindow.Navigate(NewPage);
            CurrentPage = NewPage;
        }
    }
}
