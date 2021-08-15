using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFix
{
    public partial class FormEstudiante : Form
    {
        string CodEstudiante;

        public FormEstudiante(string CodEstudiante)
        {
            InitializeComponent();
            this.CodEstudiante = CodEstudiante;           
            FillPersonalData(CodEstudiante);
        }

        public void FillPersonalData(string CodEstudiante)
        {
            dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow row = (dsTutorias.EstudianteRow)dt[0];
            labelNombresB.Text = row.Nombres;
            labelCodigoEstudiante.Text = row.CodEstudiante;
            labelNombresEstudiante.Text = row.Nombres;
            labelApellidosEstudiante.Text = row.Apellidos;
            labelEPEstudiante.Text = "INGENIERIA INFORMATICA Y DE SISTEMAS";
            labelEmailEstudiante.Text = row.Email;
            labelDireccionEstudiante.Text = row.Dirección;
            labelCelular.Text = row.Celular;
            labelInformacionPersonal.Text = row.InformaciónPersonal;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonActualizarDatos_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEstudianteActualizarDatos(CodEstudiante));
        }

        private void labelNombresB_Click(object sender, EventArgs e)
        {
            if (activeForm != null) activeForm.Close();
            FillPersonalData(labelCodigoEstudiante.Text);
            groupBoxDatosPersonales.BringToFront();
            groupBoxDatosPersonales.Show();
        }

        private void FormEstudiante_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
