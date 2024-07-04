using System;
using System.Collections.Generic;
using System.Text;

namespace MakeTable
{
    public abstract class Process<T> : Singleton<T>, IProcess where T : class, new()
    {
        public abstract void Start();

        public abstract void End();

        protected abstract string GetProcessName();

        public virtual void Init(object param)
        {

        }

        public virtual bool IsValid()
        {
            return true;
        }

        public virtual bool IsOpen()
        {
            return Config.Instance.IsOpen(this.GetProcessName());
        }
    }
}
