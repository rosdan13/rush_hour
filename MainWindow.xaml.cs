using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Rush_Hour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StreamResourceInfo AppCursor = Application.GetResourceStream(new Uri("Resources/Cursor.cur", UriKind.Relative));
            Cursor = new Cursor(AppCursor.Stream);

            PageSwitch.MainWindow = this;
            MainMenu.MainWindow = this;
            Card.MainWindow = this;
            Vehicle2D.MainWindow = this;

            Settings.SetResolution( SystemParameters.PrimaryScreenHeight, SystemParameters.PrimaryScreenWidth);

           
            Navigate(new MainMenu());
        }

        public void Navigate(Page NewPage)
        {
            Content = NewPage;
        }

        public void Quit()
        {
            this.Close();
        }

      
    }
}
