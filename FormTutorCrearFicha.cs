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
    public partial class FormTutorCrearFicha : Form
    {
        // TableAdapter FichaTutorias:
        private FichaTutoriasTableAdapter taFichaTutorias = new FichaTutoriasTableAdapter();
        private dsTutorias.FichaTutoriasDataTable dtFichaTutorias = new dsTutorias.FichaTutoriasDataTable();
        // TablaAdapter Estudiante:
        private EstudianteTableAdapter taEstudiante = new EstudianteTableAdapter();
        private dsTutorias.EstudianteDataTable dtEstudiante = new dsTutorias.EstudianteDataTable();

        string CodDocente;
        string Semestre;

        public FormTutorCrearFicha(string CodDocente, string NombresyApellidos, string Semestre)
        {
            InitializeComponent();
            this.CodDocente = CodDocente;
            this.Semestre = Semestre;
            labelMensaje.Text = "";
            labelNombresTutor.Text = NombresyApellidos;
            labelSemestre.Text = Semestre;
            labelFecha.Text = DateTime.Now.ToString("d/M/yyyy");
            var Hora = DateTime.Now;
            textBoxHora.Text = Hora.ToString("hh");
            textBoxMinutos.Text = Hora.ToString("mm");
            comboBoxAMPM.Text = Hora.ToString("tt", new System.Globalization.CultureInfo("es-PE"));           
        }

        // Validación hora:
        private bool ValidarHora(string hh, string mm, string tt)
        {
            int Hora, Minutos;
            bool val = false;
            if (int.TryParse(hh, out Hora) && int.TryParse(mm, out Minutos))
            {
                if ((Hora >= 1) && (Hora <= 12) && (Minutos >= 0) && (Minutos <= 59)) val = true;
            }

            if (val == true) return true;
            labelHoraMensaje.Text = "Hora no válida";
            return false;
        }

        // Formato hora:
        private string FormatoHora(string hh, string mm, string tt)
        {
            if (tt == "a.m.")
            {
                if (Int16.Parse(hh) == 12) hh = "00";
            }
            if (tt == "p.m.")
            {
                if (Int16.Parse(hh) < 12) hh = (Int16.Parse(hh) + 12).ToString();
            }
            return hh + ":" + mm + ":00";
        }

        private void buttonCrearFicha_Click(object sender, EventArgs e)
        {
            string Fecha = DateTime.Now.ToString("yyyy-M-d");
            if (ValidarHora(textBoxHora.Text, textBoxMinutos.Text, comboBoxAMPM.Text))
            {
                string Hora = FormatoHora(textBoxHora.Text, textBoxMinutos.Text, comboBoxAMPM.Text);
                labelHoraMensaje.Text = "";
                taFichaTutorias.Insertar(Semestre,
                                         Fecha,
                                         Hora,
                                         textBoxLugar.Text,
                                         textBoxActividad.Text,
                                         CodDocente,
                                         textBoxCodEstudiante.Text,
                                         textBoxReferencia.Text,
                                         textBoxDescripción.Text);
                labelMensaje.Text = "Se agregó un nuevo registro";
            }
            else
            {
                labelMensaje.Text = "";
            }
        }

        private void buttonBuscarEstudiante_Click(object sender, EventArgs e)
        {
            dtFichaTutorias = taFichaTutorias.GetFichaEstudiante(CodDocente, Semestre, textBoxCodEstudiante.Text);
            if (dtFichaTutorias.Rows.Count == 0)
            {
                labelMensaje.Text = "El código no existe.";
            }
            else
            {
                labelMensaje.Text = "";
                dsTutorias.FichaTutoriasRow rowFicha = (dsTutorias.FichaTutoriasRow)dtFichaTutorias.Rows[0];
                dtEstudiante = taEstudiante.GetDataByCodEstudiante(rowFicha.CodEstudiante);
                dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dtEstudiante.Rows[0];
                labelNombreEstudiante.Text = rowEstudiante.Nombres + " " + rowEstudiante.Apellidos;
            }
        }
    }
}