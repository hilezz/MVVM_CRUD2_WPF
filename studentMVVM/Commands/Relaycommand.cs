using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace studentMVVM.Commands
{
    public class Relaycommand : ICommand
    {
        //public event EventHandler CanExecuteChanged;

        Action<object> executeAction;

        Func<object, bool> canExecute;
       //Predicate<object> canExecutePredicate;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public Relaycommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
           this.executeAction = executeAction; 
           this.canExecute = canExecute;
            

        }
        public Relaycommand(Action<object> execute) : this(execute, null) { }


        public bool CanExecute(object parameter)
        {
          if (executeAction != null)
            {
                return canExecute(parameter);
            }
          else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}

//public event EventHandler CanExecuteChanged
//    {
//        add
//        {
//            CommandManager.RequerySuggested += value;
//        }
//        remove
//        {
//            CommandManager.RequerySuggested -= value;
//        }
//    }







//        public bool CanExecute(object parameter)
//        {
//            if (canExecute == null)
//            {
//                return true;
//            }
//            else
//            {
//                return canExecute(parameter);
//            }


//        }

//        public void Execute(object parameter)
//        {
//            executeAction(parameter);
//        }
