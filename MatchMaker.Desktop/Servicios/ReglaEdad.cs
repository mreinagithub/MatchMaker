using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MatchMaker
{
    public class ReglaEdad
    {

        public int Edad { get; set; }
        public IList<int> Permitidos { get; set; }

        public override string ToString()
        {
            return Edad.ToString();
        }

        public static IList<ReglaEdad> ObtenerReglas()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //var resourceName = "reglaEdades.json";
            //using Stream openStream = assembly.GetManifestResourceStream(resourceName);

            var jsonText = File.ReadAllText("Servicios/reglaEdades.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var lstReglas = JsonSerializer.Deserialize<List<ReglaEdad>>(jsonText);

            return lstReglas;
        }

    }
}
