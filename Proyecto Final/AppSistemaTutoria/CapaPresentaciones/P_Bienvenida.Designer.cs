namespace CapaPresentaciones
{
    partial class P_Bienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Bienvenida));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.imgLogoUNSAAC = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.lblInferior = new System.Windows.Forms.Label();
            this.TiempoAparicion = new System.Windows.Forms.Timer(this.components);
            this.TiempoDesaparicion = new System.Windows.Forms.Timer(this.components);
            this.ProgresoCircular = new CircularProgressBar.CircularProgressBar();
            this.Movimiento = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoUNSAAC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1000, 70);
            this.lblTitulo.TabIndex = 63;
            this.lblTitulo.Text = "Sistema de Tutoría - Universidad Nacional San Antonio Abad del Cusco";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgLogoUNSAAC
            // 
            this.imgLogoUNSAAC.BackColor = System.Drawing.Color.Transparent;
            this.imgLogoUNSAAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgLogoUNSAAC.Image = ((System.Drawing.Image)(resources.GetObject("imgLogoUNSAAC.Image")));
            this.imgLogoUNSAAC.ImageActive = null;
            this.imgLogoUNSAAC.Location = new System.Drawing.Point(52, 109);
            this.imgLogoUNSAAC.Name = "imgLogoUNSAAC";
            this.imgLogoUNSAAC.Size = new System.Drawing.Size(400, 400);
            this.imgLogoUNSAAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoUNSAAC.TabIndex = 64;
            this.imgLogoUNSAAC.TabStop = false;
            this.imgLogoUNSAAC.Zoom = 10;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblBienvenida.Location = new System.Drawing.Point(533, 129);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(367, 73);
            this.lblBienvenida.TabIndex = 65;
            this.lblBienvenida.Text = "Bienvenid@";
            // 
            // lblDatos
            // 
            this.lblDatos.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblDatos.Location = new System.Drawing.Point(542, 212);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(338, 56);
            this.lblDatos.TabIndex = 66;
            this.lblDatos.Text = "Datos";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInferior
            // 
            this.lblInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInferior.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInferior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblInferior.Location = new System.Drawing.Point(0, 530);
            this.lblInferior.Name = "lblInferior";
            this.lblInferior.Size = new System.Drawing.Size(1000, 70);
            this.lblInferior.TabIndex = 67;
            this.lblInferior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TiempoAparicion
            // 
            this.TiempoAparicion.Interval = 30;
            this.TiempoAparicion.Tick += new System.EventHandler(this.TiempoAparicion_Tick);
            // 
            // TiempoDesaparicion
            // 
            this.TiempoDesaparicion.Interval = 30;
            this.TiempoDesaparicion.Tick += new System.EventHandler(this.TiempoDesaparicion_Tick);
            // 
            // ProgresoCircular
            // 
            this.ProgresoCircular.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.ProgresoCircular.AnimationSpeed = 500;
            this.ProgresoCircular.BackColor = System.Drawing.Color.Transparent;
            this.ProgresoCircular.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgresoCircular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.ProgresoCircular.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.ProgresoCircular.InnerMargin = 2;
            this.ProgresoCircular.InnerWidth = -1;
            this.ProgresoCircular.Location = new System.Drawing.Point(610, 277);
            this.ProgresoCircular.MarqueeAnimationSpeed = 2000;
            this.ProgresoCircular.Name = "ProgresoCircular";
            this.ProgresoCircular.OuterColor = System.Drawing.Color.White;
            this.ProgresoCircular.OuterMargin = -25;
            this.ProgresoCircular.OuterWidth = 26;
            this.ProgresoCircular.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.ProgresoCircular.ProgressWidth = 25;
            this.ProgresoCircular.SecondaryFont = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgresoCircular.Size = new System.Drawing.Size(190, 190);
            this.ProgresoCircular.StartAngle = 270;
            this.ProgresoCircular.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgresoCircular.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.ProgresoCircular.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.ProgresoCircular.SubscriptText = "";
            this.ProgresoCircular.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.ProgresoCircular.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.ProgresoCircular.SuperscriptText = "%";
            this.ProgresoCircular.TabIndex = 68;
            this.ProgresoCircular.Text = "0";
            this.ProgresoCircular.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.ProgresoCircular.Value = 68;
            // 
            // Movimiento
            // 
            this.Movimiento.Fixed = true;
            this.Movimiento.Horizontal = true;
            this.Movimiento.TargetControl = this.lblTitulo;
            this.Movimiento.Vertical = true;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // P_Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.ProgresoCircular);
            this.Controls.Add(this.lblInferior);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.imgLogoUNSAAC);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bievenida";
            this.Load += new System.EventHandler(this.P_Bienvenida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoUNSAAC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private Bunifu.Framework.UI.BunifuImageButton imgLogoUNSAAC;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.Label lblInferior;
        private System.Windows.Forms.Timer TiempoAparicion;
        private System.Windows.Forms.Timer TiempoDesaparicion;
        private CircularProgressBar.CircularProgressBar ProgresoCircular;
        private Bunifu.Framework.UI.BunifuDragControl Movimiento;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
    }
}