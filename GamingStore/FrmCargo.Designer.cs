namespace GamingStore
{
    partial class FrmCargo
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
            this.dgvCargo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCargo
            // 
            this.dgvCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargo.Location = new System.Drawing.Point(85, 116);
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.RowHeadersWidth = 62;
            this.dgvCargo.RowTemplate.Height = 28;
            this.dgvCargo.Size = new System.Drawing.Size(618, 285);
            this.dgvCargo.TabIndex = 0;
            this.dgvCargo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargo_CellContentClick);
            // 
            // FrmCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCargo);
            this.Name = "FrmCargo";
            this.Text = "FrmCargo";
            this.Load += new System.EventHandler(this.FrmCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCargo;
    }
}