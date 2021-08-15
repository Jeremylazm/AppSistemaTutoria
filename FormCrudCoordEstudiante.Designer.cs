
namespace WinFormsFix
{
    partial class FormCrudCoordEstudiante
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCelularEstudiante = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtDireccionEstudiante = new System.Windows.Forms.TextBox();
            this.txtApellidosEstudiante = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxEPEstudiante = new System.Windows.Forms.ComboBox();
            this.txtEmailEstudiante = new System.Windows.Forms.TextBox();
            this.txtNombresEstudiante = new System.Windows.Forms.TextBox();
            this.buttonBuscarEstudiante = new System.Windows.Forms.Button();
            this.txtCodEstudiante = new System.Windows.Forms.TextBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.buttonEliminarEstudiante = new System.Windows.Forms.Button();
            this.buttonModificarEstudiante = new System.Windows.Forms.Button();
            this.buttonAgregarEstudiante = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(575, 50);
            this.panel3.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "ESTUDIANTE";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelMensaje);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 416);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(575, 72);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtCelularEstudiante);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.txtDireccionEstudiante);
            this.panel2.Controls.Add(this.txtApellidosEstudiante);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.comboBoxEPEstudiante);
            this.panel2.Controls.Add(this.txtEmailEstudiante);
            this.panel2.Controls.Add(this.txtNombresEstudiante);
            this.panel2.Controls.Add(this.buttonBuscarEstudiante);
            this.panel2.Controls.Add(this.txtCodEstudiante);
            this.panel2.Controls.Add(this.groupBox27);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 366);
            this.panel2.TabIndex = 92;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(75, 235);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 17);
            this.label19.TabIndex = 84;
            this.label19.Text = "Celular:";
            // 
            // txtCelularEstudiante
            // 
            this.txtCelularEstudiante.Location = new System.Drawing.Point(220, 235);
            this.txtCelularEstudiante.Name = "txtCelularEstudiante";
            this.txtCelularEstudiante.Size = new System.Drawing.Size(280, 20);
            this.txtCelularEstudiante.TabIndex = 85;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(74, 202);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 17);
            this.label18.TabIndex = 82;
            this.label18.Text = "Dirección:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(75, 34);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(134, 17);
            this.label27.TabIndex = 71;
            this.label27.Text = "Código Estudiante:";
            // 
            // txtDireccionEstudiante
            // 
            this.txtDireccionEstudiante.Location = new System.Drawing.Point(219, 202);
            this.txtDireccionEstudiante.Name = "txtDireccionEstudiante";
            this.txtDireccionEstudiante.Size = new System.Drawing.Size(280, 20);
            this.txtDireccionEstudiante.TabIndex = 83;
            // 
            // txtApellidosEstudiante
            // 
            this.txtApellidosEstudiante.Location = new System.Drawing.Point(219, 101);
            this.txtApellidosEstudiante.Name = "txtApellidosEstudiante";
            this.txtApellidosEstudiante.Size = new System.Drawing.Size(280, 20);
            this.txtApellidosEstudiante.TabIndex = 77;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(75, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 17);
            this.label17.TabIndex = 80;
            this.label17.Text = "Email:";
            // 
            // comboBoxEPEstudiante
            // 
            this.comboBoxEPEstudiante.FormattingEnabled = true;
            this.comboBoxEPEstudiante.Location = new System.Drawing.Point(219, 133);
            this.comboBoxEPEstudiante.Name = "comboBoxEPEstudiante";
            this.comboBoxEPEstudiante.Size = new System.Drawing.Size(280, 21);
            this.comboBoxEPEstudiante.TabIndex = 78;
            this.comboBoxEPEstudiante.Text = "Seleccionar";
            // 
            // txtEmailEstudiante
            // 
            this.txtEmailEstudiante.Location = new System.Drawing.Point(219, 167);
            this.txtEmailEstudiante.Name = "txtEmailEstudiante";
            this.txtEmailEstudiante.Size = new System.Drawing.Size(280, 20);
            this.txtEmailEstudiante.TabIndex = 81;
            // 
            // txtNombresEstudiante
            // 
            this.txtNombresEstudiante.Location = new System.Drawing.Point(219, 68);
            this.txtNombresEstudiante.Name = "txtNombresEstudiante";
            this.txtNombresEstudiante.Size = new System.Drawing.Size(280, 20);
            this.txtNombresEstudiante.TabIndex = 76;
            // 
            // buttonBuscarEstudiante
            // 
            this.buttonBuscarEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscarEstudiante.Location = new System.Drawing.Point(415, 33);
            this.buttonBuscarEstudiante.Name = "buttonBuscarEstudiante";
            this.buttonBuscarEstudiante.Size = new System.Drawing.Size(84, 25);
            this.buttonBuscarEstudiante.TabIndex = 70;
            this.buttonBuscarEstudiante.Text = "Buscar";
            this.buttonBuscarEstudiante.UseVisualStyleBackColor = true;
            this.buttonBuscarEstudiante.Click += new System.EventHandler(this.buttonBuscarEstudiante_Click);
            // 
            // txtCodEstudiante
            // 
            this.txtCodEstudiante.Location = new System.Drawing.Point(219, 36);
            this.txtCodEstudiante.Name = "txtCodEstudiante";
            this.txtCodEstudiante.Size = new System.Drawing.Size(157, 20);
            this.txtCodEstudiante.TabIndex = 75;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.buttonEliminarEstudiante);
            this.groupBox27.Controls.Add(this.buttonModificarEstudiante);
            this.groupBox27.Controls.Add(this.buttonAgregarEstudiante);
            this.groupBox27.Location = new System.Drawing.Point(131, 280);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(329, 54);
            this.groupBox27.TabIndex = 79;
            this.groupBox27.TabStop = false;
            // 
            // buttonEliminarEstudiante
            // 
            this.buttonEliminarEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarEstudiante.Location = new System.Drawing.Point(228, 18);
            this.buttonEliminarEstudiante.Name = "buttonEliminarEstudiante";
            this.buttonEliminarEstudiante.Size = new System.Drawing.Size(84, 25);
            this.buttonEliminarEstudiante.TabIndex = 10;
            this.buttonEliminarEstudiante.Text = "Eliminar";
            this.buttonEliminarEstudiante.UseVisualStyleBackColor = true;
            this.buttonEliminarEstudiante.Click += new System.EventHandler(this.buttonEliminarEstudiante_Click);
            // 
            // buttonModificarEstudiante
            // 
            this.buttonModificarEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificarEstudiante.Location = new System.Drawing.Point(123, 18);
            this.buttonModificarEstudiante.Name = "buttonModificarEstudiante";
            this.buttonModificarEstudiante.Size = new System.Drawing.Size(84, 25);
            this.buttonModificarEstudiante.TabIndex = 9;
            this.buttonModificarEstudiante.Text = "Modificar";
            this.buttonModificarEstudiante.UseVisualStyleBackColor = true;
            this.buttonModificarEstudiante.Click += new System.EventHandler(this.buttonModificarEstudiante_Click);
            // 
            // buttonAgregarEstudiante
            // 
            this.buttonAgregarEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarEstudiante.Location = new System.Drawing.Point(17, 18);
            this.buttonAgregarEstudiante.Name = "buttonAgregarEstudiante";
            this.buttonAgregarEstudiante.Size = new System.Drawing.Size(84, 25);
            this.buttonAgregarEstudiante.TabIndex = 8;
            this.buttonAgregarEstudiante.Text = "Agregar";
            this.buttonAgregarEstudiante.UseVisualStyleBackColor = true;
            this.buttonAgregarEstudiante.Click += new System.EventHandler(this.buttonAgregarEstudiante_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(75, 133);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(141, 17);
            this.label31.TabIndex = 74;
            this.label31.Text = "Escuela Profesional:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(75, 101);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(75, 17);
            this.label30.TabIndex = 73;
            this.label30.Text = "Apellidos:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(77, 68);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 17);
            this.label28.TabIndex = 72;
            this.label28.Text = "Nombres:";
            // 
            // FormCrudCoordEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCrudCoordEstudiante";
            this.Text = "FormCrudCoordEstudiante";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelMensaje;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCelularEstudiante;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtDireccionEstudiante;
        private System.Windows.Forms.TextBox txtApellidosEstudiante;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxEPEstudiante;
        private System.Windows.Forms.TextBox txtEmailEstudiante;
        private System.Windows.Forms.TextBox txtNombresEstudiante;
        private System.Windows.Forms.Button buttonBuscarEstudiante;
        private System.Windows.Forms.TextBox txtCodEstudiante;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.Button buttonEliminarEstudiante;
        private System.Windows.Forms.Button buttonModificarEstudiante;
        private System.Windows.Forms.Button buttonAgregarEstudiante;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
    }
}