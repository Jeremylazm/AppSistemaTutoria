
namespace CapaPresentaciones
{
    partial class P_RecuperarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_RecuperarContraseña));
            this.Movimiento = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.imgLogoUNSAAC = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnRecuperar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblDominioEmail = new System.Windows.Forms.Label();
            this.Separador5 = new Bunifu.Framework.UI.BunifuSeparator();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.imgContraseña = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoUNSAAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgContraseña)).BeginInit();
            this.SuspendLayout();
            // 
            // Movimiento
            // 
            this.Movimiento.Fixed = true;
            this.Movimiento.Horizontal = true;
            this.Movimiento.TargetControl = this.lblTitulo;
            this.Movimiento.Vertical = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(416, 40);
            this.lblTitulo.TabIndex = 64;
            this.lblTitulo.Text = "Sistema de Tutoría - UNSAAC";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnCerrar.Location = new System.Drawing.Point(380, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 73;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblCorreo.Location = new System.Drawing.Point(198, 94);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(153, 19);
            this.lblCorreo.TabIndex = 110;
            this.lblCorreo.Text = "Correro Institucional:";
            // 
            // imgLogoUNSAAC
            // 
            this.imgLogoUNSAAC.BackColor = System.Drawing.Color.Transparent;
            this.imgLogoUNSAAC.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgLogoUNSAAC.Image = ((System.Drawing.Image)(resources.GetObject("imgLogoUNSAAC.Image")));
            this.imgLogoUNSAAC.ImageActive = null;
            this.imgLogoUNSAAC.Location = new System.Drawing.Point(12, 53);
            this.imgLogoUNSAAC.Name = "imgLogoUNSAAC";
            this.imgLogoUNSAAC.Size = new System.Drawing.Size(146, 192);
            this.imgLogoUNSAAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogoUNSAAC.TabIndex = 111;
            this.imgLogoUNSAAC.TabStop = false;
            this.imgLogoUNSAAC.Zoom = 10;
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Active = true;
            this.btnRecuperar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecuperar.BorderRadius = 7;
            this.btnRecuperar.ButtonText = "Recuperar mi contraseña";
            this.btnRecuperar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecuperar.DisabledColor = System.Drawing.Color.Gray;
            this.btnRecuperar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRecuperar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRecuperar.Iconimage")));
            this.btnRecuperar.Iconimage_right = null;
            this.btnRecuperar.Iconimage_right_Selected = null;
            this.btnRecuperar.Iconimage_Selected = null;
            this.btnRecuperar.IconMarginLeft = 0;
            this.btnRecuperar.IconMarginRight = 0;
            this.btnRecuperar.IconRightVisible = true;
            this.btnRecuperar.IconRightZoom = 0D;
            this.btnRecuperar.IconVisible = true;
            this.btnRecuperar.IconZoom = 50D;
            this.btnRecuperar.IsTab = false;
            this.btnRecuperar.Location = new System.Drawing.Point(171, 163);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnRecuperar.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.selected = true;
            this.btnRecuperar.Size = new System.Drawing.Size(228, 40);
            this.btnRecuperar.TabIndex = 112;
            this.btnRecuperar.Text = "Recuperar mi contraseña";
            this.btnRecuperar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecuperar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // lblDominioEmail
            // 
            this.lblDominioEmail.AutoSize = true;
            this.lblDominioEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDominioEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblDominioEmail.Location = new System.Drawing.Point(294, 121);
            this.lblDominioEmail.Name = "lblDominioEmail";
            this.lblDominioEmail.Size = new System.Drawing.Size(110, 19);
            this.lblDominioEmail.TabIndex = 131;
            this.lblDominioEmail.Text = "@unsaac.edu.pe";
            // 
            // Separador5
            // 
            this.Separador5.BackColor = System.Drawing.Color.Transparent;
            this.Separador5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.Separador5.LineThickness = 1;
            this.Separador5.Location = new System.Drawing.Point(171, 144);
            this.Separador5.Name = "Separador5";
            this.Separador5.Size = new System.Drawing.Size(226, 10);
            this.Separador5.TabIndex = 130;
            this.Separador5.Transparency = 255;
            this.Separador5.Vertical = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtEmail.Location = new System.Drawing.Point(202, 121);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(96, 19);
            this.txtEmail.TabIndex = 129;
            // 
            // imgContraseña
            // 
            this.imgContraseña.BackColor = System.Drawing.Color.Transparent;
            this.imgContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgContraseña.Image = ((System.Drawing.Image)(resources.GetObject("imgContraseña.Image")));
            this.imgContraseña.ImageActive = null;
            this.imgContraseña.Location = new System.Drawing.Point(170, 116);
            this.imgContraseña.Name = "imgContraseña";
            this.imgContraseña.Size = new System.Drawing.Size(26, 26);
            this.imgContraseña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgContraseña.TabIndex = 132;
            this.imgContraseña.TabStop = false;
            this.imgContraseña.Zoom = 10;
            // 
            // P_RecuperarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(416, 257);
            this.Controls.Add(this.imgContraseña);
            this.Controls.Add(this.lblDominioEmail);
            this.Controls.Add(this.Separador5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.imgLogoUNSAAC);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_RecuperarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_RecuperarContraseña";
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoUNSAAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgContraseña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl Movimiento;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCorreo;
        private Bunifu.Framework.UI.BunifuImageButton imgLogoUNSAAC;
        private Bunifu.Framework.UI.BunifuFlatButton btnRecuperar;
        private System.Windows.Forms.Label lblDominioEmail;
        private Bunifu.Framework.UI.BunifuSeparator Separador5;
        public System.Windows.Forms.TextBox txtEmail;
        private Bunifu.Framework.UI.BunifuImageButton imgContraseña;
    }
}