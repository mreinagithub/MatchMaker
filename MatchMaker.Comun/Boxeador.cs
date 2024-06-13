using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun.Modelos
{
    public class Boxeador : INotifyPropertyChanged
    {

        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        [Required(ErrorMessage = "Campo Nombre requerido.")]
        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Profesor { get; set; }
        public int CantidadPeleas { get; set; }  
        public bool Asignado { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

    }
}
