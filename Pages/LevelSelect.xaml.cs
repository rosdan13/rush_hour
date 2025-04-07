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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rush_Hour
{
    /// <summary>
    /// Interaction logic for LevelSelect.xaml
    /// </summary>
    public partial class LevelSelect : Page
    {
        public LevelSelect()
        {
            Card CurrentCard;
            Canvas CardCanvas, TableCanvas;
            double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;


            InitializeComponent();

            ProjectTools.ApplyResolutionToElements(this.Content as Panel);

            for (int r = 1; r < LevelsGrid.RowDefinitions.Count - 1; r++)
            {
                for (int c = 0; c < LevelsGrid.ColumnDefinitions.Count; c++)
                {
                    CurrentCard = new Card((r - 1) * 10 + c + 1);
                    CardCanvas = CurrentCard.GetCard();

                    for (int i = 0; i < CardCanvas.Children.Count; i++)
                    {
                        if (CardCanvas.Children[i].RenderTransform is TransformGroup)
                        {
                            ((TransformGroup)CardCanvas.Children[i].RenderTransform).Children.Add(new ScaleTransform(0.11235955 * WidthRatio, 0.11235955 * HeightRatio));
                        }
                        else
                        {
                            CardCanvas.Children[i].RenderTransform = new ScaleTransform(0.11235955 * WidthRatio, 0.11235955 * HeightRatio);
                        }

                        Canvas.SetTop(CardCanvas.Children[i], 0.11235955 * Canvas.GetTop(CardCanvas.Children[i]) * HeightRatio);
                        Canvas.SetLeft(CardCanvas.Children[i], 0.11235955 * Canvas.GetLeft(CardCanvas.Children[i]) * WidthRatio);
                    }

                    TableCanvas = new Canvas();
                    Canvas.SetTop(CardCanvas, 11.59736842105 * HeightRatio);
                    Canvas.SetLeft(CardCanvas, 37.33333333333 * WidthRatio);
                    TableCanvas.Children.Add(CardCanvas);

                    Grid.SetRow(TableCanvas, r);
                    Grid.SetColumn(TableCanvas, c);

                    CardCanvas.MouseEnter += CanvasMouseEnter;
                    CardCanvas.MouseLeave += CanvasMouseLeave;
                    CardCanvas.MouseDown += CanvasMouseDown;

                    LevelsGrid.Children.Add(TableCanvas);

                    
                }
            }

            



        }

        
        

        private void CanvasMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation LiftCard = new DoubleAnimation();
            LiftCard.Duration = TimeSpan.FromSeconds(0.25);
            LiftCard.From = 11.59736842105;
            LiftCard.To = 2;

            ProjectTools.ApplyResolutionToAnimations(LiftCard, new DoubleAnimation());

            ((Canvas)sender).BeginAnimation(Canvas.TopProperty, LiftCard);
         
        }

        private void CanvasMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation LiftCard = new DoubleAnimation();
            LiftCard.Duration = TimeSpan.FromSeconds(0.25);
            LiftCard.From = 2;
            LiftCard.To = 11.59736842105;

            ProjectTools.ApplyResolutionToAnimations(LiftCard, new DoubleAnimation());

            ((Canvas)sender).BeginAnimation(Canvas.TopProperty, LiftCard);
        }

        private void CanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            BuildLevel.CurrentLevel = byte.Parse(((Canvas)sender).Name.Substring(4));
            PageSwitch.Switch(new Gameplay());
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
