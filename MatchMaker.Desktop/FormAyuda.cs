using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchMaker.Desktop
{
    public partial class FormAyuda : Form
    {
        public FormAyuda()
        {
            InitializeComponent();
        }

        private void FormAyuda_Load(object sender, EventArgs e)
        {
            try
            {                
                string readText = File.ReadAllText("Ayuda.txt", Encoding.UTF8);               
                txtAyuda.Text = readText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar la ayuda", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
