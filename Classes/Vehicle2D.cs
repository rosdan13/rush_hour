using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Navigation;
using System.Windows.Resources;


namespace Rush_Hour
{
    public class Vehicle2D
    {
        public static MainWindow MainWindow;
        private int X, Y, Color;
        private char Direction;
        private Image Model2D;



        public Vehicle2D(int Y, int X, int Color, char Direction)
        {
            this.X = X;
            this.Y = Y;
            this.Color = Color;
            this.Direction = Direction;

            BuildModel2D();
        }

        private void BuildModel2D()
        {
            TransformGroup ModelTransforms = new TransformGroup();
            RotateTransform Rotation;
            double OffsetX = 0, OffsetY = 0;
            Model2D = new Image();
            Model2D.Source = ((Image)MainWindow.FindResource("Vehicle" + Color.ToString())).Source;
            

           
            
            switch (Direction)
            {
                case 'R':
                    {
                        Rotation = new RotateTransform(270, 0, 0);
                        OffsetY = 128;
                        ModelTransforms.Children.Add(Rotation);
                    }
                    break;

                case 'L':
                    {
                        Rotation = new RotateTransform(90, 0, 0);
                        OffsetX = 256;
                        if (Color > 11)
                        { OffsetX += 128; }
                        ModelTransforms.Children.Add(Rotation);
                    }
                    break;

                case 'U':
                    {
                        Rotation = new RotateTransform(180, 0, 0);
                        OffsetX = 128;
                        OffsetY = 256;
                        if (Color > 11)
                        { OffsetY += 128; }
                        ModelTransforms.Children.Add(Rotation);
                    }

                    break;

            }

            ModelTransforms.Children.Add(new TranslateTransform(OffsetX + X * 128, OffsetY + Y * 128));
            Model2D.RenderTransform = ModelTransforms;
        }

        public Image GetImage()
        {          
            return Model2D;
        }
    }
}
