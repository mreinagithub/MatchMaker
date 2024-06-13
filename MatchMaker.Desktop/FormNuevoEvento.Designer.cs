namespace MatchMaker
{
    partial class FormNuevoEvento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoEvento));
            label1 = new Label();
            label2 = new Label();
            txtFechaEvento = new DateTimePicker();
            btnGuardar = new Button();
            btnNoGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(802, 75);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 111);
            label2.Name = "label2";
            label2.Size = new Size(243, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha en que se produjo el evento a guardar:";
            // 
            // txtFechaEvento
            // 
            txtFechaEvento.Format = DateTimePickerFormat.Short;
            txtFechaEvento.Location = new Point(261, 107);
            txtFechaEvento.Name = "txtFechaEvento";
            txtFechaEvento.Size = new Size(106, 23);
            txtFechaEvento.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(270, 138);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(269, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar evento actual y generar nuevo...";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNoGuardar
            // 
            btnNoGuardar.Location = new Point(545, 138);
            btnNoGuardar.Name = "btnNoGuardar";
            btnNoGuardar.Size = new Size(269, 23);
            btnNoGuardar.TabIndex = 2;
            btnNoGuardar.Text = "Descartar evento actual y generar nuevo...";
            btnNoGuardar.UseVisualStyleBackColor = true;
            btnNoGuardar.Click += btnNoGuardar_Click;
            // 
            // FormNuevoEvento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 173);
            Controls.Add(btnNoGuardar);
            Controls.Add(btnGuardar);
            Controls.Add(txtFechaEvento);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNuevoEvento";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo evento...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker txtFechaEvento;
        private Button btnGuardar;
        private Button btnNoGuardar;
    }
}