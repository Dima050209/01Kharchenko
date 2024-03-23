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
                return _goroscope.Birthdate;
            }
            set
            {
                if(_isShutDown)
                {
                    return;
                }
                if (value == _goroscope.Birthdate)
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
                    if(Goroscopecalculator.isBirthday(((DateTime)value).Month, ((DateTime)value).Day))
                    {
                        System.Windows.MessageBox.Show("З Днем народження!!!");
                    }
                    _goroscope.Birthdate = value;
                }
                catch(Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                    _goroscope.Birthdate = value;
                    return;
                }


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
                if (_goroscope.Birthdate == null)
                {
                    return "";
                }
                    if (Goroscopecalculator.isBirthday(((DateTime)_goroscope.Birthdate).Month, ((DateTime)_goroscope.Birthdate).Day))
                {
                    return $"Ваш вік: {Goroscopecalculator.calculateAge((DateTime)_goroscope.Birthdate)}";
                }
                return $"Ваш вік: {Goroscopecalculator.calculateAge((DateTime)_goroscope.Birthdate)}";
            }
            private set
            {
                _goroscope.Age = value;
            }
        }
        public string ChineseZodiac
        {
            get
            {
                if (_goroscope.Birthdate == null)
                {
                    return "";
                }
                return $"Китайський знак зодіака: {Goroscopecalculator.calculateChineseZodiac((DateTime)_goroscope.Birthdate)}";
            }
            private set
            {
                _goroscope.ChineseZodiac = value;
            }
        }
        public string WesternZodiac
        {
            get
            {
                if (_goroscope.Birthdate == null)
                {
                    return "";
                }
                return $"Східний знак зодіака: {Goroscopecalculator.calculateWesternZodiac((DateTime)_goroscope.Birthdate)}";
            }
            private set
            {
                _goroscope.WesternZoiac = value;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
