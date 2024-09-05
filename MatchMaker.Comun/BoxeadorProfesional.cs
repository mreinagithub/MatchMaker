using MatchMaker.Comun.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun
{
    public class BoxeadorProfesional : Boxeador
    {

        public decimal Libras { get; set; }
        public string DNI { get; set; }
        public string Nacionalidad { get; set; }
        public string Contacto { get; set; }
        public string URL { get; set; }
        
        [Ignore]
        public string Categoria
        {
            get
            {
                return "A definir";
            }
        }


    }
}
