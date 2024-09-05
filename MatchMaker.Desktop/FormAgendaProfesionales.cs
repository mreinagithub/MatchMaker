using MatchMaker.Comun.Data;
using MatchMaker.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MatchMaker.Desktop
{
    public partial class FormAgendaProfesionales : Form
    {
        public FormAgendaProfesionales()
        {
            InitializeComponent();

            this.FormClosed += FormAgendaProfesionales_FormClosed;
        }

     

        bool _grillaAllowDecimalSeparator = false;
        DatabaseHandler _dataBase;
        BindingList<BoxeadorProfesional> _boxeadores = new BindingList<BoxeadorProfesional>();
        public EventHandler OnCierreFormulario;

        bool _esLoad = false;

        const int _indiceFechaNacimiento = 4;
        const int _indiceEdad = 5;
        const int _indicePeso = 6;
        const int _indiceLibras = 7;
        const int _indiceCantidadPeleas = 9;
        const int _indiceProfesor = 10;
        const int _indiceURL = 12;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormAgendaProfesionales_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCierreFormulario?.Invoke(this, e);
        }
        private void FormAgendaProfesionales_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Delay(2000);

                _esLoad = true;

                //Iniciamos la base de datos
                _dataBase = new DatabaseHandler();

                BindearGrilla();

                //Eventos
                grillaAgendaBoxeadores.RowLeave += GrillaAgendaBoxeadores_RowLeave;
                grillaAgendaBoxeadores.UserDeletingRow += GrillaAgendaBoxeadores_UserDeletingRow;
                grillaAgendaBoxeadores.CellValidating += GrillaAgendaBoxeadores_CellValidating;
                grillaAgendaBoxeadores.CellValidated += GrillaAgendaBoxeadores_CellValidated;
                grillaAgendaBoxeadores.EditingControlShowing += GrillaAgendaBoxeadores_EditingControlShowing;
                txtFiltroNombre.TextChanged += TxtFiltroNombre_TextChanged;
                txtFiltroCategoria.TextChanged += TxtFiltroCategoria_TextChanged;
                txtFiltroProfEsc.TextChanged += TxtFiltroProfEsc_TextChanged;
                grillaAgendaBoxeadores.ColumnHeaderMouseClick += grillaAgendaBoxeadores_ColumnHeaderMouseClick;
                txtBorrarFiltros.Click += txtBorrarFiltros_Click;
                grillaAgendaBoxeadores.CellContentClick += grillaAgendaBoxeadores_CellContentClick;
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

        private void GrillaAgendaBoxeadores_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnNumber_KeyPress);
            _grillaAllowDecimalSeparator = grillaAgendaBoxeadores.CurrentCell.ColumnIndex == _indicePeso;
            if (grillaAgendaBoxeadores.CurrentCell.ColumnIndex == _indiceEdad
                || grillaAgendaBoxeadores.CurrentCell.ColumnIndex == _indicePeso
                || grillaAgendaBoxeadores.CurrentCell.ColumnIndex == _indiceLibras
                || grillaAgendaBoxeadores.CurrentCell.ColumnIndex == _indiceCantidadPeleas)
            {
                _grillaAllowDecimalSeparator = true;
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnNumber_KeyPress);
                }
            }
            else if (grillaAgendaBoxeadores.CurrentCell.ColumnIndex == _indiceProfesor)
            {
                TextBox txtBx = e.Control as TextBox;
                txtBx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBx.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //Get values
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataGridViewRow row in grillaAgendaBoxeadores.Rows)
                {
                    string value = Convert.ToString(row.Cells[grillaAgendaBoxeadores.CurrentCell.ColumnIndex].Value);
                    if (!string.IsNullOrWhiteSpace(value) && !data.Contains(value))
                    {
                        data.Add(value);
                    }
                }
                txtBx.AutoCompleteCustomSource = data;
            }
        }
        private void ColumnNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && (_grillaAllowDecimalSeparator && e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // allow 1 dot:            
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                if ((sender as TextBox).Text != ".")
                {
                    e.Handled = true;
                }
            }
        }
        private void GrillaAgendaBoxeadores_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _indiceFechaNacimiento)
            {
                bool edadEstablecida = false;
                string texto = grillaAgendaBoxeadores.CurrentCell.EditedFormattedValue.ToString();
                if (DateTime.TryParse(texto, out DateTime fechaNacim))
                {
                    //Calcular edad
                    int edad = Utilidades.CalcularEdad(fechaNacim);
                    if (edad > 0)
                    {
                        grillaAgendaBoxeadores.CurrentRow.Cells[_indiceEdad].Value = edad;
                    }
                    edadEstablecida = true;
                }
                grillaAgendaBoxeadores.CurrentRow.Cells[_indiceEdad].ReadOnly = edadEstablecida;
            }
            else if (e.ColumnIndex == _indicePeso)
            {
                string texto = grillaAgendaBoxeadores.CurrentCell.EditedFormattedValue.ToString();
                texto = texto.Replace(".", ",");
                grillaAgendaBoxeadores.CurrentCell.Value = texto;

                decimal kilos = Convert.ToDecimal(texto);

                string libras = Convert.ToString(Decimal.Round(kilos * (2.2M),0));

                grillaAgendaBoxeadores.CurrentRow.Cells[_indiceLibras].Value = libras;
            }
            else if (e.ColumnIndex == _indiceLibras)
            {
                string texto = grillaAgendaBoxeadores.CurrentCell.EditedFormattedValue.ToString();
                texto = texto.Replace(".", ",");
                grillaAgendaBoxeadores.CurrentCell.Value = texto;

                decimal libras = Convert.ToDecimal(texto);

                string kilos = Convert.ToString(Decimal.Round(libras / (2.2M),1));

                grillaAgendaBoxeadores.CurrentRow.Cells[_indicePeso].Value = kilos;
            }
        }
        private void GrillaAgendaBoxeadores_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == _indiceFechaNacimiento)
            {
                string texto = grillaAgendaBoxeadores.CurrentCell.EditedFormattedValue.ToString();
                if (!DateTime.TryParse(texto, out DateTime fechaValida))
                {
                    grillaAgendaBoxeadores.CurrentCell.Value = null;
                }
            }
        }
        private void GrillaAgendaBoxeadores_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            BoxeadorProfesional boxEliminado = _boxeadores[e.Row.Index];
            if (boxEliminado == null)
            {
                e.Cancel = true;
                return;
            }
            {
                var dr = MessageBox.Show(this, $"¿Desea eliminar a {boxEliminado}?", "Pregunta", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                DeleteBoxeadorAgenda(boxEliminado);
            }
        }
        private void GrillaAgendaBoxeadores_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //Para que se refresque el valor de la ultima celda en el boxeador.
            if (grillaAgendaBoxeadores.IsCurrentCellInEditMode) { grillaAgendaBoxeadores.EndEdit(); }

            if (_boxeadores.Count > 0)
            {

                BoxeadorProfesional boxActualizado = _boxeadores[e.RowIndex];
                if (boxActualizado == null) { return; }
                if (boxActualizado.ID == null) //Alta
                {
                    InsertBoxeadorAgenda(boxActualizado);
                }
                else //Update
                {
                    UpdateBoxeadorAgenda(boxActualizado);
                }
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
                        _boxeadores = new BindingList<BoxeadorProfesional>(_boxeadores.OrderBy(x => Utilidades.GetPropValue(x, condiciones[0])).ToList());
                    else
                        _boxeadores = new BindingList<BoxeadorProfesional>(_boxeadores.OrderByDescending(x => Utilidades.GetPropValue(x, condiciones[0])).ToList());
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
        private void grillaAgendaBoxeadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _indiceURL)
            {
                var row = grillaAgendaBoxeadores.Rows[e.RowIndex];
                if (row.Cells[_indiceURL].Value == null) return;
                var url = row.Cells[_indiceURL].Value.ToString();
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    System.Diagnostics.Process.Start(
                        new ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                }
            }
        }

        private void ConfigurarGrillaBoxeadores()
        {
            foreach (DataGridViewRow row in grillaAgendaBoxeadores.Rows)
            {
                var bx = row.DataBoundItem as BoxeadorProfesional;

                if (bx != null && bx.FechaNacimiento is not null)
                {
                    row.Cells[_indiceEdad].ReadOnly = true;
                }
            }

        }
        private void BindearGrilla()
        {
            var lstBx = GetBoxeadoresAgendaProfesional();
            _boxeadores = new BindingList<BoxeadorProfesional>(lstBx);
            grillaAgendaBoxeadores.Rows.Clear();
            grillaAgendaBoxeadores.DataSource = _boxeadores;

            ConfigurarGrillaBoxeadores();
        }
        private bool ValidarBoxeadorAgenda(BoxeadorProfesional boxeador)
        {
            if (boxeador == null)
                return false;
            if (string.IsNullOrWhiteSpace(boxeador.Nombre))
            {
                //MessageBox.Show(this, "Debe indicar el nombre del boxeador.", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            if (boxeador.Peso <= 0)
            {
                //MessageBox.Show(this, "Debe indicar el peso del boxeador.", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            if (boxeador.Edad <= 0)
            {
                //MessageBox.Show(this, "Debe indicar la edad del boxeador.", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            if (string.IsNullOrWhiteSpace(boxeador.Sexo))
            {
                //MessageBox.Show(this, "Debe indicar el sexo del boxeador.", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            return true;

        }

        private List<BoxeadorProfesional> GetBoxeadoresAgendaProfesional()
        {
            try
            {
                var conn = _dataBase.GetAgendaProfesionalesConnection();
                var results = conn.Table<BoxeadorProfesional>().ToList();

                //Actualizar edad boxeadores
                if (_esLoad)
                {
                    bool hayActualizaciones = false;
                    foreach (BoxeadorProfesional bx in results.Where(b => b.FechaNacimiento is not null))
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
        public void InsertBoxeadorAgenda(BoxeadorProfesional boxeador)
        {
            try
            {
                if (boxeador.ID != null)
                {
                    MessageBox.Show(this, "Intenta crear un boxeador ya creado", "Advertencia", MessageBoxButtons.OK);
                    return;
                }

                if (ValidarBoxeadorAgenda(boxeador))
                {
                    var conn = _dataBase.GetAgendaProfesionalesConnection();
                    conn.Insert(boxeador);
                    _dataBase.CloseConnection();
                }
                else
                    _boxeadores.Remove(boxeador);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }
        }
        public void UpdateBoxeadorAgenda(BoxeadorProfesional boxeador)
        {
            try
            {
                if (boxeador.ID == null)
                {
                    MessageBox.Show(this, "Intenta actualizar un boxeador inexistente", "Advertencia", MessageBoxButtons.OK);
                    return;
                }

                if (ValidarBoxeadorAgenda(boxeador))
                {
                    var conn = _dataBase.GetAgendaProfesionalesConnection();
                    conn.Update(boxeador);
                    _dataBase.CloseConnection();
                }
                else
                    _boxeadores.Remove(boxeador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }

        }
        public void DeleteBoxeadorAgenda(BoxeadorProfesional boxeador)
        {
            try
            {
                if (boxeador.ID != null)
                {
                    var conn = _dataBase.GetAgendaProfesionalesConnection();
                    conn.Delete(boxeador);
                    _dataBase.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }

        }
    }
}
