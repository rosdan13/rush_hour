using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Rush_Hour
{
    public static class Settings
    {
        public static bool Environment { get; private set; }
        public static double ResolutionHeight { get; private set; }
        public static double ResolutionWidth { get; private set; }
        public static Color SquaresColor { get; private set; }

        static Settings()
        {
            Environment = true;          
            SquaresColor = Colors.Blue;
        }

        public static void SetResolution(double Height, double Width)
        {
            ResolutionHeight = Height;
            ResolutionWidth = Width;
        }

        public static void SetEnvironment(bool Boolean)
        {
            Environment = Boolean;
        }

        public static void SetSquaresColor(Color Color)
        {
            SquaresColor = Color;
        }
    }
}
