
namespace CapaPresentaciones
{
    partial class P_TablaTutorados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_TablaTutorados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BordeadoMenu = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.Separador1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevaSesion = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
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
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
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
            this.lblTitulo.Text = "Tabla de Tutorados";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BordeadoMenu
            // 
            this.BordeadoMenu.ActiveBorderThickness = 1;
            this.BordeadoMenu.ActiveCornerRadius = 20;
            this.BordeadoMenu.ActiveFillColor = System.Drawing.Color.White;
            this.BordeadoMenu.ActiveForecolor = System.Drawing.Color.White;
            this.BordeadoMenu.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.BordeadoMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BordeadoMenu.BackColor = System.Drawing.Color.White;
            this.BordeadoMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BordeadoMenu.BackgroundImage")));
            this.BordeadoMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BordeadoMenu.ButtonText = "Editar Perfil";
            this.BordeadoMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.BordeadoMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BordeadoMenu.ForeColor = System.Drawing.Color.White;
            this.BordeadoMenu.IdleBorderThickness = 1;
            this.BordeadoMenu.IdleCornerRadius = 20;
            this.BordeadoMenu.IdleFillColor = System.Drawing.Color.White;
            this.BordeadoMenu.IdleForecolor = System.Drawing.Color.White;
            this.BordeadoMenu.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.BordeadoMenu.Location = new System.Drawing.Point(-1, 0);
            this.BordeadoMenu.Margin = new System.Windows.Forms.Padding(5);
            this.BordeadoMenu.Name = "BordeadoMenu";
            this.BordeadoMenu.Size = new System.Drawing.Size(815, 452);
            this.BordeadoMenu.TabIndex = 34;
            this.BordeadoMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Separador1.Location = new System.Drawing.Point(67, 77);
            this.Separador1.Name = "Separador1";
            this.Separador1.Size = new System.Drawing.Size(558, 10);
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
            this.txtBuscar.Size = new System.Drawing.Size(558, 19);
            this.txtBuscar.TabIndex = 76;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnNuevaSesion
            // 
            this.btnNuevaSesion.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnNuevaSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnNuevaSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevaSesion.BorderRadius = 7;
            this.btnNuevaSesion.ButtonText = "Nueva Sesión";
            this.btnNuevaSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaSesion.DisabledColor = System.Drawing.Color.Gray;
            this.btnNuevaSesion.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNuevaSesion.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNuevaSesion.Iconimage")));
            this.btnNuevaSesion.Iconimage_right = null;
            this.btnNuevaSesion.Iconimage_right_Selected = null;
            this.btnNuevaSesion.Iconimage_Selected = null;
            this.btnNuevaSesion.IconMarginLeft = 0;
            this.btnNuevaSesion.IconMarginRight = 0;
            this.btnNuevaSesion.IconRightVisible = true;
            this.btnNuevaSesion.IconRightZoom = 0D;
            this.btnNuevaSesion.IconVisible = true;
            this.btnNuevaSesion.IconZoom = 50D;
            this.btnNuevaSesion.IsTab = false;
            this.btnNuevaSesion.Location = new System.Drawing.Point(642, 51);
            this.btnNuevaSesion.Name = "btnNuevaSesion";
            this.btnNuevaSesion.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnNuevaSesion.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnNuevaSesion.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnNuevaSesion.selected = true;
            this.btnNuevaSesion.Size = new System.Drawing.Size(161, 40);
            this.btnNuevaSesion.TabIndex = 78;
            this.btnNuevaSesion.Text = "Nueva Sesión";
            this.btnNuevaSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevaSesion.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnNuevaSesion.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabla.EnableHeadersVisualStyles = false;
            this.dgvTabla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTabla.Location = new System.Drawing.Point(12, 97);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTabla.RowHeadersVisible = false;
            this.dgvTabla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTabla.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabla.Size = new System.Drawing.Size(791, 339);
            this.dgvTabla.TabIndex = 82;
            this.dgvTabla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTabla_CellFormatting);
            // 
            // P_TablaTutorados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 448);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.btnNuevaSesion);
            this.Controls.Add(this.Separador1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.BordeadoMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_TablaTutorados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Estudiantes";
            this.Load += new System.EventHandler(this.P_TablaTutorados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private Bunifu.Framework.UI.BunifuThinButton2 BordeadoMenu;
        private System.Windows.Forms.Label lblBuscar;
        private Bunifu.Framework.UI.BunifuSeparator Separador1;
        public System.Windows.Forms.TextBox txtBuscar;
        private Bunifu.Framework.UI.BunifuFlatButton btnNuevaSesion;
        private System.Windows.Forms.DataGridView dgvTabla;
    }
}