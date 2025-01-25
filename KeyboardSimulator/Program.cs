using Common.utils;
using System;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace KeyboardSimulator
{

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl+C to exit the application.");
            Console.WriteLine("This application will start in 5 seconds");
            Thread.Sleep(2000);
            Console.WriteLine("3 seconds");
            Thread.Sleep(1000);
            Console.WriteLine("2 seconds");
            Thread.Sleep(1000);
            Console.WriteLine("1 seconds");
            Thread.Sleep(1000);
            while (true)
            {
                // Get the current mouse position
                var mousePos = Control.MousePosition;
                Console.Clear();
                Console.WriteLine($"Mouse Position: X = {mousePos.X}, Y = {mousePos.Y}");
                MouseUltility.MoveMouseRandomCurve(mousePos.X, mousePos.Y,
                    340 + NumberUtility.GenerateRandomInteger(1, 15),
                    650 + NumberUtility.GenerateRandomInteger(1, 16),
                    NumberUtility.GenerateRandomInteger(100, 200)
                    );
                MouseUltility.LeftClick(mousePos.X, mousePos.Y);
                Thread.Sleep(NumberUtility.GenerateRandomInteger(5000, 5500));
                mousePos = Control.MousePosition;
                MouseUltility.MoveMouseRandomCurve(mousePos.X, mousePos.Y,
                  620 + NumberUtility.GenerateRandomInteger(1, 15),
                  560 + NumberUtility.GenerateRandomInteger(1, 16),
                  NumberUtility.GenerateRandomInteger(100, 200)
                  );
                MouseUltility.LeftClick(mousePos.X, mousePos.Y);
                Thread.Sleep(NumberUtility.GenerateRandomInteger(500, 1000));
            }


            //while (true)
            //{
            //    var index = NumberUtility.GenerateRandomInteger(1, 100);
            //    if (index < 30)
            //    {
            //        MoveRandomly();
            //    } else
            //    {
            //        FightRandomly();
            //    }
            //    Thread.Sleep(NumberUtility.GenerateRandomInteger(50, 3000) + 500);
            //}
        }

        //static void MoveRandomly()
        //{
        //    var index = NumberUtility.GenerateRandomInteger(1, 20);
        //    char key = 'a';
        //    if (index < 5)
        //    {
        //        key = 'd';
        //    } else if (index < 10)
        //    {
        //        key = 'w';
        //    } else if (index < 15)
        //    {
        //        key = 's';
        //    }
        //    KeyboardUltility.HoldKey(key, NumberUtility.GenerateRandomInteger(3, 1000));
        //}
        //static void FightRandomly()
        //{
        //    var index = NumberUtility.GenerateRandomInteger(1, 3);
        //    for (int i = 0; i < index; i++)
        //    {
        //        Thread.Sleep(NumberUtility.GenerateRandomInteger(50, 500) + 500);
        //        KeyboardUltility.SimulateKeyPress('f');
        //    }
        //}
    }
}
