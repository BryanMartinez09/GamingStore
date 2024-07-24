namespace GamingStore
{
    partial class FrmRol
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
            this.dgvRol = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRol
            // 
            this.dgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRol.Location = new System.Drawing.Point(92, 143);
            this.dgvRol.Name = "dgvRol";
            this.dgvRol.RowHeadersWidth = 62;
            this.dgvRol.RowTemplate.Height = 28;
            this.dgvRol.Size = new System.Drawing.Size(573, 295);
            this.dgvRol.TabIndex = 1;
            // 
            // FrmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRol);
            this.Name = "FrmRol";
            this.Text = "FrmRol";
            this.Load += new System.EventHandler(this.FrmRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRol;
    }
}