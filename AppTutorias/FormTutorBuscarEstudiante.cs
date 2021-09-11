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
    public partial class FormTutorBuscarEstudiante : Form
    {
        // TableAdapter FichaTutorias:
        private FichaTutoriasTableAdapter taFichaTutorias = new FichaTutoriasTableAdapter();
        private dsTutorias.FichaTutoriasDataTable dtFichaTutorias = new dsTutorias.FichaTutoriasDataTable();
        // TablaAdapter Estudiante:
        private EstudianteTableAdapter taEstudiante = new EstudianteTableAdapter();
        private dsTutorias.EstudianteDataTable dtEstudiante = new dsTutorias.EstudianteDataTable();

        string CodDocente;
        string Semestre;


        public FormTutorBuscarEstudiante(string CodDocente, string Semestre)
        {
            InitializeComponent();
            this.CodDocente = CodDocente;
            this.Semestre = Semestre;
            init();
            labelMensaje.Text = "";

        }

        private void buttonBuscarCodEstudiante_Click(object sender, EventArgs e)
        {
            dtFichaTutorias = taFichaTutorias.GetFichaEstudiante(CodDocente, Semestre, textBoxCodEstudiante.Text);
            if (dtFichaTutorias.Rows.Count == 0)
            {
                init();
                labelMensaje.Text = "El código no existe.";
            }
            else
            {
                labelMensaje.Text = "";
                dsTutorias.FichaTutoriasRow rowFicha = (dsTutorias.FichaTutoriasRow)dtFichaTutorias.Rows[0];
                dtEstudiante = taEstudiante.GetDataByCodEstudiante(rowFicha.CodEstudiante);
                dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dtEstudiante.Rows[0];
                labelNombresEstudiante.Text = rowEstudiante.Nombres;
                labelApellidosEstudiante.Text = rowEstudiante.Apellidos;
                labelEPEstudiante.Text = "INGENIERIA INFORMÁTICA Y DE SISTEMAS";
                labelEmailEstudiante.Text = rowEstudiante.Email;
                labelDireccionEstudiante.Text = rowEstudiante.Dirección;
                labelCelularEstudiante.Text = rowEstudiante.Celular;
                labelInformacionPersonal.Text = "Información reservada";
            }
        }

        private void init()
        {
            labelNombresEstudiante.Text = "";
            labelApellidosEstudiante.Text = "";
            labelEPEstudiante.Text = "";
            labelEmailEstudiante.Text = "";
            labelDireccionEstudiante.Text = "";
            labelCelularEstudiante.Text = "";
            labelInformacionPersonal.Text = "???";
        }
    }
}
