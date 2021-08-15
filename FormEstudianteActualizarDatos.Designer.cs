
namespace WinFormsFix
{
    partial class FormEstudianteActualizarDatos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonActualizarInfo = new System.Windows.Forms.Button();
            this.textBoxInformacionPersonal = new System.Windows.Forms.TextBox();
            this.textBoxCelularEstudiante = new System.Windows.Forms.TextBox();
            this.textBoxDireccionEstudiante = new System.Windows.Forms.TextBox();
            this.textBoxEmailEstudiante = new System.Windows.Forms.TextBox();
            this.labelCodigoEstudiante = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEPEstudiante = new System.Windows.Forms.Label();
            this.labelApellidosEstudiante = new System.Windows.Forms.Label();
            this.labelNombresEstudiante = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(195, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "ACTUALIZAR DATOS";
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
            this.panel1.Controls.Add(this.buttonActualizarInfo);
            this.panel1.Controls.Add(this.textBoxInformacionPersonal);
            this.panel1.Controls.Add(this.textBoxCelularEstudiante);
            this.panel1.Controls.Add(this.textBoxDireccionEstudiante);
            this.panel1.Controls.Add(this.textBoxEmailEstudiante);
            this.panel1.Controls.Add(this.labelCodigoEstudiante);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelEPEstudiante);
            this.panel1.Controls.Add(this.labelApellidosEstudiante);
            this.panel1.Controls.Add(this.labelNombresEstudiante);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 364);
            this.panel1.TabIndex = 91;
            // 
            // buttonActualizarInfo
            // 
            this.buttonActualizarInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActualizarInfo.Location = new System.Drawing.Point(296, 336);
            this.buttonActualizarInfo.Name = "buttonActualizarInfo";
            this.buttonActualizarInfo.Size = new System.Drawing.Size(84, 25);
            this.buttonActualizarInfo.TabIndex = 72;
            this.buttonActualizarInfo.Text = "Guardar";
            this.buttonActualizarInfo.UseVisualStyleBackColor = true;
            this.buttonActualizarInfo.Click += new System.EventHandler(this.buttonActualizarInfo_Click);
            // 
            // textBoxInformacionPersonal
            // 
            this.textBoxInformacionPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInformacionPersonal.Location = new System.Drawing.Point(230, 297);
            this.textBoxInformacionPersonal.Name = "textBoxInformacionPersonal";
            this.textBoxInformacionPersonal.Size = new System.Drawing.Size(280, 22);
            this.textBoxInformacionPersonal.TabIndex = 74;
            // 
            // textBoxCelularEstudiante
            // 
            this.textBoxCelularEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCelularEstudiante.Location = new System.Drawing.Point(230, 234);
            this.textBoxCelularEstudiante.Name = "textBoxCelularEstudiante";
            this.textBoxCelularEstudiante.Size = new System.Drawing.Size(280, 22);
            this.textBoxCelularEstudiante.TabIndex = 73;
            // 
            // textBoxDireccionEstudiante
            // 
            this.textBoxDireccionEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDireccionEstudiante.Location = new System.Drawing.Point(230, 201);
            this.textBoxDireccionEstudiante.Name = "textBoxDireccionEstudiante";
            this.textBoxDireccionEstudiante.Size = new System.Drawing.Size(280, 22);
            this.textBoxDireccionEstudiante.TabIndex = 71;
            // 
            // textBoxEmailEstudiante
            // 
            this.textBoxEmailEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmailEstudiante.Location = new System.Drawing.Point(230, 166);
            this.textBoxEmailEstudiante.Name = "textBoxEmailEstudiante";
            this.textBoxEmailEstudiante.Size = new System.Drawing.Size(280, 22);
            this.textBoxEmailEstudiante.TabIndex = 70;
            // 
            // labelCodigoEstudiante
            // 
            this.labelCodigoEstudiante.AutoSize = true;
            this.labelCodigoEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoEstudiante.Location = new System.Drawing.Point(229, 39);
            this.labelCodigoEstudiante.Name = "labelCodigoEstudiante";
            this.labelCodigoEstudiante.Size = new System.Drawing.Size(52, 16);
            this.labelCodigoEstudiante.TabIndex = 69;
            this.labelCodigoEstudiante.Text = "Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(92, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 68;
            this.label5.Text = "Código:";
            // 
            // labelEPEstudiante
            // 
            this.labelEPEstudiante.AutoSize = true;
            this.labelEPEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEPEstudiante.Location = new System.Drawing.Point(228, 135);
            this.labelEPEstudiante.Name = "labelEPEstudiante";
            this.labelEPEstudiante.Size = new System.Drawing.Size(128, 16);
            this.labelEPEstudiante.TabIndex = 67;
            this.labelEPEstudiante.Text = "Escuela Profesional";
            // 
            // labelApellidosEstudiante
            // 
            this.labelApellidosEstudiante.AutoSize = true;
            this.labelApellidosEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellidosEstudiante.Location = new System.Drawing.Point(228, 103);
            this.labelApellidosEstudiante.Name = "labelApellidosEstudiante";
            this.labelApellidosEstudiante.Size = new System.Drawing.Size(65, 16);
            this.labelApellidosEstudiante.TabIndex = 66;
            this.labelApellidosEstudiante.Text = "Apellidos";
            // 
            // labelNombresEstudiante
            // 
            this.labelNombresEstudiante.AutoSize = true;
            this.labelNombresEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombresEstudiante.Location = new System.Drawing.Point(228, 71);
            this.labelNombresEstudiante.Name = "labelNombresEstudiante";
            this.labelNombresEstudiante.Size = new System.Drawing.Size(64, 16);
            this.labelNombresEstudiante.TabIndex = 65;
            this.labelNombresEstudiante.Text = "Nombres";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(77, 268);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 17);
            this.label16.TabIndex = 64;
            this.label16.Text = "Información Personal:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label17.Location = new System.Drawing.Point(75, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 17);
            this.label17.TabIndex = 63;
            this.label17.Text = "Información General:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(90, 299);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 17);
            this.label18.TabIndex = 62;
            this.label18.Text = "Detalles:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(90, 236);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 17);
            this.label19.TabIndex = 61;
            this.label19.Text = "Celular:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(89, 203);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 17);
            this.label20.TabIndex = 60;
            this.label20.Text = "Dirección:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(90, 168);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 17);
            this.label21.TabIndex = 59;
            this.label21.Text = "Email:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(92, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 17);
            this.label22.TabIndex = 56;
            this.label22.Text = "Nombres:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(90, 102);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 17);
            this.label23.TabIndex = 57;
            this.label23.Text = "Apellidos:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(90, 134);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(141, 17);
            this.label24.TabIndex = 58;
            this.label24.Text = "Escuela Profesional:";
            // 
            // FormEstudianteActualizarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEstudianteActualizarDatos";
            this.Text = "FormEstudianteActualizarDatos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonActualizarInfo;
        private System.Windows.Forms.TextBox textBoxInformacionPersonal;
        private System.Windows.Forms.TextBox textBoxCelularEstudiante;
        private System.Windows.Forms.TextBox textBoxDireccionEstudiante;
        private System.Windows.Forms.TextBox textBoxEmailEstudiante;
        private System.Windows.Forms.Label labelCodigoEstudiante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelEPEstudiante;
        private System.Windows.Forms.Label labelApellidosEstudiante;
        private System.Windows.Forms.Label labelNombresEstudiante;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
    }
}