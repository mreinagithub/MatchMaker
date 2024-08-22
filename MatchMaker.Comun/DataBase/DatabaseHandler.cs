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

        string backupFolder = "Backups";        
        string DataSource = "MatchMaker.sqlite3";
        string DataSourceBackUp = "Backups.sqlite3";
        string DataSourceInstantanea = "MatchMaker_Respaldo.sqlite3";

        string folder;

        public DatabaseHandler()        
        {
            
            string pDataFolder = Environment.GetEnvironmentVariable("programdata");

            folder = Path.Combine(pDataFolder, "MatchMaker", "DataBase");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            _db = new SQLiteConnection(Path.Combine(folder, DataSource));
            _db.CreateTable<Boxeador>();
            _db.CreateTable<Pelea>();

            _db = new SQLiteConnection(Path.Combine(folder, DataSourceBackUp));
            _db.CreateTable<Backup>();            
        }

        public void RestoreDB()
        {
            GetConnection();
            _db.DropTable<Boxeador>();
            _db.DropTable<Pelea>();
            CloseConnection();
        }

        public void GenerarBackup(DateTime fecha, string tipoEvento)
        {
            string fullPathWithFile = Path.Combine(folder, DataSource);            
            string fullPathBackup = Path.Combine(folder, backupFolder);

            if (!Directory.Exists(fullPathBackup))
            {
                Directory.CreateDirectory(fullPathBackup);
            }

            string nombreBackup = $"Evento_{tipoEvento}_{fecha:yyyyMMdd}_{DateTime.Now:yyyyMMdd_hhmmss}.sqlite3";          
           

            File.Copy(fullPathWithFile, Path.Combine(fullPathBackup, nombreBackup), overwrite: false);

            Backup bck = new Backup
            {
                CreadoEl = DateTime.Now,
                Fecha = fecha,
                NombreArchivo = nombreBackup
            };

            _db = new SQLiteConnection(Path.Combine(folder, DataSourceBackUp));
            _db.Insert(bck);
            _db.Close();

        }
        public void TomarBackupEvento()
        {
            string fullPathWithFile = Path.Combine(folder, DataSource);
            string fullPathWithFileInst = Path.Combine(folder, DataSourceInstantanea);

            File.Copy(fullPathWithFile, fullPathWithFileInst, overwrite: true);
        }

        public SQLiteConnection GetConnection(string backup = "")
        {
            if (!string.IsNullOrEmpty(backup))
            {
                _db = new SQLiteConnection(Path.Combine(folder, backupFolder, backup));
            }
            else
            {
                _db = new SQLiteConnection(Path.Combine(folder, DataSource));
            }
            return _db;
        }
        public SQLiteConnection GetBackupConnection()
        {
            _db = new SQLiteConnection(Path.Combine(folder, DataSourceBackUp));
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
