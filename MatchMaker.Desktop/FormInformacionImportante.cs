using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchMaker.Desktop
{
    public partial class FormInformacionImportante : Form
    {
        public FormInformacionImportante()
        {
            InitializeComponent();
        }

        public EventHandler OnCierreFormulario;

        string _textoInfo = "";      
        string _fullPathFile = "";

        private void FormInformacionImportante_Load(object sender, EventArgs e)
        {
            try
            {
                string baseFolder = Path.Combine(Environment.GetEnvironmentVariable("programdata"), "MatchMaker", "DataBase");
                _fullPathFile = Path.Combine(baseFolder, "InformacionImportante.txt");

                if (File.Exists(_fullPathFile))
                {                    
                    txtInfoImportante.LoadFile(_fullPathFile, RichTextBoxStreamType.RichText);
                }                
                _textoInfo = txtInfoImportante.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al iniciar la ayuda", MessageBoxButtons.OK);
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {                
                txtInfoImportante.SaveFile(_fullPathFile, RichTextBoxStreamType.RichText);
                _textoInfo = txtInfoImportante.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al intentar guardar.", MessageBoxButtons.OK);                
            }
        }
        private void FormInformacionImportante_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCierreFormulario?.Invoke(this, e);
        }
        private void FormInformacionImportante_FormClosing(object sender, FormClosingEventArgs e)
        {
            string txt = txtInfoImportante.Text;
            if(!txt.Equals(_textoInfo))
            {
                var resu = MessageBox.Show(this,"Ha producido cambios en el texto, al cerrar, los perderá, ¿Desea continuar?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(resu != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }


    }
}
