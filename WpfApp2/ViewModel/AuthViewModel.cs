using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VIN_LIB;
using WpfApp2.Base;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    class AuthViewModel:Notify
    {
        public RelayCommand clickAuth { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        private int _timeToEnter;
        public int TimeToEnter
        {
            get
            {
                return _timeToEnter;
            }
            set
            {
                _timeToEnter = value;
                if (value == 0)
                {
                    isblock = false;
                    timer.Stop();
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(isVisibleTimer));
            }
        }

        public Visibility isVisibleTimer
        {
            get
            {
                return TimeToEnter == 0?Visibility.Hidden:Visibility.Visible;
            }
        }

        private const int seconds = 10;
        private const int countTries = 3;

        private bool isblock = false;
        private int countsOfEnter=0;
        public Action CloseView { get; set; }
        DispatcherTimer timer;
        public AuthViewModel(Action close)
        {
            RelayCommand.timerClose.Tick += new EventHandler(RelayCommand.timerClose_tick);
            RelayCommand.timerClose.Interval = new TimeSpan(0, 0, 1);
            RelayCommand.timerClose.Start();            
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            CloseView = close;
            clickAuth = new RelayCommand(p =>
            {                
                if (isblock)
                {
                    MessageBox.Show("Nizya");
                    return;
                }

                if (Pass == "1" && Login == "1")
                {
                    MainView c = new MainView();
                    c.Show();
                    CloseView();

                }
                else
                {
                    countsOfEnter++;
                    MessageBox.Show("Осталось попыток: " + (countTries - countsOfEnter));
                    if(countTries - countsOfEnter == 0)
                    {
                        BlockEnter();
                        countsOfEnter = 0;                        
                    }
                }
            });
        }

        private void BlockEnter()
        {
            isblock = true;
            TimeToEnter = seconds;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeToEnter--;               
        }

        public AuthViewModel()
        { }
    }
}
