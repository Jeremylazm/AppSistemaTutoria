
namespace WinFormsFix
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDDleft = new System.Windows.Forms.Panel();
            this.panelDDright = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDDright.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.panelDDright);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.BtnLogin);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.textBoxContraseña);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.textBoxUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(287, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 431);
            this.panel1.TabIndex = 16;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.Location = new System.Drawing.Point(267, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 37);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "@unsaac.edu.pe";
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.DimGray;
            this.BtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("BtnLogin.Image")));
            this.BtnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogin.Location = new System.Drawing.Point(168, 324);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(267, 44);
            this.BtnLogin.TabIndex = 16;
            this.BtnLogin.Text = "Iniciar sesión";
            this.BtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(69, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 1);
            this.panel3.TabIndex = 20;
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.textBoxContraseña.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxContraseña.Location = new System.Drawing.Point(69, 234);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(447, 37);
            this.textBoxContraseña.TabIndex = 15;
            this.textBoxContraseña.Text = "Password";
            this.textBoxContraseña.Enter += new System.EventHandler(this.textBoxContraseña_Enter);
            this.textBoxContraseña.Leave += new System.EventHandler(this.textBoxContraseña_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(69, 199);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(447, 1);
            this.panel4.TabIndex = 18;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.textBoxUsuario.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxUsuario.Location = new System.Drawing.Point(69, 160);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(447, 37);
            this.textBoxUsuario.TabIndex = 14;
            this.textBoxUsuario.Text = "User";
            this.textBoxUsuario.Enter += new System.EventHandler(this.textBoxUsuario_Enter);
            this.textBoxUsuario.Leave += new System.EventHandler(this.textBoxUsuario_Leave);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(564, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 9;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(128, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "SISTEMA DE TUTORÍAS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.panelDDleft);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 431);
            this.panel2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(76, 324);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "UNSAAC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 106);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panelDDleft
            // 
            this.panelDDleft.Location = new System.Drawing.Point(0, 0);
            this.panelDDleft.Name = "panelDDleft";
            this.panelDDleft.Size = new System.Drawing.Size(287, 51);
            this.panelDDleft.TabIndex = 7;
            this.panelDDleft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDDleft_MouseDown);
            // 
            // panelDDright
            // 
            this.panelDDright.Controls.Add(this.pictureBoxClose);
            this.panelDDright.Location = new System.Drawing.Point(0, 0);
            this.panelDDright.Name = "panelDDright";
            this.panelDDright.Size = new System.Drawing.Size(592, 51);
            this.panelDDright.TabIndex = 23;
            this.panelDDright.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDDright_MouseDown);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 431);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDDright.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelDDright;
        private System.Windows.Forms.Panel panelDDleft;
    }
}

