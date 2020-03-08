using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public enum ButtonState
    { 
        Off,
        Request,
        Blink,
        Flash,
    }

    public enum ProcessState
    {
        Off,
        BlinkOn,
        BlinkOff,     
        AutoRed,
        AutoYellow,
        AutoGreen,
        AutoRequest,      
    }
    
    class ViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private BackgroundWorker _worker = new BackgroundWorker();
        private System.Timers.Timer _timer = new System.Timers.Timer();

        private ProcessState _theStateOfTheProcess = ProcessState.Off;


        public ViewModel()
        {
            _timer.Elapsed += _timer_Elapsed;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerAsync();

        }
      
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _isEventRaised = false;
            _theStateOfTheProcess = _nextState;
            _timer.Stop();
        }


        private bool _isEventRaised = false;
        private ProcessState _nextState;
        private void RaiseTimerEvent(ProcessState NextProcessState, int TimeInterval)
        {
            if(!_isEventRaised)
            {
                _isEventRaised = true;
                _nextState = NextProcessState;
                _timer.Interval = TimeInterval;
                _timer.Start();
            }
        }



        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {              
                ProcessNextState(_theStateOfTheProcess);
                System.Threading.Thread.Sleep(100);
            }
        }


        public void ProcessNextState(ProcessState CurrentState)
        {
            switch (CurrentState)
            {
                case ProcessState.Off:
                    IsRedForCar = false;
                    IsYellowForCar = false;
                    IsGreenForCar = false;
                    IsRedForPeople = false;
                    IsGreenForPeople = false;

                    RaiseTimerEvent(ProcessState.Off, 1000);
                   
                    break;
                case ProcessState.BlinkOn:
                    IsRedForCar = false;
                    IsYellowForCar = true;
                    IsGreenForCar = false;
                    IsRedForPeople = false;
                    IsGreenForPeople = false;

                    RaiseTimerEvent(ProcessState.BlinkOff, 2000);

                    break;
                case ProcessState.BlinkOff:
                    IsRedForCar = false;
                    IsYellowForCar = false;
                    IsGreenForCar = false;
                    IsRedForPeople = false;
                    IsGreenForPeople = false;
                    
                    RaiseTimerEvent(ProcessState.BlinkOn, 2000);
                   
                    break;               
                case ProcessState.AutoRed:
                    IsRedForCar = true;
                    IsYellowForCar = false;
                    IsGreenForCar = false;
                    IsRedForPeople = false;
                    IsGreenForPeople = true;

                    RaiseTimerEvent(ProcessState.AutoGreen, 5000);

                    break;
                case ProcessState.AutoYellow:
                    IsRedForCar = false;
                    IsYellowForCar = true;
                    IsGreenForCar = false;
                    IsRedForPeople = true;
                    IsGreenForPeople = false;
                    
                    RaiseTimerEvent(ProcessState.AutoRed, 3000);

                    break;
                case ProcessState.AutoGreen:
                    IsRedForCar = false;
                    IsYellowForCar = false;
                    IsGreenForCar = true;
                    IsRedForPeople = true;
                    IsGreenForPeople = false;

                    RaiseTimerEvent(ProcessState.AutoYellow, 10000);

                    break;                              
            }

        }

        public void ForceNextState(ProcessState NextState)
        {
            _isEventRaised = false;
            _timer.Stop();
            _theStateOfTheProcess = NextState;
        }


        private bool _isRedForCar;
        public bool IsRedForCar 
        {
            get
            {
                return _isRedForCar;
            }
            set
            {
                _isRedForCar = value;
                OnPropertyChanged(nameof(IsRedForCarsVisible));
            }
        }

        public System.Windows.Visibility IsRedForCarsVisible
        {
            get
            {
                if(_isRedForCar)
                {
                    return System.Windows.Visibility.Visible;
                }
                else
                {
                    return System.Windows.Visibility.Hidden;
                }
            }
        }

        private bool _isYellowForCar;
        public bool IsYellowForCar
        {
            get
            {
                return _isYellowForCar;
            }
            set
            {
                _isYellowForCar = value;
                OnPropertyChanged(nameof(IsYellowForCarsVisible));
            }
        }

        public System.Windows.Visibility IsYellowForCarsVisible
        {
            get
            {
                if (_isYellowForCar)
                {
                    return System.Windows.Visibility.Visible;
                }
                else
                {
                    return System.Windows.Visibility.Hidden;
                }
            }
        }

        private bool _isGreenForCar;
        public bool IsGreenForCar
        {
            get
            {
                return _isGreenForCar;
            }
            set
            {
                _isGreenForCar = value;
                OnPropertyChanged(nameof(IsGreenForCarsVisible));
            }
        }

        public System.Windows.Visibility IsGreenForCarsVisible
        {
            get
            {
                if (_isGreenForCar)
                {
                    return System.Windows.Visibility.Visible;
                }
                else
                {
                    return System.Windows.Visibility.Hidden;
                }
            }
        }

        private bool _isGreenForPeople;
        public bool IsGreenForPeople
        {
            get
            {
                return _isGreenForPeople;
            }
            set
            {
                _isGreenForPeople = value;
                OnPropertyChanged(nameof(IsGreenForPeopleVisible));
            }
        }

        public System.Windows.Visibility IsGreenForPeopleVisible
        {
            get
            {
                if (_isGreenForPeople)
                {
                    return System.Windows.Visibility.Visible;
                }
                else
                {
                    return System.Windows.Visibility.Hidden;
                }
            }
        }

        private bool _isRedForPeople;
        public bool IsRedForPeople
        {
            get
            {
                return _isRedForPeople;
            }
            set
            {
                _isRedForPeople = value;
                OnPropertyChanged(nameof(IsRedForPeopleVisible));
            }
        }

        public System.Windows.Visibility IsRedForPeopleVisible
        {
            get
            {
                if (_isRedForPeople)
                {
                    return System.Windows.Visibility.Visible;
                }
                else
                {
                    return System.Windows.Visibility.Hidden;
                }
            }
        }



    }
}
