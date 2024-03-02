using _01Kharchenko.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace _01Kharchenko.ViewModels
{
    class GoroscopeViewModel : INotifyPropertyChanged
    {
        private Goroscope _goroscope = new Goroscope();
        private DateTime _birthdate;
        private string _age;
        private string _chineseZodiac;
        private string _westernZoiac;
        public event PropertyChangedEventHandler? PropertyChanged;
        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                try
                {
                    _goroscope.checkBirthday(value);
                   
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
        public string Age
        {
            get
            {
                if (_goroscope.isBirthday(_birthdate.Month, _birthdate.Day))
                {
                    return $"Ваш вік: {_goroscope.calculateAge(_birthdate)}. З днем народження!";
                }
                return $"Ваш вік: {_goroscope.calculateAge(_birthdate)}";
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
                return $"Китайський знак зодіака: {_goroscope.calculateChineseZodiac(_birthdate)}";
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
                return $"Східний знак зодіака: {_goroscope.calculateWesternZodiac(_birthdate)}";
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
