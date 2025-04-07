using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Rush_Hour
{
    public static class ProjectTools
    {
        public static bool HasModel(Model3DGroup ModelGroup, GeometryModel3D Model)
        {
            bool IsFound = false;
            for (int i = 0; i < ModelGroup.Children.Count && !IsFound; i++)
            {
                if (ModelGroup.Children[i] is GeometryModel3D)
                {
                    IsFound = ModelGroup.Children[i] as GeometryModel3D == Model;
                }
                else if (ModelGroup.Children[i] is Model3DGroup)
                {
                    IsFound = HasModel(ModelGroup.Children[i] as Model3DGroup, Model);
                }
            }
            return IsFound;
        }

        public static void SetMaterial(Model3DGroup ModelGroup, MaterialGroup Materials)
        {
            for (int i = 0; i < ModelGroup.Children.Count; i++)
            {
                if (ModelGroup.Children[i] is GeometryModel3D)
                {
                    if (((GeometryModel3D)ModelGroup.Children[i]).Material == null)
                    {
                        ((GeometryModel3D)ModelGroup.Children[i]).Material = Materials;
                    }
                }
                else if (ModelGroup.Children[i] is Model3DGroup)
                {
                    SetMaterial(ModelGroup.Children[i] as Model3DGroup, Materials);
                }
            }
        }

        public static void ApplyResolutionToElements(Panel ThisPanel)
        {
            double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;

            if (WidthRatio != 1 || HeightRatio != 1)
            {
                foreach (UIElement Element in ThisPanel.Children)
                {
                    if (Element is Panel)
                    {
                        
                        Canvas.SetLeft(Element, Canvas.GetLeft(Element) * WidthRatio);
                        Canvas.SetTop(Element, Canvas.GetTop(Element) * HeightRatio);
                        ApplyResolutionToElements(Element as Panel);
                    }
                    else if (!(Element is Viewport3D))
                    {
                        Element.RenderTransform = new ScaleTransform(WidthRatio, HeightRatio);
                        Canvas.SetLeft(Element, Canvas.GetLeft(Element) * WidthRatio);
                        Canvas.SetTop(Element, Canvas.GetTop(Element) * HeightRatio);
                    }
                }
            }
            
        }

        public static void ApplyResolutionToAnimations(DoubleAnimation TopAnimation, DoubleAnimation LeftAnimation)
        {
            double WidthRatio = Settings.ResolutionWidth / 1920, HeightRatio = Settings.ResolutionHeight / 1080;

            if (WidthRatio != 1 || HeightRatio != 1)
            {
                TopAnimation.From *= HeightRatio;
                TopAnimation.To *= HeightRatio;

                LeftAnimation.From *= WidthRatio;
                LeftAnimation.To *= WidthRatio;
            }
                    
        }
    }
}
