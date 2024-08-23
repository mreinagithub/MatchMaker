namespace MatchMaker.Desktop
{
    partial class FormAgendaBoxeadores
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnCerrar = new Button();
            boxeadorAgendaBindingSource = new BindingSource(components);
            grillaAgendaBoxeadores = new DataGridView();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            asignadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            nombreDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            sexoDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            fechaNacimientoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            edadDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            categoriaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cantidadPeleasDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            profesorDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            uRLDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            eventoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtFiltroNombre = new TextBox();
            txtFiltroCategoria = new TextBox();
            txtFiltroProfEsc = new TextBox();
            txtBorrarFiltros = new Button();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewComboBoxColumn();
            fechaNacimientoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            edadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoriaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadPeleasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profesorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            uRLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Navigate = new DataGridViewButtonColumn();
            eventoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)boxeadorAgendaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaAgendaBoxeadores).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(955, 548);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // boxeadorAgendaBindingSource
            // 
            boxeadorAgendaBindingSource.DataSource = typeof(Comun.BoxeadorAgenda);
            // 
            // grillaAgendaBoxeadores
            // 
            grillaAgendaBoxeadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grillaAgendaBoxeadores.AutoGenerateColumns = false;
            grillaAgendaBoxeadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaAgendaBoxeadores.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, asignadoDataGridViewCheckBoxColumn, nombreDataGridViewTextBoxColumn1, sexoDataGridViewTextBoxColumn, fechaNacimientoDataGridViewTextBoxColumn1, edadDataGridViewTextBoxColumn1, pesoDataGridViewTextBoxColumn1, categoriaDataGridViewTextBoxColumn1, cantidadPeleasDataGridViewTextBoxColumn1, profesorDataGridViewTextBoxColumn1, uRLDataGridViewTextBoxColumn1, eventoDataGridViewTextBoxColumn1 });
            grillaAgendaBoxeadores.DataSource = boxeadorAgendaBindingSource;
            grillaAgendaBoxeadores.Location = new Point(12, 40);
            grillaAgendaBoxeadores.Name = "grillaAgendaBoxeadores";
            grillaAgendaBoxeadores.Size = new Size(1018, 502);
            grillaAgendaBoxeadores.TabIndex = 3;
            grillaAgendaBoxeadores.CellContentClick += grillaAgendaBoxeadores_CellContentClick;
            grillaAgendaBoxeadores.ColumnHeaderMouseClick += grillaAgendaBoxeadores_ColumnHeaderMouseClick;
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
            // nombreDataGridViewTextBoxColumn1
            // 
            nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn1.MaxInputLength = 100;
            nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            nombreDataGridViewTextBoxColumn1.Width = 180;
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
            // fechaNacimientoDataGridViewTextBoxColumn1
            // 
            fechaNacimientoDataGridViewTextBoxColumn1.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            fechaNacimientoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            fechaNacimientoDataGridViewTextBoxColumn1.HeaderText = "Fecha Nacim.";
            fechaNacimientoDataGridViewTextBoxColumn1.Name = "fechaNacimientoDataGridViewTextBoxColumn1";
            // 
            // edadDataGridViewTextBoxColumn1
            // 
            edadDataGridViewTextBoxColumn1.DataPropertyName = "Edad";
            edadDataGridViewTextBoxColumn1.HeaderText = "Edad";
            edadDataGridViewTextBoxColumn1.Name = "edadDataGridViewTextBoxColumn1";
            // 
            // pesoDataGridViewTextBoxColumn1
            // 
            pesoDataGridViewTextBoxColumn1.DataPropertyName = "Peso";
            pesoDataGridViewTextBoxColumn1.HeaderText = "Peso";
            pesoDataGridViewTextBoxColumn1.Name = "pesoDataGridViewTextBoxColumn1";
            // 
            // categoriaDataGridViewTextBoxColumn1
            // 
            categoriaDataGridViewTextBoxColumn1.DataPropertyName = "Categoria";
            categoriaDataGridViewTextBoxColumn1.HeaderText = "Categoria";
            categoriaDataGridViewTextBoxColumn1.Name = "categoriaDataGridViewTextBoxColumn1";
            categoriaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadPeleasDataGridViewTextBoxColumn1
            // 
            cantidadPeleasDataGridViewTextBoxColumn1.DataPropertyName = "CantidadPeleas";
            cantidadPeleasDataGridViewTextBoxColumn1.HeaderText = "Cant. Peleas";
            cantidadPeleasDataGridViewTextBoxColumn1.Name = "cantidadPeleasDataGridViewTextBoxColumn1";
            // 
            // profesorDataGridViewTextBoxColumn1
            // 
            profesorDataGridViewTextBoxColumn1.DataPropertyName = "Profesor";
            profesorDataGridViewTextBoxColumn1.HeaderText = "Profesor";
            profesorDataGridViewTextBoxColumn1.Name = "profesorDataGridViewTextBoxColumn1";
            // 
            // uRLDataGridViewTextBoxColumn1
            // 
            uRLDataGridViewTextBoxColumn1.DataPropertyName = "URL";
            uRLDataGridViewTextBoxColumn1.HeaderText = "URL";
            uRLDataGridViewTextBoxColumn1.Name = "uRLDataGridViewTextBoxColumn1";
            uRLDataGridViewTextBoxColumn1.Width = 250;
            // 
            // eventoDataGridViewTextBoxColumn1
            // 
            eventoDataGridViewTextBoxColumn1.DataPropertyName = "Evento";
            eventoDataGridViewTextBoxColumn1.HeaderText = "Evento";
            eventoDataGridViewTextBoxColumn1.Name = "eventoDataGridViewTextBoxColumn1";
            eventoDataGridViewTextBoxColumn1.ReadOnly = true;
            eventoDataGridViewTextBoxColumn1.Width = 250;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 2;
            label1.Text = "Filtros:";
            // 
            // txtFiltroNombre
            // 
            txtFiltroNombre.Location = new Point(60, 6);
            txtFiltroNombre.Name = "txtFiltroNombre";
            txtFiltroNombre.PlaceholderText = "Nombre...";
            txtFiltroNombre.Size = new Size(150, 23);
            txtFiltroNombre.TabIndex = 0;
            // 
            // txtFiltroCategoria
            // 
            txtFiltroCategoria.Location = new Point(216, 6);
            txtFiltroCategoria.Name = "txtFiltroCategoria";
            txtFiltroCategoria.PlaceholderText = "Categoria...";
            txtFiltroCategoria.Size = new Size(150, 23);
            txtFiltroCategoria.TabIndex = 1;
            // 
            // txtFiltroProfEsc
            // 
            txtFiltroProfEsc.Location = new Point(372, 6);
            txtFiltroProfEsc.Name = "txtFiltroProfEsc";
            txtFiltroProfEsc.PlaceholderText = "Profesor/Escuela...";
            txtFiltroProfEsc.Size = new Size(150, 23);
            txtFiltroProfEsc.TabIndex = 2;
            // 
            // txtBorrarFiltros
            // 
            txtBorrarFiltros.Location = new Point(528, 6);
            txtBorrarFiltros.Name = "txtBorrarFiltros";
            txtBorrarFiltros.Size = new Size(111, 23);
            txtBorrarFiltros.TabIndex = 5;
            txtBorrarFiltros.Text = "Borrar filtros...";
            txtBorrarFiltros.UseVisualStyleBackColor = true;
            txtBorrarFiltros.Click += txtBorrarFiltros_Click;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.Frozen = true;
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MaxInputLength = 100;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 180;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Sexo";
            dataGridViewTextBoxColumn1.Frozen = true;
            dataGridViewTextBoxColumn1.HeaderText = "Sexo";
            dataGridViewTextBoxColumn1.Items.AddRange(new object[] { "M", "F" });
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // fechaNacimientoDataGridViewTextBoxColumn
            // 
            fechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            fechaNacimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            fechaNacimientoDataGridViewTextBoxColumn.Frozen = true;
            fechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Nacim.";
            fechaNacimientoDataGridViewTextBoxColumn.Name = "fechaNacimientoDataGridViewTextBoxColumn";
            // 
            // edadDataGridViewTextBoxColumn
            // 
            edadDataGridViewTextBoxColumn.DataPropertyName = "Edad";
            edadDataGridViewTextBoxColumn.Frozen = true;
            edadDataGridViewTextBoxColumn.HeaderText = "Edad";
            edadDataGridViewTextBoxColumn.Name = "edadDataGridViewTextBoxColumn";
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
            pesoDataGridViewTextBoxColumn.Frozen = true;
            pesoDataGridViewTextBoxColumn.HeaderText = "Peso";
            pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            categoriaDataGridViewTextBoxColumn.Frozen = true;
            categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            categoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadPeleasDataGridViewTextBoxColumn
            // 
            cantidadPeleasDataGridViewTextBoxColumn.DataPropertyName = "CantidadPeleas";
            cantidadPeleasDataGridViewTextBoxColumn.Frozen = true;
            cantidadPeleasDataGridViewTextBoxColumn.HeaderText = "Cantidad Peleas";
            cantidadPeleasDataGridViewTextBoxColumn.Name = "cantidadPeleasDataGridViewTextBoxColumn";
            // 
            // profesorDataGridViewTextBoxColumn
            // 
            profesorDataGridViewTextBoxColumn.DataPropertyName = "Profesor";
            profesorDataGridViewTextBoxColumn.Frozen = true;
            profesorDataGridViewTextBoxColumn.HeaderText = "Profesor/Escuela";
            profesorDataGridViewTextBoxColumn.MaxInputLength = 100;
            profesorDataGridViewTextBoxColumn.Name = "profesorDataGridViewTextBoxColumn";
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            uRLDataGridViewTextBoxColumn.Frozen = true;
            uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            uRLDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            uRLDataGridViewTextBoxColumn.Width = 200;
            // 
            // Navigate
            // 
            Navigate.Frozen = true;
            Navigate.HeaderText = "";
            Navigate.Name = "Navigate";
            // 
            // eventoDataGridViewTextBoxColumn
            // 
            eventoDataGridViewTextBoxColumn.DataPropertyName = "Evento";
            eventoDataGridViewTextBoxColumn.HeaderText = "Evento";
            eventoDataGridViewTextBoxColumn.Name = "eventoDataGridViewTextBoxColumn";
            eventoDataGridViewTextBoxColumn.ReadOnly = true;
            eventoDataGridViewTextBoxColumn.Width = 250;
            // 
            // FormAgendaBoxeadores
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
            Name = "FormAgendaBoxeadores";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de Boxeadores";
            Load += FormAgendaBoxeadores_Load;
            ((System.ComponentModel.ISupportInitialize)boxeadorAgendaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaAgendaBoxeadores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private BindingSource boxeadorAgendaBindingSource;
        private DataGridView grillaAgendaBoxeadores;
        private Label label1;
        private TextBox txtFiltroNombre;
        private TextBox txtFiltroCategoria;
        private TextBox txtFiltroProfEsc;
        private Button txtBorrarFiltros;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadPeleasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profesorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn Navigate;
        private DataGridViewTextBoxColumn eventoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn asignadoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private DataGridViewComboBoxColumn sexoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadPeleasDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn profesorDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn eventoDataGridViewTextBoxColumn1;
    }
}