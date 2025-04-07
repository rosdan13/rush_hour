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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Globalization;

namespace Rush_Hour
{
    public static class BuildLevel
    {
        public static Gameplay Gameplay;
        public static byte CurrentLevel;
        public static readonly string[] HexColors = { "#EB1F27", "#E328FE", "#27DDFD", "#F1D898", "#A5F8EF", "#CB9BE5", "#FFA025", "#FF549F",
                                                      "#865E50", "#70B0C5", "#2FC233", "#C9FF3E", "#5249E9", "#80FF7B", "#F455EA", "#FFFF54" };

        public static void Start()
        {
            BuildSquares();

            if (Settings.Environment)
            {
                Gameplay.Scene.Children.Add(Gameplay.Resources["Environment"] as Model3DGroup);
                BuildTable();
                BuildCar();
            }

            LoadLevel();
            
            

        }

        private static void BuildSquares()
        {
            double offsetX = -2.5, offsetZ = -2.5;
            Model3DGroup LowerSquare, SquareModel;
            Square UpperSquare;

            for (int r = 0; r < 7; r++)                             //יצירת הריבועים השטוחים
            {
                for (int c = 0; c < 7; c++)
                {
                    LowerSquare = new Model3DGroup();
                    LowerSquare.Children.Add((GeometryModel3D)Gameplay.FindResource("LowerSquare"));
                    LowerSquare.Transform = new TranslateTransform3D(offsetX - 0.5 + c, 0, offsetZ - 0.5 + r);
                    Gameplay.Scene.Children.Add(LowerSquare);
                }
            }

            for (int r = 0; r < 6; r++)                            //יצירת המשבצות העליונות
            {
                for (int c = 0; c < 6; c++)
                {                
                    SquareModel = new Model3DGroup();
                    SquareModel.Children.Add(((GeometryModel3D)Gameplay.FindResource("UpperSquare")).Clone());
                    SquareModel.Transform = new TranslateTransform3D(offsetX + c, 0, offsetZ + r);

                    UpperSquare = new Square(SquareModel);
                    GameBoard.AddSquare(UpperSquare, r, c);               
                    Gameplay.Scene.Children.Add(SquareModel);
                    
                }
            }
               
           
        }

        private static void BuildTable()
        {
            double Angle = 0;
            MeshGeometry3D RoundMesh = Gameplay.Resources["RoundMesh"] as MeshGeometry3D;
            Point CurrentPoint = new Point(Math.Cos(Angle), Math.Sin(Angle));

            RoundMesh.Positions.Add(new Point3D(CurrentPoint.X, 1, CurrentPoint.Y));
            RoundMesh.Normals.Add(new Vector3D(0, 1, 0));
            RoundMesh.TextureCoordinates.Add(new Point(CurrentPoint.X / 2 + 0.5, CurrentPoint.Y / 2 + 0.5));

            RoundMesh.Positions.Add(new Point3D(CurrentPoint.X, 0, CurrentPoint.Y));
            RoundMesh.Normals.Add(new Vector3D(CurrentPoint.X, 0, CurrentPoint.Y));
            RoundMesh.TextureCoordinates.Add(new Point(0, Angle / (2 * Math.PI)));

            RoundMesh.Positions.Add(new Point3D(CurrentPoint.X, 1, CurrentPoint.Y));
            RoundMesh.Normals.Add(new Vector3D(CurrentPoint.X, 0, CurrentPoint.Y));
            RoundMesh.TextureCoordinates.Add(new Point(1, Angle / (2 * Math.PI)));

            while (Angle < Math.PI * 2)
            {
                Angle += Math.PI / 18;

                CurrentPoint = new Point(Math.Cos(Angle), Math.Sin(Angle));

              
        

                RoundMesh.Positions.Add(new Point3D(CurrentPoint.X, 1, CurrentPoint.Y));
                RoundMesh.Normals.Add(new Vector3D(0, 1, 0));
                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 1);
                RoundMesh.TextureCoordinates.Add(new Point(CurrentPoint.X / 2 + 0.5, CurrentPoint.Y / 2 + 0.5));

                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 4);

                RoundMesh.TriangleIndices.Add(0);                                     //הגדרת המשולש העליון


                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 3);

                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 2);

                RoundMesh.Positions.Add(new Point3D(CurrentPoint.X, 0, CurrentPoint.Y));
                RoundMesh.Normals.Add(new Vector3D(CurrentPoint.X, 0, CurrentPoint.Y));
                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 1);
                RoundMesh.TextureCoordinates.Add(new Point(0, Angle / (2 * Math.PI)));          //הגדרת אחד מהמשולשים הצדדיים


                RoundMesh.Positions.Add(new Point3D(CurrentPoint.X, 1, CurrentPoint.Y));
                RoundMesh.Normals.Add(new Vector3D(CurrentPoint.X, 0, CurrentPoint.Y));
                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 1);
                RoundMesh.TextureCoordinates.Add(new Point(1, Angle / (2 * Math.PI)));

                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 2);

                RoundMesh.TriangleIndices.Add(RoundMesh.Positions.Count - 4);           //הגדרת אחד מהמשולשים הצדדיים
            }
        }

        private static void BuildCar()
        {
            Model3DGroup Model3D;
            MaterialGroup Materials = new MaterialGroup();

            
                Model3D = ((Model3DGroup)Gameplay.FindResource("RedCar")).Clone();
                Model3D.Transform = new Transform3DGroup();
                ((Transform3DGroup)Model3D.Transform).Children.Add(new ScaleTransform3D(0.1, 0.1, 0.1));
                ((Transform3DGroup)Model3D.Transform).Children.Add(new TranslateTransform3D(-80, -14, -100));

            

            Materials.Children.Add(new DiffuseMaterial(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EB1F27"))));
            Materials.Children.Add(new SpecularMaterial(new SolidColorBrush(Colors.White), 60));
            ProjectTools.SetMaterial(Model3D, Materials);         //הרכב מקבל את החומר המתאים



            Gameplay.Scene.Children.Add(Model3D);

        }

        private static void LoadLevel()
        {
            Vehicle[] VehiclesArray = new Vehicle[Levels.LevelsArray[CurrentLevel - 1].Length];
            Card LevelCard = new Card(CurrentLevel);
            string CurrentVehicle;
            int X, Y, Color;
            char Direction, Type;

            for (int i = 0; i < Levels.LevelsArray[CurrentLevel - 1].Length; i++)
            {
                CurrentVehicle = Levels.LevelsArray[CurrentLevel - 1][i];

                X = (int)char.GetNumericValue(CurrentVehicle[0]);
                Y = (int)char.GetNumericValue(CurrentVehicle[1]);
                Direction = CurrentVehicle[2];
                Type = CurrentVehicle[3];
                Color = int.Parse(CurrentVehicle[4].ToString(), NumberStyles.AllowHexSpecifier);

                VehiclesArray[i] = new Vehicle(X, Y, Direction, Type, (Color)ColorConverter.ConvertFromString(HexColors[Color]));
            }

            GameBoard.AddVehicles(VehiclesArray);
            Gameplay.CardContent.Material = new DiffuseMaterial(new VisualBrush(LevelCard.GetCard()));
        }

    }
}
