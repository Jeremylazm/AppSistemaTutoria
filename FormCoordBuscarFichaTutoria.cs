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
    public partial class FormCoordBuscarFichaTutoria : Form
    {
        // TableAdapter Tutor:
        private TutorTableAdapter taTutor = new TutorTableAdapter();
        private dsTutorias.TutorDataTable dtTutor = new dsTutorias.TutorDataTable();
        // TableAdapter FichaTutorias:
        private FichaTutoriasTableAdapter taFichaTutorias = new FichaTutoriasTableAdapter();
        private dsTutorias.FichaTutoriasDataTable dtFichaTutorias = new dsTutorias.FichaTutoriasDataTable();

        public FormCoordBuscarFichaTutoria()
        {
            InitializeComponent();
            labelMensaje.Text = "";
        }

        private void buttonBuscarFichaTutoria_Click(object sender, EventArgs e)
        {
            dtTutor = taTutor.BuscarTutor(txtCodigoDocente.Text);
            if (dtTutor.Rows.Count == 0)
            {
                labelMensaje.Text = "El código del tutor no existe";
            }
            else
            {
                dtFichaTutorias = taFichaTutorias.BuscarSemestre(txtSemestre.Text);
                if (dtFichaTutorias.Rows.Count == 0)
                {
                    labelMensaje.Text = "Semestre no válido";
                }
                else
                {
                    dtFichaTutorias = taFichaTutorias.GetDataByCodDocente(txtCodigoDocente.Text, txtSemestre.Text);
                    dataGridView1.DataSource = dtFichaTutorias;
                    labelMensaje.Text = "Fichas de Tutoria. Docente: " + txtCodigoDocente.Text + " Semestre: " + txtSemestre.Text + " Total registros: " + dtFichaTutorias.Rows.Count.ToString(); ;
                }
            }
        }
    }
}
