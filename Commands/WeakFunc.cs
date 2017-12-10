using System;
using System.Windows.Markup;
using System.Reflection;

namespace WPFluent.Commands
{
    internal class WeakFunc<TResult>
    {
        private Func<TResult> _staticFunc;

        protected MethodInfo Method { get; set; }

        public bool IsStatic
        {
            get
            {
                return this._staticFunc != null;
            }
        }

        public virtual string MethodName
        {
            get
            {
                if (this._staticFunc != null)
                    return this._staticFunc.Method.Name;
                return this.Method.Name;
            }
        }

        protected WeakReference FuncReference { get; set; }

        protected WeakReference Reference { get; set; }

        public virtual bool IsAlive
        {
            get
            {
                if (this._staticFunc == null && this.Reference == null)
                    return false;
                if (this._staticFunc != null && this.Reference == null)
                    return true;
                return this.Reference.IsAlive;
            }
        }

        public object Target
        {
            get
            {
                if (this.Reference == null)
                    return (object)null;
                return this.Reference.Target;
            }
        }

        protected object FuncTarget
        {
            get
            {
                if (this.FuncReference == null)
                    return (object)null;
                return this.FuncReference.Target;
            }
        }

        protected WeakFunc()
        {
        }

        public WeakFunc(Func<TResult> func)
            : this(func == null ? (object)null : func.Target, func)
        {
        }

        public WeakFunc(object target, Func<TResult> func)
        {
            if (func.Method.IsStatic)
            {
                this._staticFunc = func;
                if (target == null)
                    return;
                this.Reference = new WeakReference(target);
            }
            else
            {
                this.Method = func.Method;
                this.FuncReference = new WeakReference(func.Target);
                this.Reference = new WeakReference(target);
            }
        }

        public TResult Execute()
        {
            if (this._staticFunc != null)
                return this._staticFunc();
            object funcTarget = this.FuncTarget;
            if (this.IsAlive && this.Method != (MethodInfo)null && (this.FuncReference != null && funcTarget != null))
                return (TResult)this.Method.Invoke(funcTarget, (object[])null);
            return default(TResult);
        }

        public void MarkForDeletion()
        {
            this.Reference = (WeakReference)null;
            this.FuncReference = (WeakReference)null;
            this.Method = (MethodInfo)null;
            this._staticFunc = (Func<TResult>)null;
        }
    }

    internal class WeakFunc<T, TResult> : WeakFunc<TResult>
    {
        private Func<T, TResult> _staticFunc;

        public override string MethodName
        {
            get
            {
                if (this._staticFunc != null)
                    return this._staticFunc.Method.Name;
                return this.Method.Name;
            }
        }

        public override bool IsAlive
        {
            get
            {
                if (this._staticFunc == null && this.Reference == null)
                    return false;
                if (this._staticFunc == null)
                    return this.Reference.IsAlive;
                if (this.Reference != null)
                    return this.Reference.IsAlive;
                return true;
            }
        }

        public WeakFunc(Func<T, TResult> func)
            : this(func == null ? (object)null : func.Target, func)
        {
        }

        public WeakFunc(object target, Func<T, TResult> func)
        {
            if (func.Method.IsStatic)
            {
                this._staticFunc = func;
                if (target == null)
                    return;
                this.Reference = new WeakReference(target);
            }
            else
            {
                this.Method = func.Method;
                this.FuncReference = new WeakReference(func.Target);
                this.Reference = new WeakReference(target);
            }
        }

        public new TResult Execute()
        {
            return this.Execute(default(T));
        }

        public TResult Execute(T parameter)
        {
            if (this._staticFunc != null)
                return this._staticFunc(parameter);
            object funcTarget = this.FuncTarget;
            if (!this.IsAlive || !(this.Method != (MethodInfo)null) || (this.FuncReference == null || funcTarget == null))
                return default(TResult);
            return (TResult)this.Method.Invoke(funcTarget, new object[1]
      {
        (object) parameter
      });
        }

        public object ExecuteWithObject(object parameter)
        {
            return (object)this.Execute((T)parameter);
        }

        public new void MarkForDeletion()
        {
            this._staticFunc = (Func<T, TResult>)null;
            base.MarkForDeletion();
        }
    }
}
