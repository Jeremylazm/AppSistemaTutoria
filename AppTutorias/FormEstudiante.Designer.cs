
namespace WinFormsFix
{
    partial class FormEstudiante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstudiante));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonActualizarDatos = new System.Windows.Forms.Button();
            this.labelNombresB = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxUserImage = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.groupBoxDatosPersonales = new System.Windows.Forms.GroupBox();
            this.labelCodigoEstudiante = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInformacionPersonal = new System.Windows.Forms.Label();
            this.labelCelular = new System.Windows.Forms.Label();
            this.labelDireccionEstudiante = new System.Windows.Forms.Label();
            this.labelEmailEstudiante = new System.Windows.Forms.Label();
            this.labelEPEstudiante = new System.Windows.Forms.Label();
            this.labelApellidosEstudiante = new System.Windows.Forms.Label();
            this.labelNombresEstudiante = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserImage)).BeginInit();
            this.panelChildForm.SuspendLayout();
            this.groupBoxDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.buttonActualizarDatos);
            this.groupBox1.Controls.Add(this.labelNombresB);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBoxUserImage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 525);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // buttonActualizarDatos
            // 
            this.buttonActualizarDatos.Location = new System.Drawing.Point(17, 193);
            this.buttonActualizarDatos.Name = "buttonActualizarDatos";
            this.buttonActualizarDatos.Size = new System.Drawing.Size(223, 30);
            this.buttonActualizarDatos.TabIndex = 18;
            this.buttonActualizarDatos.Text = "Actualizar Datos";
            this.buttonActualizarDatos.UseVisualStyleBackColor = true;
            this.buttonActualizarDatos.Click += new System.EventHandler(this.buttonActualizarDatos_Click);
            // 
            // labelNombresB
            // 
            this.labelNombresB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNombresB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombresB.Location = new System.Drawing.Point(-1, 160);
            this.labelNombresB.Name = "labelNombresB";
            this.labelNombresB.Size = new System.Drawing.Size(260, 16);
            this.labelNombresB.TabIndex = 16;
            this.labelNombresB.Text = "ANA PAZ GUERRA";
            this.labelNombresB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNombresB.Click += new System.EventHandler(this.labelNombresB_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(164, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 21);
            this.button1.TabIndex = 15;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "BIENVENIDO";
            // 
            // pictureBoxUserImage
            // 
            this.pictureBoxUserImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserImage.Image")));
            this.pictureBoxUserImage.Location = new System.Drawing.Point(86, 46);
            this.pictureBoxUserImage.Name = "pictureBoxUserImage";
            this.pictureBoxUserImage.Size = new System.Drawing.Size(92, 96);
            this.pictureBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserImage.TabIndex = 13;
            this.pictureBoxUserImage.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.Controls.Add(this.groupBoxDatosPersonales);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(260, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(594, 525);
            this.panelChildForm.TabIndex = 3;
            // 
            // groupBoxDatosPersonales
            // 
            this.groupBoxDatosPersonales.Controls.Add(this.labelCodigoEstudiante);
            this.groupBoxDatosPersonales.Controls.Add(this.label1);
            this.groupBoxDatosPersonales.Controls.Add(this.labelInformacionPersonal);
            this.groupBoxDatosPersonales.Controls.Add(this.labelCelular);
            this.groupBoxDatosPersonales.Controls.Add(this.labelDireccionEstudiante);
            this.groupBoxDatosPersonales.Controls.Add(this.labelEmailEstudiante);
            this.groupBoxDatosPersonales.Controls.Add(this.labelEPEstudiante);
            this.groupBoxDatosPersonales.Controls.Add(this.labelApellidosEstudiante);
            this.groupBoxDatosPersonales.Controls.Add(this.labelNombresEstudiante);
            this.groupBoxDatosPersonales.Controls.Add(this.label12);
            this.groupBoxDatosPersonales.Controls.Add(this.label11);
            this.groupBoxDatosPersonales.Controls.Add(this.label10);
            this.groupBoxDatosPersonales.Controls.Add(this.label28);
            this.groupBoxDatosPersonales.Controls.Add(this.label29);
            this.groupBoxDatosPersonales.Controls.Add(this.label30);
            this.groupBoxDatosPersonales.Controls.Add(this.label32);
            this.groupBoxDatosPersonales.Controls.Add(this.label33);
            this.groupBoxDatosPersonales.Controls.Add(this.label34);
            this.groupBoxDatosPersonales.Location = new System.Drawing.Point(44, 21);
            this.groupBoxDatosPersonales.Name = "groupBoxDatosPersonales";
            this.groupBoxDatosPersonales.Size = new System.Drawing.Size(498, 355);
            this.groupBoxDatosPersonales.TabIndex = 43;
            this.groupBoxDatosPersonales.TabStop = false;
            this.groupBoxDatosPersonales.Text = "Datos Pesonales";
            // 
            // labelCodigoEstudiante
            // 
            this.labelCodigoEstudiante.AutoSize = true;
            this.labelCodigoEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoEstudiante.Location = new System.Drawing.Point(170, 51);
            this.labelCodigoEstudiante.Name = "labelCodigoEstudiante";
            this.labelCodigoEstudiante.Size = new System.Drawing.Size(52, 16);
            this.labelCodigoEstudiante.TabIndex = 51;
            this.labelCodigoEstudiante.Text = "Código";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Código:";
            // 
            // labelInformacionPersonal
            // 
            this.labelInformacionPersonal.AutoSize = true;
            this.labelInformacionPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformacionPersonal.Location = new System.Drawing.Point(169, 312);
            this.labelInformacionPersonal.Name = "labelInformacionPersonal";
            this.labelInformacionPersonal.Size = new System.Drawing.Size(134, 16);
            this.labelInformacionPersonal.TabIndex = 49;
            this.labelInformacionPersonal.Text = "Información Personal";
            // 
            // labelCelular
            // 
            this.labelCelular.AutoSize = true;
            this.labelCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCelular.Location = new System.Drawing.Point(169, 249);
            this.labelCelular.Name = "labelCelular";
            this.labelCelular.Size = new System.Drawing.Size(50, 16);
            this.labelCelular.TabIndex = 48;
            this.labelCelular.Text = "Celular";
            // 
            // labelDireccionEstudiante
            // 
            this.labelDireccionEstudiante.AutoSize = true;
            this.labelDireccionEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccionEstudiante.Location = new System.Drawing.Point(169, 216);
            this.labelDireccionEstudiante.Name = "labelDireccionEstudiante";
            this.labelDireccionEstudiante.Size = new System.Drawing.Size(65, 16);
            this.labelDireccionEstudiante.TabIndex = 47;
            this.labelDireccionEstudiante.Text = "Dirección";
            // 
            // labelEmailEstudiante
            // 
            this.labelEmailEstudiante.AutoSize = true;
            this.labelEmailEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailEstudiante.Location = new System.Drawing.Point(169, 181);
            this.labelEmailEstudiante.Name = "labelEmailEstudiante";
            this.labelEmailEstudiante.Size = new System.Drawing.Size(42, 16);
            this.labelEmailEstudiante.TabIndex = 46;
            this.labelEmailEstudiante.Text = "Email";
            // 
            // labelEPEstudiante
            // 
            this.labelEPEstudiante.AutoSize = true;
            this.labelEPEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEPEstudiante.Location = new System.Drawing.Point(169, 147);
            this.labelEPEstudiante.Name = "labelEPEstudiante";
            this.labelEPEstudiante.Size = new System.Drawing.Size(128, 16);
            this.labelEPEstudiante.TabIndex = 45;
            this.labelEPEstudiante.Text = "Escuela Profesional";
            // 
            // labelApellidosEstudiante
            // 
            this.labelApellidosEstudiante.AutoSize = true;
            this.labelApellidosEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellidosEstudiante.Location = new System.Drawing.Point(169, 115);
            this.labelApellidosEstudiante.Name = "labelApellidosEstudiante";
            this.labelApellidosEstudiante.Size = new System.Drawing.Size(65, 16);
            this.labelApellidosEstudiante.TabIndex = 44;
            this.labelApellidosEstudiante.Text = "Apellidos";
            // 
            // labelNombresEstudiante
            // 
            this.labelNombresEstudiante.AutoSize = true;
            this.labelNombresEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombresEstudiante.Location = new System.Drawing.Point(169, 83);
            this.labelNombresEstudiante.Name = "labelNombresEstudiante";
            this.labelNombresEstudiante.Size = new System.Drawing.Size(64, 16);
            this.labelNombresEstudiante.TabIndex = 43;
            this.labelNombresEstudiante.Text = "Nombres";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(18, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Información Personal:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(16, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Información General:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Detalles:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(31, 248);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 17);
            this.label28.TabIndex = 36;
            this.label28.Text = "Celular:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(30, 215);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 17);
            this.label29.TabIndex = 34;
            this.label29.Text = "Dirección:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(31, 180);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 17);
            this.label30.TabIndex = 32;
            this.label30.Text = "Email:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(33, 82);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(73, 17);
            this.label32.TabIndex = 22;
            this.label32.Text = "Nombres:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(31, 114);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(75, 17);
            this.label33.TabIndex = 23;
            this.label33.Text = "Apellidos:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(31, 146);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 17);
            this.label34.TabIndex = 24;
            this.label34.Text = "Escuela Profesional:";
            // 
            // FormEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 525);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(870, 564);
            this.Name = "FormEstudiante";
            this.Text = "FormEstudiante";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEstudiante_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserImage)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            this.groupBoxDatosPersonales.ResumeLayout(false);
            this.groupBoxDatosPersonales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonActualizarDatos;
        private System.Windows.Forms.Label labelNombresB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxUserImage;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.GroupBox groupBoxDatosPersonales;
        private System.Windows.Forms.Label labelCodigoEstudiante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInformacionPersonal;
        private System.Windows.Forms.Label labelCelular;
        private System.Windows.Forms.Label labelDireccionEstudiante;
        private System.Windows.Forms.Label labelEmailEstudiante;
        private System.Windows.Forms.Label labelEPEstudiante;
        private System.Windows.Forms.Label labelApellidosEstudiante;
        private System.Windows.Forms.Label labelNombresEstudiante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
    }
}