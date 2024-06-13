using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun.Modelos
{
    public class Backup : INotifyPropertyChanged
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime CreadoEl { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

    }
}
