using Autofac;

using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace prototype.forms.Helpers.Command
{
    public class AsyncCommand : ICommand
    {
        #region Properties

        protected Func<object, Task> executeAction;
        private readonly Func<bool> canExecute;
        private readonly Action<Exception> exceptionAction;

        private bool IsBusy { get; set; } = false;

        #endregion

        #region Events


        public event EventHandler CanExecuteChanged;

        #endregion

        public AsyncCommand(Func<Task> execute, Action<Exception> exception = null, Func<bool> canExecute = null
        ) : this(o => execute(), canExecute, exception)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }
        protected AsyncCommand(Func<object, Task> execute, Func<bool> canExecute, Action<Exception> exception)
        {
            this.executeAction = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? (() => { return true; });
            this.exceptionAction = (async (Exception ex) =>
            {
                /** Handle exceptions */
            });
        }

        public async void Execute(object parameter)
        {
            try
            {
                IsBusy = true;
                await this.executeAction(parameter);
            }
            catch (Exception ex)
            {
                this.exceptionAction(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void ChangeCanExecute()
        {
            IsBusy = !IsBusy;
            CanExecuteChanged(this, null);
        }

        public bool CanExecute(object parameter)
        {
            return !IsBusy && this.canExecute();
        }
    }

    public sealed class AsyncCommand<T> : AsyncCommand
    {
        public AsyncCommand(Func<T, Task> execute, Action<Exception> exception = null, Func<bool> canExecute = null) : base(o =>
        {
            if (IsValidParameter(o))
            {
                return execute((T)o);
            }
            return null;
        }, canExecute, exception)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        static bool IsValidParameter(object o)
        {
            if (o != null)
            {
                // The parameter isn't null, so we don't have to worry whether null is a valid option
                return o is T;
            }

            var t = typeof(T);

            // The parameter is null. Is T Nullable?
            if (Nullable.GetUnderlyingType(t) != null)
            {
                return true;
            }

            // Not a Nullable, if it's a value type then null is not valid
            return !t.GetTypeInfo().IsValueType;
        }
    }

}
