namespace GamingStore
{
    partial class FrmArqueo
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
            this.dgvArqueo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArqueo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArqueo
            // 
            this.dgvArqueo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArqueo.Location = new System.Drawing.Point(141, 165);
            this.dgvArqueo.Name = "dgvArqueo";
            this.dgvArqueo.RowHeadersWidth = 62;
            this.dgvArqueo.RowTemplate.Height = 28;
            this.dgvArqueo.Size = new System.Drawing.Size(496, 245);
            this.dgvArqueo.TabIndex = 0;
            // 
            // FrmArqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvArqueo);
            this.Name = "FrmArqueo";
            this.Text = "FrmArqueo";
            this.Load += new System.EventHandler(this.FrmArqueo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArqueo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArqueo;
    }
}