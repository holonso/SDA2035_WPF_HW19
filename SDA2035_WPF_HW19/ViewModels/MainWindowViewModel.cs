using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SDA2035_WPF_HW19.Models;

namespace SDA2035_WPF_HW19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                if (value > 0)
                    radius = value;
                else
                    radius = 0;
                OnPropertyChanged();
            }
        }
        private double circleLength;
        public double CircleLength
        {
            get => circleLength;
            set
            {
                if (value > 0)
                    circleLength = value;
                else
                    circleLength = 0;
                OnPropertyChanged();
            }
        }

        public ICommand CircleLengthCommand { get; }
        private void OnCircleLengthCommandExecute(object p)
        {
            CircleLength = Math.Round(CircleMath.LengthOfCircle(Radius), 2);
        }
        private bool CanCircleLengthCommandExecuted(object p)
        {
            if (Radius >= 0)
                return true;
            else
                return false;
        }
        public MainWindowViewModel()
        {
            CircleLengthCommand = new RelayCommand(OnCircleLengthCommandExecute, CanCircleLengthCommandExecuted);
        }
    }
}
