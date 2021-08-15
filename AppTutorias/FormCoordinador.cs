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
    public partial class FormCoordinador : Form
    {
        string EP = "IN";

        public FormCoordinador(string CodDocente)
        {
            InitializeComponent();
            FillPersonalData(CodDocente);
        }

        public void FillPersonalData(string CodDocente)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(CodDocente);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dt[0];
            labelCodigoCoordinador.Text = row.CodDocente;
            labelNombresCoordinador.Text = row.Nombres;
            labelApellidosCoordinador.Text = row.Apellidos;
            labelEPCoordinador.Text = "INGENIERIA INFORMATICA Y DE SISTEMAS";
            labelEmailCoordinador.Text = row.Email;
            labelDireccionCoordinador.Text = row.Dirección;
            labelCelularCoordinador.Text = row.Celular;
        }

        // Crud Docentes, Tutores, Estudiantes
        private void buttonOpcionesCrud_Click(object sender, EventArgs e)
        {
            if (comboBoxTablas.Text == "Docente")
            {
                openChildForm(new FormCrudCoordDocente());
            }
            if (comboBoxTablas.Text == "Tutor")
            {
                openChildForm(new FormCrudCoordTutor());
            }
            if (comboBoxTablas.Text == "Estudiante")
            {
                openChildForm(new FormCrudCoordEstudiante());
            }
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

        // Lista Docentes:
        private void buttonListaDocentes_Click(object sender, EventArgs e)
        {
            FormCoordTablas FormDocentes = new FormCoordTablas();
            openChildForm(FormDocentes);
            FormDocentes.VerData(1, "");
        }

        // Lista Tutores:
        private void buttonListaTutores_Click(object sender, EventArgs e)
        {
            FormCoordTablas FormTutores = new FormCoordTablas();
            openChildForm(FormTutores);
            FormTutores.VerData(2, EP);
        }

        // Lista Estudiantes:
        private void buttonListaEstudiantes_Click(object sender, EventArgs e)
        {
            FormCoordTablas FormEstudiantes = new FormCoordTablas();
            openChildForm(FormEstudiantes);
            FormEstudiantes.VerData(3, "");
        }

        // Lista Estudiantes en riesgo académico:
        private void buttonRiesgoAcademico_Click(object sender, EventArgs e)
        {
            FormCoordTablas FormEstudiantesRiesgo = new FormCoordTablas();
            openChildForm(FormEstudiantesRiesgo);
            FormEstudiantesRiesgo.VerData(4, EP);
        }

        private void buttonBuscarFichaTutorias_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCoordBuscarFichaTutoria());
        }

        private void buttonInformeTutorias_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCoordInforme());
        }

        private void labelNombresB_Click(object sender, EventArgs e)
        {
            if (activeForm != null) activeForm.Close();
            FillPersonalData(labelCodigoCoordinador.Text);
            groupBoxDatosPersonales.BringToFront();
            groupBoxDatosPersonales.Show();
        }

        private void FormCoordinador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
