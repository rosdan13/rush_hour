using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace Rush_Hour
{
    public static class GameBoard
    {
        private static Square[,] Squares = new Square[6, 6];                    //מערך המשבצות שעל לוח המשחק
        private static Vehicle[] Vehicles;                                      //מערך הרכבים שעל הלוח
        private static Vehicle CurrentVehicle;                                  //הרכב הנוכחי
        public static bool IsLevelCompleted { get; private set; }

        public static void AddSquare(Square NewSquare, int r, int c)            //הוספת משבצת ללוח
        {
            Squares[r, c] = NewSquare;
            
        }

        public static void AddVehicles(Vehicle[] VehicleArray)                 //הוספת מערך מכוניות ללוח
        {
            Vehicles = VehicleArray;
            UpdateSquaresAvailability();
            IsLevelCompleted = false;
           
        }

        public static void MouseMoveHighlight(GeometryModel3D Model)            //פונקציה המאירה אובייקט תלת ממדי (מכונית או משבצת רלוונטית) כשהעכבר נמצא עליו
        {
            if (!IsLevelCompleted)
            {

                bool GeometryFound = false;

                if (Vehicles != null)                                               //סריקת כל הרכבים אם הם מכילים את המודל שנמצא מתחת לעכבר. הרכב שעליו העכבר מואר ואילו שאר הרכבים מפסיקים להאיר
                {
                    for (int i = 0; i < Vehicles.Length; i++)
                    {
                        if (!GeometryFound && Vehicles[i].Contains(Model))
                        {
                            Vehicles[i].MouseOn();
                            GeometryFound = true;
                        }
                        else
                        {
                            Vehicles[i].MouseOff();
                        }
                    }
                }


                for (int r = 0; r < Squares.GetLength(0); r++)                     //סריקת כל המשבצות אם הן מכילות את המודל שתחת העכבר. המשבצת שעליה העכבר מוארת אם היא רלוונטית ואילו שאר המשבצות מפסיקות להאיר
                {
                    for (int c = 0; c < Squares.GetLength(1); c++)
                    {
                        if (!GeometryFound && Squares[r, c].Contains(Model))
                        {

                            Squares[r, c].MouseOn();
                            GeometryFound = true;
                        }
                        else
                        {
                            Squares[r, c].MouseOff();
                        }
                    }
                }

            }

        }

        public static void MouseClick(GeometryModel3D Model)                            //הפונקציה מתרחשת בעת לחיצה על העכבר
        {
            if (!IsLevelCompleted)
            {

                bool GeometryFound = false;

                for (int i = 0; i < Vehicles.Length && !GeometryFound; i++)                                  //בדיקה האם מכונית נלחצה. במידה וכן, היא המכונית הנוכחית שבה התוכנית מתמקדת, והמכונית הקודמת מאבדת את הפוקוס
                {
                    if (Vehicles[i] != CurrentVehicle && Vehicles[i].Contains(Model))
                    {
                        GeometryFound = true;
                        if (CurrentVehicle != null)
                        {
                            CurrentVehicle.MouseRelease();
                        }
                        CurrentVehicle = Vehicles[i];
                        Vehicles[i].MouseClick();
                        ShowRelevantSquares();                                            //פונקציה המאירה את כל המשבצות שעליהן המכונית יכולה לנסוע
                    }
                }

                for (int r = 0; r < Squares.GetLength(0) && !GeometryFound; r++)
                {
                    for (int c = 0; c < Squares.GetLength(1) && !GeometryFound; c++)
                    {
                        if (Squares[r, c].Contains(Model) && Squares[r, c].IsRelevant && CurrentVehicle != null)
                        {
                            Squares[r, c].MouseClick();
                            CurrentVehicle.Transform(c, r);
                            CurrentVehicle.MouseRelease();
                            CurrentVehicle = null;
                            UpdateSquaresAvailability();
                            ShowRelevantSquares();

                            GeometryFound = true;
                        }
                    }
                }
            }
        }

        private static void ShowRelevantSquares()                                    //פונקציה המאירה את כל המשבצות שעליהן המכונית יכולה לנסוע
        {
            int Rows = 0, Columns = 0, r, c;
            bool Stop = false;


            for (r = 0; r < Squares.GetLength(0); r++)                              //כל המשבצות שבלוח שהיו רלוונטיות עכשיו אינן רלוונטיות
            {
                for (c = 0; c < Squares.GetLength(1); c++)
                {
                    Squares[r, c].MakeIrrelevant();
                }
            }


            if (CurrentVehicle != null)
            {


                if (CurrentVehicle.Direction == 'R' || CurrentVehicle.Direction == 'L')                    //במידה והרכב מאוזן, כל המשבצות שהרכב יכול להגיע אליהן באותה שורה נהיות רלוונטיות
                {
                    Columns = (int)CurrentVehicle.Position.X + 2;
                    if (CurrentVehicle.Type == 'T')
                    {
                        Columns++;
                    }


                    for (c = Columns; c < Squares.GetLength(1) && !Stop; c++)                            //בדיקת כל המשבצות שמימין לרכב
                    {
                        if (Squares[(int)CurrentVehicle.Position.Y, c].IsAvailable)
                        {
                            if ((int)CurrentVehicle.Position.Y == 2 && c == 5)
                            {
                                Squares[(int)CurrentVehicle.Position.Y, c].MakeSpecialRelevant();        //במידה וזו המשבצת שלפני היציאה מהלוח, היא מוארת בצבע אחר
                            }
                            else
                            {
                                Squares[(int)CurrentVehicle.Position.Y, c].MakeRelevant(); 
                            }
                         
                        }
                        else
                        {
                            Stop = true;                                                                //במידה ונמצא רכב שחוסם את תנועת המכונית, הלולאה מפסיקה כי המשבצות שאחריו אינן רלוונטיות 
                        }
                    }

                    Stop = false;

                    for (c = (int)CurrentVehicle.Position.X - 1; c >= 0 && !Stop; c--)                   //בדיקת כל המשבצות שמשמאל לרכב
                    {
                        if (Squares[(int)CurrentVehicle.Position.Y, c].IsAvailable)
                        {
                            Squares[(int)CurrentVehicle.Position.Y, c].MakeRelevant();
                        }
                        else
                        {
                            Stop = true;
                        }
                    }
                }


                else if (CurrentVehicle.Direction == 'U' || CurrentVehicle.Direction == 'D')                     //במידה והרכב מאונך, כל המשבצות שהרכב יכול להגיע אליהן באותו טור נהיות רלוונטיות
                {
                    Rows = (int)CurrentVehicle.Position.Y + 2;
                    if (CurrentVehicle.Type == 'T')
                    {
                        Rows++;
                    }


                    for (r = Rows; r < Squares.GetLength(0) && !Stop; r++)                                   //בדיקת כל המשבצות שמתחת לרכב
                    {
                        if (Squares[r, (int)CurrentVehicle.Position.X].IsAvailable)
                        {
                            Squares[r, (int)CurrentVehicle.Position.X].MakeRelevant();
                        }
                        else
                        {
                            Stop = true;
                        }

                    }

                    Stop = false;

                    for (r = (int)CurrentVehicle.Position.Y - 1; r >= 0 && !Stop; r--)                    //בדיקת כל המשבצות שמעל לרכב
                    {
                        if (Squares[r, (int)CurrentVehicle.Position.X].IsAvailable)
                        {
                            Squares[r, (int)CurrentVehicle.Position.X].MakeRelevant();
                        }
                        else
                        {
                            Stop = true;
                        }
                    }
                }
            }
        }

        private static void UpdateSquaresAvailability()
        {
            for (int r = 0; r < Squares.GetLength(0); r++)
            {
                for (int c = 0; c < Squares.GetLength(1); c++)
                {
                    Squares[r, c].IsAvailable = true;
                }
            }

            for (int i = 0; i < Vehicles.Length; i++)                                                                     //כל המשבצות הנמצאות מתחת למכוניות מוגדרות כלא זמינות
            {

                Squares[(int)Vehicles[i].Position.Y, (int)Vehicles[i].Position.X].IsAvailable = false;

                if (Vehicles[i].Direction == 'U' || Vehicles[i].Direction == 'D')
                {
                    Squares[(int)Vehicles[i].Position.Y + 1, (int)Vehicles[i].Position.X].IsAvailable = false;
                    if (Vehicles[i].Type == 'T')
                    {
                        Squares[(int)Vehicles[i].Position.Y + 2, (int)Vehicles[i].Position.X].IsAvailable = false;
                    }
                }
                else if (Vehicles[i].Direction == 'R' || Vehicles[i].Direction == 'L')
                {
                    Squares[(int)Vehicles[i].Position.Y, (int)Vehicles[i].Position.X + 1].IsAvailable = false;
                    if (Vehicles[i].Type == 'T')
                    {
                        Squares[(int)Vehicles[i].Position.Y, (int)Vehicles[i].Position.X + 2].IsAvailable = false;
                    }
                }
            }

            
        }

        public static void CompleteLevel()
        {
            IsLevelCompleted = true;
        }
    }
}
