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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FechaElegida = this.txtFechaEvento.Value;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNoGuardar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"Se va a descartar el evento actual. ¿Proceder?","Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            
        }
    }
}
