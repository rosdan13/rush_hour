using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;


namespace Rush_Hour
{
    public class Vehicle: Highlighted
    {
        public static Gameplay Gameplay;
        public Point Position { get; private set; }                  //המיקום ביחס ללוח
        public char Direction { get; private set; }
        public char Type { get; private set; }                       //סוג הרכב: מכונית או משאית
        private Color Color;
        private MaterialGroup Materials;                       //החומר המתאים לצבע של הרכב
        private bool IsClicked;
        private Model3DGroup Model3D { get;  set; }           //המודל התלת - ממדי של הרכב


        public Vehicle(int Y, int X, char Direction, char Type, Color Color)
        {
            Position = new Point(X, Y);
            this.Direction = Direction;
            this.Type = Type;
            this.Color = Color;

            
            BuildModel3D();
        }

        private void BuildModel3D()
        {
            IsClicked = false;                                           //בהתחלה הרכב אינו לחוץ
            IsHighlighted = false;                                       //בהתחלה הרכב אינו מואר
            AxisAngleRotation3D VehicleRotation;                        //טרנספורמציית הסיבוב של הרכב 
            double RotationAngle = 0;                                   //זווית הסיבוב של הרכב
            double OffsetX = -2.5, OffsetY = -2;                        //השיעורים הקבועים שיש להוסיף למיקום של הרכב כדי שהאובייקט יתקבל במיקום המתאים

         

            Materials = new MaterialGroup();                             //החומר של הרכב בצבע המתאים
            Materials.Children.Add(new DiffuseMaterial(new SolidColorBrush(Color)));
            Materials.Children.Add(new SpecularMaterial(new SolidColorBrush(Colors.White), 60));
            SolidColorBrush EmissiveBrush = new SolidColorBrush(Color);
            EmissiveBrush.Opacity = 0;
            Materials.Children.Add(new EmissiveMaterial(EmissiveBrush));


            if (Color == (Color)ColorConverter.ConvertFromString("#EB1F27"))                                 //יצירת המודל התלת - ממדי
            {
                Model3D = ((Model3DGroup)Gameplay.FindResource("RedCar")).Clone();
            }
            else
            {
                if (Type == 'C')

                {
                    Model3D = ((Model3DGroup)Gameplay.FindResource("Car")).Clone(); 
                }

                else
                {
                    Model3D = ((Model3DGroup)Gameplay.FindResource("Truck")).Clone();
                
                }          
            }
            ProjectTools.SetMaterial(Model3D, Materials);        //הרכב מקבל את החומר המתאים



            switch (Direction)
            {
                case 'R':
                    {
                        RotationAngle = 90;
                        OffsetX += 0.5;
                        OffsetY -= 0.5;
                        if (Type == 'T')
                            OffsetX += 0.5;
            
                    }
                    break;

                case 'L':
                    {
                        RotationAngle = 270;
                        OffsetX += 0.5;
                        OffsetY -= 0.5;
                        if (Type == 'T')
                            OffsetX += 0.5;
                    }
                    break;

                case 'U':
                    {
                        RotationAngle = 180;
                        if (Type == 'T')
                            OffsetY += 0.5;
                    }

                    break;

                case 'D':
                    {
                        RotationAngle = 0;
                        if (Type == 'T')
                            OffsetY += 0.5;
                    }
                    break;


            }

            VehicleRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), RotationAngle);
            ((Transform3DGroup)Model3D.Transform).Children.Add(new RotateTransform3D (VehicleRotation));

            ((Transform3DGroup)Model3D.Transform).Children.Add(new TranslateTransform3D(OffsetX + Position.X, 0, OffsetY + Position.Y));


            Gameplay.Scene.Children.Add(Model3D);
        }

        public void Transform(int X, int Y)
        {
       
            DoubleAnimation TransformAnimationX = new DoubleAnimation();
            DoubleAnimation TransformAnimationY = new DoubleAnimation();
            int OffsetSquares = 1, NumOfSquaresX = (int)(X - Position.X), NumOfSquaresY = (int)(Y - Position.Y);                           //מספר משבצות שיש להפחית ממיקום היעד בשל אורכו של הרכב
            if (Type == 'T')
            {
                OffsetSquares++;
            }

            ((Transform3DGroup)Model3D.Transform).Children.Add(new TranslateTransform3D());

      

            if (NumOfSquaresY != 0)
            {
                
                TransformAnimationY.From = 0;
                TransformAnimationY.To = NumOfSquaresY;
                TransformAnimationY.Duration = TimeSpan.FromMilliseconds(Math.Abs((int)TransformAnimationY.To * 250));
                

                Position = new Point(X, Y);

                if (NumOfSquaresY > 0)
                {
                    TransformAnimationY.To -= OffsetSquares;
                    TransformAnimationY.Duration = TimeSpan.FromMilliseconds(Math.Abs((int)TransformAnimationY.To * 250));
                    Position = new Point(X, Y - OffsetSquares);
                }
                
                ((Transform3DGroup)Model3D.Transform).Children[((Transform3DGroup)Model3D.Transform).Children.Count - 1].BeginAnimation(TranslateTransform3D.OffsetZProperty, TransformAnimationY);
            }
            else if (NumOfSquaresX != 0)
            {
              
                TransformAnimationX.From = 0;
                TransformAnimationX.To = NumOfSquaresX;
                TransformAnimationX.Duration = TimeSpan.FromMilliseconds(Math.Abs((int)TransformAnimationX.To * 250));

                Position = new Point(X, Y);

                if (NumOfSquaresX > 0)
                {
                    TransformAnimationX.To -= OffsetSquares;
                    TransformAnimationX.Duration = TimeSpan.FromMilliseconds(Math.Abs((int)TransformAnimationX.To * 250));
                    Position = new Point(X - OffsetSquares, Y);
                }

                ((Transform3DGroup)Model3D.Transform).Children[((Transform3DGroup)Model3D.Transform).Children.Count - 1].BeginAnimation(TranslateTransform3D.OffsetXProperty, TransformAnimationX);
            }

            if (Color == (Color)ColorConverter.ConvertFromString("#EB1F27") && X == 5 && Y == 2)
            {
                TransformCompleted(TransformAnimationX.Duration.TimeSpan);
            }

        }

        private void TransformCompleted(TimeSpan BeginTime)
        {
            DoubleAnimation ResetCamera = new DoubleAnimation(), VehicleAnimation = new DoubleAnimation(), CongratulationsOpacity = new DoubleAnimation(), MainMenuOpacity = new DoubleAnimation();
            Point3DAnimationUsingKeyFrames CameraPosition = new Point3DAnimationUsingKeyFrames();
            Vector3DAnimation CameraLookDirection = new Vector3DAnimation();

            GameBoard.CompleteLevel();

            Gameplay.HUD.Visibility = Visibility.Hidden;

            ResetCamera.Duration = TimeSpan.FromMilliseconds(Math.Max(Math.Abs(Gameplay.SceneHorizontalRotation.Angle), Math.Abs(Gameplay.SceneVerticalRotation.Angle)) * 20);

            ResetCamera.From = Gameplay.SceneHorizontalRotation.Angle;
            ResetCamera.To = 0;
            
            ResetCamera.BeginTime = BeginTime;
            Gameplay.SceneHorizontalRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, ResetCamera);

            ResetCamera.From = Gameplay.SceneVerticalRotation.Angle;
            ResetCamera.To = 0;
            ResetCamera.BeginTime = BeginTime;
            Gameplay.SceneVerticalRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, ResetCamera);

            CameraPosition.BeginTime = BeginTime + ResetCamera.Duration.TimeSpan;
            CameraPosition.KeyFrames.Add(new SplinePoint3DKeyFrame(new Point3D(1.85, 1.71, -0.65), TimeSpan.FromSeconds(3)));
            CameraPosition.KeyFrames.Add(new LinearPoint3DKeyFrame(new Point3D(3.85, 1.71, -0.65), TimeSpan.FromSeconds(5)));


            CameraLookDirection.From = Gameplay.Camera.LookDirection;
            CameraLookDirection.To = new Vector3D(1, 0, 0);
            CameraLookDirection.Duration = TimeSpan.FromSeconds(3);
            CameraLookDirection.BeginTime = BeginTime + ResetCamera.Duration.TimeSpan;

            Gameplay.Camera.BeginAnimation(PerspectiveCamera.PositionProperty, CameraPosition);
            Gameplay.Camera.BeginAnimation(PerspectiveCamera.LookDirectionProperty, CameraLookDirection);

            VehicleAnimation.By = 2;
            VehicleAnimation.Duration = TimeSpan.FromSeconds(2);
            VehicleAnimation.BeginTime = TimeSpan.FromSeconds(3) + CameraPosition.BeginTime;

            VehicleAnimation.Completed += VehicleAnimationCompleted;
            ((Transform3DGroup)Model3D.Transform).Children.Add(new TranslateTransform3D());
            ((TranslateTransform3D)((Transform3DGroup)Model3D.Transform).Children[((Transform3DGroup)Model3D.Transform).Children.Count - 1]).BeginAnimation(TranslateTransform3D.OffsetXProperty, VehicleAnimation);

            
            
            CongratulationsOpacity.From = 0;
            CongratulationsOpacity.To = 1;
            CongratulationsOpacity.Duration = TimeSpan.FromSeconds(3);
            CongratulationsOpacity.BeginTime = CameraPosition.BeginTime + TimeSpan.FromSeconds(5);
            Gameplay.Congratulations1.BeginAnimation(TextBlock.OpacityProperty, CongratulationsOpacity);
            Gameplay.Congratulations2.BeginAnimation(TextBlock.OpacityProperty, CongratulationsOpacity);

            MainMenuOpacity.From = 0;
            MainMenuOpacity.To = 1;
            MainMenuOpacity.Duration = TimeSpan.FromSeconds(2);
            MainMenuOpacity.BeginTime = CongratulationsOpacity.BeginTime + TimeSpan.FromSeconds(3.5);
            Gameplay.MainMenuTextBlock.BeginAnimation(TextBlock.OpacityProperty, MainMenuOpacity);

            
        }

        private void VehicleAnimationCompleted(object sender, EventArgs e)
        {
            Gameplay.CompletionCanvas.Visibility = Visibility.Visible;
        }

        public override bool Contains(GeometryModel3D Model)       //בדיקה האם הרכב מכיל את המודל הנתון
        {
            return ProjectTools.HasModel(Model3D, Model);
        }

        public override void MouseOn()
        {
            if (!IsHighlighted && !IsClicked)
            {
                DoubleAnimation HighlightAnimation = new DoubleAnimation();
                HighlightAnimation.From = ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.Opacity;
                HighlightAnimation.To = 0.3;
                HighlightAnimation.Duration = TimeSpan.FromMilliseconds(250);
                ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.BeginAnimation(Brush.OpacityProperty, HighlightAnimation);
                IsHighlighted = true;
            }
            
        }

        public override void MouseOff()
        {
            if (IsHighlighted && !IsClicked)
            {
                DoubleAnimation HighlightAnimation = new DoubleAnimation();
                HighlightAnimation.From = ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.Opacity;
                HighlightAnimation.To = 0;
                HighlightAnimation.Duration = TimeSpan.FromMilliseconds(250);
                ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.BeginAnimation(Brush.OpacityProperty, HighlightAnimation);
                IsHighlighted = false;
            }
               
        }

        public override void MouseClick()
        {
            if (IsHighlighted && !IsClicked)
            {
                ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.BeginAnimation(Brush.OpacityProperty, null);
                ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.Opacity = 0.6;
                IsClicked = true;
            }
        }

        public void MouseRelease()
        {
            if (IsClicked)
            {
                ((EmissiveMaterial)Materials.Children[Materials.Children.Count - 1]).Brush.Opacity = 0;
                IsClicked = false;
            }
        }


    }
}
