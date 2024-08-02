using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun.Modelos
{
    public class Pelea: INotifyPropertyChanged
    {


        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string  Sexo { get; set; }
        public string Categoria { get; set; }
        [Indexed]
        public int Boxeador1ID { get; set; }
        [Ignore]
        public Boxeador Boxeador1 { get; set; }
        public string ProfesorBoxeador1 { get; set; }
        [Indexed]
        public int Boxeador2ID { get; set; }
        [Ignore]
        public Boxeador Boxeador2 { get; set; }
        public string ProfesorBoxeador2 { get; set; }
        public int Orden { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
