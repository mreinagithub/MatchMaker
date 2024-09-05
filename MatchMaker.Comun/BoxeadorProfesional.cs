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
                string resu = "Sin Definir";
                if(String.IsNullOrWhiteSpace(Sexo)) return resu;
                if(Sexo == "M")
                {
                    if (Libras <= 105)
                        resu = CategoriaProfesional.Minimo.ToString();
                    else if(Libras <= 108)
                        resu = CategoriaProfesional.MiniMosca.ToString();
                    else if (Libras <= 112)
                        resu = CategoriaProfesional.Mosca.ToString();
                    else if (Libras <= 115)
                        resu = CategoriaProfesional.SuperMosca.ToString();
                    else if (Libras <= 118)
                        resu = CategoriaProfesional.Gallo.ToString();
                    else if (Libras <= 122)
                        resu = CategoriaProfesional.SuperGallo.ToString();
                    else if (Libras <= 126)
                        resu = CategoriaProfesional.Pluma.ToString();
                    else if (Libras <= 130)
                        resu = CategoriaProfesional.SuperPluma.ToString();
                    else if (Libras <= 135)
                        resu = CategoriaProfesional.Ligero.ToString();
                    else if (Libras <= 140)
                        resu = CategoriaProfesional.SuperLigero.ToString();
                    else if (Libras <= 147)
                        resu = CategoriaProfesional.Welter.ToString();
                    else if (Libras <= 154)
                        resu = CategoriaProfesional.SuperWelter.ToString();
                    else if (Libras <= 160)
                        resu = CategoriaProfesional.Mediano.ToString();
                    else if (Libras <= 168)
                        resu = CategoriaProfesional.SuperMediano.ToString();
                    else if (Libras <= 175)
                        resu = CategoriaProfesional.MedioPesado.ToString();
                    else if (Libras <= 200)
                        resu = CategoriaProfesional.Crucero.ToString();
                    else if (Libras <= 224)
                        resu = CategoriaProfesional.SuperCrucero.ToString();
                    else
                        resu = CategoriaProfesional.Pesado.ToString();

                }
                else
                {
                    if (Libras <= 102)
                        resu = CategoriaProfesional.Atomo.ToString();
                    else if (Libras <= 105)
                        resu = CategoriaProfesional.Minimo.ToString();
                    else if (Libras <= 108)
                        resu = CategoriaProfesional.MiniMosca.ToString();
                    else if (Libras <= 112)
                        resu = CategoriaProfesional.Mosca.ToString();
                    else if (Libras <= 115)
                        resu = CategoriaProfesional.SuperMosca.ToString();
                    else if (Libras <= 118)
                        resu = CategoriaProfesional.Gallo.ToString();
                    else if (Libras <= 122)
                        resu = CategoriaProfesional.SuperGallo.ToString();
                    else if (Libras <= 126)
                        resu = CategoriaProfesional.Pluma.ToString();
                    else if (Libras <= 130)
                        resu = CategoriaProfesional.SuperPluma.ToString();
                    else if (Libras <= 135)
                        resu = CategoriaProfesional.Ligero.ToString();
                    else if (Libras <= 140)
                        resu = CategoriaProfesional.SuperLigero.ToString();
                    else if (Libras <= 147)
                        resu = CategoriaProfesional.Welter.ToString();
                    else if (Libras <= 154)
                        resu = CategoriaProfesional.SuperWelter.ToString();
                    else if (Libras <= 160)
                        resu = CategoriaProfesional.Mediano.ToString();
                    else if (Libras <= 168)
                        resu = CategoriaProfesional.SuperMediano.ToString();
                    else
                        resu = CategoriaProfesional.Pesado.ToString();
                }
                return resu;
            }
        }


    }
}
