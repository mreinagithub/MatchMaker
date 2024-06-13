using MatchMaker.Comun.Data;
using MatchMaker.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchMaker
{
    public partial class FormOtrosEventos : Form
    {
        public FormOtrosEventos()
        {
            InitializeComponent();
        }

        DatabaseHandler _dataBase;
        BindingList<Backup> _backups = new BindingList<Backup>();


        public string ArchivoAAbrir { get; set; }

        private void FormOtrosEventos_Load(object sender, EventArgs e)
        {
            try
            {
                //Iniciamos la base de datos
                _dataBase = new DatabaseHandler();
                var lstbk = GetBackups();
                _backups = new BindingList<Backup>(lstbk);
                grillaBackups.Rows.Clear();
                grillaBackups.DataSource = _backups;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar la pantalla.", MessageBoxButtons.OK);
                this.Close();
            }
        }

        public List<Backup> GetBackups()
        {
            try
            {
                var conn = _dataBase.GetBackupConnection();
                var results = conn.Table<Backup>().ToList();
                _dataBase.CloseConnection();

                return results.OrderByDescending(p => p.CreadoEl)
                  .ToList();
            }
            catch
            {
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            var row = grillaBackups.CurrentRow;
            if (row == null)
                return;

            var bck = row.DataBoundItem as Backup; if (bck == null) return;

            ArchivoAAbrir = bck.NombreArchivo;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
