namespace CapaPresentaciones
{
    partial class P_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Menu));
            this.MovimientoMenu = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnRestaurar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMaximizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.imgLogoUNSAAC = new Bunifu.Framework.UI.BunifuImageButton();
            this.BordeadoMenu = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.BordeadoContenedor = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnContenedor = new System.Windows.Forms.Panel();
            this.pnLateral = new System.Windows.Forms.Panel();
            this.btnMiTutor = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnInformeTutorias = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTutores = new Bunifu.Framework.UI.BunifuFlatButton();
            this.separador = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnTutorados = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDocentes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEstudiantes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTutorias = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Separador1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnEditarPerfil = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblAcceso = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.pnInferior = new System.Windows.Forms.Panel();
            this.pnPrincipal = new System.Windows.Forms.Panel();
            this.imgPerfil = new CapaPresentaciones.Otros_Controles.JALMCircularPictureBox();
            this.pnSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoUNSAAC)).BeginInit();
            this.pnLateral.SuspendLayout();
            this.pnPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // MovimientoMenu
            // 
            this.MovimientoMenu.Fixed = true;
            this.MovimientoMenu.Horizontal = true;
            this.MovimientoMenu.TargetControl = this.pnSuperior;
            this.MovimientoMenu.Vertical = true;
            // 
            // pnSuperior
            // 
            this.pnSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.pnSuperior.Controls.Add(this.lblTitulo);
            this.pnSuperior.Controls.Add(this.btnMinimizar);
            this.pnSuperior.Controls.Add(this.btnRestaurar);
            this.pnSuperior.Controls.Add(this.btnMaximizar);
            this.pnSuperior.Controls.Add(this.btnCerrar);
            this.pnSuperior.Controls.Add(this.imgLogoUNSAAC);
            this.pnSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSuperior.Location = new System.Drawing.Point(173, 0);
            this.pnSuperior.Name = "pnSuperior";
            this.pnSuperior.Size = new System.Drawing.Size(827, 70);
            this.pnSuperior.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Location = new System.Drawing.Point(86, 26);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(639, 24);
            this.lblTitulo.TabIndex = 64;
            this.lblTitulo.Text = "Sistema de Tutoría - Universidad Nacional San Antonio Abad del Cusco";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.ImageActive = null;
            this.btnMinimizar.Location = new System.Drawing.Point(731, 12);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(24, 24);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 9;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.ImageActive = null;
            this.btnRestaurar.Location = new System.Drawing.Point(761, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(24, 24);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Zoom = 10;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.ImageActive = null;
            this.btnMaximizar.Location = new System.Drawing.Point(761, 12);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(24, 24);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 7;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Zoom = 10;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.Location = new System.Drawing.Point(791, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // imgLogoUNSAAC
            // 
            this.imgLogoUNSAAC.BackColor = System.Drawing.Color.Transparent;
            this.imgLogoUNSAAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgLogoUNSAAC.Image = ((System.Drawing.Image)(resources.GetObject("imgLogoUNSAAC.Image")));
            this.imgLogoUNSAAC.ImageActive = null;
            this.imgLogoUNSAAC.Location = new System.Drawing.Point(3, 2);
            this.imgLogoUNSAAC.Name = "imgLogoUNSAAC";
            this.imgLogoUNSAAC.Size = new System.Drawing.Size(65, 65);
            this.imgLogoUNSAAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoUNSAAC.TabIndex = 5;
            this.imgLogoUNSAAC.TabStop = false;
            this.imgLogoUNSAAC.Zoom = 10;
            // 
            // BordeadoMenu
            // 
            this.BordeadoMenu.ElipseRadius = 15;
            this.BordeadoMenu.TargetControl = this;
            // 
            // BordeadoContenedor
            // 
            this.BordeadoContenedor.ElipseRadius = 15;
            this.BordeadoContenedor.TargetControl = this.pnContenedor;
            // 
            // pnContenedor
            // 
            this.pnContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnContenedor.BackColor = System.Drawing.Color.White;
            this.pnContenedor.ForeColor = System.Drawing.Color.White;
            this.pnContenedor.Location = new System.Drawing.Point(179, 76);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.Size = new System.Drawing.Size(815, 448);
            this.pnContenedor.TabIndex = 6;
            // 
            // pnLateral
            // 
            this.pnLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pnLateral.Controls.Add(this.btnMiTutor);
            this.pnLateral.Controls.Add(this.btnInformeTutorias);
            this.pnLateral.Controls.Add(this.btnTutores);
            this.pnLateral.Controls.Add(this.separador);
            this.pnLateral.Controls.Add(this.btnTutorados);
            this.pnLateral.Controls.Add(this.imgPerfil);
            this.pnLateral.Controls.Add(this.btnDocentes);
            this.pnLateral.Controls.Add(this.btnEstudiantes);
            this.pnLateral.Controls.Add(this.btnTutorias);
            this.pnLateral.Controls.Add(this.Separador1);
            this.pnLateral.Controls.Add(this.btnEditarPerfil);
            this.pnLateral.Controls.Add(this.lblUsuario);
            this.pnLateral.Controls.Add(this.lblAcceso);
            this.pnLateral.Controls.Add(this.lblDatos);
            this.pnLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLateral.Location = new System.Drawing.Point(0, 0);
            this.pnLateral.Name = "pnLateral";
            this.pnLateral.Size = new System.Drawing.Size(173, 600);
            this.pnLateral.TabIndex = 4;
            // 
            // btnMiTutor
            // 
            this.btnMiTutor.Active = true;
            this.btnMiTutor.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnMiTutor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnMiTutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMiTutor.BorderRadius = 7;
            this.btnMiTutor.ButtonText = "Mi Tutor";
            this.btnMiTutor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMiTutor.DisabledColor = System.Drawing.Color.Gray;
            this.btnMiTutor.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMiTutor.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnMiTutor.Iconimage")));
            this.btnMiTutor.Iconimage_right = null;
            this.btnMiTutor.Iconimage_right_Selected = null;
            this.btnMiTutor.Iconimage_Selected = null;
            this.btnMiTutor.IconMarginLeft = 0;
            this.btnMiTutor.IconMarginRight = 0;
            this.btnMiTutor.IconRightVisible = true;
            this.btnMiTutor.IconRightZoom = 0D;
            this.btnMiTutor.IconVisible = true;
            this.btnMiTutor.IconZoom = 50D;
            this.btnMiTutor.IsTab = false;
            this.btnMiTutor.Location = new System.Drawing.Point(5, 284);
            this.btnMiTutor.Name = "btnMiTutor";
            this.btnMiTutor.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnMiTutor.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnMiTutor.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnMiTutor.selected = true;
            this.btnMiTutor.Size = new System.Drawing.Size(161, 40);
            this.btnMiTutor.TabIndex = 43;
            this.btnMiTutor.Text = "Mi Tutor";
            this.btnMiTutor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMiTutor.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnMiTutor.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiTutor.Click += new System.EventHandler(this.btnMiTutor_Click);
            // 
            // btnInformeTutorias
            // 
            this.btnInformeTutorias.Active = true;
            this.btnInformeTutorias.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnInformeTutorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnInformeTutorias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInformeTutorias.BorderRadius = 7;
            this.btnInformeTutorias.ButtonText = "Informe Tutorias";
            this.btnInformeTutorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformeTutorias.DisabledColor = System.Drawing.Color.Gray;
            this.btnInformeTutorias.Iconcolor = System.Drawing.Color.Transparent;
            this.btnInformeTutorias.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnInformeTutorias.Iconimage")));
            this.btnInformeTutorias.Iconimage_right = null;
            this.btnInformeTutorias.Iconimage_right_Selected = null;
            this.btnInformeTutorias.Iconimage_Selected = null;
            this.btnInformeTutorias.IconMarginLeft = 0;
            this.btnInformeTutorias.IconMarginRight = 0;
            this.btnInformeTutorias.IconRightVisible = true;
            this.btnInformeTutorias.IconRightZoom = 0D;
            this.btnInformeTutorias.IconVisible = true;
            this.btnInformeTutorias.IconZoom = 50D;
            this.btnInformeTutorias.IsTab = false;
            this.btnInformeTutorias.Location = new System.Drawing.Point(4, 540);
            this.btnInformeTutorias.Name = "btnInformeTutorias";
            this.btnInformeTutorias.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnInformeTutorias.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnInformeTutorias.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnInformeTutorias.selected = true;
            this.btnInformeTutorias.Size = new System.Drawing.Size(161, 40);
            this.btnInformeTutorias.TabIndex = 49;
            this.btnInformeTutorias.Text = "Informe Tutorias";
            this.btnInformeTutorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInformeTutorias.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnInformeTutorias.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnTutores
            // 
            this.btnTutores.Active = true;
            this.btnTutores.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTutores.BorderRadius = 7;
            this.btnTutores.ButtonText = "Tutores";
            this.btnTutores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTutores.DisabledColor = System.Drawing.Color.Gray;
            this.btnTutores.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTutores.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnTutores.Iconimage")));
            this.btnTutores.Iconimage_right = null;
            this.btnTutores.Iconimage_right_Selected = null;
            this.btnTutores.Iconimage_Selected = null;
            this.btnTutores.IconMarginLeft = 0;
            this.btnTutores.IconMarginRight = 0;
            this.btnTutores.IconRightVisible = true;
            this.btnTutores.IconRightZoom = 0D;
            this.btnTutores.IconVisible = true;
            this.btnTutores.IconZoom = 50D;
            this.btnTutores.IsTab = false;
            this.btnTutores.Location = new System.Drawing.Point(5, 448);
            this.btnTutores.Name = "btnTutores";
            this.btnTutores.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutores.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnTutores.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnTutores.selected = true;
            this.btnTutores.Size = new System.Drawing.Size(161, 40);
            this.btnTutores.TabIndex = 48;
            this.btnTutores.Text = "Tutores";
            this.btnTutores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTutores.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnTutores.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutores.Click += new System.EventHandler(this.btnTutores_Click);
            // 
            // separador
            // 
            this.separador.BackColor = System.Drawing.Color.Transparent;
            this.separador.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.separador.LineThickness = 1;
            this.separador.Location = new System.Drawing.Point(7, 376);
            this.separador.Name = "separador";
            this.separador.Size = new System.Drawing.Size(161, 20);
            this.separador.TabIndex = 47;
            this.separador.Transparency = 255;
            this.separador.Vertical = false;
            // 
            // btnTutorados
            // 
            this.btnTutorados.Active = true;
            this.btnTutorados.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutorados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutorados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTutorados.BorderRadius = 7;
            this.btnTutorados.ButtonText = "Tutorados";
            this.btnTutorados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTutorados.DisabledColor = System.Drawing.Color.Gray;
            this.btnTutorados.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTutorados.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnTutorados.Iconimage")));
            this.btnTutorados.Iconimage_right = null;
            this.btnTutorados.Iconimage_right_Selected = null;
            this.btnTutorados.Iconimage_Selected = null;
            this.btnTutorados.IconMarginLeft = 0;
            this.btnTutorados.IconMarginRight = 0;
            this.btnTutorados.IconRightVisible = true;
            this.btnTutorados.IconRightZoom = 0D;
            this.btnTutorados.IconVisible = true;
            this.btnTutorados.IconZoom = 50D;
            this.btnTutorados.IsTab = false;
            this.btnTutorados.Location = new System.Drawing.Point(6, 330);
            this.btnTutorados.Name = "btnTutorados";
            this.btnTutorados.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutorados.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnTutorados.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnTutorados.selected = true;
            this.btnTutorados.Size = new System.Drawing.Size(161, 40);
            this.btnTutorados.TabIndex = 46;
            this.btnTutorados.Text = "Tutorados";
            this.btnTutorados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTutorados.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnTutorados.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutorados.Click += new System.EventHandler(this.btnTutorados_Click);
            // 
            // btnDocentes
            // 
            this.btnDocentes.Active = true;
            this.btnDocentes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnDocentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDocentes.BorderRadius = 7;
            this.btnDocentes.ButtonText = "Docentes";
            this.btnDocentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocentes.DisabledColor = System.Drawing.Color.Gray;
            this.btnDocentes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDocentes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDocentes.Iconimage")));
            this.btnDocentes.Iconimage_right = null;
            this.btnDocentes.Iconimage_right_Selected = null;
            this.btnDocentes.Iconimage_Selected = null;
            this.btnDocentes.IconMarginLeft = 0;
            this.btnDocentes.IconMarginRight = 0;
            this.btnDocentes.IconRightVisible = true;
            this.btnDocentes.IconRightZoom = 0D;
            this.btnDocentes.IconVisible = true;
            this.btnDocentes.IconZoom = 50D;
            this.btnDocentes.IsTab = false;
            this.btnDocentes.Location = new System.Drawing.Point(5, 402);
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnDocentes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnDocentes.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnDocentes.selected = true;
            this.btnDocentes.Size = new System.Drawing.Size(161, 40);
            this.btnDocentes.TabIndex = 44;
            this.btnDocentes.Text = "Docentes";
            this.btnDocentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDocentes.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnDocentes.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocentes.Click += new System.EventHandler(this.btnDocentes_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.Active = true;
            this.btnEstudiantes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEstudiantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEstudiantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstudiantes.BorderRadius = 7;
            this.btnEstudiantes.ButtonText = "Estudiantes";
            this.btnEstudiantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstudiantes.DisabledColor = System.Drawing.Color.Gray;
            this.btnEstudiantes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEstudiantes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEstudiantes.Iconimage")));
            this.btnEstudiantes.Iconimage_right = null;
            this.btnEstudiantes.Iconimage_right_Selected = null;
            this.btnEstudiantes.Iconimage_Selected = null;
            this.btnEstudiantes.IconMarginLeft = 0;
            this.btnEstudiantes.IconMarginRight = 0;
            this.btnEstudiantes.IconRightVisible = true;
            this.btnEstudiantes.IconRightZoom = 0D;
            this.btnEstudiantes.IconVisible = true;
            this.btnEstudiantes.IconZoom = 50D;
            this.btnEstudiantes.IsTab = false;
            this.btnEstudiantes.Location = new System.Drawing.Point(4, 494);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEstudiantes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnEstudiantes.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEstudiantes.selected = true;
            this.btnEstudiantes.Size = new System.Drawing.Size(161, 40);
            this.btnEstudiantes.TabIndex = 43;
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstudiantes.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEstudiantes.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // btnTutorias
            // 
            this.btnTutorias.Active = true;
            this.btnTutorias.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutorias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTutorias.BorderRadius = 7;
            this.btnTutorias.ButtonText = "Tutorías";
            this.btnTutorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTutorias.DisabledColor = System.Drawing.Color.Gray;
            this.btnTutorias.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTutorias.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnTutorias.Iconimage")));
            this.btnTutorias.Iconimage_right = null;
            this.btnTutorias.Iconimage_right_Selected = null;
            this.btnTutorias.Iconimage_Selected = null;
            this.btnTutorias.IconMarginLeft = 0;
            this.btnTutorias.IconMarginRight = 0;
            this.btnTutorias.IconRightVisible = true;
            this.btnTutorias.IconRightZoom = 0D;
            this.btnTutorias.IconVisible = true;
            this.btnTutorias.IconZoom = 50D;
            this.btnTutorias.IsTab = false;
            this.btnTutorias.Location = new System.Drawing.Point(5, 284);
            this.btnTutorias.Name = "btnTutorias";
            this.btnTutorias.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnTutorias.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnTutorias.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnTutorias.selected = true;
            this.btnTutorias.Size = new System.Drawing.Size(161, 40);
            this.btnTutorias.TabIndex = 42;
            this.btnTutorias.Text = "Tutorías";
            this.btnTutorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTutorias.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnTutorias.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutorias.Click += new System.EventHandler(this.btnTutorias_Click);
            // 
            // Separador1
            // 
            this.Separador1.BackColor = System.Drawing.Color.Transparent;
            this.Separador1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.Separador1.LineThickness = 1;
            this.Separador1.Location = new System.Drawing.Point(5, 257);
            this.Separador1.Name = "Separador1";
            this.Separador1.Size = new System.Drawing.Size(161, 35);
            this.Separador1.TabIndex = 34;
            this.Separador1.Transparency = 255;
            this.Separador1.Vertical = false;
            // 
            // btnEditarPerfil
            // 
            this.btnEditarPerfil.ActiveBorderThickness = 1;
            this.btnEditarPerfil.ActiveCornerRadius = 20;
            this.btnEditarPerfil.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditarPerfil.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditarPerfil.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditarPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditarPerfil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarPerfil.BackgroundImage")));
            this.btnEditarPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarPerfil.ButtonText = "Editar Perfil";
            this.btnEditarPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarPerfil.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditarPerfil.IdleBorderThickness = 1;
            this.btnEditarPerfil.IdleCornerRadius = 20;
            this.btnEditarPerfil.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditarPerfil.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditarPerfil.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditarPerfil.Location = new System.Drawing.Point(5, 222);
            this.btnEditarPerfil.Margin = new System.Windows.Forms.Padding(5);
            this.btnEditarPerfil.Name = "btnEditarPerfil";
            this.btnEditarPerfil.Size = new System.Drawing.Size(161, 41);
            this.btnEditarPerfil.TabIndex = 33;
            this.btnEditarPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditarPerfil.Click += new System.EventHandler(this.btnEditarPerfil_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblUsuario.Location = new System.Drawing.Point(5, 195);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(161, 19);
            this.lblUsuario.TabIndex = 32;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAcceso
            // 
            this.lblAcceso.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblAcceso.Location = new System.Drawing.Point(5, 167);
            this.lblAcceso.Name = "lblAcceso";
            this.lblAcceso.Size = new System.Drawing.Size(161, 19);
            this.lblAcceso.TabIndex = 31;
            this.lblAcceso.Text = "Acceso";
            this.lblAcceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDatos
            // 
            this.lblDatos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblDatos.Location = new System.Drawing.Point(5, 120);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(161, 38);
            this.lblDatos.TabIndex = 30;
            this.lblDatos.Text = "Datos";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnInferior
            // 
            this.pnInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.pnInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnInferior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pnInferior.Location = new System.Drawing.Point(173, 530);
            this.pnInferior.Name = "pnInferior";
            this.pnInferior.Size = new System.Drawing.Size(827, 70);
            this.pnInferior.TabIndex = 5;
            // 
            // pnPrincipal
            // 
            this.pnPrincipal.Controls.Add(this.pnSuperior);
            this.pnPrincipal.Controls.Add(this.pnContenedor);
            this.pnPrincipal.Controls.Add(this.pnInferior);
            this.pnPrincipal.Controls.Add(this.pnLateral);
            this.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnPrincipal.Name = "pnPrincipal";
            this.pnPrincipal.Size = new System.Drawing.Size(1000, 600);
            this.pnPrincipal.TabIndex = 5;
            // 
            // imgPerfil
            // 
            this.imgPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.imgPerfil.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.imgPerfil.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.imgPerfil.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.imgPerfil.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.imgPerfil.BorderSize = 2;
            this.imgPerfil.GradientAngle = 50F;
            this.imgPerfil.Image = ((System.Drawing.Image)(resources.GetObject("imgPerfil.Image")));
            this.imgPerfil.Location = new System.Drawing.Point(34, 12);
            this.imgPerfil.Name = "imgPerfil";
            this.imgPerfil.Size = new System.Drawing.Size(100, 100);
            this.imgPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPerfil.TabIndex = 45;
            this.imgPerfil.TabStop = false;
            // 
            // P_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "P_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú del Sistema";
            this.Load += new System.EventHandler(this.P_Menu_Load);
            this.pnSuperior.ResumeLayout(false);
            this.pnSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoUNSAAC)).EndInit();
            this.pnLateral.ResumeLayout(false);
            this.pnPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl MovimientoMenu;
        private Bunifu.Framework.UI.BunifuElipse BordeadoMenu;
        private Bunifu.Framework.UI.BunifuElipse BordeadoContenedor;
        private System.Windows.Forms.Panel pnPrincipal;
        private System.Windows.Forms.Panel pnSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private Bunifu.Framework.UI.BunifuImageButton btnRestaurar;
        private Bunifu.Framework.UI.BunifuImageButton btnMaximizar;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton imgLogoUNSAAC;
        private System.Windows.Forms.Panel pnContenedor;
        private System.Windows.Forms.Panel pnInferior;
        private System.Windows.Forms.Panel pnLateral;
        private Bunifu.Framework.UI.BunifuFlatButton btnDocentes;
        private Bunifu.Framework.UI.BunifuFlatButton btnEstudiantes;
        private Bunifu.Framework.UI.BunifuFlatButton btnTutorias;
        private Bunifu.Framework.UI.BunifuSeparator Separador1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEditarPerfil;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblAcceso;
        private System.Windows.Forms.Label lblDatos;
        private Otros_Controles.JALMCircularPictureBox imgPerfil;
        private Bunifu.Framework.UI.BunifuFlatButton btnTutorados;
        private Bunifu.Framework.UI.BunifuFlatButton btnInformeTutorias;
        private Bunifu.Framework.UI.BunifuFlatButton btnTutores;
        private Bunifu.Framework.UI.BunifuSeparator separador;
        private Bunifu.Framework.UI.BunifuFlatButton btnMiTutor;
    }
}