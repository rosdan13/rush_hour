using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Rush_Hour
{
    public class Square: Highlighted
    {
        private Model3DGroup SquareGeometry;                //המודל התלת-ממדי של המשבצת
        public bool IsAvailable { get; set; }              //האם המשבצת פנויה
        public bool IsRelevant { get; private set; }        //האם המשבצת רלוונטית והרכב יכול לנסוע עליה
       


        
        public Square(Model3DGroup Model)
        {
            SquareGeometry = Model;
            IsAvailable = true;
            IsHighlighted = false;
            IsRelevant = false;
        }

        public void MakeRelevant()                   //יצירת ריבוע מואר רלוונטי לנסיעת הרכב
        {
            IsRelevant = true;
            GeometryModel3D Highlighted = ((GeometryModel3D)SquareGeometry.Children[0]).Clone();
            Highlighted.Material = new EmissiveMaterial(new SolidColorBrush(Settings.SquaresColor));
            SquareGeometry.Children.Add(Highlighted);          
        }

        public void MakeSpecialRelevant()
        {
            IsRelevant = true;
            GeometryModel3D Highlighted = ((GeometryModel3D)SquareGeometry.Children[0]).Clone();
            Highlighted.Material = new EmissiveMaterial(new SolidColorBrush(Colors.Green));
            SquareGeometry.Children.Add(Highlighted);  
        }

        public void MakeIrrelevant()
        {
            if (IsRelevant)
            {
                IsRelevant = false;
                SquareGeometry.Children.RemoveAt(SquareGeometry.Children.Count - 1);
            }
        }

        public override void MouseOn()                    //שינוי צבע לריבוע הרלוונטי במקרה שהעכבר עומד על המשבצת
        {
            if (IsRelevant && !IsHighlighted)
            {
                
                GeometryModel3D Highlighted = ((GeometryModel3D)SquareGeometry.Children[SquareGeometry.Children.Count - 1]);
                EmissiveMaterial Material = (EmissiveMaterial)Highlighted.Material;
                SolidColorBrush Brush = (SolidColorBrush)Material.Brush;
                if (Brush.Color == Colors.Blue)
                {
                    Brush.Color = Colors.MidnightBlue;
                }
                else if (Brush.Color == Colors.Red)
                {
                    Brush.Color = (Color)ColorConverter.ConvertFromString("#FFFF1010");
                }
                else if (Brush.Color == Colors.Green)
                {
                    Brush.Color = Colors.ForestGreen;
                }
                
                IsHighlighted = true;
            }
        }
        
        public override void MouseOff()                //החזרת הצבע של הריבוע הרלוונטי למצבו הקודם כאשר העכבר עוזב את המשבצת
        {
            if (IsRelevant && IsHighlighted)
            {
                GeometryModel3D Highlighted = ((GeometryModel3D)SquareGeometry.Children[SquareGeometry.Children.Count - 1]);
                EmissiveMaterial Material = (EmissiveMaterial)Highlighted.Material;
                SolidColorBrush Brush = (SolidColorBrush)Material.Brush;
                if (Brush.Color == Colors.MidnightBlue)
                {
                    Brush.Color = Colors.Blue;
                }
                else if (Brush.Color == (Color)ColorConverter.ConvertFromString("#FFFF1010"))
                {
                    Brush.Color = Colors.Red;
                }
                else if (Brush.Color == Colors.ForestGreen)
                {
                    Brush.Color = Colors.Green;
                }
           
                IsHighlighted = false;
            }
        }

        public override void MouseClick()
        {
            if (IsHighlighted && IsRelevant)
            {
                SquareGeometry.Children.RemoveAt(SquareGeometry.Children.Count - 1);
                IsHighlighted = false;
                IsRelevant = false;
            }

        }

        public override bool Contains(GeometryModel3D Model)       //בדיקה האם המשבצת מכילה את המודל הנתון
        {
            return ProjectTools.HasModel(SquareGeometry, Model);
        }

    }
}
