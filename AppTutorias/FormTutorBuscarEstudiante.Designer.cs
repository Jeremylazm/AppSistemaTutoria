
namespace WinFormsFix
{
    partial class FormTutorBuscarEstudiante
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
            this.buttonBuscarCodEstudiante = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCodEstudiante = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSolicitarDatos = new System.Windows.Forms.Button();
            this.labelInformacionPersonal = new System.Windows.Forms.Label();
            this.labelCelularEstudiante = new System.Windows.Forms.Label();
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
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBuscarCodEstudiante
            // 
            this.buttonBuscarCodEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscarCodEstudiante.Location = new System.Drawing.Point(435, 18);
            this.buttonBuscarCodEstudiante.Name = "buttonBuscarCodEstudiante";
            this.buttonBuscarCodEstudiante.Size = new System.Drawing.Size(84, 25);
            this.buttonBuscarCodEstudiante.TabIndex = 32;
            this.buttonBuscarCodEstudiante.Text = "Buscar";
            this.buttonBuscarCodEstudiante.UseVisualStyleBackColor = true;
            this.buttonBuscarCodEstudiante.Click += new System.EventHandler(this.buttonBuscarCodEstudiante_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Código Estudiante:";
            // 
            // textBoxCodEstudiante
            // 
            this.textBoxCodEstudiante.Location = new System.Drawing.Point(205, 21);
            this.textBoxCodEstudiante.Name = "textBoxCodEstudiante";
            this.textBoxCodEstudiante.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodEstudiante.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonBuscarCodEstudiante);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxCodEstudiante);
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 54);
            this.panel2.TabIndex = 87;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 50);
            this.panel3.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "BUSCAR ESTUDIANTE";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelMensaje);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 414);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(585, 72);
            this.groupBox6.TabIndex = 90;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Mensaje:";
            // 
            // labelMensaje
            // 
            this.labelMensaje.AutoSize = true;
            this.labelMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensaje.Location = new System.Drawing.Point(7, 20);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(116, 15);
            this.labelMensaje.TabIndex = 0;
            this.labelMensaje.Text = "Se agrego con éxito";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSolicitarDatos);
            this.panel1.Controls.Add(this.labelInformacionPersonal);
            this.panel1.Controls.Add(this.labelCelularEstudiante);
            this.panel1.Controls.Add(this.labelDireccionEstudiante);
            this.panel1.Controls.Add(this.labelEmailEstudiante);
            this.panel1.Controls.Add(this.labelEPEstudiante);
            this.panel1.Controls.Add(this.labelApellidosEstudiante);
            this.panel1.Controls.Add(this.labelNombresEstudiante);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 315);
            this.panel1.TabIndex = 91;
            // 
            // buttonSolicitarDatos
            // 
            this.buttonSolicitarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSolicitarDatos.Location = new System.Drawing.Point(452, 268);
            this.buttonSolicitarDatos.Name = "buttonSolicitarDatos";
            this.buttonSolicitarDatos.Size = new System.Drawing.Size(54, 20);
            this.buttonSolicitarDatos.TabIndex = 59;
            this.buttonSolicitarDatos.Text = "Solicitar";
            this.buttonSolicitarDatos.UseVisualStyleBackColor = true;
            // 
            // labelInformacionPersonal
            // 
            this.labelInformacionPersonal.AutoSize = true;
            this.labelInformacionPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformacionPersonal.Location = new System.Drawing.Point(212, 271);
            this.labelInformacionPersonal.Name = "labelInformacionPersonal";
            this.labelInformacionPersonal.Size = new System.Drawing.Size(134, 16);
            this.labelInformacionPersonal.TabIndex = 66;
            this.labelInformacionPersonal.Text = "Información Personal";
            // 
            // labelCelularEstudiante
            // 
            this.labelCelularEstudiante.AutoSize = true;
            this.labelCelularEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCelularEstudiante.Location = new System.Drawing.Point(212, 208);
            this.labelCelularEstudiante.Name = "labelCelularEstudiante";
            this.labelCelularEstudiante.Size = new System.Drawing.Size(50, 16);
            this.labelCelularEstudiante.TabIndex = 65;
            this.labelCelularEstudiante.Text = "Celular";
            // 
            // labelDireccionEstudiante
            // 
            this.labelDireccionEstudiante.AutoSize = true;
            this.labelDireccionEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccionEstudiante.Location = new System.Drawing.Point(212, 175);
            this.labelDireccionEstudiante.Name = "labelDireccionEstudiante";
            this.labelDireccionEstudiante.Size = new System.Drawing.Size(65, 16);
            this.labelDireccionEstudiante.TabIndex = 64;
            this.labelDireccionEstudiante.Text = "Dirección";
            // 
            // labelEmailEstudiante
            // 
            this.labelEmailEstudiante.AutoSize = true;
            this.labelEmailEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailEstudiante.Location = new System.Drawing.Point(212, 140);
            this.labelEmailEstudiante.Name = "labelEmailEstudiante";
            this.labelEmailEstudiante.Size = new System.Drawing.Size(42, 16);
            this.labelEmailEstudiante.TabIndex = 63;
            this.labelEmailEstudiante.Text = "Email";
            // 
            // labelEPEstudiante
            // 
            this.labelEPEstudiante.AutoSize = true;
            this.labelEPEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEPEstudiante.Location = new System.Drawing.Point(212, 106);
            this.labelEPEstudiante.Name = "labelEPEstudiante";
            this.labelEPEstudiante.Size = new System.Drawing.Size(128, 16);
            this.labelEPEstudiante.TabIndex = 62;
            this.labelEPEstudiante.Text = "Escuela Profesional";
            // 
            // labelApellidosEstudiante
            // 
            this.labelApellidosEstudiante.AutoSize = true;
            this.labelApellidosEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellidosEstudiante.Location = new System.Drawing.Point(212, 74);
            this.labelApellidosEstudiante.Name = "labelApellidosEstudiante";
            this.labelApellidosEstudiante.Size = new System.Drawing.Size(65, 16);
            this.labelApellidosEstudiante.TabIndex = 61;
            this.labelApellidosEstudiante.Text = "Apellidos";
            // 
            // labelNombresEstudiante
            // 
            this.labelNombresEstudiante.AutoSize = true;
            this.labelNombresEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombresEstudiante.Location = new System.Drawing.Point(212, 42);
            this.labelNombresEstudiante.Name = "labelNombresEstudiante";
            this.labelNombresEstudiante.Size = new System.Drawing.Size(64, 16);
            this.labelNombresEstudiante.TabIndex = 60;
            this.labelNombresEstudiante.Text = "Nombres";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(61, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 17);
            this.label12.TabIndex = 58;
            this.label12.Text = "Información Personal:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(59, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 17);
            this.label11.TabIndex = 57;
            this.label11.Text = "Información General:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(74, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 56;
            this.label10.Text = "Detalles:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(74, 207);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 17);
            this.label28.TabIndex = 55;
            this.label28.Text = "Celular:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(73, 174);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 17);
            this.label29.TabIndex = 54;
            this.label29.Text = "Dirección:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(74, 139);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 17);
            this.label30.TabIndex = 53;
            this.label30.Text = "Email:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(76, 41);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(73, 17);
            this.label32.TabIndex = 50;
            this.label32.Text = "Nombres:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(74, 73);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(75, 17);
            this.label33.TabIndex = 51;
            this.label33.Text = "Apellidos:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(74, 105);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 17);
            this.label34.TabIndex = 52;
            this.label34.Text = "Escuela Profesional:";
            // 
            // FormTutorBuscarEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTutorBuscarEstudiante";
            this.Text = "FormTutorBuscarEstudiante";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonBuscarCodEstudiante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCodEstudiante;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSolicitarDatos;
        private System.Windows.Forms.Label labelInformacionPersonal;
        private System.Windows.Forms.Label labelCelularEstudiante;
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