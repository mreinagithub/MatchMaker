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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnCerrar = new Button();
            boxeadorAgendaBindingSource = new BindingSource(components);
            grillaAgendaBoxeadores = new DataGridView();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            asignadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewComboBoxColumn();
            fechaNacimientoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            edadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoriaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadPeleasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profesorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            uRLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eventoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtFiltroNombre = new TextBox();
            txtFiltroCategoria = new TextBox();
            txtFiltroProfEsc = new TextBox();
            ((System.ComponentModel.ISupportInitialize)boxeadorAgendaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaAgendaBoxeadores).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(885, 495);
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
            grillaAgendaBoxeadores.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, asignadoDataGridViewCheckBoxColumn, nombreDataGridViewTextBoxColumn, dataGridViewTextBoxColumn1, fechaNacimientoDataGridViewTextBoxColumn, edadDataGridViewTextBoxColumn, pesoDataGridViewTextBoxColumn, categoriaDataGridViewTextBoxColumn, cantidadPeleasDataGridViewTextBoxColumn, profesorDataGridViewTextBoxColumn, uRLDataGridViewTextBoxColumn, eventoDataGridViewTextBoxColumn });
            grillaAgendaBoxeadores.DataSource = boxeadorAgendaBindingSource;
            grillaAgendaBoxeadores.Location = new Point(12, 40);
            grillaAgendaBoxeadores.Name = "grillaAgendaBoxeadores";
            grillaAgendaBoxeadores.Size = new Size(948, 449);
            grillaAgendaBoxeadores.TabIndex = 3;
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
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MaxInputLength = 100;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 180;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Sexo";
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
            fechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Nacim.";
            fechaNacimientoDataGridViewTextBoxColumn.Name = "fechaNacimientoDataGridViewTextBoxColumn";
            // 
            // edadDataGridViewTextBoxColumn
            // 
            edadDataGridViewTextBoxColumn.DataPropertyName = "Edad";
            edadDataGridViewTextBoxColumn.HeaderText = "Edad";
            edadDataGridViewTextBoxColumn.Name = "edadDataGridViewTextBoxColumn";
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
            pesoDataGridViewTextBoxColumn.HeaderText = "Peso";
            pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
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
            cantidadPeleasDataGridViewTextBoxColumn.HeaderText = "Cantidad Peleas";
            cantidadPeleasDataGridViewTextBoxColumn.Name = "cantidadPeleasDataGridViewTextBoxColumn";
            // 
            // profesorDataGridViewTextBoxColumn
            // 
            profesorDataGridViewTextBoxColumn.DataPropertyName = "Profesor";
            profesorDataGridViewTextBoxColumn.HeaderText = "Profesor/Escuela";
            profesorDataGridViewTextBoxColumn.MaxInputLength = 100;
            profesorDataGridViewTextBoxColumn.Name = "profesorDataGridViewTextBoxColumn";
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            uRLDataGridViewTextBoxColumn.Width = 200;
            // 
            // eventoDataGridViewTextBoxColumn
            // 
            eventoDataGridViewTextBoxColumn.DataPropertyName = "Evento";
            eventoDataGridViewTextBoxColumn.HeaderText = "Evento";
            eventoDataGridViewTextBoxColumn.Name = "eventoDataGridViewTextBoxColumn";
            eventoDataGridViewTextBoxColumn.ReadOnly = true;
            eventoDataGridViewTextBoxColumn.Width = 250;
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
            // FormAgendaBoxeadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 530);
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
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn asignadoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadPeleasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profesorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eventoDataGridViewTextBoxColumn;
        private Label label1;
        private TextBox txtFiltroNombre;
        private TextBox txtFiltroCategoria;
        private TextBox txtFiltroProfEsc;
    }
}