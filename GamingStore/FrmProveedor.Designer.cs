namespace GamingStore
{
    partial class FrmProveedor
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
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Location = new System.Drawing.Point(82, 97);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.RowHeadersWidth = 62;
            this.dgvProveedor.RowTemplate.Height = 28;
            this.dgvProveedor.Size = new System.Drawing.Size(626, 325);
            this.dgvProveedor.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProveedor);
            this.panel1.Location = new System.Drawing.Point(22, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 462);
            this.panel1.TabIndex = 2;
            // 
            // FrmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 515);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProveedor";
            this.Text = "FrmProveedor";
            this.Load += new System.EventHandler(this.FrmProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.Panel panel1;
    }
}