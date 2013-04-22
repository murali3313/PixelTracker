// Type: System.ComponentModel.Component
// Assembly: System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.dll

using System;
using System.Runtime.InteropServices;

namespace System.ComponentModel
{
    [DesignerCategory("Component")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    public class Component : MarshalByRefObject, IComponent, IDisposable
    {
        public Component();
        protected virtual bool CanRaiseEvents { get; }
        protected EventHandlerList Events { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IContainer Container { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        protected bool DesignMode { get; }

        #region IComponent Members

        public void Dispose();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ISite Site { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Disposed;

        #endregion

        ~Component();
        protected virtual void Dispose(bool disposing);
        protected virtual object GetService(Type service);
        public override string ToString();
    }
}
