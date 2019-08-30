using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class Zakazi : PropertyChangedBase
    {
        // Модель базы данных
        private int id;
        private string fio;
        private string number;
        private string address;
        private string tovar;
        private string summa;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string FIO
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged("FIO");
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Tovar
        {
            get { return tovar; }
            set
            {
                tovar = value;
                OnPropertyChanged("Tovar");
            }
        }
        public string Summa
        {
            get { return summa; }
            set
            {
                summa = value;
                OnPropertyChanged("Summa");
            }
        }

    }
}
