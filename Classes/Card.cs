using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Rush_Hour
{
    public class Card
    {
        public static MainWindow MainWindow;
        private int Level;
        private Canvas CardCanvas;
        private Vehicle2D[] Vehicles;
        private TextBlock DifficultyBar, LevelNumberRed, LevelNumberBlack;

        public Card(int Level)
        {
            Image CardImage = new Image();
            TransformGroup CardImageTransform = new TransformGroup();
            int X, Y, Color;
            char Direction;
            string CurrentVehicle;

            this.Level = Level;
            CardCanvas = new Canvas();
            CardCanvas.Name = "Card" + Level.ToString();
            DifficultyBar = new TextBlock();
            LevelNumberRed = new TextBlock();
            LevelNumberBlack = new TextBlock();

            CardImage.Source = ((Image)MainWindow.FindResource("CardImage")).Source;
            CardImageTransform.Children.Add(new ScaleTransform(1.335, 1.335));
            CardImage.RenderTransform = CardImageTransform;
            CardCanvas.Children.Add(CardImage);



           
                Vehicles = new Vehicle2D[Levels.LevelsArray[Level - 1].Length];

                for (int i = 0; i < Levels.LevelsArray[Level - 1].Length; i++)
                {
                    CurrentVehicle = Levels.LevelsArray[Level - 1][i];
                    X = (int)char.GetNumericValue(CurrentVehicle[0]);
                    Y = (int)char.GetNumericValue(CurrentVehicle[1]);
                    Color = int.Parse(CurrentVehicle[4].ToString(), NumberStyles.AllowHexSpecifier);
                    Direction = CurrentVehicle[2];

                    Vehicles[i] = new Vehicle2D(X, Y, Color, Direction);
                    Canvas.SetTop(Vehicles[i].GetImage(), 310);
                    Canvas.SetLeft(Vehicles[i].GetImage(), 128);

                    CardCanvas.Children.Add(Vehicles[i].GetImage());
                }
            

            DifficultyBar.FontFamily = new FontFamily("Aharoni");
            DifficultyBar.FontSize = 60;
            DifficultyBar.Width = 1029;
            DifficultyBar.Height = 150;
            DifficultyBar.TextAlignment = TextAlignment.Center;
            DifficultyBar.Padding = new Thickness(50);

            if (Level <= 10)
            {
                DifficultyBar.Background = new SolidColorBrush(Colors.Green);
                DifficultyBar.Text = "BEGINNER";
            }
            else if (Level <= 20)
            {
                DifficultyBar.Background = new SolidColorBrush(Colors.Orange);
                DifficultyBar.Text = "INTERMEDIATE";
            }
            else if (Level <= 30)
            {
                DifficultyBar.Background = new SolidColorBrush(Colors.MediumBlue);
                DifficultyBar.Text = "ADVANCED";
            }
            else if (Level <= 40)
            {
                DifficultyBar.Background = new SolidColorBrush(Colors.Red);
                DifficultyBar.Text = "EXPERT";
            }

            Canvas.SetTop(DifficultyBar, 1461);
            CardCanvas.Children.Add(DifficultyBar);

            LevelNumberBlack.Text = Level.ToString();
            LevelNumberBlack.FontFamily = new FontFamily("Aharoni");
            LevelNumberBlack.FontSize = 180;
            LevelNumberBlack.FontStretch = FontStretches.Expanded;
            LevelNumberBlack.FontStyle = FontStyles.Oblique;
            LevelNumberBlack.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetTop(LevelNumberBlack, 1210);
            Canvas.SetLeft(LevelNumberBlack, 60);
            CardCanvas.Children.Add(LevelNumberBlack);

            LevelNumberRed.Text = Level.ToString();
            LevelNumberRed.FontFamily = new FontFamily("Aharoni");
            LevelNumberRed.FontSize = 180;
            LevelNumberRed.FontStretch = FontStretches.Expanded;
            LevelNumberRed.FontStyle = FontStyles.Oblique;
            LevelNumberRed.Foreground = new SolidColorBrush(Colors.Red);
            Canvas.SetTop(LevelNumberRed, 1200);
            Canvas.SetLeft(LevelNumberRed, 50);
            CardCanvas.Children.Add(LevelNumberRed);



        }

        public Canvas GetCard()
        {
            return CardCanvas;
        }
    }
}
