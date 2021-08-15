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
    public partial class FormEstudianteActualizarDatos : Form
    {
        // TableAdapter Estudiante:
        private EstudianteTableAdapter taEstudiante = new EstudianteTableAdapter();
        private dsTutorias.EstudianteDataTable dtEstudiante = new dsTutorias.EstudianteDataTable();

        public FormEstudianteActualizarDatos(string CodEstudiante)
        {
            InitializeComponent();
            labelMensaje.Text = "";
            FillPersonalData(CodEstudiante);
        }

        private void FillPersonalData(string CodEstudiante)
        {
            dtEstudiante = taEstudiante.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dtEstudiante[0];
            labelCodigoEstudiante.Text = rowEstudiante.CodEstudiante;
            labelNombresEstudiante.Text = rowEstudiante.Nombres;
            labelApellidosEstudiante.Text = rowEstudiante.Apellidos;
            labelApellidosEstudiante.Text = rowEstudiante.Apellidos;
            labelEPEstudiante.Text = "INGENIERÍA INFORMÁTICA Y DE SISTEMAS";
            textBoxEmailEstudiante.Text = rowEstudiante.Email;
            textBoxDireccionEstudiante.Text = rowEstudiante.Dirección;
            textBoxCelularEstudiante.Text = rowEstudiante.Celular;
            textBoxInformacionPersonal.Text = rowEstudiante.InformaciónPersonal;
        }

        private void buttonActualizarInfo_Click(object sender, EventArgs e)
        {
            dtEstudiante = taEstudiante.GetDataByCodEstudiante(labelCodigoEstudiante.Text);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dtEstudiante[0];

            taEstudiante.Modificar(labelNombresEstudiante.Text,
                                   labelApellidosEstudiante.Text,
                                   "IN",
                                   textBoxEmailEstudiante.Text,
                                   textBoxDireccionEstudiante.Text,
                                   textBoxCelularEstudiante.Text,
                                   textBoxInformacionPersonal.Text,
                                   labelCodigoEstudiante.Text);

            labelMensaje.Text = "Se modificó el registro";
        }
    }
}
