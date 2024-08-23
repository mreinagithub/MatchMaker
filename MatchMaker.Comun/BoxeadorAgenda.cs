using MatchMaker.Comun.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun
{
    public class BoxeadorAgenda : Boxeador
    {

        
        public string URL { get; set; }
        public string Evento { get; set; }
        [Ignore]
        public string Categoria { 
            get
            {
                if (this.Peso <= 49) return "Cat 49";
                if (this.Peso <= 52) return "Cat 52";
                if (this.Peso <= 56) return "Cat 56";
                if (this.Peso <= 60) return "Cat 60";
                if (this.Peso <= 64) return "Cat 64";
                if (this.Peso <= 69) return "Cat 69";
                if (this.Peso <= 75) return "Cat 75";
                if (this.Peso <= 81) return "Cat 81";
                if (this.Peso <= 91) return "Cat 91";
                return "Cat 91+";
            }
        }

        public static BoxeadorAgenda Crear(Boxeador bx, string evento)
        {
            var boxAgenda = new BoxeadorAgenda();               
            boxAgenda.Nombre = bx.Nombre;   
            boxAgenda.Peso = bx.Peso;            
            boxAgenda.FechaNacimiento = bx.FechaNacimiento; 
            boxAgenda.Edad = bx.Edad;   
            boxAgenda.Sexo = bx.Sexo;   
            boxAgenda.Profesor = bx.Profesor;   
            boxAgenda.CantidadPeleas = bx.CantidadPeleas;   
            boxAgenda.Asignado = bx.Asignado;
            boxAgenda.Evento = evento;            
            return boxAgenda;
        }

    }
}
