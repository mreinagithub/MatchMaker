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

        bool _esLoad = false;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormAgendaBoxeadores_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Delay(2000);

                _esLoad = true;

                //Iniciamos la base de datos
                _dataBase = new DatabaseHandler();

                BindearGrilla();

                //Eventos
                //grillaAgendaBoxeadores.RowLeave += 
                //grillaAgendaBoxeadores.CellLeave += 
                //grillaAgendaBoxeadores.UserDeletingRow += 
                //grillaAgendaBoxeadores.CellValidating += 
                //grillaAgendaBoxeadores.CellValidated += 
                //grillaAgendaBoxeadores.EditingControlShowing += 
                txtFiltroNombre.TextChanged += TxtFiltroNombre_TextChanged;
                txtFiltroCategoria.TextChanged += TxtFiltroCategoria_TextChanged;
                txtFiltroProfEsc.TextChanged += TxtFiltroProfEsc_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar el programa", MessageBoxButtons.OK);
                this.Close();
            }
            finally
            {
                _esLoad = false;
            }
        }
        private void TxtFiltroProfEsc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al leer la agenda", MessageBoxButtons.OK);
            }
        }
        private void TxtFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al leer la agenda", MessageBoxButtons.OK);
            }


        }
        private void TxtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al leer la agenda", MessageBoxButtons.OK);
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
        private void txtBorrarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltroNombre.Text = "";
                txtFiltroCategoria.Text = "";
                txtFiltroProfEsc.Text = "";
                BindearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al leer la agenda", MessageBoxButtons.OK);
            }
        }


        private List<BoxeadorAgenda> GetBoxeadoresAgenda()
        {
            try
            {
                var conn = _dataBase.GetAgendaConnection();
                var results = conn.Table<BoxeadorAgenda>().ToList();

                //Actualizar edad boxeadores
                if (_esLoad)
                {
                    bool hayActualizaciones = false;
                    foreach (BoxeadorAgenda bx in results.Where(b => b.FechaNacimiento is not null))
                    {
                        //Calcular edad
                        int edad = Utilidades.CalcularEdad(bx.FechaNacimiento.Value);
                        if (edad > 0 && edad != bx.Edad)
                        {
                            bx.Edad = edad;
                            hayActualizaciones = true;
                        }
                    }
                    if (hayActualizaciones)
                        conn.UpdateAll(results.Where(b => b.FechaNacimiento is not null), true);
                }

                _dataBase.CloseConnection();

                string fNombre = txtFiltroNombre.Text;
                string fCat = txtFiltroCategoria.Text;
                string fProfesor = txtFiltroProfEsc.Text;

                results = results.Where(b => b.Nombre.ToUpper().Contains(fNombre.ToUpper())
                                          && b.Categoria.ToUpper().Contains(fCat.ToUpper())
                                          && b.Profesor.ToUpper().Contains(fProfesor.ToUpper())).ToList();
                return results;
            }
            catch
            {
                throw;
            }
        }
        private void ConfigurarGrillaBoxeadores()
        {
            foreach (DataGridViewRow row in grillaAgendaBoxeadores.Rows)
            {
                var bx = row.DataBoundItem as BoxeadorAgenda;

                if (bx != null && bx.FechaNacimiento is not null)
                {
                    row.Cells[5].ReadOnly = true;
                }
            }

        }
        private void BindearGrilla()
        {
            var lstBx = GetBoxeadoresAgenda();
            _boxeadores = new BindingList<BoxeadorAgenda>(lstBx);
            grillaAgendaBoxeadores.Rows.Clear();
            grillaAgendaBoxeadores.DataSource = _boxeadores;

            ConfigurarGrillaBoxeadores();
        }

      
    }
}
