using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.utils
{
    public static class MouseUltility
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // Constants for mouse_event
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        public static void MoveMouseRandomCurve(int startX, int startY, int endX, int endY, int duration)
        {
            int steps = 10; 
            double stepDuration = duration / (double)steps; 

            Random rand = new Random();
            int randomIndex = (rand.Next(1, 70)) - 45;

            for (int i = 0; i <= steps; i++)
            {
                double t = i / (double)steps;

                double offset = Math.Sin(t * Math.PI) * randomIndex; 

                int currentX = (int)(startX + (endX - startX) * t);
                int currentY = (int)(startY + (endY - startY) * t) + (int)offset;
                SetCursorPos(currentX, currentY);
                Thread.Sleep((int)stepDuration);
            }
        }
        public static void LeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
        }
    }
}
