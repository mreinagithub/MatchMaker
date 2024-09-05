namespace MatchMaker.Desktop
{
    partial class FormInformacionImportante
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
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtInfoImportante = new RichTextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(572, 458);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(79, 24);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(487, 458);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(79, 24);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtInfoImportante
            // 
            txtInfoImportante.AcceptsTab = true;
            txtInfoImportante.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtInfoImportante.BackColor = SystemColors.Window;
            txtInfoImportante.Location = new Point(8, 12);
            txtInfoImportante.Name = "txtInfoImportante";
            txtInfoImportante.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtInfoImportante.Size = new Size(643, 440);
            txtInfoImportante.TabIndex = 4;
            txtInfoImportante.Text = "";
            // 
            // FormInformacionImportante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 497);
            Controls.Add(txtInfoImportante);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            MinimumSize = new Size(679, 536);
            Name = "FormInformacionImportante";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Información Importante";
            FormClosing += FormInformacionImportante_FormClosing;
            FormClosed += FormInformacionImportante_FormClosed;
            Load += FormInformacionImportante_Load;
            ResumeLayout(false);
        }

        #endregion

        
        private Button btnCancelar;
        private Button btnGuardar;
        private RichTextBox txtInfoImportante;
    }
}