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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Rush_Hour
{
    /// <summary>
    /// Interaction logic for HowToPlay.xaml
    /// </summary>
    public partial class HowToPlay : Page
    {
        public HowToPlay()
        {
            InitializeComponent();

            ProjectTools.ApplyResolutionToElements(this.Content as Panel);
        }

        private void OnBackMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();


            Size.From = 50;
            Size.To = 60;
            Size.Duration = TimeSpan.FromSeconds(0.3);

            Top.From = 30;
            Top.To = 25;
            Top.Duration = TimeSpan.FromSeconds(0.3);

            Left.From = 30;
            Left.To = 19;
            Left.Duration = TimeSpan.FromSeconds(0.3);

            ProjectTools.ApplyResolutionToAnimations(Top, Left);

            ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
            ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
            ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
        }

        private void OnBackMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();


            Size.From = 60;
            Size.To = 50;
            Size.Duration = TimeSpan.FromSeconds(0.3);

            Top.From = 25;
            Top.To = 30;
            Top.Duration = TimeSpan.FromSeconds(0.3);

            Left.From = 19;
            Left.To = 30;
            Left.Duration = TimeSpan.FromSeconds(0.3);

            ProjectTools.ApplyResolutionToAnimations(Top, Left);

            ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
            ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
            ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);

        }

        private void OnBackMouseDown(object sender, MouseButtonEventArgs e)
        {
            PageSwitch.Switch(new MainMenu());
        }
    }
}
