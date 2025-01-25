using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.utils
{
    public static class KeyboardUltility
    {
        public static void SimulateKeyPress(char key)
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

        public static void HoldKey(char key, int milliseconds)
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

        // Windows API functions and structures
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public int type;
            public InputUnion u;

            public static int Size => Marshal.SizeOf(typeof(INPUT));
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
    }
}
