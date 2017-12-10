using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFluent.Commands
{
    internal class RelayCommand : ICommand
    {
        private readonly WeakAction _execute;
        private readonly WeakFunc<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action execute)
            : this(execute, (Func<bool>)null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this._execute = new WeakAction(execute);
            if (canExecute == null)
                return;
            this._canExecute = new WeakFunc<bool>(canExecute);
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
                return true;
            if (this._canExecute.IsStatic || this._canExecute.IsAlive)
                return this._canExecute.Execute();
            return false;
        }

        public virtual void Execute(object parameter)
        {
            if (!this.CanExecute(parameter) || this._execute == null || !this._execute.IsStatic && !this._execute.IsAlive)
                return;
            this._execute.Execute();
        }
    }

    internal class RelayCommand<T> : ICommand
    {
        private readonly WeakAction<T> _execute;
        private readonly WeakFunc<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<T> execute)
            : this(execute, (Func<T, bool>)null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this._execute = new WeakAction<T>(execute);
            if (canExecute == null)
                return;
            this._canExecute = new WeakFunc<T, bool>(canExecute);
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
                return true;
            if (this._canExecute.IsStatic || this._canExecute.IsAlive)
            {
                if (parameter == null && typeof(T).IsValueType)
                    return this._canExecute.Execute(default(T));
                if (parameter is T)
                    return this._canExecute.Execute((T)parameter);
            }
            return false;
        }

        public virtual void Execute(object parameter)
        {
            object parameter1 = parameter;
            if (parameter != null && parameter.GetType() != typeof(T) && parameter is IConvertible)
                parameter1 = Convert.ChangeType(parameter, typeof(T), (IFormatProvider)null);
            if (!this.CanExecute(parameter1) || this._execute == null || !this._execute.IsStatic && !this._execute.IsAlive)
                return;
            if (parameter1 == null)
            {
                if (typeof(T).IsValueType)
                    this._execute.Execute(default(T));
                else
                    this._execute.Execute((T)parameter1);
            }
            else
                this._execute.Execute((T)parameter1);
        }
    }
}
