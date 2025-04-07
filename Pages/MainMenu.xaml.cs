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
using System.Windows.Media.Media3D;

namespace Rush_Hour
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public static MainWindow MainWindow;
        private static bool Loading = true;
        private static Canvas CanvasCard;
        private static Image V, X;

        public MainMenu()
        {
            InitializeComponent();
            ProjectTools.ApplyResolutionToElements(this.Content as Panel);
            BuildCard();
            BuildMessageBox();       
            
        }

        private void BuildCard()
        {
            double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;
            Card Card = new Card(1);
            Canvas CardCanvas = Card.GetCard();

            CanvasCard = CardCanvas;
            CanvasCard.RenderTransform = new ScaleTransform(WidthRatio * 0.5, HeightRatio * 0.5);
            Canvas.SetLeft(CanvasCard, 1203 * WidthRatio);
            Canvas.SetTop(CanvasCard, 179 * HeightRatio);

            ((Panel)Content).Children.Add(CanvasCard);
            
        }

        private void BuildMessageBox()
        {
            double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;
            Border MessageBox = (Border)Resources["MessageBox"];
            V = (Image)Resources["V"];
            X = (Image)Resources["X"];

            MessageBox.RenderTransform = new ScaleTransform(WidthRatio, HeightRatio);
            Canvas.SetLeft(MessageBox, Canvas.GetLeft(MessageBox) * WidthRatio);
            Canvas.SetTop(MessageBox, Canvas.GetTop(MessageBox) * HeightRatio);

            V.RenderTransform = new ScaleTransform(WidthRatio, HeightRatio);
            Canvas.SetLeft(V, Canvas.GetLeft(V) * WidthRatio);
            Canvas.SetTop(V, Canvas.GetTop(V) * HeightRatio);

            X.RenderTransform = new ScaleTransform(WidthRatio, HeightRatio);
            Canvas.SetLeft(X, Canvas.GetLeft(X) * WidthRatio);
            Canvas.SetTop(X, Canvas.GetTop(X) * HeightRatio);

            ((Panel)Content).Children.Add(MessageBox);
            ((Panel)Content).Children.Add(V);
            ((Panel)Content).Children.Add(X);

        }

        private void TextBlockMouseEnter(object sender, MouseEventArgs e)
        {
            if (!Loading && V.Visibility == Visibility.Hidden)
            {
                DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();
                string Name = ((TextBlock)sender).Name;


                Size.From = 80;
                Size.To = 90;
                Size.Duration = TimeSpan.FromSeconds(0.3);


                switch (Name)
                {
                    case "Start":
                        Top.From = 350;
                        Left.To = 64;
                        break;
                    case "HowToPlay":
                        Top.From = 465;
                        Left.To = 45;
                        break;
                    case "Options":
                        Top.From = 580;
                        Left.To = 57;
                        break;
                    case "About":
                        Top.From = 695;
                        Left.To = 61;
                        break;
                    case "Exit":
                        Top.From = 810;
                        Left.To = 66;
                        break;
                }

                Top.To = Top.From - 5;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.From = 75;
                Left.Duration = TimeSpan.FromSeconds(0.3);


                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
            
        }

        private void TextBlockMouseLeave(object sender, MouseEventArgs e)
        {

            if (!Loading && V.Visibility == Visibility.Hidden)
            {
                DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();
                string Name = ((TextBlock)sender).Name;


                Size.From = 90;
                Size.To = 80;
                Size.Duration = TimeSpan.FromSeconds(0.3);


                switch (Name)
                {
                    case "Start":
                        Top.To = 350;
                        Left.From = 64;
                        break;
                    case "HowToPlay":
                        Top.To = 465;
                        Left.From = 45;
                        break;
                    case "Options":
                        Top.To = 580;
                        Left.From = 57;
                        break;
                    case "About":
                        Top.To = 695;
                        Left.From = 61;
                        break;
                    case "Exit":
                        Top.To = 810;
                        Left.From = 66;
                        break;
                }

                Top.From = Top.To - 5;
                Top.Duration = TimeSpan.FromSeconds(0.3);

                Left.To = 75;
                Left.Duration = TimeSpan.FromSeconds(0.3);

                ProjectTools.ApplyResolutionToAnimations(Top, Left);

                ((TextBlock)sender).BeginAnimation(TextBlock.FontSizeProperty, Size);
                ((TextBlock)sender).BeginAnimation(Canvas.TopProperty, Top);
                ((TextBlock)sender).BeginAnimation(Canvas.LeftProperty, Left);
            }
                
        }

        private void TextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!Loading && V.Visibility == Visibility.Hidden)
            {
                Page DestinationPage = new Page();
                string Name = ((TextBlock)sender).Name;

                switch (Name)
                {
                    case "Start":
                        DestinationPage = new LevelSelect();
                        break;
                    case "HowToPlay":
                        DestinationPage = new HowToPlay();
                        break;
                    case "Options":
                        DestinationPage = new GameOptions();
                        break;
                    case "About":
                        DestinationPage = new About();
                        break;
                    case "Exit":
                        DestinationPage = null;
                        break;
                }

                if (DestinationPage != null)
                {
                    PageSwitch.Switch(DestinationPage);
                }
                else
                {
                    QuitGame();
                }
            }
                
        }

        private void QuitGame()
        {
            ((Border)Resources["MessageBox"]).Visibility = Visibility.Visible;
            V.Visibility = Visibility.Visible;
            X.Visibility = Visibility.Visible;
        }

        private void ImageMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation Size = new DoubleAnimation(), Top = new DoubleAnimation(), Left = new DoubleAnimation();

            if (((Image)sender) == V)
            {
                Size.From = 128;
                Size.To = 150;

                Top.From = 510;
                Top.To = 499;

                Left.From = 700;
                Left.To = 689;
            }
            else
            {
                Size.From = 100;
                Size.To = 122;

                Top.From = 530;
                Top.To = 519;

                Left.From = 1120;
                Left.To = 1109;
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

            if (((Image)sender) == V)
            {
                Size.From = 150;
                Size.To = 128;

                Top.From = 499;
                Top.To = 510;

                Left.From = 689;
                Left.To = 700;
            }
            else
            {
                Size.From = 122;
                Size.To = 100;

                Top.From = 519;
                Top.To = 530;

                Left.From = 1109;
                Left.To = 1120;
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
            if (((Image)sender) == V)
            {
                MainWindow.Quit();
            }
            else
            {
                ((Border)Resources["MessageBox"]).Visibility = Visibility.Hidden;
                V.Visibility = Visibility.Hidden;
                X.Visibility = Visibility.Hidden;
            }
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {

            if (Loading)
            {
                double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;
                DoubleAnimation PressMouseAnimation = new DoubleAnimation();

                PressMouse.Visibility = Visibility.Visible;

                PressMouseAnimation.By = -1;
                PressMouseAnimation.Duration = TimeSpan.FromSeconds(1);
                PressMouseAnimation.AutoReverse = true;
                PressMouseAnimation.RepeatBehavior = RepeatBehavior.Forever;

                PressMouse.BeginAnimation(TextBlock.OpacityProperty, PressMouseAnimation);

                foreach (UIElement Element in ThisCanvas.Children)
                {
                    if (Element is Image && Element != V && Element != X)
                    {
                        Canvas.SetLeft(Element, 510 * WidthRatio);
                    }
                    else if (Element is TextBlock && Element != PressMouse)
                    {
                        Element.Opacity = 0;
                    }
                    else if (Element is Canvas)
                    {
                        Canvas.SetLeft(Element, 780 * WidthRatio);
                        Canvas.SetTop(Element, 300 * HeightRatio);
                        Element.RenderTransform = new ScaleTransform(WidthRatio * 0.35, HeightRatio * 0.35);
                    }
                }

                
            }
            
            
        }

      

        

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Loading && PressMouse.Visibility == Visibility.Visible)
            {
                double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;
                DoubleAnimation ImageAnimation = new DoubleAnimation(), TextBlockAnimation = new DoubleAnimation(), CardAnimation = new DoubleAnimation();

                PressMouse.Visibility = Visibility.Hidden;

                foreach (UIElement Element in ThisCanvas.Children)
                {
                    if (Element is Image && Element != V && Element != X)
                    {
                      
                        ImageAnimation.By = -510 * WidthRatio;
                        ImageAnimation.Duration = TimeSpan.FromSeconds(2);
                        Element.BeginAnimation(Canvas.LeftProperty, ImageAnimation);

                    }
                    else if (Element is TextBlock && Element != PressMouse)
                    {
                        
                        TextBlockAnimation.By = 1;
                        TextBlockAnimation.Duration = TimeSpan.FromSeconds(2);
                        TextBlockAnimation.BeginTime = TimeSpan.FromSeconds(2);
                        TextBlockAnimation.Completed += AnimationCompleted;
                        Element.BeginAnimation(TextBlock.OpacityProperty, TextBlockAnimation);
                    }
                    else if (Element is Canvas)
                    {
                        CardAnimation.By = 500 * WidthRatio;
                        CardAnimation.Duration = TimeSpan.FromSeconds(2);
                        CardAnimation.Completed += LeftAnimationCompleted;
                        Element.BeginAnimation(Canvas.LeftProperty, CardAnimation);


                        CardAnimation = new DoubleAnimation();
                        CardAnimation.From = WidthRatio * 0.35;
                        CardAnimation.To = WidthRatio * 0.5;
                        CardAnimation.Duration = TimeSpan.FromSeconds(1.5);
                        CardAnimation.BeginTime = TimeSpan.FromSeconds(2);

                        ((ScaleTransform)Element.RenderTransform).BeginAnimation(ScaleTransform.ScaleXProperty, CardAnimation);

                        CardAnimation = new DoubleAnimation();
                        CardAnimation.From = HeightRatio * 0.35;
                        CardAnimation.To = HeightRatio * 0.5;
                        CardAnimation.Duration = TimeSpan.FromSeconds(1.5);
                        CardAnimation.BeginTime = TimeSpan.FromSeconds(2);

                        ((ScaleTransform)Element.RenderTransform).BeginAnimation(ScaleTransform.ScaleYProperty, CardAnimation);

                        CardAnimation = new DoubleAnimation();
                        CardAnimation.By = -121;
                        CardAnimation.Duration = TimeSpan.FromSeconds(1.5);
                        CardAnimation.BeginTime = TimeSpan.FromSeconds(2);

                        Element.BeginAnimation(Canvas.TopProperty, CardAnimation);


                    }
                }
            }
        }

        private void AnimationCompleted(object sender, EventArgs e)
        {
            Loading = false;
        }

        private void LeftAnimationCompleted(object sender, EventArgs e)
        {
            DoubleAnimation CardAnimation = new DoubleAnimation();

            CardAnimation.By = -77;
            CardAnimation.Duration = TimeSpan.FromSeconds(1.5);

            CanvasCard.BeginAnimation(Canvas.LeftProperty, CardAnimation);
        }
    }
}
