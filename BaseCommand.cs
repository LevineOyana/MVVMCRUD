using System;
using System.Collections.Generic;
using System.Text;

namespace WPFMVVM
{
    public abstract class BaseCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
