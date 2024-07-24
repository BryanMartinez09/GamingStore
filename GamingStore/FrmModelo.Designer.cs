namespace GamingStore
{
    partial class FrmModelo
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
            this.dgvModelo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvModelo
            // 
            this.dgvModelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModelo.Location = new System.Drawing.Point(87, 120);
            this.dgvModelo.Name = "dgvModelo";
            this.dgvModelo.RowHeadersWidth = 62;
            this.dgvModelo.RowTemplate.Height = 28;
            this.dgvModelo.Size = new System.Drawing.Size(573, 295);
            this.dgvModelo.TabIndex = 1;
            // 
            // FrmModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvModelo);
            this.Name = "FrmModelo";
            this.Text = "FrmModelo";
            this.Load += new System.EventHandler(this.FrmModelo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvModelo;
    }
}