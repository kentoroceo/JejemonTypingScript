﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JejemonTypingScript
{
    public class KeyboardHook
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public enum Modifiers
        {
            None = 0x0000,
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Win = 0x0008
        }

        public int modifier;
        public int key;
        public IntPtr hWnd;
        public int id;

        public KeyboardHook(int modifiers, int keyID, Keys key, Form f)
        {
            this.modifier = modifiers;
            this.key = (int)key;
            this.hWnd = f.Handle;
            this.id = keyID;
        }

        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }


        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }
        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
