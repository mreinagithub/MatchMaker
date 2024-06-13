using MatchMaker.Comun.Data;
using MatchMaker.Comun.Modelos;

namespace MatchMaker.TVShow
{
    public class DataBaseSupport
    {


        public DataBaseSupport()
        {
            _dataBase = new DatabaseHandler();
        }

        DatabaseHandler _dataBase;

        public List<PeleaDTO> GetPeleas()
        {
            try
            {
                var conn = _dataBase.GetConnection();
                var results = conn.Table<Pelea>().ToList();     
                var boxeadores = conn.Table<Boxeador>().ToList();

                _dataBase.CloseConnection();

                IList<PeleaDTO> _peleas = new List<PeleaDTO>();

                //Asignar boxeadores
                foreach (var pelea in results)
                {
                    var pdto = new PeleaDTO();
                    pdto.Orden = pelea.Orden;
                    pdto.BoxeadorRinconRojo = boxeadores.FirstOrDefault(b => b.ID == pelea.Boxeador1ID).Nombre;
                    pdto.BoxeadorRinconAzul = boxeadores.FirstOrDefault(b => b.ID == pelea.Boxeador2ID).Nombre;

                    _peleas.Add(pdto);                    
                }

                return _peleas.OrderBy(p => p.Orden)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

    }
}
