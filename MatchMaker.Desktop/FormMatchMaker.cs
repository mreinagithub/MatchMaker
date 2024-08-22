using MatchMaker.Comun.Data;
using MatchMaker.Comun.Modelos;
using MatchMaker.Comun;
using SQLite;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static SQLite.SQLite3;
using MatchMaker.Desktop;

namespace MatchMaker
{
    public partial class FormMatchMaker : Form
    {
        public FormMatchMaker()
        {
            //SETEAR CULTURA ARGENTINA
            var cInfo = new CultureInfo("es-AR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = cInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = cInfo;

            InitializeComponent();
        }

        bool _SoloLectura = false;

        bool _grillaAllowDecimalSeparator = false;
        DatabaseHandler _dataBase;
        BindingList<Boxeador> _boxeadores = new BindingList<Boxeador>();

        BindingList<Boxeador> _boxMascCat49 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat49 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat52 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat52 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat56 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat56 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat60 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat60 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat64 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat64 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat69 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat69 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat75 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat75 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat81 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat81 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCat91 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCat91 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxMascCatMas91 = new BindingList<Boxeador>();
        BindingList<Boxeador> _boxFemCatMas91 = new BindingList<Boxeador>();

        BindingList<Pelea> _peleas = new BindingList<Pelea>();

        IList<ReglaEdad> _reglasEdad = new List<ReglaEdad>();

        System.Windows.Forms.Timer _timer;

        FormAyuda _fayuda = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Iniciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar el programa", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void GrillaIngreso_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 3)
            //{
            //    string texto = grillaIngreso.CurrentCell.EditedFormattedValue.ToString();
            //    if (!DateTime.TryParse(texto, out DateTime fechaValida))
            //    {
            //        grillaIngreso.CurrentCell.Value = "";                    
            //    }
            //}


            ////Para que se refresque el valor de la ultima celda en el boxeador.
            //if (grillaIngreso.IsCurrentCellInEditMode) { grillaIngreso.EndEdit(); }
            //Boxeador boxActualizado = _boxeadores[e.RowIndex];
            //if (boxActualizado == null) { return; }
            //if (boxActualizado.ID != null)
            //{
            //    UpdateRecord(boxActualizado);
            //}
            //ArmarCategorias();
        }
        private void GrillaIngreso_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string texto = grillaIngreso.CurrentCell.EditedFormattedValue.ToString();
                if (!DateTime.TryParse(texto, out DateTime fechaValida))
                {
                    grillaIngreso.CurrentCell.Value = null;                    
                }
            }
        }
        private void GrillaIngreso_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //Para que se refresque el valor de la ultima celda en el boxeador.
            if (grillaIngreso.IsCurrentCellInEditMode) { grillaIngreso.EndEdit(); }

            if (_boxeadores.Count > 0)
            {

                Boxeador boxActualizado = _boxeadores[e.RowIndex];
                if (boxActualizado == null) { return; }
                if (boxActualizado.ID == null) //Alta
                {
                    InsertBoxeador(boxActualizado);
                }
                else //Update
                {
                    UpdateBoxeador(boxActualizado);
                }
                ArmarCategorias();
            }
        }
        private void GrillaIngreso_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Boxeador boxEliminado = _boxeadores[e.Row.Index];
            if (boxEliminado == null)
            {
                e.Cancel = true;
                return;
            }
            {
                if (boxEliminado.Asignado)
                {
                    e.Cancel = true;
                    return;
                }

                var dr = MessageBox.Show(this, $"¿Desea eliminar a {boxEliminado}?", "Pregunta", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                DeleteBoxeador(boxEliminado);
            }
            ArmarCategorias();
        }
        private void grillaIngreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnNumber_KeyPress);
            _grillaAllowDecimalSeparator = grillaIngreso.CurrentCell.ColumnIndex == 5;
            if (grillaIngreso.CurrentCell.ColumnIndex == 4
                || grillaIngreso.CurrentCell.ColumnIndex == 5
                || grillaIngreso.CurrentCell.ColumnIndex == 6)
            {
                _grillaAllowDecimalSeparator = true;
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnNumber_KeyPress);
                }
            }
            else if(grillaIngreso.CurrentCell.ColumnIndex == 7)
            {
                TextBox txtBx = e.Control as TextBox;
                txtBx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBx.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //Get values
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataGridViewRow row in grillaIngreso.Rows)
                {
                    string value = Convert.ToString(row.Cells[grillaIngreso.CurrentCell.ColumnIndex].Value);
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
        private void grillaIngreso_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                bool edadEstablecida = false;
                string texto = grillaIngreso.CurrentCell.EditedFormattedValue.ToString();
                if (DateTime.TryParse(texto, out DateTime fechaNacim))
                {
                    //Calcular edad
                    int edad = CalcularEdad(fechaNacim);
                    if (edad > 0)
                    {
                        grillaIngreso.CurrentRow.Cells[4].Value = edad;
                    }
                    edadEstablecida = true;
                }
                grillaIngreso.CurrentRow.Cells[4].ReadOnly = edadEstablecida;
            }
            else if (e.ColumnIndex == 5)
            {
                string texto = grillaIngreso.CurrentCell.EditedFormattedValue.ToString();
                texto = texto.Replace(".", ",");
                grillaIngreso.CurrentCell.Value = texto;
            }
        }       

        private void grillaPeleas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    string col = grillaPeleas.Columns[e.ColumnIndex].DataPropertyName;
            //    string order = "ASC";
            //    if (grillaPeleas.Tag != null)
            //        order = grillaPeleas.Tag.ToString().Contains("ASC") ? "DESC" : "ASC";
            //    grillaPeleas.Tag = col + "|" + order;

            //    if (grillaPeleas.Tag != null && !string.IsNullOrWhiteSpace(grillaPeleas.Tag.ToString()))
            //    {
            //        string[] condiciones = grillaPeleas.Tag.ToString().Split('|');
            //        if (condiciones[1].Contains("ASC"))
            //            _peleas = new BindingList<Pelea>(_peleas.OrderBy(x => GetPropValue(x, condiciones[0])).ToList());
            //        else
            //            _peleas = new BindingList<Pelea>(_peleas.OrderByDescending(x => GetPropValue(x, condiciones[0])).ToList());
            //        grillaPeleas.DataSource = _peleas;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MostrarMensaje.MostrarError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }
        private void contextArmarPelea_Opening(object sender, CancelEventArgs e)
        {

            ValidarSiPuedeArmarPelea(sender);
        }
        private void contextArmarPelea_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name != "toolArmarPelea")
                return;



            ArmarPelea(sender);

        }
        private void contextDesarmarPelea_Opening(object sender, CancelEventArgs e)
        {
            ValidarSiPuedeEjecutarAcciones(sender);
        }
        private void contextDesarmarPelea_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var c = sender as ContextMenuStrip;
            var src = c.SourceControl;

            if (e.ClickedItem.Name == "toolDesarmarPelea")
                DesarmarPelea(src);

            if (e.ClickedItem.Name == "toolSubir")
            {
                int? nIndice = SubirPelea(src);
                SeleccionManualGrilla((DataGridView)src, nIndice);
            }

            if (e.ClickedItem.Name == "toolBajar")
            {
                int? nIndice = BajarPelea(grillaPeleas);
                SeleccionManualGrilla((DataGridView)src, nIndice);
            }

        }
        private void grillaPeleas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;

            DesarmarPelea(sender);
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SoloLectura)
                    return;

                int? nIndice = SubirPelea(grillaPeleas);
                SeleccionManualGrilla(grillaPeleas, nIndice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al reordenar", MessageBoxButtons.OK);
            }

        }
        private void btnBajar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SoloLectura)
                    return;

                int? nIndice = BajarPelea(grillaPeleas);
                SeleccionManualGrilla(grillaPeleas, nIndice);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al reordenar", MessageBoxButtons.OK);
            }
        }

        private void nuevoEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormNuevoEvento fNuevo = new FormNuevoEvento();
                var resu = fNuevo.ShowDialog();
                if (resu == DialogResult.Yes)
                {
                    _dataBase.GenerarBackup(fNuevo.FechaElegida, fNuevo.TipoEventoElegido);
                    _dataBase.RestoreDB();
                    Iniciar();
                }
                else if (resu == DialogResult.No)
                {
                    _dataBase.RestoreDB();
                    Iniciar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar el programa", MessageBoxButtons.OK);
            }


        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            nuevoEventoToolStripMenuItem.Enabled = !_SoloLectura;
            volverAlEventoActualToolStripMenuItem.Enabled = _SoloLectura;
        }
        private void verOtrosEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                FormOtrosEventos f = new FormOtrosEventos();
                var resu = f.ShowDialog();
                if (resu != DialogResult.OK)
                    return;

                Iniciar(f.ArchivoAAbrir);

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "Error al iniciar la pantalla", MessageBoxButtons.OK);
            }
        }
        private void volverAlEventoActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Iniciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar el evento actual", MessageBoxButtons.OK);
            }
        }


        private void exportarPeleasAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1 = new SaveFileDialog();
                //openFileDialog.InitialDirectory = "c:\\";
                saveFileDialog1.Filter = "Archivo Excel(*.xlsx)|*.xlsx|Excel 2007 (*.xls)|*.xls";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = "peleas";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = DataGridView_To_Datatable(grillaPeleas);
                    dt.exportToExcel(saveFileDialog1.FileName);
                    MessageBox.Show("Exportación realizada.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void guiaDeUsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fayuda = new FormAyuda();
            _fayuda.ShowDialog();

        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_SoloLectura) return;

            try
            {
                _timer.Stop();
                //Tomar backup del archivo
                _dataBase.TomarBackupEvento();
            }
            catch
            {
               //Consumimos
            }
            finally
            {
                _timer.Start();
            }
        }

        private void Iniciar(string backup = "")
        {
            try
            {
                Task.Delay(2000);

                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;

                this.Text = $"Match Maker (v{version}) - {(string.IsNullOrWhiteSpace(backup) ? "Evento Actual" : backup.Substring(0, 15) + " (evento guardado)")}";


                _SoloLectura = !string.IsNullOrWhiteSpace(backup);

                //Iniciamos la base de datos
                _dataBase = new DatabaseHandler();
                var lstBx = GetBoxeadores(backup);
                _boxeadores = new BindingList<Boxeador>(lstBx);
                var lstPeleas = GetPeleas(backup);
                _peleas = new BindingList<Pelea>(lstPeleas);

                //Binding
                grillaIngreso.Rows.Clear();
                grillaIngreso.DataSource = _boxeadores;
                grillaPeleas.Rows.Clear();
                grillaPeleas.DataSource = _peleas;

                ArmarCategorias();

                //Eventos
                grillaIngreso.RowLeave -= GrillaIngreso_RowLeave;
                grillaIngreso.CellLeave -= GrillaIngreso_CellLeave;
                grillaIngreso.UserDeletingRow -= GrillaIngreso_UserDeletingRow;
                grillaIngreso.CellValidating -= GrillaIngreso_CellValidating;
                grillaIngreso.CellValidated -= grillaIngreso_CellValidated;
                grillaIngreso.EditingControlShowing -= grillaIngreso_EditingControlShowing;                

                _timer = null;

                if (!_SoloLectura)
                {

                    //IniciarTimer
                    _timer = new System.Windows.Forms.Timer();
                    _timer.Interval = (60*10*1000); //Respaldo c/10 minutos
                    _timer.Tick += _timer_Tick;                    

                    ////Eventos
                    //grillaIngreso.RowLeave -= GrillaIngreso_RowLeave;
                    //grillaIngreso.CellLeave -= GrillaIngreso_CellLeave;
                    //grillaIngreso.UserDeletingRow -= GrillaIngreso_UserDeletingRow;
                    //grillaIngreso.CellValidating -= GrillaIngreso_CellValidating;
                    //grillaIngreso.CellValidated -= grillaIngreso_CellValidated;
                    //grillaIngreso.EditingControlShowing -= grillaIngreso_EditingControlShowing;

                    grillaIngreso.RowLeave += GrillaIngreso_RowLeave;
                    grillaIngreso.CellLeave += GrillaIngreso_CellLeave;
                    grillaIngreso.UserDeletingRow += GrillaIngreso_UserDeletingRow;
                    grillaIngreso.CellValidating += GrillaIngreso_CellValidating;
                    grillaIngreso.CellValidated += grillaIngreso_CellValidated;
                    grillaIngreso.EditingControlShowing += grillaIngreso_EditingControlShowing;                    

                    //Cargar Reglas Edades
                    _reglasEdad = ReglaEdad.ObtenerReglas();
                }

                BloquearAsignadosYColorearGrillas();

                if (!_SoloLectura && _timer != null) _timer.Start();

            }
            catch
            {
                throw;
            }
        }

       

        private bool ValidarBoxeador(Boxeador boxeador)
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
        private void ArmarCategorias()
        {
            _boxMascCat49 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso <= 49)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat49.DataSource = _boxMascCat49;

            _boxFemCat49 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso <= 49)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat49.DataSource = _boxFemCat49;

            _boxMascCat52 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 49 && b.Peso <= 52)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat52.DataSource = _boxMascCat52;

            _boxFemCat52 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 49 && b.Peso <= 52)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat52.DataSource = _boxFemCat52;

            _boxMascCat56 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 52 && b.Peso <= 56)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat56.DataSource = _boxMascCat56;

            _boxFemCat56 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 52 && b.Peso <= 56)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat56.DataSource = _boxFemCat56;

            _boxMascCat60 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 56 && b.Peso <= 60)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat60.DataSource = _boxMascCat60;

            _boxFemCat60 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 56 && b.Peso <= 60)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat60.DataSource = _boxFemCat60;

            _boxMascCat64 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 60 && b.Peso <= 64)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat64.DataSource = _boxMascCat64;

            _boxFemCat64 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 60 && b.Peso <= 64)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat64.DataSource = _boxFemCat64;

            _boxMascCat69 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 64 && b.Peso <= 69)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat69.DataSource = _boxMascCat69;

            _boxFemCat69 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 64 && b.Peso <= 69)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat69.DataSource = _boxFemCat69;

            _boxMascCat75 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 69 && b.Peso <= 75)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat75.DataSource = _boxMascCat75;

            _boxFemCat75 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 69 && b.Peso <= 75)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat75.DataSource = _boxFemCat75;

            _boxMascCat81 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 75 && b.Peso <= 81)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat81.DataSource = _boxMascCat81;

            _boxFemCat81 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 75 && b.Peso <= 81)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat81.DataSource = _boxFemCat81;

            _boxMascCat91 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 81 && b.Peso <= 91)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaMascCat91.DataSource = _boxMascCat91;

            _boxFemCat91 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 81 && b.Peso <= 91)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCat91.DataSource = _boxFemCat91;

            _boxMascCatMas91 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "M" && b.Peso > 91)
               .Where(b => !b.Asignado)
               .OrderBy(b => b.Edad)
               .ToList());
            grillaMascCatMas91.DataSource = _boxMascCatMas91;

            _boxFemCatMas91 = new BindingList<Boxeador>(_boxeadores.Where(b => b.Sexo == "F" && b.Peso > 91)
                .Where(b => !b.Asignado)
                .OrderBy(b => b.Edad)
                .ToList());
            grillaFemCatMas91.DataSource = _boxFemCatMas91;

            //BloquearAsignadosYColorearGrillas();

        }
        private object GetPropValue(object src, string propName)
        {
            //Obtiene el valor de la propiedad desde el source por reflexión.            
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        private void BloquearAsignadosYColorearGrillas()
        {
            foreach (DataGridViewRow row in grillaIngreso.Rows)
            {
                var bx = row.DataBoundItem as Boxeador;
                if (bx != null && bx.Asignado)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else
                {
                    row.ReadOnly = _SoloLectura;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

        }
        private void ValidarSiPuedeArmarPelea(object sender)
        {
            var c = sender as ContextMenuStrip;

            c.Items["toolArmarPelea"].Enabled = false;

            var src = c.SourceControl;

            if (src != null && src is DataGridView)
            {
                var grd = (DataGridView)src;
                var slc = grd.SelectedRows;
                if (slc.Count == 2)
                {
                    var bx1 = slc[1].DataBoundItem as Boxeador;
                    var bx2 = slc[0].DataBoundItem as Boxeador;

                    if (bx1 != null && !bx1.Asignado
                        && bx2 != null && !bx2.Asignado)
                    {
                        c.Items["toolArmarPelea"].Enabled = !_SoloLectura;
                    }
                }

            }
        }
        private void ValidarSiPuedeEjecutarAcciones(object sender)
        {
            var c = sender as ContextMenuStrip;

            c.Items["toolDesarmarPelea"].Enabled = false;
            c.Items["toolSubir"].Enabled = false;
            c.Items["toolBajar"].Enabled = false;

            var src = c.SourceControl;

            if (src != null && src is DataGridView)
            {
                var grd = (DataGridView)src;
                var slc = grd.SelectedRows;
                if (slc.Count == 1)
                {
                    var pelea = slc[0].DataBoundItem as Pelea;

                    if (pelea != null)
                    {
                        c.Items["toolDesarmarPelea"].Enabled = !_SoloLectura;
                        c.Items["toolSubir"].Enabled = !_SoloLectura;
                        c.Items["toolBajar"].Enabled = !_SoloLectura;
                    }
                }

            }
        }
        private void ArmarPelea(object sender)
        {
            var c = sender as ContextMenuStrip;
            var src = c.SourceControl;

            if (src == null || src is not DataGridView)
                return;

            var grd = (DataGridView)src;
            var slc = grd.SelectedRows;
            if (slc.Count != 2)
                return;

            var bx1 = slc[1].DataBoundItem as Boxeador;
            var bx2 = slc[0].DataBoundItem as Boxeador;

            if (bx1 == null || bx1.Asignado || bx2 == null || bx2.Asignado)
                return;

            bool advertirIncompatibilidadEdad = false;
            var regla1 = _reglasEdad.FirstOrDefault(e => e.Edad.Equals(bx1.Edad));
            var regla2 = _reglasEdad.FirstOrDefault(e => e.Edad.Equals(bx2.Edad));
            if (regla1 == null) //El boxeador 1 es mayor de edad.
            {
                if (regla2 != null && !regla2.Permitidos.Any(p => p == 0)) //Vemos si el boxeador 2 tambien es mayor de edad o acepta pelar con mayores de edad.
                {
                    advertirIncompatibilidadEdad = true;
                }
            }
            else if (regla2 == null) //El boxeador 2 es mayor de edad.
            {
                if (!regla1.Permitidos.Any(p => p == 0)) //Vemos si el boxeador 1 acepta pelear con mayores de edad.
                {
                    advertirIncompatibilidadEdad = true;
                }
            }
            else
            {
                if (regla1.Edad != regla2.Edad
                    && !regla1.Permitidos.Any(p => p == regla2.Edad)
                    && !regla2.Permitidos.Any(p => p == regla1.Edad)) //Si no tienen la misma edad, vemos si Boxeador 2 está entre los permitidos del boxeador 1 y viceversa.
                {
                    advertirIncompatibilidadEdad = true;
                }
            }

            string mensaje;
            if (advertirIncompatibilidadEdad)
            {
                mensaje = $"Hay INCOMPATIBILIDAD entre las edades de los boxeadores.\n{bx1} - Edad: {bx1.Edad}\n{bx2} - Edad: {bx2.Edad}\n\n¿Desea ARMAR la pelea de todas formas?";
            }
            else
            {
                mensaje = $"¿Desea ARMAR la pelea entre {bx1} y {bx2}?";
            }
            var resu = MessageBox.Show(this, mensaje, "Pregunta", MessageBoxButtons.YesNo);
            if (resu != DialogResult.Yes)
                return;

            string categoria = tabPrincipal.SelectedTab?.Text;
            if (categoria == "Ingreso")
                categoria = "MIX";

            Pelea pelea = new Pelea
            {
                Categoria = categoria,
                Sexo = bx1.Sexo,
                Boxeador1 = bx1,
                Boxeador1ID = bx1.ID.Value,
                ProfesorBoxeador1 = bx1.Profesor,
                Boxeador2 = bx2,
                Boxeador2ID = bx2.ID.Value,
                ProfesorBoxeador2 = bx2.Profesor,
            };

            int orden = _peleas.OrderByDescending(p => p.Orden).FirstOrDefault()?.Orden ?? 0;
            pelea.Orden = orden + 1;

            bx1.Asignado = true;
            bx2.Asignado = true;

            bool guardado = InsertPelea(pelea);

            if (!guardado)
            {
                bx1.Asignado = false;
                bx2.Asignado = false;
            }
            else
            {
                _peleas.Add(pelea);
                //MessageBox.Show(this, "Pelea armada.", "Información", MessageBoxButtons.OK);
            }
            ArmarCategorias();
            BloquearAsignadosYColorearGrillas();
        }
        private void DesarmarPelea(object src)
        {


            if (src == null || src is not DataGridView)
                return;

            var grd = (DataGridView)src;
            var slc = grd.SelectedRows;
            if (slc.Count != 1)
                return;

            var pelea = slc[0].DataBoundItem as Pelea;

            if (pelea == null)
                return;

            var resu = MessageBox.Show(this, $"¿Desea DESARMAR la pelea entre {pelea.Boxeador1} y {pelea.Boxeador2}?", "Pregunta", MessageBoxButtons.YesNo);
            if (resu != DialogResult.Yes)
                return;

            pelea.Boxeador1.Asignado = false;
            pelea.Boxeador2.Asignado = false;

            bool guardado = DeletePelea(pelea);

            if (!guardado)
            {
                pelea.Boxeador1.Asignado = true;
                pelea.Boxeador2.Asignado = true;
            }
            else
            {
                _peleas.Remove(pelea);
                //MessageBox.Show(this, "Pelea desarmada.", "Información", MessageBoxButtons.OK);
            }
            ArmarCategorias();
            BloquearAsignadosYColorearGrillas();
            ReordenarPeleas();
        }
        private int? SubirPelea(object src)
        {
            int? nuevOrden = null;

            if (src == null || src is not DataGridView)
                return nuevOrden;

            var grd = (DataGridView)src;
            var slc = grd.SelectedRows;
            if (slc.Count != 1)
                return nuevOrden;

            var pelea = slc[0].DataBoundItem as Pelea;

            if (pelea == null)
                return nuevOrden;

            int orden = pelea.Orden;
            var pelaAnt = _peleas.Where(p => p.Orden < orden)
                                .OrderByDescending(p => p.Orden)
                                .FirstOrDefault();
            if (pelaAnt != null)
            {
                nuevOrden = grd.CurrentRow.Index - 1;

                pelea.Orden = pelaAnt.Orden;
                pelaAnt.Orden = orden;

                ReordenarPeleas();
            }
            return nuevOrden;
        }
        private int? BajarPelea(object src)
        {

            int? nuevOrden = null;

            if (src == null || src is not DataGridView)
                return nuevOrden;

            var grd = (DataGridView)src;
            var slc = grd.SelectedRows;
            if (slc.Count != 1)
                return nuevOrden;

            var pelea = slc[0].DataBoundItem as Pelea;

            if (pelea == null)
                return nuevOrden;

            int orden = pelea.Orden;
            var pelaPost = _peleas
                .Where(p => p.Orden > orden)
                .OrderBy(p => p.Orden)
                .FirstOrDefault();
            if (pelaPost != null)
            {
                nuevOrden = grd.CurrentRow.Index + 1;

                pelea.Orden = pelaPost.Orden;
                pelaPost.Orden = orden;

                ReordenarPeleas();


            }
            return nuevOrden;

        }
        private void ReordenarPeleas()
        {
            //reordenar
            int i = 1;
            foreach (var p in _peleas.OrderBy(p => p.Orden))
            {
                p.Orden = i;
                UpdatePelea(p);
                i++;

            }

            _peleas = new BindingList<Pelea>(_peleas.OrderBy(p => p.Orden).ToList());
            grillaPeleas.DataSource = _peleas;
        }
        private void SeleccionManualGrilla(DataGridView dgv, int? nIndice)
        {
            if (nIndice.HasValue)
            {
                dgv.ClearSelection();
                dgv.CurrentCell = null;
                dgv.Rows[nIndice.Value].Selected = true;
                dgv.CurrentCell = dgv[0, nIndice.Value];
            }
        }
        public static DataTable DataGridView_To_Datatable(DataGridView dg)
        {
            DataTable ExportDataTable = new DataTable();
            foreach (DataGridViewColumn col in dg.Columns)
            {
                if (col.Visible)
                    ExportDataTable.Columns.Add(col.HeaderText);
            }
            foreach (DataGridViewRow row in dg.Rows)
            {
                int i = 0;
                DataRow dRow = ExportDataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (dg.Columns[cell.ColumnIndex].Visible)
                    {
                        dRow[i] = cell.Value;
                        i++;
                    }

                }
                ExportDataTable.Rows.Add(dRow);
            }
            return ExportDataTable;
        }


        private int CalcularEdad(DateTime fechaNacimiento)
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

        //DataSave
        public List<Boxeador> GetBoxeadores(string backup = "")
        {
            try
            {
                var conn = _dataBase.GetConnection(backup);
                var results = conn.Table<Boxeador>().ToList();
                _dataBase.CloseConnection();

                return results;
            }
            catch
            {
                throw;
            }
        }
        public void InsertBoxeador(Boxeador boxeador)
        {
            try
            {
                if (boxeador.ID != null)
                {
                    MessageBox.Show(this, "Intenta crear un boxeador ya creado", "Advertencia", MessageBoxButtons.OK);
                    return;
                }

                if (ValidarBoxeador(boxeador))
                {
                    var conn = _dataBase.GetConnection();
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
        public void UpdateBoxeador(Boxeador boxeador)
        {
            try
            {
                if (boxeador.ID == null)
                {
                    MessageBox.Show(this, "Intenta actualizar un boxeador inexistente", "Advertencia", MessageBoxButtons.OK);
                    return;
                }
                if (boxeador.Asignado)
                {

                }

                if (ValidarBoxeador(boxeador))
                {
                    var conn = _dataBase.GetConnection();
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
        public void DeleteBoxeador(Boxeador boxeador)
        {
            try
            {
                if (boxeador.ID != null)
                {
                    var conn = _dataBase.GetConnection();
                    conn.Delete(boxeador);
                    _dataBase.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }

        }

        public List<Pelea> GetPeleas(string backup = "")
        {
            try
            {
                var conn = _dataBase.GetConnection(backup);
                var results = conn.Table<Pelea>().ToList();
                _dataBase.CloseConnection();

                //Asignar boxeadores
                foreach (var pelea in results)
                {
                    pelea.Boxeador1 = _boxeadores.FirstOrDefault(b => b.ID == pelea.Boxeador1ID);
                    pelea.Boxeador2 = _boxeadores.FirstOrDefault(b => b.ID == pelea.Boxeador2ID);
                }

                return results.OrderBy(p => p.Orden)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }
        public bool InsertPelea(Pelea pelea)
        {
            bool fueGuardado = false;
            try
            {
                var conn = _dataBase.GetConnection();

                conn.Insert(pelea);
                conn.Update(pelea.Boxeador1);
                conn.Update(pelea.Boxeador2);

                _dataBase.CloseConnection();
                fueGuardado = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }
            return fueGuardado;
        }
        public bool DeletePelea(Pelea pelea)
        {
            bool fueGuardado = false;
            try
            {
                var conn = _dataBase.GetConnection();

                conn.Delete(pelea);
                conn.Update(pelea.Boxeador1);
                conn.Update(pelea.Boxeador2);

                _dataBase.CloseConnection();
                fueGuardado = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }
            return fueGuardado;
        }
        public bool UpdatePelea(Pelea pelea)
        {
            bool fueGuardado = false;
            try
            {
                var conn = _dataBase.GetConnection();

                conn.Update(pelea);

                _dataBase.CloseConnection();
                fueGuardado = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error en base de datos", MessageBoxButtons.OK);
            }
            return fueGuardado;
        }

      
    }
}
