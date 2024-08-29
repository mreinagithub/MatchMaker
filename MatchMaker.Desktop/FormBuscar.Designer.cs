namespace MatchMaker.Desktop
{
    partial class FormBuscar
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
            btnBuscar = new Button();
            btnCerrar = new Button();
            label1 = new Label();
            txtTextoABuscar = new TextBox();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(311, 16);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(114, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar siguiente...";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(311, 45);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 23);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 2;
            label1.Text = "Buscar";
            // 
            // txtTextoABuscar
            // 
            txtTextoABuscar.Location = new Point(60, 16);
            txtTextoABuscar.Name = "txtTextoABuscar";
            txtTextoABuscar.PlaceholderText = "Ingrese texto a buscar...";
            txtTextoABuscar.Size = new Size(245, 23);
            txtTextoABuscar.TabIndex = 0;
            txtTextoABuscar.TextChanged += txtTextoABuscar_TextChanged;
            txtTextoABuscar.KeyPress += txtTextoABuscar_KeyPress;
            // 
            // FormBuscar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 84);
            Controls.Add(txtTextoABuscar);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            Controls.Add(btnBuscar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBuscar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar...";
            Load += FormBuscar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private Button btnCerrar;
        private Label label1;
        private TextBox txtTextoABuscar;
    }
}