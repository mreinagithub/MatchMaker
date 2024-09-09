using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun
{
    public static class Utilidades
    {

        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }
                else if (fechaNacimiento.Month == fechaActual.Month
                    && fechaNacimiento.Day > fechaActual.Day)
                {
                    --edad;
                }

                return edad;
            }
        }
        public static object GetPropValue(object src, string propName)
        {
            //Obtiene el valor de la propiedad desde el source por reflexión.            
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

      
    }
}
