
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp2.Base
{
    public class RelayCommand : ICommand
    {
        private const int timeToClose = 60;
        private static int timeSpend = 0;
        private const int timeToNotify = 10;
        public static void ResetTimer()
        {
            timeSpend = 0;
        }
        
        public static DispatcherTimer timerClose = new DispatcherTimer();

        public static void timerClose_tick(object sender, EventArgs e)
        {
            timeSpend++;
            if(timeToClose-timeSpend == timeToNotify)
            {
                //MessageBox.Show($"Бездействие. {timeToNotify} сек до закрытия");
            }
            if(timeSpend==timeToClose)
            {
                new MainWindow().Show();
                foreach (Window w in App.Current.Windows)
                {
                    if (w is MainWindow)
                        continue;
                    w.Close();
                }
                

            }
        }

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            timeSpend = 0;
            this.execute(parameter);
        }
    }
    
}