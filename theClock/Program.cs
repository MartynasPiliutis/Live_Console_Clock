using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace theClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 70);
            Console.CursorSize = 14;
            Console.SetBufferSize(200, 100);


            DrawClock();

            for (int i = 0; i <= 1000; i++)
            {
                CurrentTime();
            }
            Console.ReadLine();

        }

        public static void ShowTime(int h, int m, int s)
        {
            Console.SetCursorPosition(67, 18); Console.Write($"{h.ToString("D2")}:{m.ToString("D2")}:{s.ToString("D2")}"); //time
        }
        public static void CurrentTime()
        {
            int h = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            ShowTime(h, min, s);
            DrawMinutesArrow(min, 2);
            DrawHourArrow(h, min, 3);
            DrawSecondArrow(s, 1);
            Thread.Sleep(950);
            DrawSecondArrow(s, 0);
            DrawMinutesArrow(min, 0);
            DrawHourArrow(h, min, 0);
        }

        public static void DrawClock()
        {
            Console.SetCursorPosition(71, 33); Console.Write("O"); //middle
            Console.SetCursorPosition(70, 2); Console.Write("|||"); //top 0 upper
            Console.SetCursorPosition(70, 3); Console.Write("|||"); //top 0 lower
            Console.SetCursorPosition(131, 33); Console.Write("=="); //right 15
            Console.SetCursorPosition(71, 63); Console.Write("|"); //bottom 30 upper
            Console.SetCursorPosition(71, 64); Console.Write("|"); //bottom 30 lower
            Console.SetCursorPosition(10, 33); Console.Write("=="); //left 45

            Console.SetCursorPosition(101, 7); Console.Write("*");//5
            Console.SetCursorPosition(123, 18); Console.Write("*");//10
            Console.SetCursorPosition(123, 48); Console.Write("*");//20
            Console.SetCursorPosition(101, 59); Console.Write("*"); //25
            Console.SetCursorPosition(41, 59); Console.Write("*");  //35
            Console.SetCursorPosition(19, 48); Console.Write("*");  //40
            Console.SetCursorPosition(19, 18); Console.Write("*");  //50
            Console.SetCursorPosition(41, 7); Console.Write("*");   //55
        }

        public static void DrawSeconds()
        {
            int mastx;
            int masty;
            int r;
            Console.Write("mastx: ");
            mastx = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("masty: ");
            masty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("r: ");
            r = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < 60; i++)
            {
                CalculatePoint(i, mastx, masty, r, 1);
            }
        }

        public static void DrawMinutesArrow(int min, int wc)

        {
            int mastx = 2;
            int masty = 1;
            for (int i = 26; i > 1; i--)
            {
                CalculatePoint(min, mastx, masty, i, wc);
            }
        }

        public static void DrawHourArrow(int hour, int min, int wc)

        {
            int mastx = 2;
            int masty = 1;
            int hour_conv = hour * 5 + min / 12;
            for (int i = 15; i > 1; i--)
            {
                CalculatePoint(hour_conv, mastx, masty, i, wc);
            }
        }

        public static void DrawSecondArrow(int sec, int wc)

        {
            int mastx = 2;
            int masty = 1;
            for (int i = 29; i > 1; i--)
            {
                CalculatePoint(sec, mastx, masty, i, wc);
            }
        }

        public static void CalculatePoint(int min, int mast_x, int mast_y, int r_input, int selection)
        {
            double angx = min * 6;
            double angy = 90 - angx;

            double angx_rad = (Math.PI / 180) * angx;
            double angy_rad = (Math.PI / 180) * angy;

            double coox = Math.Sin(angx_rad) * r_input;
            double cooy = Math.Sin(angy_rad) * r_input;

            coox = coox * mast_x;
            cooy = cooy * mast_y;

            int x_temp = Convert.ToInt32(Math.Round(coox, MidpointRounding.AwayFromZero));
            int y_temp = Convert.ToInt32(Math.Round(cooy, MidpointRounding.AwayFromZero));

            int x = x_temp + 71;
            int y = 33 - y_temp;

            if (selection == 0)
            {
                Console.SetCursorPosition(x, y); Console.Write(" ");
            }
            else if (selection == 1)
            {
                Console.SetCursorPosition(x, y); Console.Write(".");
            }
            else if (selection == 2)
            {
                Console.SetCursorPosition(x, y); Console.Write("0");

            }
            else
            {
                Console.SetCursorPosition(x, y); Console.Write("@");
            }
        }
    }
}
