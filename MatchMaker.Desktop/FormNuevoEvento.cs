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
    public partial class FormNuevoEvento : Form
    {
        public FormNuevoEvento()
        {
            InitializeComponent();
        }

        public DateTime FechaElegida { get; set; }
        public string TipoEventoElegido { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FechaElegida = this.txtFechaEvento.Value;

            string tipoEvento = (string)this.cmbTipoEvento.SelectedItem;
            if (string.IsNullOrWhiteSpace(tipoEvento) || tipoEvento == "<Seleccione...>")
            {
                MessageBox.Show(this, "Debe seleccionar el tipo de evento.", "Advertencia", MessageBoxButtons.OK);
                return;
            }

            TipoEventoElegido = tipoEvento;

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNoGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Se va a descartar el evento actual. ¿Proceder?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }

        }

        private void FormNuevoEvento_Load(object sender, EventArgs e)
        {
            this.cmbTipoEvento.SelectedIndex = 0;
        }
    }
}
