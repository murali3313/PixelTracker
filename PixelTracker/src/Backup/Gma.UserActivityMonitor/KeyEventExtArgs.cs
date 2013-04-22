using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
#pragma warning disable 1591
    public class KeyEventExtArgs:KeyEventArgs
#pragma warning restore 1591
    {
        public KeyEventExtArgs(Keys keyData) : base(keyData)
        {
        }
    }
}
