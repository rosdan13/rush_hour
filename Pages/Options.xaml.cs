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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class GameOptions : Page
    {
        public GameOptions()
        {
            InitializeComponent();

            ProjectTools.ApplyResolutionToElements(this.Content as Panel);
            ResolutionInfo.Text = Settings.ResolutionWidth.ToString() + "x" + Settings.ResolutionHeight.ToString();
            if (!Settings.Environment)
            {
                On.Foreground = new SolidColorBrush(Colors.Black);
                Off.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1F27"));
            }
            if (Settings.SquaresColor == Colors.Red)
            {
                Blue.Foreground = new SolidColorBrush(Colors.Black);
                Red.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1F27"));
            }
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

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Size.From = 65;
                Size.To = 75;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 500;
                Top.To = 495;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1100;
                Left.To = 1093;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }

            
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((TextBlock)sender).FontSize > 65)
            {
                Size.From = 75;
                Size.To = 65;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 495;
                Top.To = 500;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1093;
                Left.To = 1100;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
                
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Settings.SetEnvironment(true);
                On.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1F27"));
                Off.Foreground = new SolidColorBrush(Colors.Black);
            }
                
        }

        private void OffMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Size.From = 65;
                Size.To = 75;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 500;
                Top.To = 495;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1300;
                Left.To = 1293;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
        }

        private void OffMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((TextBlock)sender).FontSize > 65)
            {
                Size.From = 75;
                Size.To = 65;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 495;
                Top.To = 500;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1293;
                Left.To = 1300;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
        }
    }

        private void OffMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Settings.SetEnvironment(false);
                Off.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1F27"));
                On.Foreground = new SolidColorBrush(Colors.Black);                           
            }
        }

        private void BlueMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Size.From = 65;
                Size.To = 75;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 700;
                Top.To = 695;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1100;
                Left.To = 1093;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
        }

        private void BlueMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((TextBlock)sender).FontSize > 65)
            {
                Size.From = 75;
                Size.To = 65;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 695;
                Top.To = 700;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1093;
                Left.To = 1100;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
        }

        private void BlueMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Settings.SetSquaresColor(Colors.Blue);
                Blue.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1F27"));
                Red.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void RedMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Size.From = 65;
                Size.To = 75;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 700;
                Top.To = 695;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1300;
                Left.To = 1293;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
        }

        private void RedMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((TextBlock)sender).FontSize > 65)
            {
                Size.From = 75;
                Size.To = 65;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 695;
                Top.To = 700;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 1293;
                Left.To = 1300;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
        }

        private void RedMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((SolidColorBrush)((TextBlock)sender).Foreground).Color == Colors.Black)
            {
                Settings.SetSquaresColor(Colors.Red);
                Red.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1F27"));
                Blue.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}
