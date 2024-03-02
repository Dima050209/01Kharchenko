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
        private int _age;
        private string _chineseZodiac;
        private string _westernZoiac;
        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                try
                {
                    _goroscope.checkBirthday(_birthdate);
                }
                catch(Exception e)
                {
                   
                }
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(ChineseZodiac));
                OnPropertyChanged(nameof(WesternZodiac));
            }
        }
        public int Age
        {
            get
            {
                return _goroscope.calculateAge(_birthdate);
            }
            set
            {
                _age = value;
            }
        }
        public string ChineseZodiac
        {
            get
            {
                return _goroscope.calculateChineseZodiac(_birthdate);
            }
            set
            {
                _chineseZodiac = value;
            }
        }
        public string WesternZodiac
        {
            get
            {
                return _goroscope.calculateWesternZodiac(_birthdate);
            }
            set
            {
                _westernZoiac = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
