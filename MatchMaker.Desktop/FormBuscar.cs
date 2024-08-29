using MatchMaker.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchMaker.Desktop
{
    public partial class FormBuscar : Form
    {
        public FormBuscar(DataGridView dgv)
        {
            _dgv = dgv;
            InitializeComponent();
        }

        DataGridView _dgv;
        int cantidadResultadosYaVistos = 0;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.BuscarSiguienteRow(this.txtTextoABuscar.Text);
            if (row != null)
            {
                _dgv.ClearSelection();
                row.Selected = true;
                _dgv.CurrentCell = row.Cells[1];
            }
            else if (this.cantidadResultadosYaVistos == 0)
            {
                MessageBox.Show(this, "No se ha encontrado el texto buscado", "Información", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(this, "Se ha llegado al final de la búsqueda.", "Información", MessageBoxButtons.OK);
                this.cantidadResultadosYaVistos = 0;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FormBuscar_Load(object sender, EventArgs e)
        {
            if (_dgv == null)
                this.Close();
        }
        private void txtTextoABuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                e.Handled = true;
                //e.SuppressKeyPress = true;
            }
        }
        private void txtTextoABuscar_TextChanged(object sender, EventArgs e)
        {
            cantidadResultadosYaVistos = 0;
        }

        private DataGridViewRow BuscarSiguienteRow(string texto)
        {
            int encontrados = 0;
            foreach (DataGridViewRow row in _dgv.Rows)
            {
                foreach (DataGridViewCell celda in row.Cells)
                {
                    if (!string.IsNullOrWhiteSpace(celda.EditedFormattedValue.ToString())
                        && celda.EditedFormattedValue.ToString().ToUpper().IndexOf(texto.ToUpper()) >= 0)
                    {
                        encontrados++;
                        if (encontrados > this.cantidadResultadosYaVistos)
                        {
                            this.cantidadResultadosYaVistos++;
                            _dgv.Rows[celda.RowIndex].Selected = true;
                            return row;
                        }
                    }
                }
            }
            return null;

        }

        
    }
}
