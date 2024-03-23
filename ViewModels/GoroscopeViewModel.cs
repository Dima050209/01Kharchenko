using _01Kharchenko.Models;
using _01Kharchenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _01Kharchenko.ViewModels
{
    class GoroscopeViewModel : INotifyPropertyChanged
    {
        private Goroscope _goroscope = new Goroscope();
        private DateTime? _birthdate = null;
        private string _age;
        private string _chineseZodiac;
        private string _westernZoiac;
        private bool _isShutDown = false;
        public event PropertyChangedEventHandler? PropertyChanged;

        public GoroscopeViewModel()
        {
            Application.Current.MainWindow.Closing += new CancelEventHandler(OnWindowClosing);
        }

        public DateTime? Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                if(_isShutDown)
                {
                    return;
                }
                try
                {
                    if(value != null)
                    {
                        Goroscopecalculator.checkBirthday((DateTime)value);
                    } 
                    else
                    {
                        return;
                    }
                }
                catch(Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                    return;
                }

                _birthdate = value;

                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(ChineseZodiac));
                OnPropertyChanged(nameof(WesternZodiac));
            }
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            _isShutDown = true;
        }
        public string Age
        {
            get
            {
                if (_birthdate == null)
                {
                    return "";
                }
                    if (Goroscopecalculator.isBirthday(((DateTime)_birthdate).Month, ((DateTime)_birthdate).Day))
                {
                    return $"Ваш вік: {Goroscopecalculator.calculateAge((DateTime)_birthdate)}";
                }
                return $"Ваш вік: {Goroscopecalculator.calculateAge((DateTime)_birthdate)}";
            }
            private set
            {
                _age = value;
            }
        }
        public string ChineseZodiac
        {
            get
            {
                if (_birthdate == null)
                {
                    return "";
                }
                return $"Китайський знак зодіака: {Goroscopecalculator.calculateChineseZodiac((DateTime)_birthdate)}";
            }
            private set
            {
                _chineseZodiac = value;
            }
        }
        public string WesternZodiac
        {
            get
            {
                if (_birthdate == null)
                {
                    return "";
                }
                return $"Східний знак зодіака: {Goroscopecalculator.calculateWesternZodiac((DateTime)_birthdate)}";
            }
            private set
            {
                _westernZoiac = value;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
