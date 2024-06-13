namespace MatchMaker
{
    partial class FormOtrosEventos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grillaBackups = new DataGridView();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreArchivoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            creadoElDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            backupBindingSource = new BindingSource(components);
            label1 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaBackups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backupBindingSource).BeginInit();
            SuspendLayout();
            // 
            // grillaBackups
            // 
            grillaBackups.AllowUserToAddRows = false;
            grillaBackups.AllowUserToDeleteRows = false;
            grillaBackups.AutoGenerateColumns = false;
            grillaBackups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaBackups.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, fechaDataGridViewTextBoxColumn, nombreArchivoDataGridViewTextBoxColumn, creadoElDataGridViewTextBoxColumn });
            grillaBackups.DataSource = backupBindingSource;
            grillaBackups.Location = new Point(12, 27);
            grillaBackups.Name = "grillaBackups";
            grillaBackups.ReadOnly = true;
            grillaBackups.Size = new Size(595, 275);
            grillaBackups.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            iDDataGridViewTextBoxColumn.ReadOnly = true;
            iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreArchivoDataGridViewTextBoxColumn
            // 
            nombreArchivoDataGridViewTextBoxColumn.DataPropertyName = "NombreArchivo";
            nombreArchivoDataGridViewTextBoxColumn.HeaderText = "NombreArchivo";
            nombreArchivoDataGridViewTextBoxColumn.Name = "nombreArchivoDataGridViewTextBoxColumn";
            nombreArchivoDataGridViewTextBoxColumn.ReadOnly = true;
            nombreArchivoDataGridViewTextBoxColumn.Width = 250;
            // 
            // creadoElDataGridViewTextBoxColumn
            // 
            creadoElDataGridViewTextBoxColumn.DataPropertyName = "CreadoEl";
            creadoElDataGridViewTextBoxColumn.HeaderText = "CreadoEl";
            creadoElDataGridViewTextBoxColumn.Name = "creadoElDataGridViewTextBoxColumn";
            creadoElDataGridViewTextBoxColumn.ReadOnly = true;
            creadoElDataGridViewTextBoxColumn.Width = 150;
            // 
            // backupBindingSource
            // 
            backupBindingSource.DataSource = typeof(Comun.Modelos.Backup);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(475, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione un evento pasado que quiera volver a ver y presione 'Ver evento seleccionado'";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(511, 308);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(333, 308);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(172, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Ver evento seleccionado";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FormOtrosEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 343);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(grillaBackups);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormOtrosEventos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver otros eventos";
            Load += FormOtrosEventos_Load;
            ((System.ComponentModel.ISupportInitialize)grillaBackups).EndInit();
            ((System.ComponentModel.ISupportInitialize)backupBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaBackups;
        private Label label1;
        private Button btnCancelar;
        private Button btnAceptar;
        private BindingSource backupBindingSource;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreArchivoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn creadoElDataGridViewTextBoxColumn;
    }
}