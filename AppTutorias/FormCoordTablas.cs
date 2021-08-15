using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsFix.dsTutoriasTableAdapters;

namespace WinFormsFix
{
    public partial class FormCoordTablas : Form
    {
        // TableAdapter Docente:
        private DocenteTableAdapter taDocente = new DocenteTableAdapter();
        private dsTutorias.DocenteDataTable dtDocente = new dsTutorias.DocenteDataTable();
        // TableAdapter Estudiante:
        private EstudianteTableAdapter taEstudiante = new EstudianteTableAdapter();
        private dsTutorias.EstudianteDataTable dtEstudiante = new dsTutorias.EstudianteDataTable();
        // TableAdapter RiesgoAcadémico:
        private RiesgoAcademicoTableAdapter taRiesgoAcademico = new RiesgoAcademicoTableAdapter();
        private dsTutorias.RiesgoAcademicoDataTable dtRiesgoAcademico = new dsTutorias.RiesgoAcademicoDataTable();

        public FormCoordTablas()
        {
            InitializeComponent();
        }

        public void VerData(int opt, string CodEP)
        {
            if (opt == 1)
            {
                labelTitulo.Text = "DOCENTES";
                dtDocente = taDocente.GetData();
                dataGridView1.DataSource = dtDocente;
                labelMensaje.Text = "Lista de Docentes. Total registros: " + dtDocente.Rows.Count.ToString();
            }
            if (opt == 2)
            {               
                labelTitulo.Text = "TUTORES";
                dtDocente = taDocente.GetTutoresByCodEP(CodEP);
                dataGridView1.DataSource = dtDocente;
                labelMensaje.Text = "Lista de Tutores. Total registros: " + dtDocente.Rows.Count.ToString();
            }
            if (opt == 3)
            {
                labelTitulo.Text = "ESTUDIANTES";
                dtEstudiante = taEstudiante.GetData();
                dataGridView1.DataSource = dtEstudiante;
                labelMensaje.Text = "Lista de Estudiantes. Total registros: " + dtEstudiante.Rows.Count.ToString();
            }
            if (opt == 4)
            {
                labelTitulo.Text = "ESTUDIANTES EN RIESGO ACADÉMICO";
                dtRiesgoAcademico = taRiesgoAcademico.GetData(CodEP);
                dataGridView1.DataSource =dtRiesgoAcademico;
                labelMensaje.Text = "Lista de Estudiantes en riesgo académico. Total registros: " + dtRiesgoAcademico.Rows.Count.ToString();
            }
        }
    }
}
