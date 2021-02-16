using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JejemonTypingScript
{
    public partial class Form1 : Form
    {
        List<KeyboardHook> hooks = new List<KeyboardHook>();
        List<Boolean> registered = new List<Boolean>();

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                KeyboardManager.PressKey(Keys.CapsLock);

                switch (m.WParam.ToInt32())
                {
                    case (int)Keys.A:
                        KeyboardManager.PressKey(Keys.D4); //4
                        KeyboardManager.PressKey(Keys.H); //4
                        break;
                    case (int)Keys.E:
                        KeyboardManager.PressKey(Keys.D3); //3
                        break;
                    case (int)(Keys.O):
                        KeyboardManager.PressKey(Keys.D0); //0
                        KeyboardManager.PressKey(Keys.W); //W
                        break;
                    case (int)(Keys.S):
                        KeyboardManager.PressKey(Keys.Z); //Z
                        KeyboardManager.PressKey(Keys.CapsLock);
                        KeyboardManager.PressKey(Keys.Z); //Z
                        break;

                }
                
            }
            base.WndProc(ref m);
        }
        private void EnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableCheckBox.Checked)
            {
                RegisterKeys();
            }
            else
            {
                UnregisterKeys();
            }
        }

        private void RegisterKeys()
        {
            hooks.Add(new KeyboardHook((int)KeyboardHook.Modifiers.None, (int)Keys.A, Keys.A, this)); //A
            hooks.Add(new KeyboardHook((int)KeyboardHook.Modifiers.None, (int)Keys.E, Keys.E, this)); //E
            hooks.Add(new KeyboardHook((int)KeyboardHook.Modifiers.None, (int)Keys.O, Keys.O, this)); //O
            hooks.Add(new KeyboardHook((int)KeyboardHook.Modifiers.None, (int)Keys.S, Keys.S, this)); //S
            foreach (KeyboardHook hook in hooks)
            {
                hook.Register(); 
            }
        }

        private void UnregisterKeys()
        {
            foreach (KeyboardHook hook in hooks)
            {
                hook.Unregister();
            }
        }
    }
}
