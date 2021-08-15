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
    public partial class FormTutorEstudiantes : Form
    {
        // TableAdapter FichaTutorias:
        private TutorTableAdapter taTutor = new TutorTableAdapter();
        private dsTutorias.TutorDataTable dtTutor = new dsTutorias.TutorDataTable();
        // TableAdapter Estudiante:
        private EstudianteTableAdapter taEstudiante = new EstudianteTableAdapter();
        private dsTutorias.EstudianteDataTable dtEstudiante = new dsTutorias.EstudianteDataTable();

        public FormTutorEstudiantes(string CodigoTutor, string Semestre)
        {
            InitializeComponent();
            dtTutor = taTutor.GetEstudiantesByCodTutor(CodigoTutor, Semestre);
            DataTable Estudiantes = new DataTable();
            Estudiantes.Columns.Add("CodEstudiante");
            Estudiantes.Columns.Add("Nombres");
            Estudiantes.Columns.Add("Apellidos");
            Estudiantes.Columns.Add("Email");
            Estudiantes.Columns.Add("Dirección");
            Estudiantes.Columns.Add("Celular");
            foreach (dsTutorias.TutorRow rowFicha in dtTutor)
            {
                dtEstudiante = taEstudiante.GetDataByCodEstudiante(rowFicha.CodEstudiante);
                dsTutorias.EstudianteRow row = (dsTutorias.EstudianteRow)dtEstudiante[0];
                string[] tmp = new string[6]; // Temporal
                tmp[0] = row.CodEstudiante;
                tmp[1] = row.Nombres;
                tmp[2] = row.Apellidos;
                tmp[3] = row.Email;
                tmp[4] = row.Dirección;
                tmp[5] = row.Celular;
                Estudiantes.Rows.Add(tmp);
            }
            dataGridView1.DataSource = Estudiantes;
            labelMensaje.Text = "Lista de Estudiantes. Total registros: " + Estudiantes.Rows.Count.ToString();
        }
    }
}
