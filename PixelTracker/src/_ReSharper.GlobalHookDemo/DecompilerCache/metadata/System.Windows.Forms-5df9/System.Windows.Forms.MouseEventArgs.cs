// Type: System.Windows.Forms.MouseEventArgs
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    [ComVisible(true)]
    public class MouseEventArgs : EventArgs
    {
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta);
        public MouseButtons Button { get; }
        public int Clicks { get; }
        public int X { get; }
        public int Y { get; }
        public int Delta { get; }
        public Point Location { get; }
    }
}
