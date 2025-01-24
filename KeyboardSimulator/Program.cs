using Common;
using System;
using System.Runtime.InteropServices;

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
                var index = NumberUtility.GenerateRandomInteger(1, 100);
                if (index < 30)
                {
                    MoveRandomly();
                } else
                {
                    FightRandomly();
                }
                Thread.Sleep(NumberUtility.GenerateRandomInteger(50, 3000) + 500);
            }
        }
        static void MoveRandomly()
        {
            var index = NumberUtility.GenerateRandomInteger(1, 20);
            char key = 'a';
            if (index < 5)
            {
                key = 'd';
            } else if (index < 10)
            {
                key = 'w';
            } else if (index < 15)
            {
                key = 's';
            }
            HoldKey(key, NumberUtility.GenerateRandomInteger(3, 1000));
        }
        static void FightRandomly()
        {
            var index = NumberUtility.GenerateRandomInteger(1, 3);
            for (int i = 0; i < index; i++)
            {
                Thread.Sleep(NumberUtility.GenerateRandomInteger(50, 500) + 500);
                SimulateKeyPress('f');
            }
        }
     
        static void HoldKey(char key, int milliseconds)
        {
            short keyCode = VkKeyScan(key);

            // Create a KEYBDINPUT structure for the key down event
            INPUT inputDown = new INPUT
            {
                type = 1, // Input type: Keyboard
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = (ushort)(keyCode & 0xFF), // Virtual-Key code
                        dwFlags = 0 // Key down
                    }
                }
            };

            // Send the key down event
            SendInput(1, new INPUT[] { inputDown }, INPUT.Size);

            // Hold the key for the specified duration
            Thread.Sleep(milliseconds);

            // Create a KEYBDINPUT structure for the key up event
            INPUT inputUp = new INPUT
            {
                type = 1, // Input type: Keyboard
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = (ushort)(keyCode & 0xFF), // Virtual-Key code
                        dwFlags = 2 // Key up
                    }
                }
            };

            // Send the key up event
            SendInput(1, new INPUT[] { inputUp }, INPUT.Size);
        }
        static void SimulateKeyPress(char key)
        {
            // Convert the character to the Virtual-Key code
            short keyCode = VkKeyScan(key);

            // Create a KEYBDINPUT structure for the key down event
            INPUT inputDown = new INPUT
            {
                type = 1, // Input type: Keyboard
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = (ushort)(keyCode & 0xFF), // Virtual-Key code
                        dwFlags = 0 // Key down
                    }
                }
            };

            // Create a KEYBDINPUT structure for the key up event
            INPUT inputUp = new INPUT
            {
                type = 1, // Input type: Keyboard
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = (ushort)(keyCode & 0xFF), // Virtual-Key code
                        dwFlags = 2 // Key up
                    }
                }
            };

            // Send the input events
            INPUT[] inputs = { inputDown, inputUp };
            SendInput((uint)inputs.Length, inputs, INPUT.Size);
        }

        // Windows API functions and structures
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public int type;
            public InputUnion u;

            public static int Size => Marshal.SizeOf(typeof(INPUT));
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
    }
}
