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
    public partial class FormTutor : Form
    {
        string CodDocente;
        string Semestre = "2021-II";

        public FormTutor(string CodDocente)
        {
            InitializeComponent();
            this.CodDocente = CodDocente;
            FillPersonalData(CodDocente);
        }

        public void FillPersonalData(string CodDocente)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(CodDocente);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dt[0];
            labelCodigoDocente.Text = row.CodDocente;
            labelNombresDocente.Text = row.Nombres;
            labelApellidosDocente.Text = row.Apellidos;
            labelEPDocente.Text = "INGENIERIA INFORMATICA Y DE SISTEMAS";
            labelTipoContratoDocente.Text = row.TipoContrato;
            labelEmailDocente.Text = row.Email;
            labelDireccionDocente.Text = row.Dirección;
            labelCelularDocente.Text = row.Celular;

            if (row.TipoContrato == "NOMBRADO")
            {
                if (row.Categoria == "PR" && row.Regimen == "DE")
                {
                    labelCatRegTipo.Text = "PRINCIPAL - DEDICACIÓN EXCLUSIVA";
                }
                if (row.Categoria == "PR" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "PRINCIPAL - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AS" && row.Regimen == "DE")
                {
                    labelCatRegTipo.Text = "ASOCIADO - DEDICACIÓN EXCLUSIVA";
                }
                if (row.Categoria == "AS" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "ASOCIADO - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AS" && row.Regimen == "TP")
                {
                    labelCatRegTipo.Text = "ASOCIADO - TIEMPO PARCIAL";
                }
                if (row.Categoria == "AU" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "AUXILIAR - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AU" && row.Regimen == "TP")
                {
                    labelCatRegTipo.Text = "AUXILIAR - TIEMPO PARCIAL";
                }
            }
            if (row.TipoContrato == "CONTRATADO")
            {
                labelCatRegTipo.Text = row.Tipo;
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

        // Actualizar datos:
        private void buttonActualizarDatos_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorActualizarDatos(CodDocente));
        }

        // Ver tutorias:
        private void buttonVerTutorias_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FormTutorTutorias(CodDocente));
        }

        // Crear ficha tutoria:
        private void buttonCrearFichaTutoria_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorCrearFicha(CodDocente, labelNombresDocente.Text + " " + labelApellidosDocente.Text, Semestre));
        }

        // Lista Estudiantes:
        private void buttonListaEstudiantes_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorEstudiantes(CodDocente, Semestre));
        }

        // Buscar estudiante:
        private void buttonBuscarEstudiante_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorBuscarEstudiante(CodDocente, Semestre));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (activeForm != null) activeForm.Close();
            FillPersonalData(labelCodigoDocente.Text);
            groupBoxDatosPersonales.BringToFront();
            groupBoxDatosPersonales.Show();
        }

        private void FormTutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
