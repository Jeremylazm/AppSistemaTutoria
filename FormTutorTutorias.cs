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
    public partial class FormTutorTutorias : Form
    {
        // TableAdapter FichaTutorias:
        private FichaTutoriasTableAdapter taFichaTutorias = new FichaTutoriasTableAdapter();
        private dsTutorias.FichaTutoriasDataTable dtFichaTutorias = new dsTutorias.FichaTutoriasDataTable();

        string CodigoTutor;

        public FormTutorTutorias(string CodigoTutor)
        {
            InitializeComponent();
            this.CodigoTutor = CodigoTutor;
            labelMensaje.Text = "";
        }

        private void buttonVerTutorias_Click(object sender, EventArgs e)
        {
            dtFichaTutorias = taFichaTutorias.BuscarSemestre(txtSemestre.Text);
            if (dtFichaTutorias.Rows.Count == 0)
            {
                labelMensaje.Text = "Semestre no válido";
            }
            else
            {
                dtFichaTutorias = taFichaTutorias.GetDataByCodDocente(CodigoTutor, txtSemestre.Text);
                dataGridView1.DataSource = dtFichaTutorias;
                labelMensaje.Text = "Fichas de Tutoria. Semestre: " + txtSemestre.Text + " Total registros: " + dtFichaTutorias.Rows.Count.ToString();
            }
        }
    }
}