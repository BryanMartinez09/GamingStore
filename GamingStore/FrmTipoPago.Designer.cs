namespace GamingStore
{
    partial class FrmTipoPago
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
            this.dgvTipPago = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipPago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTipPago
            // 
            this.dgvTipPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipPago.Location = new System.Drawing.Point(100, 110);
            this.dgvTipPago.Name = "dgvTipPago";
            this.dgvTipPago.RowHeadersWidth = 62;
            this.dgvTipPago.RowTemplate.Height = 28;
            this.dgvTipPago.Size = new System.Drawing.Size(559, 291);
            this.dgvTipPago.TabIndex = 0;
            // 
            // FrmTipoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTipPago);
            this.Name = "FrmTipoPago";
            this.Text = "FrmTipoPago";
            this.Load += new System.EventHandler(this.FrmTipoPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTipPago;
    }
}