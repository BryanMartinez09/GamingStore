namespace GamingStore
{
    partial class FrmBuscarProductos
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNombreProd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbstockcero = new System.Windows.Forms.RadioButton();
            this.btnListar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.rbStock = new System.Windows.Forms.RadioButton();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListarProducts = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNombreProd);
            this.groupBox2.Location = new System.Drawing.Point(567, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 126);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nombre";
            // 
            // txtNombreProd
            // 
            this.txtNombreProd.Location = new System.Drawing.Point(19, 42);
            this.txtNombreProd.Name = "txtNombreProd";
            this.txtNombreProd.Size = new System.Drawing.Size(285, 26);
            this.txtNombreProd.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbstockcero);
            this.groupBox1.Controls.Add(this.btnListar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.rbStock);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Location = new System.Drawing.Point(66, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            // 
            // rbstockcero
            // 
            this.rbstockcero.AutoSize = true;
            this.rbstockcero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbstockcero.Location = new System.Drawing.Point(240, 95);
            this.rbstockcero.Name = "rbstockcero";
            this.rbstockcero.Size = new System.Drawing.Size(142, 25);
            this.rbstockcero.TabIndex = 8;
            this.rbstockcero.TabStop = true;
            this.rbstockcero.Text = "Stock cero(0)";
            this.rbstockcero.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(400, 93);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(66, 27);
            this.btnListar.TabIndex = 7;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(17, 38);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(178, 26);
            this.txtCodigo.TabIndex = 4;
            // 
            // rbStock
            // 
            this.rbStock.AutoSize = true;
            this.rbStock.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStock.Location = new System.Drawing.Point(240, 22);
            this.rbStock.Name = "rbStock";
            this.rbStock.Size = new System.Drawing.Size(84, 25);
            this.rbStock.TabIndex = 1;
            this.rbStock.TabStop = true;
            this.rbStock.Text = "Todos";
            this.rbStock.UseVisualStyleBackColor = true;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(16, 82);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(178, 32);
            this.cboCategoria.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DarkBlue;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(42, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1125, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "ESTADO PRODUCTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvListarProducts
            // 
            this.dgvListarProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarProducts.Location = new System.Drawing.Point(66, 243);
            this.dgvListarProducts.Name = "dgvListarProducts";
            this.dgvListarProducts.RowHeadersWidth = 62;
            this.dgvListarProducts.RowTemplate.Height = 28;
            this.dgvListarProducts.Size = new System.Drawing.Size(985, 331);
            this.dgvListarProducts.TabIndex = 15;
            // 
            // FrmBuscarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 646);
            this.Controls.Add(this.dgvListarProducts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscarProductos";
            this.Text = "FrmBuscarProductos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombreProd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbstockcero;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.RadioButton rbStock;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListarProducts;
    }
}