using System;
using System.Windows.Markup;
using System.Reflection;

namespace WPFluent.Commands
{
    internal class WeakAction
    {
        private Action _staticAction;

        protected MethodInfo Method { get; set; }

        public virtual string MethodName
        {
            get
            {
                if (this._staticAction != null)
                    return this._staticAction.Method.Name;
                return this.Method.Name;
            }
        }

        protected WeakReference ActionReference { get; set; }

        protected WeakReference Reference { get; set; }

        public bool IsStatic
        {
            get
            {
                return this._staticAction != null;
            }
        }

        public virtual bool IsAlive
        {
            get
            {
                if (this._staticAction == null && this.Reference == null)
                    return false;
                if (this._staticAction != null && this.Reference == null)
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

        protected object ActionTarget
        {
            get
            {
                if (this.ActionReference == null)
                    return (object)null;
                return this.ActionReference.Target;
            }
        }

        protected WeakAction()
        {
        }

        public WeakAction(Action action)
            : this(action == null ? (object)null : action.Target, action)
        {
        }

        public WeakAction(object target, Action action)
        {
            if (action.Method.IsStatic)
            {
                this._staticAction = action;
                if (target == null)
                    return;
                this.Reference = new WeakReference(target);
            }
            else
            {
                this.Method = action.Method;
                this.ActionReference = new WeakReference(action.Target);
                this.Reference = new WeakReference(target);
            }
        }

        public void Execute()
        {
            if (this._staticAction != null)
            {
                this._staticAction();
            }
            else
            {
                object actionTarget = this.ActionTarget;
                if (!this.IsAlive || !(this.Method != (MethodInfo)null) || (this.ActionReference == null || actionTarget == null))
                    return;
                this.Method.Invoke(actionTarget, (object[])null);
            }
        }

        public void MarkForDeletion()
        {
            this.Reference = (WeakReference)null;
            this.ActionReference = (WeakReference)null;
            this.Method = (MethodInfo)null;
            this._staticAction = (Action)null;
        }
    }

    internal class WeakAction<T> : WeakAction
    {
        private Action<T> _staticAction;

        public override string MethodName
        {
            get
            {
                if (this._staticAction != null)
                    return this._staticAction.Method.Name;
                return this.Method.Name;
            }
        }

        public override bool IsAlive
        {
            get
            {
                if (this._staticAction == null && this.Reference == null)
                    return false;
                if (this._staticAction == null)
                    return this.Reference.IsAlive;
                if (this.Reference != null)
                    return this.Reference.IsAlive;
                return true;
            }
        }

        public WeakAction(Action<T> action)
            : this(action == null ? (object)null : action.Target, action)
        {
        }

        public WeakAction(object target, Action<T> action)
        {
            if (action.Method.IsStatic)
            {
                this._staticAction = action;
                if (target == null)
                    return;
                this.Reference = new WeakReference(target);
            }
            else
            {
                this.Method = action.Method;
                this.ActionReference = new WeakReference(action.Target);
                this.Reference = new WeakReference(target);
            }
        }

        public new void Execute()
        {
            this.Execute(default(T));
        }

        public void Execute(T parameter)
        {
            if (this._staticAction != null)
            {
                this._staticAction(parameter);
            }
            else
            {
                object actionTarget = this.ActionTarget;
                if (!this.IsAlive || !(this.Method != (MethodInfo)null) || (this.ActionReference == null || actionTarget == null))
                    return;
                this.Method.Invoke(actionTarget, new object[1]
        {
          (object) parameter
        });
            }
        }

        public void ExecuteWithObject(object parameter)
        {
            this.Execute((T)parameter);
        }

        public new void MarkForDeletion()
        {
            this._staticAction = (Action<T>)null;
            base.MarkForDeletion();
        }
    }
}
