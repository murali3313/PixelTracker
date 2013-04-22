// Type: System.Windows.Forms.KeyEventArgs
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    [ComVisible(true)]
    public class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(Keys keyData);
        public virtual bool Alt { get; }
        public bool Control { get; }
        public bool Handled { get; set; }
        public Keys KeyCode { get; }
        public int KeyValue { get; }
        public Keys KeyData { get; }
        public Keys Modifiers { get; }
        public virtual bool Shift { get; }
        public bool SuppressKeyPress { get; set; }
    }
}
