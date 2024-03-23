using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Kharchenko.Models
{
    class Goroscope
    {
        private DateTime? _birthdate;
        private string _age;
        private string _chineseZodiac;
        private string _westernZoiac;

        public DateTime? Birthdate
        { 
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
            }
        }
        public string Age
        {
            get
            {
                return _age;
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
                return _chineseZodiac;
            }
            set
            {
                _chineseZodiac = value;
            }
        }
        public string WesternZoiac
        {
            get
            {
                return _westernZoiac;
            }
            set
            {
                _westernZoiac = value;
            }
        }
    }
}
