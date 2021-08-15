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
    public partial class FormCrudCoordEstudiante : Form
    {
        public FormCrudCoordEstudiante()
        {
            InitializeComponent();
        }

        // Buscar:
        private void buttonBuscarEstudiante_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(txtCodEstudiante.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.ForeColor = Color.Red;
                labelMensaje.Text = "El alumno no existe";
                comboBoxEPEstudiante.Text = "Seleccionar";
            }
            else
            {
                dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dt.Rows[0];
                txtNombresEstudiante.Text = rowEstudiante.Nombres;
                txtApellidosEstudiante.Text = rowEstudiante.Apellidos;
                if (rowEstudiante.CodEP == "IN")
                {
                    comboBoxEPEstudiante.Text = "INGENIERIA INFORMATICA Y DE SISTEMAS";
                }
                txtEmailEstudiante.Text = rowEstudiante.Email;
                txtDireccionEstudiante.Text = rowEstudiante.Dirección;
                txtCelularEstudiante.Text = rowEstudiante.Celular;
                labelMensaje.Text = "";
            }
        }

        // Agregar:
        private void buttonAgregarEstudiante_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(txtCodEstudiante.Text);
            if (dt.Rows.Count != 0)
            {
                labelMensaje.Text = "El alumno ya existe";
            }
            else
            {
                ta.Insertar(txtCodEstudiante.Text.Trim(), 
                            txtNombresEstudiante.Text.Trim().ToUpper(),
                            txtApellidosEstudiante.Text.Trim().ToUpper(),
                            "IN",
                            txtEmailEstudiante.Text.Trim(),
                            txtDireccionEstudiante.Text.Trim().ToUpper(),
                            txtCelularEstudiante.Text.Trim(),
                            "NO CONSIGNA");
                labelMensaje.ForeColor = Color.Black;
                labelMensaje.Text = "Se agregó un nuevo registro";

                // Crear usuario
                string Usuario = txtCodEstudiante.Text + "@unsaac.edu.pe";
                dsTutoriasTableAdapters.UsuariosTableAdapter taUsuario = new dsTutoriasTableAdapters.UsuariosTableAdapter();
                taUsuario.Insertar(Usuario, txtCodEstudiante.Text, "ESTUDIANTE");
            }
        }

        // Modificar:
        private void buttonModificarEstudiante_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(txtCodEstudiante.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "El código no existe";
            }
            else
            {
                ta.Modificar(txtNombresEstudiante.Text.Trim().ToUpper(),
                             txtApellidosEstudiante.Text.Trim().ToUpper(),
                             "IN",
                             txtEmailEstudiante.Text.Trim(),
                             txtDireccionEstudiante.Text.Trim().ToUpper(),
                             txtCelularEstudiante.Text.Trim(),
                             null,
                             txtCodEstudiante.Text.Trim());

                labelMensaje.ForeColor = Color.Black;
                labelMensaje.Text = "Se modificó el registro";
            }
        }

        // Eliminar:
        private void buttonEliminarEstudiante_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(txtCodEstudiante.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "El código no existe";
            }
            else
            {
                ta.Eliminar(txtCodEstudiante.Text);
                labelMensaje.Text = "Se eliminó el registro";

                // Eliminar Usuario también
                dsTutoriasTableAdapters.UsuariosTableAdapter taUsuarios = new dsTutoriasTableAdapters.UsuariosTableAdapter();
                taUsuarios.Eliminar(txtCodEstudiante.Text + "@unsaac.edu.pe");
            }
        }
    }
}
