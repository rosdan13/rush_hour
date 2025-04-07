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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rush_Hour
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : Page
    {
        public Gameplay()
        {
            InitializeComponent();
            BuildLevel.Gameplay = this;
            SceneCamera.Gameplay = this;
            Vehicle.Gameplay = this;
            BuildLevel.Start();

            ProjectTools.ApplyResolutionToElements(this.Content as Panel);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
          
            Point MouseCursor = e.GetPosition(Viewport);
            RayMeshGeometry3DHitTestResult Result = VisualTreeHelper.HitTest(Viewport, MouseCursor) as RayMeshGeometry3DHitTestResult;


            if (Result.ModelHit is GeometryModel3D && !GameBoard.IsLevelCompleted && MessageBox.Visibility == Visibility.Hidden)
                GameBoard.MouseMoveHighlight(Result.ModelHit as GeometryModel3D);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point MouseCursor = e.GetPosition(Viewport);
            RayMeshGeometry3DHitTestResult Result = VisualTreeHelper.HitTest(Viewport, MouseCursor) as RayMeshGeometry3DHitTestResult;

            if (Result.ModelHit is GeometryModel3D && !GameBoard.IsLevelCompleted && MessageBox.Visibility == Visibility.Hidden)
            {
               GameBoard.MouseClick(Result.ModelHit as GeometryModel3D);

            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat && !GameBoard.IsLevelCompleted && MessageBox.Visibility == Visibility.Hidden)
            {
                if (e.Key == Key.W || e.Key == Key.S || e.Key == Key.A || e.Key == Key.D)
                {
                    SceneCamera.Rotate(e);
                }
                else if (e.Key == Key.C)
                {
                    SceneCamera.Reset();
                }
            }



        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!GameBoard.IsLevelCompleted && MessageBox.Visibility == Visibility.Hidden)
            {
                if (e.Key == Key.W || e.Key == Key.S || e.Key == Key.A || e.Key == Key.D)
                {
                    SceneCamera.Rotate(e);
                }
            }
                       
        }

        private void ViewportLoaded(object sender, RoutedEventArgs e)
        {

            Viewport.Focusable = true;
            Keyboard.Focus(Viewport);
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!GameBoard.IsLevelCompleted && MessageBox.Visibility == Visibility.Hidden)
            {
                SceneCamera.Zoom(e);
            }
              
        }

        private void MainMenuOnMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (CompletionCanvas.Opacity == 1)
            {
                Size.From = 80;
                Size.To = 90;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 510;
                Top.To = 505;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 745;
                Left.To = 718;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                MainMenuTextBlock.BeginAnimation(TextBlock.FontSizeProperty, Size);
                MainMenuTextBlock.BeginAnimation(Canvas.TopProperty, Top);
                MainMenuTextBlock.BeginAnimation(Canvas.LeftProperty, Left);
            }
           
        }

        private void MainMenuOnMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (CompletionCanvas.Opacity == 1)
            {
                Size.From = 90;
                Size.To = 80;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 505;
                Top.To = 510;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 718;
                Left.To = 745;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                MainMenuTextBlock.BeginAnimation(TextBlock.FontSizeProperty, Size);
                MainMenuTextBlock.BeginAnimation(Canvas.TopProperty, Top);
                MainMenuTextBlock.BeginAnimation(Canvas.LeftProperty, Left);
            }
           
        }

        private void MainMenuOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CompletionCanvas.Opacity == 1)
            {
            PageSwitch.Switch(new MainMenu());
            }
        }

        private void QuitMouseEnter(object sender, MouseEventArgs e)
        {
            
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (MessageBox.Visibility == Visibility.Hidden)
            {
                Size.From = 70;
                Size.To = 80;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 30;
                Top.To = 25;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 30;
                Left.To = 25;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((Image)sender).BeginAnimation(Image.WidthProperty, Size);
                ((Image)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((Image)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
            
        }

        private void QuitMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (MessageBox.Visibility == Visibility.Hidden)
            {
                Size.From = 80;
                Size.To = 70;
                Size.Duration = TimeSpan.FromSeconds(0.3);

                Top.From = 25;
                Top.To = 30;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 25;
                Left.To = 30;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((Image)sender).BeginAnimation(Image.WidthProperty, Size);
                ((Image)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((Image)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }


        }

        private void QuitMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Visibility == Visibility.Hidden)
            {
                MessageBox.Visibility = Visibility.Visible;
                V.Visibility = Visibility.Visible;
                X.Visibility = Visibility.Visible;
            }
                
        }

        private void ImageMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((Image)sender).Name == "V")
            {
                Size.From = 64;
                Size.To = 75;

                Top.From = 440;
                Top.To = 435;

                Left.From = 825;
                Left.To = 820;
            }
            else
            {
                Size.From = 50;
                Size.To = 61;

                Top.From = 448;
                Top.To = 443;

                Left.From = 1045;
                Left.To = 1040;
            }

            Size.Duration = TimeSpan.FromSeconds(0.3);
            Top.Duration = TimeSpan.FromSeconds(0.3);
            Left.Duration = TimeSpan.FromSeconds(0.3);

            ProjectTools.ApplyResolutionToAnimations(Top, Left);

            ((Image)sender).BeginAnimation(Image.WidthProperty, Size);
            ((Image)sender).BeginAnimation(Canvas.TopProperty, Top);
            ((Image)sender).BeginAnimation(Canvas.LeftProperty, Left);
        }

        private void ImageMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((Image)sender).Name == "V")
            {
                Size.From = 75;
                Size.To = 64;

                Top.From = 435;
                Top.To = 440;

                Left.From = 820;
                Left.To = 825;
            }
            else
            {
                Size.From = 61;
                Size.To = 50;

                Top.From = 443;
                Top.To = 448;

                Left.From = 1040;
                Left.To = 1045;
            }

            Size.Duration = TimeSpan.FromSeconds(0.3);
            Top.Duration = TimeSpan.FromSeconds(0.3);
            Left.Duration = TimeSpan.FromSeconds(0.3);

            ProjectTools.ApplyResolutionToAnimations(Top, Left);

            ((Image)sender).BeginAnimation(Image.WidthProperty, Size);
            ((Image)sender).BeginAnimation(Canvas.TopProperty, Top);
            ((Image)sender).BeginAnimation(Canvas.LeftProperty, Left);
        }

        private void ImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((Image)sender).Name == "V")
            {
                PageSwitch.Switch(new MainMenu());
            }
            else
            {
                MessageBox.Visibility = Visibility.Hidden;
                V.Visibility = Visibility.Hidden;
                X.Visibility = Visibility.Hidden;
            }
        }
    }
}
