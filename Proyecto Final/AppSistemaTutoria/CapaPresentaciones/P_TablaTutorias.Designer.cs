namespace CapaPresentaciones
{
    partial class P_TablaTutorias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_TablaTutorias));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.Separador1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnExportar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.BordeadoTablaTutorias = new Bunifu.UI.WinForms.BunifuGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.Location = new System.Drawing.Point(782, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 74;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(815, 40);
            this.lblTitulo.TabIndex = 73;
            this.lblTitulo.Text = "Tabla de Fichas de Tutorías";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblBuscar.Location = new System.Drawing.Point(9, 58);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 19);
            this.lblBuscar.TabIndex = 75;
            this.lblBuscar.Text = "Buscar:";
            // 
            // Separador1
            // 
            this.Separador1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Separador1.BackColor = System.Drawing.Color.Transparent;
            this.Separador1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.Separador1.LineThickness = 1;
            this.Separador1.Location = new System.Drawing.Point(67, 79);
            this.Separador1.Margin = new System.Windows.Forms.Padding(4);
            this.Separador1.Name = "Separador1";
            this.Separador1.Size = new System.Drawing.Size(372, 8);
            this.Separador1.TabIndex = 77;
            this.Separador1.Transparency = 255;
            this.Separador1.Vertical = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtBuscar.Location = new System.Drawing.Point(67, 58);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(368, 19);
            this.txtBuscar.TabIndex = 76;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Active = true;
            this.btnEliminar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.BorderRadius = 7;
            this.btnEliminar.ButtonText = "Eliminar";
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.DisabledColor = System.Drawing.Color.Gray;
            this.btnEliminar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEliminar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Iconimage")));
            this.btnEliminar.Iconimage_right = null;
            this.btnEliminar.Iconimage_right_Selected = null;
            this.btnEliminar.Iconimage_Selected = null;
            this.btnEliminar.IconMarginLeft = 0;
            this.btnEliminar.IconMarginRight = 0;
            this.btnEliminar.IconRightVisible = true;
            this.btnEliminar.IconRightZoom = 0D;
            this.btnEliminar.IconVisible = true;
            this.btnEliminar.IconZoom = 50D;
            this.btnEliminar.IsTab = false;
            this.btnEliminar.Location = new System.Drawing.Point(545, 51);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEliminar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnEliminar.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEliminar.selected = true;
            this.btnEliminar.Size = new System.Drawing.Size(126, 40);
            this.btnEliminar.TabIndex = 80;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEliminar.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Active = true;
            this.btnExportar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportar.BorderRadius = 7;
            this.btnExportar.ButtonText = "Exportar";
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.DisabledColor = System.Drawing.Color.Gray;
            this.btnExportar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExportar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnExportar.Iconimage")));
            this.btnExportar.Iconimage_right = null;
            this.btnExportar.Iconimage_right_Selected = null;
            this.btnExportar.Iconimage_Selected = null;
            this.btnExportar.IconMarginLeft = 0;
            this.btnExportar.IconMarginRight = 0;
            this.btnExportar.IconRightVisible = true;
            this.btnExportar.IconRightZoom = 0D;
            this.btnExportar.IconVisible = true;
            this.btnExportar.IconZoom = 50D;
            this.btnExportar.IsTab = false;
            this.btnExportar.Location = new System.Drawing.Point(677, 51);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnExportar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnExportar.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnExportar.selected = true;
            this.btnExportar.Size = new System.Drawing.Size(126, 40);
            this.btnExportar.TabIndex = 81;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnExportar.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.AllowUserToResizeColumns = false;
            this.dgvTabla.AllowUserToResizeRows = false;
            this.dgvTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTabla.BackgroundColor = System.Drawing.Color.White;
            this.dgvTabla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTabla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTabla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabla.ColumnHeadersHeight = 40;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla.EnableHeadersVisualStyles = false;
            this.dgvTabla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTabla.Location = new System.Drawing.Point(12, 97);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTabla.RowHeadersVisible = false;
            this.dgvTabla.RowHeadersWidth = 51;
            this.dgvTabla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTabla.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabla.Size = new System.Drawing.Size(791, 339);
            this.dgvTabla.TabIndex = 82;
            // 
            // BordeadoTablaTutorias
            // 
            this.BordeadoTablaTutorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BordeadoTablaTutorias.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.BordeadoTablaTutorias.BorderRadius = 8;
            this.BordeadoTablaTutorias.BorderThickness = 1;
            this.BordeadoTablaTutorias.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BordeadoTablaTutorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.BordeadoTablaTutorias.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BordeadoTablaTutorias.LabelIndent = 10;
            this.BordeadoTablaTutorias.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.BordeadoTablaTutorias.Location = new System.Drawing.Point(-1, 0);
            this.BordeadoTablaTutorias.Name = "BordeadoTablaTutorias";
            this.BordeadoTablaTutorias.Size = new System.Drawing.Size(815, 448);
            this.BordeadoTablaTutorias.TabIndex = 198;
            this.BordeadoTablaTutorias.TabStop = false;
            // 
            // P_TablaTutorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 448);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.Separador1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.BordeadoTablaTutorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "P_TablaTutorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Fichas de Tutorías";
            this.Load += new System.EventHandler(this.P_TablaTutorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private Bunifu.Framework.UI.BunifuSeparator Separador1;
        public System.Windows.Forms.TextBox txtBuscar;
        private Bunifu.Framework.UI.BunifuFlatButton btnEliminar;
        private Bunifu.Framework.UI.BunifuFlatButton btnExportar;
        private System.Windows.Forms.DataGridView dgvTabla;
        private Bunifu.UI.WinForms.BunifuGroupBox BordeadoTablaTutorias;
    }
}