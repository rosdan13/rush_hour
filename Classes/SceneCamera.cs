using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

using System.Windows.Threading;

namespace Rush_Hour
{
    public static class SceneCamera
    {
        public static Gameplay Gameplay;
        private static Key HorizontalKey = Key.None, VerticalKey = Key.None;
        private static DoubleAnimation HorizontalAnimation, VerticalAnimation;
        private static AnimationClock HorizontalClock = null, VerticalClock = null;
       

        public static void Rotate(KeyEventArgs e)
        {
        
          if (e.Key == Key.A || e.Key == Key.D)
            {
               
                    HorizontalRotation(e);
                
                
            }
          else if (e.Key == Key.W || e.Key == Key.S)
            {
               
                    VerticalRotation(e);
               
                
            }
        }

        private static void HorizontalRotation(KeyEventArgs e)
        {
            double CurrentValue;
 
            if (e.IsDown && HorizontalKey == Key.None)
            {
                HorizontalKey = e.Key;

                if (e.Key == Key.D)
                {
                    HorizontalAnimation = Gameplay.Resources["RotationRight"] as DoubleAnimation;          
                }
                else if (e.Key == Key.A)
                {
                    HorizontalAnimation = Gameplay.Resources["RotationLeft"] as DoubleAnimation;
                }

                HorizontalClock = HorizontalAnimation.CreateClock();
                Gameplay.SceneHorizontalRotation.ApplyAnimationClock(AxisAngleRotation3D.AngleProperty, HorizontalClock);
            }
            else
            {
                if (e.IsUp && e.Key == HorizontalKey)
                {
                    CurrentValue = HorizontalAnimation.GetCurrentValue(0, 0, HorizontalClock);
                    Gameplay.SceneHorizontalRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, null);
                    Gameplay.SceneHorizontalRotation.Angle += CurrentValue;
                    HorizontalKey = Key.None;
                }
                
               
            }

            


        }

        private static void VerticalRotation(KeyEventArgs e)
        {
            double CurrentValue;

            if (e.IsDown && VerticalKey == Key.None)
            {
                VerticalKey = e.Key;

                if (e.Key == Key.W)
                {
                    VerticalAnimation = Gameplay.Resources["RotationUp"] as DoubleAnimation;
                    VerticalAnimation.By = 45 - Gameplay.SceneVerticalRotation.Angle;
                    VerticalAnimation.Duration = TimeSpan.FromSeconds((Math.Abs((double)VerticalAnimation.By / 45)));
                }
                else if (e.Key == Key.S)
                {
                    VerticalAnimation = Gameplay.Resources["RotationDown"] as DoubleAnimation;
                    VerticalAnimation.By = -44 - Gameplay.SceneVerticalRotation.Angle;
                    VerticalAnimation.Duration = TimeSpan.FromSeconds(Math.Abs((double)VerticalAnimation.By / 44));
                }

                VerticalClock = VerticalAnimation.CreateClock();
                Gameplay.SceneVerticalRotation.ApplyAnimationClock(AxisAngleRotation3D.AngleProperty, VerticalClock);
            }
            else if (e.IsUp && e.Key == VerticalKey)
            {
                CurrentValue = VerticalAnimation.GetCurrentValue(0, 0, VerticalClock);
                Gameplay.SceneVerticalRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, null);
                Gameplay.SceneVerticalRotation.Angle += CurrentValue;
                VerticalKey = Key.None;
            }
        }

        public static void Zoom(MouseWheelEventArgs e)
        {
            Point3DAnimation ZoomAnimationPosition = new Point3DAnimation();
            ZoomAnimationPosition.Duration = TimeSpan.FromMilliseconds(250);            

            if (e.Delta > 0 && Gameplay.Camera.Position.Y > 6 && Gameplay.Camera.Position.Z > 6)
            {
                if (Gameplay.Camera.Position.Y >= 18 && Gameplay.Camera.Position.Z >= 18)
                {
                    ZoomAnimationPosition.By = new Point3D(0, -12, -12);
                }
                else
                {
                    ZoomAnimationPosition.By = new Point3D(0, 6 - Gameplay.Camera.Position.Y, 6 - Gameplay.Camera.Position.Z);
                }
             
                Gameplay.Camera.BeginAnimation(PerspectiveCamera.PositionProperty, ZoomAnimationPosition);
            
            }
            else if (e.Delta < 0 && Gameplay.Camera.Position.Y < 192 && Gameplay.Camera.Position.Z <192)
            {
                if (Gameplay.Camera.Position.Y <= 180 && Gameplay.Camera.Position.Z <= 180)
                {
                    ZoomAnimationPosition.By = new Point3D(0, 12, 12);
                }
                else
                {
                    ZoomAnimationPosition.By = new Point3D(0, 192 - Gameplay.Camera.Position.Y, 192 - Gameplay.Camera.Position.Z);
                }
                
            
                Gameplay.Camera.BeginAnimation(PerspectiveCamera.PositionProperty, ZoomAnimationPosition);
            
            }     
        }

        public static void Reset()
        {
            Gameplay.Camera.BeginAnimation(PerspectiveCamera.PositionProperty, null);
            Gameplay.Camera.Position = new Point3D (0,18,18);
            Gameplay.SceneHorizontalRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, null);
            Gameplay.SceneHorizontalRotation.Angle = 0;
            Gameplay.SceneVerticalRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, null);
            Gameplay.SceneVerticalRotation.Angle = 0;
        }
    }
}
