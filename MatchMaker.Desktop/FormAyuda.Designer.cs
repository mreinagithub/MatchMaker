namespace MatchMaker.Desktop
{
    partial class FormAyuda
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
            txtAyuda = new TextBox();
            SuspendLayout();
            // 
            // txtAyuda
            // 
            txtAyuda.Dock = DockStyle.Fill;
            txtAyuda.Font = new Font("Segoe UI", 11F);
            txtAyuda.Location = new Point(0, 0);
            txtAyuda.Multiline = true;
            txtAyuda.Name = "txtAyuda";
            txtAyuda.ReadOnly = true;
            txtAyuda.ScrollBars = ScrollBars.Vertical;
            txtAyuda.Size = new Size(548, 450);
            txtAyuda.TabIndex = 0;
            // 
            // FormAyuda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 450);
            Controls.Add(txtAyuda);
            MinimizeBox = false;
            MinimumSize = new Size(564, 489);
            Name = "FormAyuda";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ayuda";
            Load += FormAyuda_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAyuda;
    }
}