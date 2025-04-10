﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rush_Hour
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Page
    {
        public About()
        {
            InitializeComponent();
            ProjectTools.ApplyResolutionToElements(this.Content as Panel);
        }
       

        private void OnAboutLoaded(object sender, RoutedEventArgs e)
        {
            LoadScene(this);
            
        }


        private static void LoadScene(About About)
        {
            Model3DGroup TabletBook = new Model3DGroup();
            DoubleAnimation BringBook = new DoubleAnimation(), OpenAnimation = new DoubleAnimation(), Hideios = new DoubleAnimation(), ShowCodeTora = new DoubleAnimation();
            Brush iosImage1, CodeImage, iosImage2, ToraImage;
            DiscreteStringKeyFrame LetterAnimation;
            StringAnimationUsingKeyFrames StringAnimation;
            string CurrentString, FullString;

            BringBook.By = -4.1;
            BringBook.Duration = TimeSpan.FromSeconds(5);

            OpenAnimation.By = -185;
            OpenAnimation.Duration = TimeSpan.FromSeconds(5);
            OpenAnimation.BeginTime = TimeSpan.FromSeconds(5);

            Hideios.By = -1;
            Hideios.Duration = TimeSpan.FromSeconds(2);
            Hideios.BeginTime = TimeSpan.FromSeconds(10);

            ShowCodeTora.By = 1;
            ShowCodeTora.Duration = TimeSpan.FromSeconds(2);
            ShowCodeTora.BeginTime = TimeSpan.FromSeconds(10);


            TabletBook.Children.Add(((Model3DGroup)About.FindResource("Tablet")).Clone());


            TabletBook.Children.Add(((Model3DGroup)About.FindResource("Tablet")).Clone());
            ((Transform3DGroup)TabletBook.Children[1].Transform).Children.Add(new TranslateTransform3D(0, 0.06, 0));


            TabletBook.Children.Add(((Model3DGroup)About.FindResource("Tablet")).Clone());
            ((Transform3DGroup)TabletBook.Children[2].Transform).Children.Add(new TranslateTransform3D(0, 0.12, 0));
            ((GeometryModel3D)((Model3DGroup)TabletBook.Children[2]).Children[((Model3DGroup)TabletBook.Children[2]).Children.Count - 1]).Material = ((MaterialGroup)About.FindResource("CodeScreen")).Clone();
            iosImage1 = ((DiffuseMaterial)((MaterialGroup)((GeometryModel3D)((Model3DGroup)TabletBook.Children[2]).Children[((Model3DGroup)TabletBook.Children[2]).Children.Count - 1]).Material).Children[1]).Brush;
            CodeImage = ((DiffuseMaterial)((MaterialGroup)((GeometryModel3D)((Model3DGroup)TabletBook.Children[2]).Children[((Model3DGroup)TabletBook.Children[2]).Children.Count - 1]).Material).Children[0]).Brush;


            TabletBook.Children.Add(((Model3DGroup)About.FindResource("Tablet")).Clone());
            ((Transform3DGroup)TabletBook.Children[3].Transform).Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 180)));
            ((Transform3DGroup)TabletBook.Children[3].Transform).Children.Add(new TranslateTransform3D(0, 0.24, 0));
            ((Transform3DGroup)TabletBook.Children[3].Transform).Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 0), new Point3D(0, 0.2, -0.9)));
            ((GeometryModel3D)((Model3DGroup)TabletBook.Children[3]).Children[((Model3DGroup)TabletBook.Children[3]).Children.Count - 1]).Material = ((MaterialGroup)About.FindResource("ToraScreen")).Clone();
            iosImage2 = ((DiffuseMaterial)((MaterialGroup)((GeometryModel3D)((Model3DGroup)TabletBook.Children[3]).Children[((Model3DGroup)TabletBook.Children[2]).Children.Count - 1]).Material).Children[1]).Brush;
            ToraImage = ((DiffuseMaterial)((MaterialGroup)((GeometryModel3D)((Model3DGroup)TabletBook.Children[3]).Children[((Model3DGroup)TabletBook.Children[2]).Children.Count - 1]).Material).Children[0]).Brush;


            TabletBook.Children.Add(((Model3DGroup)About.FindResource("Tablet")).Clone());
            ((Transform3DGroup)TabletBook.Children[4].Transform).Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 180)));
            ((Transform3DGroup)TabletBook.Children[4].Transform).Children.Add(new TranslateTransform3D(0, 0.3, 0));
            ((Transform3DGroup)TabletBook.Children[4].Transform).Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 0), new Point3D(0, 0.2, -0.94)));


            TabletBook.Children.Add(((Model3DGroup)About.FindResource("Tablet")).Clone());
            ((Transform3DGroup)TabletBook.Children[5].Transform).Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 180)));
            ((Transform3DGroup)TabletBook.Children[5].Transform).Children.Add(new TranslateTransform3D(0, 0.36, 0));
            ((Transform3DGroup)TabletBook.Children[5].Transform).Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 0), new Point3D(0, 0.2, -0.98)));
            ((GeometryModel3D)((Model3DGroup)TabletBook.Children[5]).Children[0]).Material = About.FindResource("Logo") as MaterialGroup;


            About.BookScene.Children.Add(TabletBook);


            TabletBook.Transform = new TranslateTransform3D(4.1,0,0);

            ((TranslateTransform3D)TabletBook.Transform).BeginAnimation(TranslateTransform3D.OffsetXProperty, BringBook);

            ((AxisAngleRotation3D)((RotateTransform3D)((Transform3DGroup)TabletBook.Children[3].Transform).Children[((Transform3DGroup)TabletBook.Children[3].Transform).Children.Count - 1]).Rotation).BeginAnimation(AxisAngleRotation3D.AngleProperty, OpenAnimation);
            ((AxisAngleRotation3D)((RotateTransform3D)((Transform3DGroup)TabletBook.Children[4].Transform).Children[((Transform3DGroup)TabletBook.Children[4].Transform).Children.Count - 1]).Rotation).BeginAnimation(AxisAngleRotation3D.AngleProperty, OpenAnimation);
            ((AxisAngleRotation3D)((RotateTransform3D)((Transform3DGroup)TabletBook.Children[5].Transform).Children[((Transform3DGroup)TabletBook.Children[5].Transform).Children.Count - 1]).Rotation).BeginAnimation(AxisAngleRotation3D.AngleProperty, OpenAnimation);

            iosImage1.BeginAnimation(Brush.OpacityProperty, Hideios);
            iosImage2.BeginAnimation(Brush.OpacityProperty, Hideios);
            CodeImage.BeginAnimation(Brush.OpacityProperty, ShowCodeTora);
            ToraImage.BeginAnimation(Brush.OpacityProperty, ShowCodeTora);

            foreach (TextBlock TextBlock in About.Text.Children)
            {
                if (TextBlock != About.Back)
                {
                    StringAnimation = new StringAnimationUsingKeyFrames();
                    StringAnimation.Duration = TimeSpan.FromSeconds(TextBlock.Text.Length * 0.08);
                    StringAnimation.BeginTime = TimeSpan.FromSeconds(12);

                    FullString = TextBlock.Text;
                    CurrentString = "";
                    TextBlock.Text = "";



                    foreach (char Letter in FullString)
                    {
                        LetterAnimation = new DiscreteStringKeyFrame();
                        LetterAnimation.KeyTime = KeyTime.Paced;

                        CurrentString += Letter;

                        LetterAnimation.Value = CurrentString;
                        StringAnimation.KeyFrames.Add(LetterAnimation);
                    }
                    TextBlock.RenderTransformOrigin = new Point(1, 1);
                    TextBlock.BeginAnimation(TextBlock.TextProperty, StringAnimation);
                }
            }

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

            Back.BeginAnimation(TextBlock.FontSizeProperty, Size);
            Back.BeginAnimation(Canvas.TopProperty, Top);
            Back.BeginAnimation(Canvas.LeftProperty, Left);

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

            Back.BeginAnimation(TextBlock.FontSizeProperty, Size);
            Back.BeginAnimation(Canvas.TopProperty, Top);
            Back.BeginAnimation(Canvas.LeftProperty, Left);


        }

        private void OnBackMouseDown(object sender, MouseButtonEventArgs e)
        {
            PageSwitch.Switch(new MainMenu());
        }
    }
}
