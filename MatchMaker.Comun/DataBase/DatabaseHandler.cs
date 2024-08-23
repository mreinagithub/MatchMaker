using MatchMaker.Comun.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Comun.Data
{
    public class DatabaseHandler
    {
        private SQLiteConnection _db;

        string otrosEventosFolder = "OtrosEventos";        

        string DataSource = "MatchMaker.sqlite3";
        string DataSourceBackUp = "Backups.sqlite3";
        string DataSourceAgenda = "AgendaBoxeadores.sqlite3";

        string DataSourceRespaldo = "MatchMaker_Respaldo.sqlite3";   
        string DataSourdeAgendaRespaldo = "AgendaBoxeadores_Respaldo.sqlite3";

        string baseFolder;
        string agendaFolder;
        string respaldoFolder;

        public DatabaseHandler()
        {
            
            string pDataFolder = Environment.GetEnvironmentVariable("programdata");

            baseFolder = Path.Combine(pDataFolder, "MatchMaker", "DataBase");

            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            _db = new SQLiteConnection(Path.Combine(baseFolder, DataSource));
            _db.CreateTable<Boxeador>();
            _db.CreateTable<Pelea>();

            _db = new SQLiteConnection(Path.Combine(baseFolder, DataSourceBackUp));
            _db.CreateTable<Backup>();

            agendaFolder = Path.Combine(baseFolder, "Agenda");

            if (!Directory.Exists(agendaFolder))
            {
                Directory.CreateDirectory(agendaFolder);
            }

            _db = new SQLiteConnection(Path.Combine(agendaFolder, DataSourceAgenda));
            _db.CreateTable<BoxeadorAgenda>();

            respaldoFolder = Path.Combine(baseFolder, "Respaldos");

            if (!Directory.Exists(respaldoFolder))
            {
                Directory.CreateDirectory(respaldoFolder);
            }
        }

        public void RestoreDB()
        {
            GetConnection();
            _db.DropTable<Boxeador>();
            _db.DropTable<Pelea>();
            CloseConnection();
        }

        public string GuardarEvento(DateTime fecha, string tipoEvento)
        {
            string fullPathWithFile = Path.Combine(baseFolder, DataSource);            
            string fullPathOtroEvento = Path.Combine(baseFolder, otrosEventosFolder);

            if (!Directory.Exists(fullPathOtroEvento))
            {
                Directory.CreateDirectory(fullPathOtroEvento);
            }

            string nomBackupBase = $"{tipoEvento}_{fecha:yyyyMMdd}_({DateTime.Now:yyyyMMdd_HHmmss})";
            string nombreBackup = $"{nomBackupBase}.sqlite3";          
           

            File.Copy(fullPathWithFile, Path.Combine(fullPathOtroEvento, nombreBackup), overwrite: false);

            Backup bck = new Backup
            {
                CreadoEl = DateTime.Now,
                Fecha = fecha,
                NombreArchivo = nombreBackup
            };

            _db = new SQLiteConnection(Path.Combine(baseFolder, DataSourceBackUp));
            _db.Insert(bck);
            _db.Close();

            return nomBackupBase;
        }
        public void TomarBackupEvento()
        {
            string fullPathWithFile = Path.Combine(baseFolder, DataSource);
            string fullPathWithFileInst = Path.Combine(respaldoFolder, DataSourceRespaldo);

            File.Copy(fullPathWithFile, fullPathWithFileInst, overwrite: true);
        }
        public void TomarBackupAgendaBoxeadores()
        {
            string fullPathWithFile = Path.Combine(agendaFolder, DataSourceAgenda);
            string fullPathWithFileInst = Path.Combine(respaldoFolder, DataSourdeAgendaRespaldo);

            File.Copy(fullPathWithFile, fullPathWithFileInst, overwrite: true);
        }

        public SQLiteConnection GetConnection(string backup = "")
        {
            if (!string.IsNullOrEmpty(backup))
            {
                _db = new SQLiteConnection(Path.Combine(baseFolder, otrosEventosFolder, backup));
            }
            else
            {
                _db = new SQLiteConnection(Path.Combine(baseFolder, DataSource));
            }
            return _db;
        }
        public SQLiteConnection GetBackupConnection()
        {
            _db = new SQLiteConnection(Path.Combine(baseFolder, DataSourceBackUp));
            return _db;
        }
        public SQLiteConnection GetAgendaConnection()
        {
            _db = new SQLiteConnection(Path.Combine(agendaFolder, DataSourceAgenda));
            return _db;
        }
        public void CloseConnection()
        {
            _db.Close();
        }

        private void Copy(string inputFilePath, string outputFilePath)
        {
            using (var inputFile = new FileStream(
                    inputFilePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
            {
                using (var outputFile = new FileStream(outputFilePath, FileMode.Create))
                {
                    var buffer = new byte[0x10000];
                    int bytes;

                    while ((bytes = inputFile.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytes);
                    }
                }
            }
        }
    }
}
