namespace CapaPresentaciones
{
    partial class P_TablaTutores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_TablaTutores));
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BordeadoMenu = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.Separador1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnAsignar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnImportar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvTablaTutores = new System.Windows.Forms.DataGridView();
            this.dgvTablaEstudiantes = new System.Windows.Forms.DataGridView();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEstudiantes = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuSeparator3 = new Bunifu.Framework.UI.BunifuSeparator();
            this.textBoxSeleccionarTutor = new System.Windows.Forms.TextBox();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.textBoxTotalRegistros = new System.Windows.Forms.TextBox();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnVerTutorados = new Bunifu.Framework.UI.BunifuFlatButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnVer = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaTutores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaEstudiantes)).BeginInit();
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
            this.lblTitulo.Text = "Tabla de Tutores";
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
            this.lblBuscar.Location = new System.Drawing.Point(20, 89);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(131, 19);
            this.lblBuscar.TabIndex = 75;
            this.lblBuscar.Text = "Seleccionar Tutor:";
            // 
            // Separador1
            // 
            this.Separador1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Separador1.BackColor = System.Drawing.Color.Transparent;
            this.Separador1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.Separador1.LineThickness = 1;
            this.Separador1.Location = new System.Drawing.Point(157, 102);
            this.Separador1.Name = "Separador1";
            this.Separador1.Size = new System.Drawing.Size(227, 14);
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
            this.txtBuscar.Location = new System.Drawing.Point(133, 58);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(138, 19);
            this.txtBuscar.TabIndex = 76;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Active = true;
            this.btnAsignar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAsignar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignar.BorderRadius = 7;
            this.btnAsignar.ButtonText = "Asignar";
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.DisabledColor = System.Drawing.Color.Gray;
            this.btnAsignar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAsignar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAsignar.Iconimage")));
            this.btnAsignar.Iconimage_right = null;
            this.btnAsignar.Iconimage_right_Selected = null;
            this.btnAsignar.Iconimage_Selected = null;
            this.btnAsignar.IconMarginLeft = 0;
            this.btnAsignar.IconMarginRight = 0;
            this.btnAsignar.IconRightVisible = true;
            this.btnAsignar.IconRightZoom = 0D;
            this.btnAsignar.IconVisible = true;
            this.btnAsignar.IconZoom = 50D;
            this.btnAsignar.IsTab = false;
            this.btnAsignar.Location = new System.Drawing.Point(445, 399);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAsignar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnAsignar.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAsignar.selected = true;
            this.btnAsignar.Size = new System.Drawing.Size(108, 37);
            this.btnAsignar.TabIndex = 78;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAsignar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAsignar.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Active = true;
            this.btnImportar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportar.BorderRadius = 7;
            this.btnImportar.ButtonText = "Importar";
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.DisabledColor = System.Drawing.Color.Gray;
            this.btnImportar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnImportar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnImportar.Iconimage")));
            this.btnImportar.Iconimage_right = null;
            this.btnImportar.Iconimage_right_Selected = null;
            this.btnImportar.Iconimage_Selected = null;
            this.btnImportar.IconMarginLeft = 0;
            this.btnImportar.IconMarginRight = 0;
            this.btnImportar.IconRightVisible = true;
            this.btnImportar.IconRightZoom = 0D;
            this.btnImportar.IconVisible = true;
            this.btnImportar.IconZoom = 50D;
            this.btnImportar.IsTab = false;
            this.btnImportar.Location = new System.Drawing.Point(685, 399);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnImportar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnImportar.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnImportar.selected = true;
            this.btnImportar.Size = new System.Drawing.Size(98, 37);
            this.btnImportar.TabIndex = 81;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnImportar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dgvTablaTutores
            // 
            this.dgvTablaTutores.AllowUserToAddRows = false;
            this.dgvTablaTutores.AllowUserToDeleteRows = false;
            this.dgvTablaTutores.AllowUserToResizeColumns = false;
            this.dgvTablaTutores.AllowUserToResizeRows = false;
            this.dgvTablaTutores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaTutores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTablaTutores.BackgroundColor = System.Drawing.Color.White;
            this.dgvTablaTutores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTablaTutores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTablaTutores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaTutores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTablaTutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTablaTutores.EnableHeadersVisualStyles = false;
            this.dgvTablaTutores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTablaTutores.Location = new System.Drawing.Point(12, 122);
            this.dgvTablaTutores.Name = "dgvTablaTutores";
            this.dgvTablaTutores.ReadOnly = true;
            this.dgvTablaTutores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTablaTutores.RowHeadersVisible = false;
            this.dgvTablaTutores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTablaTutores.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTablaTutores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTablaTutores.Size = new System.Drawing.Size(382, 268);
            this.dgvTablaTutores.TabIndex = 82;
            this.dgvTablaTutores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablaTutores_CellClick);
            // 
            // dgvTablaEstudiantes
            // 
            this.dgvTablaEstudiantes.AllowUserToAddRows = false;
            this.dgvTablaEstudiantes.AllowUserToDeleteRows = false;
            this.dgvTablaEstudiantes.AllowUserToResizeColumns = false;
            this.dgvTablaEstudiantes.AllowUserToResizeRows = false;
            this.dgvTablaEstudiantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaEstudiantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTablaEstudiantes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTablaEstudiantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTablaEstudiantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTablaEstudiantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaEstudiantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTablaEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTablaEstudiantes.EnableHeadersVisualStyles = false;
            this.dgvTablaEstudiantes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTablaEstudiantes.Location = new System.Drawing.Point(424, 122);
            this.dgvTablaEstudiantes.Name = "dgvTablaEstudiantes";
            this.dgvTablaEstudiantes.ReadOnly = true;
            this.dgvTablaEstudiantes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTablaEstudiantes.RowHeadersVisible = false;
            this.dgvTablaEstudiantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvTablaEstudiantes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTablaEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTablaEstudiantes.Size = new System.Drawing.Size(379, 268);
            this.dgvTablaEstudiantes.TabIndex = 83;
            this.dgvTablaEstudiantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablaEstudiantes_CellClick);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(400, 51);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(18, 385);
            this.bunifuSeparator1.TabIndex = 84;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.label1.Location = new System.Drawing.Point(162, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 85;
            this.label1.Text = "TUTORES";
            // 
            // labelEstudiantes
            // 
            this.labelEstudiantes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstudiantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.labelEstudiantes.Location = new System.Drawing.Point(480, 55);
            this.labelEstudiantes.Name = "labelEstudiantes";
            this.labelEstudiantes.Size = new System.Drawing.Size(209, 19);
            this.labelEstudiantes.TabIndex = 86;
            this.labelEstudiantes.Text = "ESTUDIANTES SIN TUTOR";
            this.labelEstudiantes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(487, 102);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(130, 14);
            this.bunifuSeparator2.TabIndex = 87;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.label3.Location = new System.Drawing.Point(420, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 88;
            this.label3.Text = "Buscar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.label4.Location = new System.Drawing.Point(623, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 89;
            this.label4.Text = "Total registros:";
            // 
            // bunifuSeparator3
            // 
            this.bunifuSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuSeparator3.LineThickness = 1;
            this.bunifuSeparator3.Location = new System.Drawing.Point(735, 102);
            this.bunifuSeparator3.Name = "bunifuSeparator3";
            this.bunifuSeparator3.Size = new System.Drawing.Size(63, 14);
            this.bunifuSeparator3.TabIndex = 90;
            this.bunifuSeparator3.Transparency = 255;
            this.bunifuSeparator3.Vertical = false;
            // 
            // textBoxSeleccionarTutor
            // 
            this.textBoxSeleccionarTutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSeleccionarTutor.BackColor = System.Drawing.Color.White;
            this.textBoxSeleccionarTutor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSeleccionarTutor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSeleccionarTutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.textBoxSeleccionarTutor.Location = new System.Drawing.Point(157, 89);
            this.textBoxSeleccionarTutor.Name = "textBoxSeleccionarTutor";
            this.textBoxSeleccionarTutor.Size = new System.Drawing.Size(227, 19);
            this.textBoxSeleccionarTutor.TabIndex = 91;
            this.textBoxSeleccionarTutor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSeleccionarTutor.TextChanged += new System.EventHandler(this.textBoxSeleccionarTutor_TextChanged);
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBuscar.BackColor = System.Drawing.Color.White;
            this.textBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.textBoxBuscar.Location = new System.Drawing.Point(487, 89);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(130, 19);
            this.textBoxBuscar.TabIndex = 92;
            this.textBoxBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            // 
            // textBoxTotalRegistros
            // 
            this.textBoxTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotalRegistros.BackColor = System.Drawing.Color.White;
            this.textBoxTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.textBoxTotalRegistros.Location = new System.Drawing.Point(735, 89);
            this.textBoxTotalRegistros.Name = "textBoxTotalRegistros";
            this.textBoxTotalRegistros.Size = new System.Drawing.Size(63, 19);
            this.textBoxTotalRegistros.TabIndex = 93;
            this.textBoxTotalRegistros.Text = "10";
            this.textBoxTotalRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTotalRegistros.TextChanged += new System.EventHandler(this.textBoxTotalRegistros_TextChanged);
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
            this.btnEliminar.Location = new System.Drawing.Point(567, 399);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEliminar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnEliminar.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEliminar.selected = true;
            this.btnEliminar.Size = new System.Drawing.Size(103, 37);
            this.btnEliminar.TabIndex = 94;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEliminar.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVerTutorados
            // 
            this.btnVerTutorados.Active = true;
            this.btnVerTutorados.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerTutorados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerTutorados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerTutorados.BorderRadius = 7;
            this.btnVerTutorados.ButtonText = "Ver Tutorados";
            this.btnVerTutorados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTutorados.DisabledColor = System.Drawing.Color.Gray;
            this.btnVerTutorados.Iconcolor = System.Drawing.Color.Transparent;
            this.btnVerTutorados.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnVerTutorados.Iconimage")));
            this.btnVerTutorados.Iconimage_right = null;
            this.btnVerTutorados.Iconimage_right_Selected = null;
            this.btnVerTutorados.Iconimage_Selected = null;
            this.btnVerTutorados.IconMarginLeft = 0;
            this.btnVerTutorados.IconMarginRight = 0;
            this.btnVerTutorados.IconRightVisible = true;
            this.btnVerTutorados.IconRightZoom = 0D;
            this.btnVerTutorados.IconVisible = true;
            this.btnVerTutorados.IconZoom = 50D;
            this.btnVerTutorados.IsTab = false;
            this.btnVerTutorados.Location = new System.Drawing.Point(133, 399);
            this.btnVerTutorados.Name = "btnVerTutorados";
            this.btnVerTutorados.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerTutorados.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnVerTutorados.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerTutorados.selected = true;
            this.btnVerTutorados.Size = new System.Drawing.Size(138, 37);
            this.btnVerTutorados.TabIndex = 95;
            this.btnVerTutorados.Text = "Ver Tutorados";
            this.btnVerTutorados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerTutorados.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerTutorados.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTutorados.Click += new System.EventHandler(this.btnVerTutorados_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnVer
            // 
            this.btnVer.Active = true;
            this.btnVer.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVer.BorderRadius = 7;
            this.btnVer.ButtonText = "Ver";
            this.btnVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer.DisabledColor = System.Drawing.Color.Gray;
            this.btnVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.Iconcolor = System.Drawing.Color.Transparent;
            this.btnVer.Iconimage = null;
            this.btnVer.Iconimage_right = null;
            this.btnVer.Iconimage_right_Selected = null;
            this.btnVer.Iconimage_Selected = null;
            this.btnVer.IconMarginLeft = 0;
            this.btnVer.IconMarginRight = 0;
            this.btnVer.IconRightVisible = true;
            this.btnVer.IconRightZoom = 0D;
            this.btnVer.IconVisible = true;
            this.btnVer.IconZoom = 50D;
            this.btnVer.IsTab = false;
            this.btnVer.Location = new System.Drawing.Point(729, 54);
            this.btnVer.Name = "btnVer";
            this.btnVer.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVer.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnVer.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVer.selected = true;
            this.btnVer.Size = new System.Drawing.Size(54, 23);
            this.btnVer.TabIndex = 96;
            this.btnVer.Text = "Ver";
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVer.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVer.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // P_TablaTutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 448);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnVerTutorados);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.textBoxTotalRegistros);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.textBoxSeleccionarTutor);
            this.Controls.Add(this.bunifuSeparator3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.labelEstudiantes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.dgvTablaEstudiantes);
            this.Controls.Add(this.dgvTablaTutores);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.Separador1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.BordeadoMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_TablaTutores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Estudiantes";
            this.Load += new System.EventHandler(this.P_TablaDocentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaTutores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaEstudiantes)).EndInit();
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
        private Bunifu.Framework.UI.BunifuFlatButton btnAsignar;
        private Bunifu.Framework.UI.BunifuFlatButton btnImportar;
        private System.Windows.Forms.DataGridView dgvTablaTutores;
        private System.Windows.Forms.DataGridView dgvTablaEstudiantes;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Label labelEstudiantes;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxSeleccionarTutor;
        public System.Windows.Forms.TextBox textBoxTotalRegistros;
        public System.Windows.Forms.TextBox textBoxBuscar;
        private Bunifu.Framework.UI.BunifuFlatButton btnEliminar;
        private Bunifu.Framework.UI.BunifuFlatButton btnVerTutorados;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Bunifu.Framework.UI.BunifuFlatButton btnVer;
    }
}