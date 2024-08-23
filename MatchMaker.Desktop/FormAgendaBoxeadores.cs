using MatchMaker.Comun;
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

namespace MatchMaker.Desktop
{
    public partial class FormAgendaBoxeadores : Form
    {
        public FormAgendaBoxeadores()
        {
            InitializeComponent();
        }


        bool _grillaAllowDecimalSeparator = false;
        DatabaseHandler _dataBase;
        BindingList<BoxeadorAgenda> _boxeadores = new BindingList<BoxeadorAgenda>();

        public string FiltroNombre { get; set; }
        public string FiltroCategoria { get; set; }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormAgendaBoxeadores_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Delay(2000);

                //Iniciamos la base de datos
                _dataBase = new DatabaseHandler();
                var lstBx = GetBoxeadoresAgenda();
                _boxeadores = new BindingList<BoxeadorAgenda>(lstBx);

                //Binding
                grillaAgendaBoxeadores.Rows.Clear();
                grillaAgendaBoxeadores.DataSource = _boxeadores;

                FiltroNombre = "";
                FiltroCategoria = "";
               
                //Eventos
                //grillaAgendaBoxeadores.RowLeave += 
                //grillaAgendaBoxeadores.CellLeave += 
                //grillaAgendaBoxeadores.UserDeletingRow += 
                //grillaAgendaBoxeadores.CellValidating += 
                //grillaAgendaBoxeadores.CellValidated += 
                //grillaAgendaBoxeadores.EditingControlShowing += 
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar el programa", MessageBoxButtons.OK);
                this.Close();
            }
        }

       
        private void grillaAgendaBoxeadores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string col = grillaAgendaBoxeadores.Columns[e.ColumnIndex].DataPropertyName;
                string order = "ASC";
                if (grillaAgendaBoxeadores.Tag != null)
                    order = grillaAgendaBoxeadores.Tag.ToString().Contains("ASC") ? "DESC" : "ASC";
                grillaAgendaBoxeadores.Tag = col + "|" + order;

                if (grillaAgendaBoxeadores.Tag != null && !string.IsNullOrWhiteSpace(grillaAgendaBoxeadores.Tag.ToString()))
                {
                    string[] condiciones = grillaAgendaBoxeadores.Tag.ToString().Split('|');
                    if (condiciones[1].Contains("ASC"))
                        _boxeadores = new BindingList<BoxeadorAgenda>(_boxeadores.OrderBy(x => Utilidades.GetPropValue(x, condiciones[0])).ToList());
                    else
                        _boxeadores = new BindingList<BoxeadorAgenda>(_boxeadores.OrderByDescending(x => Utilidades.GetPropValue(x, condiciones[0])).ToList());
                    grillaAgendaBoxeadores.DataSource = _boxeadores;
                }
            }
            catch (Exception ex)
            {
                //MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public List<BoxeadorAgenda> GetBoxeadoresAgenda()
        {
            try
            {
                var conn = _dataBase.GetAgendaConnection();
                var results = conn.Table<BoxeadorAgenda>().ToList();
                _dataBase.CloseConnection();

                return results;
            }
            catch
            {
                throw;
            }
        }

      
    }
}
