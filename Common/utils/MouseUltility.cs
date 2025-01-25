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
        public static void MoveMouseRandomCurve(int startX, int startY, int endX, int endY, int duration)
        {
            int steps = 100; // Number of steps for the smooth movement
            double stepDuration = duration / (double)steps; // Duration for each step

            Random rand = new Random();

            for (int i = 0; i <= steps; i++)
            {
                // Calculate the progress (0 to 1)
                double t = i / (double)steps;

                // Create a random offset for the y-coordinate to create a curve effect
                double offset = Math.Sin(t * Math.PI) * (rand.Next(20, 100)); // Random amplitude

                // Calculate the current position using a curved path
                int currentX = (int)(startX + (endX - startX) * t);
                int currentY = (int)(startY + (endY - startY) * t) + (int)offset;

                // Move the cursor to the current position
                SetCursorPos(currentX, currentY);

                // Wait for the specified duration
                Thread.Sleep((int)stepDuration);
            }
        }
    }
}
