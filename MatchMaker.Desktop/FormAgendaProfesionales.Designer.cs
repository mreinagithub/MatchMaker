namespace MatchMaker.Desktop
{
    partial class FormAgendaProfesionales
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtBorrarFiltros = new Button();
            txtFiltroProfEsc = new TextBox();
            txtFiltroCategoria = new TextBox();
            txtFiltroNombre = new TextBox();
            label1 = new Label();
            grillaAgendaBoxeadores = new DataGridView();
            boxeadorAgendaBindingSource = new BindingSource(components);
            btnCerrar = new Button();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sexoDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            nacionalidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dNIDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaNacimientoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            edadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            librasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoriaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadPeleasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profesorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contactoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            uRLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            asignadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)grillaAgendaBoxeadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boxeadorAgendaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txtBorrarFiltros
            // 
            txtBorrarFiltros.Location = new Point(528, 9);
            txtBorrarFiltros.Name = "txtBorrarFiltros";
            txtBorrarFiltros.Size = new Size(111, 23);
            txtBorrarFiltros.TabIndex = 12;
            txtBorrarFiltros.Text = "Borrar filtros...";
            txtBorrarFiltros.UseVisualStyleBackColor = true;
            // 
            // txtFiltroProfEsc
            // 
            txtFiltroProfEsc.Location = new Point(372, 9);
            txtFiltroProfEsc.Name = "txtFiltroProfEsc";
            txtFiltroProfEsc.PlaceholderText = "Profesor/Escuela...";
            txtFiltroProfEsc.Size = new Size(150, 23);
            txtFiltroProfEsc.TabIndex = 8;
            // 
            // txtFiltroCategoria
            // 
            txtFiltroCategoria.Location = new Point(216, 9);
            txtFiltroCategoria.Name = "txtFiltroCategoria";
            txtFiltroCategoria.PlaceholderText = "Categoria...";
            txtFiltroCategoria.Size = new Size(150, 23);
            txtFiltroCategoria.TabIndex = 7;
            // 
            // txtFiltroNombre
            // 
            txtFiltroNombre.Location = new Point(60, 9);
            txtFiltroNombre.Name = "txtFiltroNombre";
            txtFiltroNombre.PlaceholderText = "Nombre...";
            txtFiltroNombre.Size = new Size(150, 23);
            txtFiltroNombre.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 9;
            label1.Text = "Filtros:";
            // 
            // grillaAgendaBoxeadores
            // 
            grillaAgendaBoxeadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grillaAgendaBoxeadores.AutoGenerateColumns = false;
            grillaAgendaBoxeadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAgendaBoxeadores.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn, sexoDataGridViewTextBoxColumn, nacionalidadDataGridViewTextBoxColumn, dNIDataGridViewTextBoxColumn, fechaNacimientoDataGridViewTextBoxColumn, edadDataGridViewTextBoxColumn, pesoDataGridViewTextBoxColumn, librasDataGridViewTextBoxColumn, categoriaDataGridViewTextBoxColumn, cantidadPeleasDataGridViewTextBoxColumn, profesorDataGridViewTextBoxColumn, contactoDataGridViewTextBoxColumn, uRLDataGridViewTextBoxColumn, iDDataGridViewTextBoxColumn, asignadoDataGridViewCheckBoxColumn });
            grillaAgendaBoxeadores.DataSource = boxeadorAgendaBindingSource;
            grillaAgendaBoxeadores.Location = new Point(12, 43);
            grillaAgendaBoxeadores.Name = "grillaAgendaBoxeadores";
            grillaAgendaBoxeadores.Size = new Size(1018, 502);
            grillaAgendaBoxeadores.TabIndex = 10;
            // 
            // boxeadorAgendaBindingSource
            // 
            boxeadorAgendaBindingSource.DataSource = typeof(Comun.BoxeadorProfesional);
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(955, 551);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MaxInputLength = 100;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 180;
            // 
            // sexoDataGridViewTextBoxColumn
            // 
            sexoDataGridViewTextBoxColumn.DataPropertyName = "Sexo";
            sexoDataGridViewTextBoxColumn.HeaderText = "Sexo";
            sexoDataGridViewTextBoxColumn.Items.AddRange(new object[] { "M", "F" });
            sexoDataGridViewTextBoxColumn.Name = "sexoDataGridViewTextBoxColumn";
            sexoDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            sexoDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // nacionalidadDataGridViewTextBoxColumn
            // 
            nacionalidadDataGridViewTextBoxColumn.DataPropertyName = "Nacionalidad";
            nacionalidadDataGridViewTextBoxColumn.HeaderText = "Nacionalidad";
            nacionalidadDataGridViewTextBoxColumn.MaxInputLength = 50;
            nacionalidadDataGridViewTextBoxColumn.Name = "nacionalidadDataGridViewTextBoxColumn";
            nacionalidadDataGridViewTextBoxColumn.Width = 120;
            // 
            // dNIDataGridViewTextBoxColumn
            // 
            dNIDataGridViewTextBoxColumn.DataPropertyName = "DNI";
            dNIDataGridViewTextBoxColumn.HeaderText = "DNI";
            dNIDataGridViewTextBoxColumn.MaxInputLength = 20;
            dNIDataGridViewTextBoxColumn.Name = "dNIDataGridViewTextBoxColumn";
            // 
            // fechaNacimientoDataGridViewTextBoxColumn
            // 
            fechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            fechaNacimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            fechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Nacim.";
            fechaNacimientoDataGridViewTextBoxColumn.Name = "fechaNacimientoDataGridViewTextBoxColumn";
            // 
            // edadDataGridViewTextBoxColumn
            // 
            edadDataGridViewTextBoxColumn.DataPropertyName = "Edad";
            edadDataGridViewTextBoxColumn.HeaderText = "Edad";
            edadDataGridViewTextBoxColumn.Name = "edadDataGridViewTextBoxColumn";
            edadDataGridViewTextBoxColumn.Width = 80;
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
            pesoDataGridViewTextBoxColumn.HeaderText = "Peso (Kg)";
            pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
            pesoDataGridViewTextBoxColumn.Width = 80;
            // 
            // librasDataGridViewTextBoxColumn
            // 
            librasDataGridViewTextBoxColumn.DataPropertyName = "Libras";
            librasDataGridViewTextBoxColumn.HeaderText = "Libras";
            librasDataGridViewTextBoxColumn.Name = "librasDataGridViewTextBoxColumn";
            librasDataGridViewTextBoxColumn.Width = 80;
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            categoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadPeleasDataGridViewTextBoxColumn
            // 
            cantidadPeleasDataGridViewTextBoxColumn.DataPropertyName = "CantidadPeleas";
            cantidadPeleasDataGridViewTextBoxColumn.HeaderText = "Cant.Peleas";
            cantidadPeleasDataGridViewTextBoxColumn.Name = "cantidadPeleasDataGridViewTextBoxColumn";
            // 
            // profesorDataGridViewTextBoxColumn
            // 
            profesorDataGridViewTextBoxColumn.DataPropertyName = "Profesor";
            profesorDataGridViewTextBoxColumn.HeaderText = "Profesor/Escuela";
            profesorDataGridViewTextBoxColumn.Name = "profesorDataGridViewTextBoxColumn";
            profesorDataGridViewTextBoxColumn.Width = 120;
            // 
            // contactoDataGridViewTextBoxColumn
            // 
            contactoDataGridViewTextBoxColumn.DataPropertyName = "Contacto";
            contactoDataGridViewTextBoxColumn.HeaderText = "Contacto";
            contactoDataGridViewTextBoxColumn.Name = "contactoDataGridViewTextBoxColumn";
            contactoDataGridViewTextBoxColumn.Width = 180;
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            uRLDataGridViewTextBoxColumn.Width = 250;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // asignadoDataGridViewCheckBoxColumn
            // 
            asignadoDataGridViewCheckBoxColumn.DataPropertyName = "Asignado";
            asignadoDataGridViewCheckBoxColumn.HeaderText = "Asignado";
            asignadoDataGridViewCheckBoxColumn.Name = "asignadoDataGridViewCheckBoxColumn";
            asignadoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // FormAgendaProfesionales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 583);
            Controls.Add(txtBorrarFiltros);
            Controls.Add(txtFiltroProfEsc);
            Controls.Add(txtFiltroCategoria);
            Controls.Add(txtFiltroNombre);
            Controls.Add(label1);
            Controls.Add(grillaAgendaBoxeadores);
            Controls.Add(btnCerrar);
            MinimumSize = new Size(663, 569);
            Name = "FormAgendaProfesionales";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de Boxeadores Profesionales";
            Load += FormAgendaProfesionales_Load;
            ((System.ComponentModel.ISupportInitialize)grillaAgendaBoxeadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)boxeadorAgendaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button txtBorrarFiltros;
        private TextBox txtFiltroProfEsc;
        private TextBox txtFiltroCategoria;
        private TextBox txtFiltroNombre;
        private Label label1;
        private DataGridView grillaAgendaBoxeadores;
        private Button btnCerrar;
        private BindingSource boxeadorAgendaBindingSource;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn sexoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nacionalidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dNIDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn librasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadPeleasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profesorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contactoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn asignadoDataGridViewCheckBoxColumn;
    }
}